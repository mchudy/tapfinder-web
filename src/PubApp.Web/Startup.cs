using Autofac;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PubApp.Web.Startup))]
namespace PubApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AppModule>();
            var container = builder.Build();

            appBuilder.UseAutofacMiddleware(container);

            WebApiConfig.Configure(appBuilder, container);
            MappingsConfig.ConfigureMappings();
        }
    }
}