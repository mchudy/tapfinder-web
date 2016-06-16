using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Identity.EntityFramework;
using TapFinder.DataAccess.Entities;

namespace TapFinder.DataAccess
{
    public class AppUserLogin : IdentityUserLogin<int> { }

    public class AppUserRole : IdentityUserRole<int> { }

    public class AppUserClaim : IdentityUserClaim<int> { }

    public class AppRole : IdentityRole<int, AppUserRole>
    {
        public AppRole()
        { }

        public AppRole(string name)
        {
            Name = name;
        }
    }

    public class ApplicationUserStore :
        UserStore<User, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {

        public ApplicationUserStore(ApplicationContext context) : base(context)
        {

        }
    }

    public class AppRoleStore : RoleStore<AppRole, int, AppUserRole>
    {
        public AppRoleStore(ApplicationContext context)
            : base(context)
        {
        }
    }

    public class AppClaimsPrincipal : ClaimsPrincipal
    {
        public AppClaimsPrincipal(IPrincipal principal) : base(principal)
        { }

    }
}