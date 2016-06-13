using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using PubApp.DataAccess;
using PubApp.DataAccess.Entities;
using PubApp.Web.Dtos;
using PubApp.Web.Infrastructure;
using System;
using System.Configuration;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PubApp.Web.Services
{
    public class UsersService
    {
        private readonly ApplicationUserManager userManager;
        private readonly ApplicationContext ctx;

        public UsersService(ApplicationUserManager userManager, ApplicationContext ctx)
        {
            this.userManager = userManager;
            this.ctx = ctx;
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

        public async Task<User> FindByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<User> FindByName(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<User> FindAsync(UserLoginInfo loginInfo)
        {
            User user = await userManager.FindAsync(loginInfo);
            return user;
        }

        public async Task<IdentityResult> CreateAsync(User user)
        {
            return await userManager.CreateAsync(user);
        }

        public async Task<IdentityResult> AddLoginAsync(int userId, UserLoginInfo login)
        {
            return await userManager.AddLoginAsync(userId, login);
        }

        public void SetImage(int userId, string imagePath)
        {
            var user = ctx.Users.Find(userId);
            user.ImagePath = imagePath;
            ctx.SaveChanges();
        }

        public async Task<ParsedExternalAccessToken> VerifyExternalAccessToken(string provider, string accessToken)
        {
            ParsedExternalAccessToken parsedToken = null;

            string verifyTokenEndPoint;

            if (provider == "Facebook")
            {
                var appToken = ConfigurationManager.AppSettings["FacebookAppToken"];
                verifyTokenEndPoint =
                    $"https://graph.facebook.com/debug_token?input_token={accessToken}&access_token={appToken}";
            }
            else
            {
                return null;
            }

            var client = new HttpClient();
            var uri = new Uri(verifyTokenEndPoint);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                parsedToken = new ParsedExternalAccessToken();

                if (provider == "Facebook")
                {
                    parsedToken.user_id = jObj["data"]["user_id"];
                    parsedToken.app_id = jObj["data"]["app_id"];

                    if (!string.Equals(AuthConfig.FacebookAuthOptions.AppId, parsedToken.app_id, StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }
                }
            }
            return parsedToken;
        }

        public dynamic GenerateLocalAccessTokenResponse(string userName, int userId)
        {
            var tokenExpiration = TimeSpan.FromDays(14);

            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim("role", "user"));

            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };

            var ticket = new AuthenticationTicket(identity, props);
            var accessToken = AuthConfig.OAuthOptions.AccessTokenFormat.Protect(ticket);
            dynamic tokenResponse = new JObject(
                                        new JProperty("userName", userName),
                                        new JProperty("access_token", accessToken),
                                        new JProperty("token_type", "bearer"),
                                        new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                        new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                        new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
            );
            return tokenResponse;
        }
    }
}