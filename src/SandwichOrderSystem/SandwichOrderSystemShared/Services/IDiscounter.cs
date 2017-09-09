using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystemShared.Services
{
    public interface IDiscounter
    {
        IItem GetDiscountItemConditionally(IOrder order);
    }
}