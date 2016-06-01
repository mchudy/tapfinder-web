using System;

namespace PubApp.Web.Dtos
{
    public class PlaceBeerDto
    {
        public int Id { get; set; }
        public string PlaceId { get; set; }

        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal Price { get; set; }

        // likes - dislikes
        public int Rating { get; set; }

        public string UserName { get; set; }
        public BeerDto Beer { get; set; }
    }
}