using Microsoft.AspNet.Identity.EntityFramework;
using PubApp.DataAccess.Entities;
using System.Data.Entity;

namespace PubApp.DataAccess
{
    public class ApplicationContext
        : IdentityDbContext<User, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public ApplicationContext()
            : base("name=DbConnection")
        {
        }

        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(null);
        }

        public IDbSet<Like> Likes { get; set; }
        public IDbSet<LikeableItem> LikeableItems { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<SpecialOffer> SpecialOffers { get; set; }
        public IDbSet<BeerStyle> BeerStyles { get; set; }
        public IDbSet<Beer> Beers { get; set; }
        public IDbSet<Brewery> Breweries { get; set; }
        public IDbSet<PlaceBeer> PlacesBeers { get; set; }
        public IDbSet<Badge> Badges { get; set; }
        public IDbSet<Rank> Ranks { get; set; }
        public IDbSet<UserFavouritePlace> UsersFavouritePlaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(s => s.Badges)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("BadgeId");
                    cs.ToTable("UsersBadges");
                });
        }
    }
}
