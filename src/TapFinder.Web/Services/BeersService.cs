using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TapFinder.DataAccess;
using TapFinder.Web.Dtos;
using TapFinder.Web.Dtos.BeerDtos;

namespace TapFinder.Web.Services
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
            var beer = ctx.Beers
                .Include(b => b.Brewery)
                .Include(b => b.Style)
                .SingleOrDefault(b => b.Id == id);
            var dto = Mapper.Map<BeerDetailsDto>(beer);
            if (dto != null)
            {
                dto.Places = ctx.PlacesBeers
                    .Where(pb => pb.BeerId == id)
                    .ProjectTo<PlaceWithBeerDto>()
                    .ToList();
            }
            return dto;
        }
    }
}