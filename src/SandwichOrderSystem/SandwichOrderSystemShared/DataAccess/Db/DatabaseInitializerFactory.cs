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

        public DatabaseInitializer CreateDatabaseInitializer()
        {
            return container.Container.Resolve<DatabaseInitializer>();
        }
    }
}