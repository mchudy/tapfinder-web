using Autofac;
using Microsoft.Owin;
using Owin;
using TapFinder.Web;
using TapFinder.Web.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]
namespace TapFinder.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppModule>();
            var container = builder.Build();

            appBuilder.UseAutofacMiddleware(container);

            AuthConfig.ConfigureAuth(appBuilder);
            WebApiConfig.Configure(appBuilder, container);
            MappingsConfig.ConfigureMappings();
        }
    }
}