using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class DatabaseInitializerFactory : IDatabaseInitializerFactory
    {
        IDContainerIWrapper container;
        public DatabaseInitializerFactory(IDContainerIWrapper container)
        {
            this.container = container;
        }

        public DatabaseInitializer createDatabaseInitializer()
        {
            return container.Container.Resolve<DatabaseInitializer>();
        }
    }
}