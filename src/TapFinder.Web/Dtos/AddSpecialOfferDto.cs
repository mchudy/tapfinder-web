using System;

namespace TapFinder.Web.Dtos
{
    public class AddSpecialOfferDto
    {
        public string PlaceId { get; set; }

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}