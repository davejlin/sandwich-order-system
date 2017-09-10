namespace SandwichOrderSystemShared.DataAccess.Db
{
    public interface IContextFactory
    {
        Context CreateContext();
    }
}