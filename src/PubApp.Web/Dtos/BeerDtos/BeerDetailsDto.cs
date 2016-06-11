using System.Collections.Generic;

namespace PubApp.Web.Dtos
{
    public class BeerDetailsDto : BeerDto
    {
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IList<PlaceWithBeerDto> Places { get; set; }
    }
}