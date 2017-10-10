using SandwichOrderSystemShared.Models;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.Services
{
    public interface IOrderManager
    {
        IOrders Orders { get; }
        IOrder CurrentOrder { get; }
        int Count { get; }
        decimal OrdersPrice { get; }
        decimal CurrentOrderPrice { get; }

        void AddItemToCurrentOrder(IItem item);
        void AddCurrentOrderToOrders();
        void ResetCurrentOrder();
        void ResetOrders();
        void FinishOrders(PaymentMethodType type);
    }
}
