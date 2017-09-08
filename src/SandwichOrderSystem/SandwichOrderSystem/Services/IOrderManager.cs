using SandwichOrderSystemShared.Models;

namespace SandwichOrderSystem.Services
{
    public interface IOrderManager
    {
        IOrders Orders { get; }
        IOrder CurrentOrder { get; }
        int Count { get; }
        decimal TotalOrdersPrice { get; }
        decimal CurrentOrderTotalPrice { get; }
        bool IsCurrentOrderComboMeal { get; }

        void AddItemToOrder<T>(IItem item);
        void AddOrderToOrders();
        void ResetCurrentOrder();
        void ResetOrders();
        void FinishOrders();
    }
}
