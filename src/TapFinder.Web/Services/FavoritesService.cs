using System.Linq;
using TapFinder.DataAccess;
using TapFinder.DataAccess.Entities;

namespace TapFinder.Web.Services
{
    public class FavoritesService
    {
        private readonly ApplicationContext ctx;

        public FavoritesService(ApplicationContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddFavouritePlace(int userId, string placeId)
        {
            if (UserFavoriteExists(userId, placeId)) return false;
            ctx.UsersFavouritePlaces.Add(new UserFavouritePlace
            {
                UserId = userId,
                PlaceId = placeId
            });
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteFavoritePlace(int userId, string placeId)
        {
            var userFavorite = ctx.UsersFavouritePlaces.FirstOrDefault(up => up.UserId == userId &&
                                                                             up.PlaceId == placeId);
            if (userFavorite == null) return false;
            ctx.UsersFavouritePlaces.Remove(userFavorite);
            ctx.SaveChanges();
            return true;
        }

        public bool UserFavoriteExists(int userId, string placeId)
        {
            return (ctx.UsersFavouritePlaces.FirstOrDefault(up => up.UserId == userId &&
                                                                  up.PlaceId == placeId) != null);
        }
    }
}