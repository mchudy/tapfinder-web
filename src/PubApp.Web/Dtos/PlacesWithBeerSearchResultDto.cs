using System.Collections.Generic;

namespace PubApp.Web.Dtos
{
    public class PlacesWithBeerSearchResultDto
    {
        public string PlaceId { get; set; }
        public IList<PlaceBeerDto> Beers { get; set; }
    }
}