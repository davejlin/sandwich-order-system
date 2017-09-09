using System.Collections.Generic;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.Models
{
    public class Orders : IOrders
    {
        public ICollection<IOrder> OrderCollection { get; private set; }

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
                if (OrderCollection == null)
                {
                    return 0;
                }
                else
                {
                    return OrderCollection.Count;
                }

            }
        }

        public override string ToString()
        {
            string ordersString = EMPTY_STRING;
            int orderNumber = 1;
            foreach (IOrder order in OrderCollection)
            {
                ordersString += string.Format(ORDERS_FORMAT, ORDERS_TITLE, orderNumber, order.ToString());
                orderNumber += 1;
            }
            return ordersString;
        }
    }
}
