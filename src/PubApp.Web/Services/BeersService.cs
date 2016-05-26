using AutoMapper.QueryableExtensions;
using PubApp.DataAccess;
using PubApp.Web.Dtos;
using System.Collections.Generic;
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

        public IList<BeerStyleDto> GetAllBeerStyles()
        {
            return context.BeerStyles
                .ProjectTo<BeerStyleDto>()
                .ToList();
        }
    }
}