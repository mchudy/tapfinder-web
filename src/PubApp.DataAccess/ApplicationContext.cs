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

    }
}
