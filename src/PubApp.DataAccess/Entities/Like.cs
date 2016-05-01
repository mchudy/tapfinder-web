using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PubApp.DataAccess.Entities
{
    public class Like
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int LikedItemId { get; set; }

        // true for like, false for dislike
        public bool Liked { get; set; }

        public virtual User User { get; set; }
        public virtual LikeableItem LikeableItem { get; set; }
    }
}
