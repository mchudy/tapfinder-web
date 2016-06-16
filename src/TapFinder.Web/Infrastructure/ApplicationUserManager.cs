using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TapFinder.DataAccess.Entities;

namespace TapFinder.Web.Infrastructure
{

    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IUserStore<User, int> store, IdentityFactoryOptions<ApplicationUserManager> options)
          : base(store)
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            if (options.DataProtectionProvider != null)
            {
                UserTokenProvider =
                    new DataProtectorTokenProvider<User, int>(options.DataProtectionProvider.Create("ASP.NET Identity"));
            }
        }
    }
}