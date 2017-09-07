using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderSystemShared.Services
{
    public interface IOrderManager
    {
        IOrders Orders { get; }
        int Count { get; }

        void AddItemToOrder(IItem item);
        void AddOrder();
        void ResetOrder();
    }
}
