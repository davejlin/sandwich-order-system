using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SandwichOrderingSystemShared.DataAccess;
using SandwichOrderingSystemShared.DataAccess.Db;
using SandwichOrderingSystemShared.DataAccess.Deserializer;
using SandwichOrderingSystemShared.Models;

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
