using SandwichOrderSystem.Models;
using SandwichOrderSystem.Services;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using static SandwichOrderSystem.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichOrderSystem.ViewModels
{
    public class ViewModel : IViewModel
    {
        private IDictionary<Type, List<IMenuItem>> menuItemsDict;

        IOrderManager orderManager;

        public ViewModel(IMenuItemsFactory menuItemsFactory, IOrderManager orderManager)
        {
            this.orderManager = orderManager;

            menuItemsDict = menuItemsFactory.GetMenuItems();
        }

        public IEnumerable<string> GetItemCommandMenu<T>() where T : class, IItem
        {
            List<string> commandMenu = new List<string>();

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

        public IEnumerable<string> GetItemCommands<T>() where T : class, IItem
        {
            List<string> itemCommands = new List<string>();

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

        public void AddItem<T>(string c) where T : class, IItem
        {
            var itemList = getItemList<T>();
            if (itemList != null)
            {
                var menuItem = itemList.Find(i => i.MenuCommand == c);
                orderManager.AddItemToOrder(menuItem);
            }
        }

        public void AddOrder()
        {
            orderManager.AddOrderToOrders();
        }

        public void ResetOrder()
        {
            orderManager.ResetCurrentOrder();
        }

        public void ResetOrders()
        {
            orderManager.ResetOrders();
        }

        public void FinishOrders()
        {
            orderManager.FinishOrders();
        }

        private List<IMenuItem> getItemList<T>() where T : class, IItem
        {
            if (menuItemsDict.ContainsKey(typeof(T)))
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
