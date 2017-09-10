using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IItemFactory
    {
        T CreateItem<T>(string[] properties) where T : class, IItem;
    }
}
