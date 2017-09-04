using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class DatabaseInitializerFactory : IDatabaseInitializerFactory
    {
        public DatabaseInitializer createDatabaseInitializer()
        {
            return DISharedInstaller.Container.Resolve<DatabaseInitializer>();
        }
    }
}