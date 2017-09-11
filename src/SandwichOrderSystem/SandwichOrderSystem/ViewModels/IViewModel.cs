using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

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
        void FinishOrders();
        decimal GetOrdersPrice();
        decimal GetCurrentOrderPrice();
    }
}
