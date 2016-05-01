using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PubApp.DataAccess.Entities
{
    [Table("SpecialOffers")]
    public class SpecialOffer : LikeableItem
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        public int PlaceId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Place Place { get; set; }
    }
}
