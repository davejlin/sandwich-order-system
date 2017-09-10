using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderSystemShared.DataAccess;
using SandwichOrderSystemShared.DataAccess.Db;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Services;

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
            Container = container;

            container.Register(Component.For<IDContainerIWrapper>().ImplementedBy<DIContainerWrapper>());
            container.Register(Component.For<IDataInitializer>().ImplementedBy<DataInitializer>());
            container.Register(Component.For<IDataParser>().ImplementedBy<DataParser>());
            container.Register(Component.For<IFileSystemManager>().ImplementedBy<FileSystemManager>());
            container.Register(Component.For<IItemFactory>().ImplementedBy<ItemFactory>());
            container.Register(Component.For<IErrorHandler>().ImplementedBy<ErrorHandler>());
            container.Register(Component.For<IDiscounter>().ImplementedBy<Discounter>());
            container.Register(Component.For<IOrderManager>().ImplementedBy<OrderManager>());

            container.Register(Component.For<IContextFactory>().ImplementedBy<ContextFactory>());
            container.Register(Component.For<IDatabaseInitializerFactory>().ImplementedBy<DatabaseInitializerFactory>());

            container.Register(Component.For<Context>().LifeStyle.Transient);
            container.Register(Component.For<DatabaseInitializer>().LifeStyle.Transient);

            container.Register(Component.For<IRepository>().ImplementedBy<Repository>());
        }
    }
}
