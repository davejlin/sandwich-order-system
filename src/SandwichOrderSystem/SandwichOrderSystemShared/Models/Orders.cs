using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public class Orders : IOrders
    {
        public IEnumerable<IOrder> OrderCollection { get; set; }
    }
}
