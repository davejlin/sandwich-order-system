﻿using SandwichOrderSystem.Models;
using SandwichOrderSystemShared.DataAccess;
using SandwichOrderSystemShared.Models;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.Services
{
    public class MenuItemsFactory : IMenuItemsFactory
    {
        private Dictionary<Type, List<IMenuItem>> menuItemsDict;
        private IRepository repository;

        public MenuItemsFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public IMenuItem CreateMenuItem(IItem item, string menuCommand)
        {
            IMenuItem menuItem = new MenuItem()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                MenuCommand = menuCommand
            };

            return menuItem;
        }

        public Dictionary<Type, List<IMenuItem>> CreateMenuItems()
        {
            menuItemsDict = new Dictionary<Type, List<IMenuItem>>();

            loadMenuItem<SignatureSandwich>();
            loadMenuItem<Bread>();
            loadMenuItem<Filling>();
            loadMenuItem<Cheese>();
            loadMenuItem<Vegetable>();
            loadMenuItem<Condiment>();
            loadMenuItem<Drink>();
            loadMenuItem<Chips>();

            return menuItemsDict;
        }

        private void loadMenuItem<T>() where T : class, IItem
        {
            List<IMenuItem> menuItems = new List<IMenuItem>();
            int itemNumber = 1;

            IEnumerable<T> itemList = repository.GetItem<T>();
            if (itemList != null)
            {
                foreach (IItem item in itemList)
                {

                    IMenuItem menuItem = CreateMenuItem(item, itemNumber.ToString());
                    menuItems.Add(menuItem);

                    itemNumber += 1;
                }

                menuItemsDict.Add(typeof(T), menuItems);
            }
        }
    }
}