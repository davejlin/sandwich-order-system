using SandwichOrderSystem.Models;
using SandwichOrderSystem.Services;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewModels
{
    public class ViewModel : IViewModel
    {
        private IDictionary<Type, List<IMenuItem>> menuItemsDict;

        IOrderManager orderManager;

        public ViewModel(IMenuItemsFactory menuItemsFactory, IOrderManager orderManager)
        {
            this.orderManager = orderManager;

            menuItemsDict = menuItemsFactory.CreateMenuItems();
        }

        string menuCommandFormat = " {0} - {1,-20} {2}";
        public IEnumerable<string> GetItemCommandMenu<T>() where T : class, IItem
        {
            List<string> commandMenu = new List<string>();

            if (menuItemsDict.ContainsKey(typeof(T)))
            {
                var itemList = menuItemsDict[typeof(T)];
                if (itemList != null)
                {
                    foreach (IMenuItem item in itemList)
                    {
                        string command = string.Format(menuCommandFormat, item.MenuCommand, item.Name, item.Price);
                        commandMenu.Add(command);
                    }
                }
            }

            return commandMenu;
        }

        public IEnumerable<string> GetItemCommands<T>() where T : class, IItem
        {
            List<string> itemCommands = new List<string>();

            if (menuItemsDict.ContainsKey(typeof(T)))
            {
                var itemList = menuItemsDict[typeof(T)];
                if (itemList != null)
                {
                    foreach (IMenuItem item in itemList)
                    {
                        itemCommands.Add(item.MenuCommand);
                    }
                }
            }

            return itemCommands;
        }
    }
}
