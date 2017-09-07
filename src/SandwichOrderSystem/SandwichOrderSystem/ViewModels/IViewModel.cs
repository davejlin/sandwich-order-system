using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewModels
{
    public interface IViewModel
    {
        IEnumerable<string> GetItemCommandMenu<T>() where T : class, IItem;
        IEnumerable<string> GetItemCommands<T>() where T : class, IItem;
        IOrders GetOrders();
        int GetOrdersCount();
        void AddItem<T>(string c) where T : class, IItem;
        void AddOrder();
        void ResetOrder();
    }
}
