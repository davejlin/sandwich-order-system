using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystem.Models
{
    public class MenuItem : Item, IMenuItem
    {
        public string MenuCommand { get; }

        public MenuItem(IItem item, string menuCommand)
        {
            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            MenuCommand = menuCommand;
        }
    }
}
