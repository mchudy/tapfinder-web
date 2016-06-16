using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TapFinder.Web.Infrastructure;

namespace TapFinder.Web
{
    public class AuthConfig
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public static FacebookAuthenticationOptions FacebookAuthOptions { get; private set; }

        public static void ConfigureAuth(IAppBuilder app)
        {
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
#if DEBUG
                AllowInsecureHttp = true
#else
                AllowInsecureHttp = false
#endif
            };

            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);

            app.UseOAuthBearerTokens(OAuthOptions);

            FacebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = System.Configuration.ConfigurationManager.AppSettings["FacebookAppId"],
                AppSecret = System.Configuration.ConfigurationManager.AppSettings["FacebookAppSecret"]
            };
            app.UseFacebookAuthentication(FacebookAuthOptions);
        }
    }
}