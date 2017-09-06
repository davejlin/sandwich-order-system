using SandwichOrderSystem.Models;
using SandwichOrderSystem.Services;
using SandwichOrderSystemShared.DataAccess;
using SandwichOrderSystemShared.Models;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewModels
{
    public class ViewModel : IViewModel
    {
        private Dictionary<Type, List<IMenuItem>> menuItemsDict;

        IMenuItemsFactory menuItemsFactory;

        public ViewModel(IMenuItemsFactory menuItemsFactory)
        {
            this.menuItemsFactory = menuItemsFactory;
            menuItemsDict = menuItemsFactory.CreateMenuItems();
        }

        string menuCommandFormat = " {0} - {1,-20} {2}";
        public IEnumerable<string> GetItemForMenuCommands<T>() where T : class, IItem
        {
            List<string> itemMenuCommands = new List<string>();

            if (menuItemsDict.ContainsKey(typeof(T)))
            {
                var itemList = menuItemsDict[typeof(T)];
                if (itemList != null)
                {
                    foreach (IMenuItem item in itemList)
                    {
                        string command = string.Format(menuCommandFormat, item.MenuCommand, item.Name, item.Price);
                        itemMenuCommands.Add(command);
                    }
                }
            }

            return itemMenuCommands;
        }
    }
}
