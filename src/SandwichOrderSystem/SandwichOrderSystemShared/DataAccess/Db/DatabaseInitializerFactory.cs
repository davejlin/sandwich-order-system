using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class DatabaseInitializerFactory : IDatabaseInitializerFactory
    {
        IDIContainerIWrapper container;
        public DatabaseInitializerFactory(IDIContainerIWrapper container)
        {
            this.container = container;
        }

        public DatabaseInitializer createDatabaseInitializer()
        {
            return container.Container.Resolve<DatabaseInitializer>();
        }
    }
}