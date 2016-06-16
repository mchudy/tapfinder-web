using System.Collections.Generic;

namespace TapFinder.Web.Dtos.BeerDtos
{
    public class BeerDetailsDto : BeerDto
    {
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IList<PlaceWithBeerDto> Places { get; set; }
    }
}