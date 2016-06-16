using Autofac;

namespace TapFinder.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>()
                .AsSelf()
                .InstancePerRequest();
        }
    }
}
