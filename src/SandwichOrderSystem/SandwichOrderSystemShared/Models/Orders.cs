using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public class Orders : IOrders
    {
        public IEnumerable<IOrder> OrderCollection { get; set; }

        private string FORMAT = " Order {0}:\n\n{1}\n\n";
        public override string ToString()
        {
            string ordersString = "";
            int orderNumber = 0;
            foreach (IOrder order in OrderCollection)
            {
                ordersString += string.Format(FORMAT, orderNumber, order.ToString());
                orderNumber += 1;
            }
            return ordersString;
        }
    }
}
