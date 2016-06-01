using AutoMapper;
using PubApp.DataAccess;
using PubApp.DataAccess.Entities;
using PubApp.Web.Dtos;
using System.Linq;

namespace PubApp.Web.Services
{
    public class LikesService
    {
        private readonly ApplicationContext ctx;

        public LikesService(ApplicationContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddLike(LikeDto dto, int userId)
        {
            var newLike = Mapper.Map<Like>(dto);
            newLike.UserId = userId;
            ctx.Likes.Add(newLike);
            ctx.SaveChanges();
        }

        public bool UpdateLike(LikeDto dto, int userId)
        {
            var like = ctx.Likes
                .FirstOrDefault(l => l.LikeableItemId == dto.LikeableItemId && l.UserId == userId);
            if (like == null)
            {
                return false;
            }
            like.Liked = dto.Liked;
            ctx.SaveChanges();
            return true;
        }

        public RatingDto GetRating(int itemId)
        {
            if (ctx.LikeableItems.Find(itemId) == null)
            {
                return null;
            }
            int rating = ctx.Likes.Count(l => l.LikeableItemId == itemId) -
                   ctx.Likes.Count(l => !l.Liked);
            return new RatingDto { Id = itemId, Rating = rating };
        }
    }
}