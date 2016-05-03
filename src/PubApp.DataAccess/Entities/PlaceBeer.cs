using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PubApp.DataAccess.Entities
{
    /// <summary>
    /// Represents a beer available on tap at the given place
    /// </summary>
    [Table("PlacesBeers")]
    public class PlaceBeer : LikeableItem
    {
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal Price { get; set; }

        public string PlaceId { get; set; }
        public int UserId { get; set; }
        public int BeerId { get; set; }

        public virtual Beer Beer { get; set; }
        public virtual User User { get; set; }
    }
}