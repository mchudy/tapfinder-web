using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TapFinder.DataAccess.Entities
{
    public class User :
        IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>,
        IUser<int>
    {
        public string ImagePath { get; set; }
        public int Experience { get; set; }

        public int RankId { get; set; }
        public virtual Rank Rank { get; set; }

        public virtual ICollection<Badge> Badges { get; set; } = new HashSet<Badge>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            UserManager<User, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(
                this, authenticationType);
            return userIdentity;
        }
    }
}