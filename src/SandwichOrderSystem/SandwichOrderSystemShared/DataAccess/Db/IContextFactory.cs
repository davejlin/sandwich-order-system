namespace SandwichOrderSystemShared.DataAccess.Db
{
    public interface IContextFactory
    {
        Context createContext();
    }
}