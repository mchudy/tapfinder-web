using System.Collections.Generic;
using System.Linq;
using TapFinder.DataAccess;
using TapFinder.DataAccess.Entities;

namespace TapFinder.Web.Services
{
    public class BadgesService
    {
        private const int InitialBadgeId = 1;

        private const int FirstBeerBadgeId = 2;
        private const int FirstSpecialOfferBadgeId = 3;
        private const int TenSpecialOffersBadgeId = 4;
        private const int TenBeersBadgeId = 5;

        private readonly Dictionary<int, int> specialOfferBadges = new Dictionary<int, int>
        {
            {1, FirstSpecialOfferBadgeId},
            {10, TenSpecialOffersBadgeId}
        };

        private readonly Dictionary<int, int> beerBadges = new Dictionary<int, int>
        {
            {1, FirstBeerBadgeId},
            {10, TenBeersBadgeId}
        };

        private readonly ApplicationContext ctx;

        public BadgesService(ApplicationContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddInitialBadge(User user)
        {
            var badge = ctx.Badges.Find(InitialBadgeId);
            user.Badges.Add(badge);
            ctx.SaveChanges();
        }

        public void UpdateBeerBadges(int userId)
        {
            int addedBeers = ctx.PlacesBeers.Count(pb => pb.UserId == userId) + 1;
            int badgeId;
            if (beerBadges.TryGetValue(addedBeers, out badgeId))
            {
                AddBadge(userId, badgeId);
            }
        }

        public void UpdateSpecialOfferBadges(int userId)
        {
            int addedSpecialOffers = ctx.SpecialOffers.Count(pb => pb.UserId == userId) + 1;
            int badgeId;
            if (specialOfferBadges.TryGetValue(addedSpecialOffers, out badgeId))
            {
                AddBadge(userId, badgeId);
            }
        }

        private void AddBadge(int userId, int badgeId)
        {
            var user = ctx.Users.Find(userId);
            var badge = ctx.Badges.Find(badgeId);
            user.Badges.Add(badge);
        }
    }
}