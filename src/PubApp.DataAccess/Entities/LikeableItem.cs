using System.ComponentModel.DataAnnotations.Schema;

namespace PubApp.DataAccess.Entities
{
    public abstract class LikeableItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}