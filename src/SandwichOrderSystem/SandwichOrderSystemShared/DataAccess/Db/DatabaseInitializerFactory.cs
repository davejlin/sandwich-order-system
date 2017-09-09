using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class DatabaseInitializerFactory : IDatabaseInitializerFactory
    {
        public DatabaseInitializerFactory() { }

        public DatabaseInitializer createDatabaseInitializer()
        {
            return DISharedInstaller.Container.Resolve<DatabaseInitializer>();
        }
    }
}