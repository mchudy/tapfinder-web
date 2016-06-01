using System;

namespace PubApp.Web.Dtos
{
    public class SpecialOfferDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PlaceId { get; set; }
        public string UserName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        // likes - dislikes
        public int Rating { get; set; }
    }
}