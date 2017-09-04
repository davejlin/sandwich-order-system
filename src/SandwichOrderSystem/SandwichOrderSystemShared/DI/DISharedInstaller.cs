using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderSystemShared.DataAccess;
using SandwichOrderSystemShared.DataAccess.Deserializer;

namespace SandwichOrderSystemShared.DI
{
    public class DISharedInstaller : IWindsorInstaller
    {
        private static IWindsorContainer container;
        public static IWindsorContainer Container
        {
            get
            {
                return container;
            }

            private set
            {
                container = value;
            }
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            DISharedInstaller.Container = container;

            container.Register(Component.For<IRepository>().ImplementedBy<Repository>());

            container.Register(Component.For<IDataInitializer>().ImplementedBy<DataInitializer>());
            container.Register(Component.For<IDataParser>().ImplementedBy<DataParser>());
            container.Register(Component.For<IFileSystemManager>().ImplementedBy<FileSystemManager>());
            container.Register(Component.For<IItemFactory>().ImplementedBy<ItemFactory>());
        }
    }
}
