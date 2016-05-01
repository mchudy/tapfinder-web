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

        public IDbSet<Place> Places { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<LikeableItem> LikeableItems { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<SpecialOffer> SpecialOffers { get; set; }
    }
}
