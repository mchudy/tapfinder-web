using AutoMapper;
using AutoMapper.QueryableExtensions;
using PubApp.DataAccess;
using PubApp.Web.Dtos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace PubApp.Web.Services
{
    [Authorize]
    public class BeersService
    {
        private const int maxSearchResults = 40;
        private readonly ApplicationContext ctx;

        public BeersService(ApplicationContext ctx)
        {
            this.ctx = ctx;
        }

        public IList<BeerStyleDto> GetAllBeerStyles()
        {
            return ctx.BeerStyles
                .OrderBy(b => b.Name)
                .ProjectTo<BeerStyleDto>()
                .ToList();
        }

        public IList<BeerDto> FindBeers(string query)
        {
            return ctx.Beers
                .Include(b => b.Brewery)
                .Include(b => b.Style)
                .Where(b => b.Name.Contains(query) || b.Brewery.Name.Contains(query))
                .Take(maxSearchResults)
                .ProjectTo<BeerDto>()
                .ToList();
        }

        public BeerDetailsDto GetBeerDetails(int id)
        {
            var beer = ctx.Beers.Find(id);
            return Mapper.Map<BeerDetailsDto>(beer);
        }
    }
}