using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using PubApp.DataAccess;
using PubApp.DataAccess.Entities;
using PubApp.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PubApp.Web.Services
{
    public class PlacesService
    {
        public const int AddBeerExperience = 10;
        public const int AddSpecialOfferExperience = 25;

        private readonly ApplicationContext ctx;
        private readonly Expression<Func<int, int>> ratingExpression;

        public PlacesService(ApplicationContext ctx)
        {
            this.ctx = ctx;
            ratingExpression = GetRating();
        }

        public IList<PlaceBeerDto> GetBeers(string id)
        {
            //TODO: messy, but avoids N + 1
            return ctx.PlacesBeers
                .AsExpandable()
                .Include(pb => pb.Beer)
                .Include(pb => pb.User)
                .Where(pb => pb.PlaceId == id)
                .Select(p => new PlaceBeerDto
                {
                    Id = p.Id,
                    AddedDate = p.AddedDate,
                    UserName = p.User.UserName,
                    PlaceId = id,
                    Beer = new BeerDto
                    {
                        Brewery = new BreweryDto { Id = p.Beer.BreweryId, Name = p.Beer.Brewery.Name },
                        Id = p.BeerId,
                        Name = p.Beer.Name,
                        Style = p.Beer.Style.Name,
                        StyleId = p.Beer.BeerStyleId
                    },
                    Description = p.Description,
                    Price = p.Price,
                    Rating = ratingExpression.Invoke(p.Id)
                })
                .ToList();
        }

        public IList<SpecialOfferDto> GetSpecialOffers(string id)
        {
            return ctx.SpecialOffers
                .AsExpandable()
                .Include(so => so.User)
                .Where(so => so.PlaceId == id && so.EndDate >= DateTime.Now)
                .Select(s => new SpecialOfferDto
                {
                    Id = s.Id,
                    UserName = s.User.UserName,
                    Title = s.Title,
                    PlaceId = id,
                    Description = s.Description,
                    Rating = ratingExpression.Invoke(s.Id),
                    StartDate = s.StartDate,
                    EndDate = s.EndDate
                })
                .ToList();
        }

        public int AddComment(CommentDto dto, int userId)
        {
            var comment = ctx.Comments.Add(Mapper.Map<Comment>(dto));
            comment.Date = DateTime.Now;
            comment.UserId = userId;
            ctx.SaveChanges();
            return comment.Id;
        }

        public IList<CommentDto> GetComments(string placeId)
        {
            return ctx.Comments.Where(c => c.PlaceId == placeId)
                .OrderByDescending(c => c.Date)
                .ProjectTo<CommentDto>()
                .ToList();
        }

        private Expression<Func<int, int>> GetRating()
        {
            return id =>
                ctx.Likes.Count(l => l.LikeableItemId == id && l.Liked) -
                ctx.Likes.Count(l => l.LikeableItemId == id && !l.Liked);
        }

        public PlaceBeerDto GetPlaceBeer(int beerId, string placeId)
        {
            var placeBeer = ctx.PlacesBeers
                .FirstOrDefault(pb => pb.BeerId == beerId && pb.PlaceId == placeId);
            if (placeBeer == null) return null;
            return Mapper.Map<PlaceBeerDto>(placeBeer);
        }

        public PlaceBeerDto AddPlaceBeer(AddPlaceBeerDto dto, int userId)
        {
            var newBeer = ctx.PlacesBeers.Add(Mapper.Map<PlaceBeer>(dto));
            newBeer.UserId = userId;
            newBeer.AddedDate = DateTime.Now;
            UpdateExperience(userId, AddBeerExperience);
            ctx.SaveChanges();
            return Mapper.Map<PlaceBeerDto>(newBeer);
        }

        public SpecialOfferDto AddSpecialOffer(AddSpecialOfferDto dto, int userId)
        {
            var newOffer = ctx.SpecialOffers.Add(Mapper.Map<SpecialOffer>(dto));
            newOffer.UserId = userId;
            UpdateExperience(userId, AddSpecialOfferExperience);
            ctx.SaveChanges();
            return Mapper.Map<SpecialOfferDto>(newOffer);
        }

        public IList<PlacesWithBeerSearchResultDto> GetPlacesWithBeer(int beerStyleId, decimal maxPrice, IList<string> placesIds)
        {
            return ctx.PlacesBeers
                .Include(p => p.Beer)
                .Include(p => p.User)
                .Include(p => p.Beer.Brewery)
                .Include(p => p.Beer.Style)
                .Where(p => placesIds.Contains(p.PlaceId) && p.Beer.Style.Id == beerStyleId && p.Price <= maxPrice)
                .ToList()
                .GroupBy(pb => pb.PlaceId)
                .Select(g => new PlacesWithBeerSearchResultDto
                {
                    PlaceId = g.Key,
                    Beers = g.AsQueryable().ProjectTo<PlaceBeerDto>().ToList()
                })
                .ToList();
        }

        private void UpdateExperience(int userId, int newExperience)
        {
            var user = ctx.Users.Find(userId);
            user.Experience += newExperience;
            var rank = ctx.Ranks.Where(r => r.MinExperience >= user.Experience)
                .OrderByDescending(r => r.MinExperience)
                .FirstOrDefault();
            user.Rank = rank;
        }
    }
}