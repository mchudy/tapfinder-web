using LinqKit;
using PubApp.DataAccess;
using PubApp.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PubApp.DataAccess.Entities;

namespace PubApp.Web.Services
{
    public class PlacesService
    {
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
                    AddedDate = p.AddedDate,
                    UserName = p.User.UserName,
                    PlaceId = id,
                    Beer = new BeerDto
                    {
                        Brewery = new BreweryDto { Id = p.Beer.BreweryId, Name = p.Beer.Brewery.Name },
                        Description = p.Beer.Description,
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
                .Where(so => so.PlaceId == id && so.EndDate < DateTime.Now)
                .Select(s => new SpecialOfferDto
                {
                    UserName = s.User.UserName,
                    PlaceId = id,
                    Description = s.Description,
                    Rating = ratingExpression.Invoke(s.Id),
                    StartDate = s.StartDate,
                    EndDate = s.EndDate
                })
                .ToList();
        }

        public IList<CommentDto> GetComments(string id)
        {
            return ctx.Comments
                .AsExpandable()
                .Include(c => c.User)
                .Where(c => c.PlaceId == id)
                .Select(c => new CommentDto
                {
                    Text = c.Text,
                    Date = c.Date,
                    PlaceId = c.PlaceId,
                    UserName = c.User.UserName
                }).ToList();
        } 

        private Expression<Func<int, int>> GetRating()
        {
            return id =>
                ctx.Likes.Count(l => l.LikeableItemId == id && l.Liked) -
                ctx.Likes.Count(l => l.LikeableItemId == id && !l.Liked);
        }
    }
}