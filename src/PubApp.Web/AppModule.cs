using Autofac;
using Autofac.Integration.WebApi;
using PubApp.DataAccess;

namespace PubApp.Web
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(Startup).Assembly);
            builder.RegisterAssemblyModules(typeof(ApplicationContext).Assembly);
        }
    }
}