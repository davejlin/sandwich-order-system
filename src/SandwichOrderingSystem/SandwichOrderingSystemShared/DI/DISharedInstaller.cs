using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderingSystemShared.DataAccess;
using SandwichOrderingSystemShared.DataAccess.Deserializer;

namespace SandwichOrderingSystemShared.DI
{
    public class DISharedInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IRepository>().ImplementedBy<Repository>());

            container.Register(Component.For<IDataInitializer>().ImplementedBy<DataInitializer>());
            container.Register(Component.For<IDataParser>().ImplementedBy<DataParser>());
            container.Register(Component.For<IFileSystemManager>().ImplementedBy<FileSystemManager>());
            container.Register(Component.For<IItemFactory>().ImplementedBy<ItemFactory>());


        }
    }
}
