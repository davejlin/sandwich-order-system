using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystemShared.Services
{
    public interface IItemFactory
    {
        T CreateItem<T>(string[] properties) where T : class, IItem;
    }
}
