using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public class Orders : IOrders
    {
        public ICollection<IOrder> OrderCollection { get; set; }

        public Orders()
        {
            Reset();
        }

        public void Reset()
        {
            OrderCollection = new List<IOrder>();
        }

        public void Add(IOrder order)
        {
            if (order != null)
            {
                OrderCollection.Add(order);
            }
        }

        public int Count
        {
            get
            {
                if (OrderCollection != null)
                {
                    return OrderCollection.Count;
                }
                else
                {
                    return 0;
                }

            }
        }

        private string FORMAT = "  Order {0}:\n{1}\n\n";
        public override string ToString()
        {
            string ordersString = "";
            int orderNumber = 1;
            foreach (IOrder order in OrderCollection)
            {
                ordersString += string.Format(FORMAT, orderNumber, order.ToString());
                orderNumber += 1;
            }
            return ordersString;
        }
    }
}
