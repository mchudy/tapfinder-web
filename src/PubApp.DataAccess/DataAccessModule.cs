using Autofac;

namespace PubApp.DataAccess
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
