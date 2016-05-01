using Microsoft.AspNet.Identity;
using PubApp.DataAccess.Entities;
using PubApp.Web.Dtos;
using PubApp.Web.Infrastructure;
using System.Threading.Tasks;

namespace PubApp.Web.Services
{
    public class UsersService
    {
        private readonly ApplicationUserManager userManager;

        public UsersService(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> RegisterUser(UserRegisterDto registerData)
        {
            var user = new User { UserName = registerData.UserName, Email = registerData.Email };
            IdentityResult result = await userManager.CreateAsync(user, registerData.Password);
            return result.Succeeded;
        }

        public async Task<bool> ChangePassword(ChangePasswordDto dto, int currentUserId)
        {
            var result = await userManager.ChangePasswordAsync(currentUserId, dto.OldPassword, dto.NewPassword);
            return result.Succeeded;
        }
    }
}