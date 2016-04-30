using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PubApp.Web.Infrastructure;
using System;

namespace PubApp.Web
{
    public class AuthConfig
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),

                //TODO: Install certificate on the server and disable in release
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);

            //TODO
            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

        }
    }
}