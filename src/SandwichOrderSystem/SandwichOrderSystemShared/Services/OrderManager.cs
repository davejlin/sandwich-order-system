using SandwichOrderSystemShared.Models;
using System.Collections.Generic;
using System.Linq;

namespace SandwichOrderSystemShared.Services
{
    public class OrderManager : IOrderManager
    {
        public IOrders Orders { get; }

        private IOrder currentOrder;
        public IOrder CurrentOrder
        {
            get
            {
                if (currentOrder == null)
                {
                    currentOrder = new Order();
                    return currentOrder;
                }
                else
                {
                    return currentOrder;
                }
            }

            private set
            {
                currentOrder = value;
            }
        }

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
                CurrentOrder.Items.Add(item);
            }
        }

        public void AddOrderToOrders()
        {
            if (CurrentOrder != null)
            {
                Orders.Add(CurrentOrder);
                ResetCurrentOrder();
            }
        }

        public void ResetCurrentOrder()
        {
            CurrentOrder = null;
        }

        public void ResetOrders()
        {
            ResetCurrentOrder();
            Orders.Reset();
        }

        public void FinishOrders()
        {
            // TODO: Pass order along to payment and repository services
            ResetOrders();
        }
    }
}
