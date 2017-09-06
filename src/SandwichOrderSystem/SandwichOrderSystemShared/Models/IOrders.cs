using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public interface IOrders
    {
        IEnumerable<IOrder> OrderCollection { get; set; }
    }
}
