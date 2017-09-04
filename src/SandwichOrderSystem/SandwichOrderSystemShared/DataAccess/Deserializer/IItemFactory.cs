namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IItemFactory
    {
        T CreateItem<T>(string[] properties) where T : class;
    }
}
