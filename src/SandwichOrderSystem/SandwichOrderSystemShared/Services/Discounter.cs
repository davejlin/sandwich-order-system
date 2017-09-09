using SandwichOrderSystemShared.Models;
using System.Linq;
using SandwichOrderSystemShared.Models.Items;

namespace SandwichOrderSystemShared.Services
{
    public class Discounter : IDiscounter
    {
        private string drinkType = typeof(Drink).ToString();
        private string chipsType = typeof(Chips).ToString();

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
