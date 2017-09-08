using SandwichOrderSystemShared.Models;
using static SandwichOrderSystemShared.Constants;
using System.Linq;
using System;

namespace SandwichOrderSystemShared.Services
{
    public class OrderManager : IOrderManager
    {
        public IOrders Orders { get; }

        public bool IsCurrentOrderComboMeal
        {
            get
            {
                return isCurrentOrderHaveDrink && isCurrentOrderHaveChips;
            }
        }

        private bool isCurrentOrderHaveDrink;
        private bool isCurrentOrderHaveChips;
        private bool isComboMealApplied;

        private IOrder currentOrder;
        public IOrder CurrentOrder
        {
            get
            {
                if (currentOrder == null)
                {
                    ResetCurrentOrder();
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
            ResetCurrentOrder();
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

        public decimal TotalOrdersPrice
        {
            get
            {
                return Orders.OrderCollection
                    .Sum(o => o.Items
                    .Sum(i => i.Price));
            }
        }

        public decimal CurrentOrderTotalPrice
        {
            get
            {
                return currentOrder.Items
                    .Sum(i => i.Price);
            }
        }

        public void AddItemToOrder<T>(IItem item)
        {
            if (item != null)
            {
                CurrentOrder.Items.Add(item);
                checkComboMeal<T>(item);
            }
        }

        private void checkComboMeal<T>(IItem item)
        {
            Type itemType = typeof(T);
            if (itemType == typeof(Drink))
            {
                isCurrentOrderHaveDrink = true;
            }
            else if (itemType == typeof(Chips))
            {
                isCurrentOrderHaveChips = true;
            }

            if (!isComboMealApplied)
            {
                addComboMeal();
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
            CurrentOrder = new Order();
            isCurrentOrderHaveDrink = false;
            isCurrentOrderHaveChips = false;
            isComboMealApplied = false;
    }

        public void ResetOrders()
        {
            ResetCurrentOrder();
            Orders.Reset();
        }

        private void addComboMeal()
        {
            if (IsCurrentOrderComboMeal)
            {
                CurrentOrder.Items.Add(new ComboMealItem());
                isComboMealApplied = true;
            }
        }

        private class ComboMealItem : Item
        {
            internal ComboMealItem()
            {
                Id = COMBO_MEAL_ID;
                Name = COMBO_MEAL_NAME;
                Price = COMBO_MEAL_PRICE;
            }
        }

        public void FinishOrders()
        {
            // TODO: Pass order along to payment and repository services
            ResetOrders();
        }
    }
}
