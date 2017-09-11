namespace SandwichOrderSystemShared.DataAccess.Db
{
    public interface IDatabaseInitializerFactory
    {
        DatabaseInitializer CreateDatabaseInitializer();
    }
}