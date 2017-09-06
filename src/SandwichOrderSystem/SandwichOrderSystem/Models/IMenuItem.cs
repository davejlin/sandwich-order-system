using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystem.Models
{
    public interface IMenuItem : IItem
    {
        string MenuCommand { get; }
    }
}
