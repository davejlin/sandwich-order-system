using SandwichOrderSystemShared.Models;
using System.Collections.Generic;
using System.Linq;

namespace SandwichOrderSystemShared.Services
{
    public class OrderManager : IOrderManager
    {
        public IOrders Orders { get; set; }

        private IOrder currentOrder;

        public OrderManager()
        {
            Orders = new Orders();
        }

        public int Count
        {
            get
            {
                if (Orders != null && Orders.OrderCollection != null)
                {
                    return Orders.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddItemToOrder(IItem item)
        {
            if (item != null)
            {
                var order = getCurrentOrder();
                order.Items.Add(item);
                setCurrentOrder(order);
            }
        }

        public void AddOrder()
        {
            if (currentOrder != null)
            {
                Orders.Add(currentOrder);
                ResetOrder();
            }
        }

        public void ResetOrder()
        {
            currentOrder = null;
        }

        private IOrder getCurrentOrder()
        {
            if (currentOrder == null)
            {
                return new Order();
            }
            else
            {
                return currentOrder;
            }
        }

        private void setCurrentOrder(IOrder order)
        {
            currentOrder = order;
        }
    }
}
