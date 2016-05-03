using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PubApp.DataAccess.Entities
{
    [Table("Comments")]
    public class Comment : LikeableItem
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string PlaceId { get; set; }

        public virtual User User { get; set; }
    }
}
