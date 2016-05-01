using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace PubApp.DataAccess.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DbGeography Location { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<SpecialOffer> SpecialOffers { get; set; } = new HashSet<SpecialOffer>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
