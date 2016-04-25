using System.Data.Entity;

namespace PubApp.DataAccess
{
    public class ApplicationContext : DbContext
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
