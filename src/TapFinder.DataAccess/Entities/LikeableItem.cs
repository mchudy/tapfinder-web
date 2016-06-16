using System.ComponentModel.DataAnnotations.Schema;

namespace TapFinder.DataAccess.Entities
{
    public abstract class LikeableItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}