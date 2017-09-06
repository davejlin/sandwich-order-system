using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystem.Models
{
    public class MenuItem : IMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

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
