using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using TapFinder.DataAccess;
using TapFinder.Web.Services;

namespace TapFinder.Web.Infrastructure
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(Startup).Assembly);
            builder.RegisterModule<IdentityModule>();
            builder.RegisterAssemblyModules(typeof(ApplicationContext).Assembly);
            builder.RegisterType<NLogExceptionLogger>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .Where(t => t.Namespace.EndsWith("Services"))
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterType<ImageSaver>().AsSelf().SingleInstance();
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
            IComponentRegistration registration)
        {
            registration.Preparing += PrepareLogger;
        }

        private static void PrepareLogger(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(new[]
            {
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(NLog.ILogger),
                        (p, c) => NLog.LogManager.GetLogger(p.Member.DeclaringType?.FullName)
                    )
                });
        }
    }
}