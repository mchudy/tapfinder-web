using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PubApp.DataAccess.Entities
{
    [Table("UsersFavouritePlaces")]
    public class UserFavouritePlace
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public string PlaceId { get; set; }
    }
}
