using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.Models.Items
{
    public class DiscountItem : Item
    {
        public DiscountItem()
        {
            Id = DISCOUNT_ITEM_ID;
            Name = DISCOUNT_ITEM_NAME;
            Price = DISCOUNT_ITEM_PRICE;
            Type = typeof(DiscountItem).Name;
        }
    }
}
