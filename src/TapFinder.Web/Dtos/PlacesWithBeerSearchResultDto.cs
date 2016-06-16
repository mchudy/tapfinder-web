using System.Collections.Generic;

namespace TapFinder.Web.Dtos
{
    public class PlacesWithBeerSearchResultDto
    {
        public string PlaceId { get; set; }
        public IList<PlaceBeerDto> Beers { get; set; }
    }
}