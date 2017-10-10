using SandwichOrderSystemShared.Models;
using System.Collections.Generic;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystem.ViewModels
{
    public interface IViewModel
    {
        IEnumerable<string> GetMenuItemCommandStrings<T>() where T : class, IItem;
        IEnumerable<string> GetMenuItemCommands<T>() where T : class, IItem;
        IOrders GetOrders();
        IOrder GetCurrentOrder();
        int GetOrdersCount();
        void AddItem<T>(string command) where T : class, IItem;
        void AddCurrentOrderToOrders();
        void ResetCurrentOrder();
        void ResetOrders();
        void FinishOrders(PaymentMethodType type);
        decimal GetOrdersPrice();
        decimal GetCurrentOrderPrice();
    }
}
