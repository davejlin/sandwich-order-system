using SandwichOrderSystemShared.Models;
using System.Collections.Generic;
using System.Linq;

namespace SandwichOrderSystemShared.Services
{
    public class OrderManager : IOrderManager
    {
        public IOrders Orders { get; set; }

        public OrderManager()
        {
        }

        public int Count
        {
            get
            {
                if (Orders != null && Orders.OrderCollection != null)
                {
                    return Orders.OrderCollection.Count();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
