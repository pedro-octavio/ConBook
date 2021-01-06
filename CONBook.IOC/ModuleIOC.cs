using Autofac;
using CONBook.IOC.IOC;

namespace CONBook.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            ConfigurationIOC.Load(containerBuilder);
        }
    }
}
