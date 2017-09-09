using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public interface IOrders
    {
        ICollection<IOrder> OrderCollection { get; }
        int Count { get; }

        void Reset();
        void Add(IOrder order);
    }
}
