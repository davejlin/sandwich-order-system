using SandwichOrderSystemShared.Models;
using System.Linq;
using SandwichOrderSystemShared.Models.Items;

namespace SandwichOrderSystemShared.Services
{
    public class Discounter : IDiscounter
    {
        private string drinkType = typeof(Drink).Name;
        private string chipsType = typeof(Chips).Name;

        public IItem GetDiscountItemConditionally(IOrder order)
        {
            var hasDrink = order.Items.Any(i => i.Type == drinkType);
            var hasChips = order.Items.Any(i => i.Type == chipsType);

            if (hasDrink && hasChips)
            {
                return new DiscountItem();
            }
            else
            {
                return null;
            }
        }
    }
}
