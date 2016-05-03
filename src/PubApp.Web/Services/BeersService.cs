using PubApp.DataAccess;
using PubApp.DataAccess.Entities;
using System.Linq;

namespace PubApp.Web.Services
{
    public class BeersService
    {
        private readonly ApplicationContext context;

        public BeersService(ApplicationContext context)
        {
            this.context = context;
        }

        public IQueryable<BeerStyle> GetAllBeerStyles()
        {
            return context.BeerStyles;
        }
    }
}