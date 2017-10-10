using SandwichOrderSystem.Models;
using SandwichOrderSystem.Services;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using static SandwichOrderSystem.Constants;
using System;
using System.Collections.Generic;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystem.ViewModels
{
    public class ViewModel : IViewModel
    {
        private IDictionary<Type, List<IMenuItem>> menuItemsDict;
        private IOrderManager orderManager;

        public ViewModel(IMenuItemsFactory menuItemsFactory, IOrderManager orderManager)
        {
            this.orderManager = orderManager;

            menuItemsDict = menuItemsFactory.GetMenuItems();
        }

        public IEnumerable<string> GetMenuItemCommandStrings<T>() where T : class, IItem
        {
            var commandMenu = new List<string>();

            var itemList = getItemList<T>();
            if (itemList != null)
            {
                foreach (IMenuItem item in itemList)
                {
                    string command = string.Format(MENU_COMMAND_FORMAT, item.MenuCommand, item.Name, item.Price);
                    commandMenu.Add(command);
                }
            }

            return commandMenu;
        }

        public IEnumerable<string> GetMenuItemCommands<T>() where T : class, IItem
        {
            var itemCommands = new List<string>();

            var itemList = getItemList<T>();
            if (itemList != null)
            {
                foreach (IMenuItem item in itemList)
                {
                    itemCommands.Add(item.MenuCommand);
                }
            }

            return itemCommands;
        }

        public void AddItem<T>(string command) where T : class, IItem
        {
            var itemList = getItemList<T>();
            if (itemList != null)
            {
                var menuItem = itemList.Find(i => i.MenuCommand == command);
                if (menuItem != null)
                {
                    orderManager.AddItemToCurrentOrder(menuItem);
                }
            }
        }

        public int GetOrdersCount()
        {
            return orderManager.Count;
        }

        public IOrders GetOrders()
        {
            return orderManager.Orders;
        }

        public IOrder GetCurrentOrder()
        {
            return orderManager.CurrentOrder;
        }

        public decimal GetOrdersPrice()
        {
            return orderManager.OrdersPrice;
        }

        public decimal GetCurrentOrderPrice()
        {
            return orderManager.CurrentOrderPrice;
        }

        public void AddCurrentOrderToOrders()
        {
            orderManager.AddCurrentOrderToOrders();
        }

        public void ResetCurrentOrder()
        {
            orderManager.ResetCurrentOrder();
        }

        public void ResetOrders()
        {
            orderManager.ResetOrders();
        }

        public void FinishOrders(PaymentMethodType type)
        {
            orderManager.FinishOrders(type);
        }

        private List<IMenuItem> getItemList<T>() where T : class, IItem
        {
            if (menuItemsDict != null && menuItemsDict.ContainsKey(typeof(T)))
            {
                return menuItemsDict[typeof(T)];
            }
            else
            {
                return null;
            }
        }
    }
}
