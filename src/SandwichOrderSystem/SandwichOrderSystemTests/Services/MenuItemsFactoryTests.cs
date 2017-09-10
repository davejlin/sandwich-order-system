using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystem.Models;
using SandwichOrderSystemShared.DataAccess;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Models;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.Services.Tests
{
    [TestClass()]
    public class MenuItemsFactoryTests
    {
        IItemFactory itemFactory;
        Mock<IRepository> mockRepository;
        MenuItemsFactory menuItemsFactory;

        Type[] types = new Type[] { typeof(SignatureSandwich), typeof(Bread), typeof(Filling), typeof(Cheese), typeof(Vegetable), typeof(Condiment), typeof(Drink), typeof(Chips) };

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            menuItemsFactory = new MenuItemsFactory(mockRepository.Object);
        }

        [TestMethod()]
        public void MenuItemsFactoryTest()
        {
            var name = "sandwich";
            var price = "1.0";
            var menuCommand = "m";

            var item = itemFactory.CreateItem<SignatureSandwich>(new string[] { name, price });
            var expectedMenuItem = new MenuItem(item, menuCommand);

            var actualMenuItem = menuItemsFactory.CreateMenuItem(item, menuCommand);

            Assert.AreEqual(expectedMenuItem.Name, actualMenuItem.Name, "should have same name");
            Assert.AreEqual(expectedMenuItem.Price, actualMenuItem.Price, "should have same price");
            Assert.AreEqual(expectedMenuItem.Type, actualMenuItem.Type, "should have same type");
            Assert.AreEqual(expectedMenuItem.MenuCommand, actualMenuItem.MenuCommand, "should have same menu command");
        }

        [TestMethod()]
        public void GetMenuItems()
        {
            var name1 = "item1";
            var price1 = "1.0";

            var name2 = "item2";
            var price2 = "2.0";

            var nameList = new string[] { name1, name2 };
            var priceList = new string[] { price1, price2 };

            var menuItems = menuItemsFactory.GetMenuItems();

            foreach (var type in types)
            {
                Assert.IsTrue(menuItems.Keys.Contains(type), "should have IItem type");

                var i = 0;
                foreach (var menuItem in menuItems[type])
                {
                    Assert.AreEqual(nameList[i], menuItem.Name, "shoud have same name");
                    Assert.AreEqual(Convert.ToDecimal(priceList[i]), menuItem.Price, "should have same price");
                    Assert.AreEqual(type.Name, menuItem.Type, "should have same type");
                    Assert.AreEqual((i+1).ToString(), menuItem.MenuCommand, "should have correct menu command");

                    i++;
                }
            }
        }

        [TestMethod()]
        public void GetMenuItems_ReturnsEmptyListIfRepositoryReturnsNull()
        {
            mockRepository = new Mock<IRepository>();
            menuItemsFactory = new MenuItemsFactory(mockRepository.Object);

            var menuItems = menuItemsFactory.GetMenuItems();

            foreach (var type in types)
            {
                Assert.IsTrue(menuItems.Keys.Contains(type), "should have IItem type");

                var i = 0;
                foreach (var menuItem in menuItems[type])
                {
                    Assert.Fail("should be empty");
                }

                Assert.AreEqual(0, i, "should be empty");
            }
        }

        private void setupMocks()
        {
            itemFactory = new ItemFactory();

            mockRepository = new Mock<IRepository>();

            setupMockMenuItemsListReturns<SignatureSandwich>();
            setupMockMenuItemsListReturns<Bread>();
            setupMockMenuItemsListReturns<Filling>();
            setupMockMenuItemsListReturns<Cheese>();
            setupMockMenuItemsListReturns<Vegetable>();
            setupMockMenuItemsListReturns<Condiment>();
            setupMockMenuItemsListReturns<Drink>();
            setupMockMenuItemsListReturns<Chips>();
        }

        private void setupMockMenuItemsListReturns<T>() where T : class, IItem
        {
            var name1 = "item1";
            var price1 = "1.0";
            var item1 = itemFactory.CreateItem<T>(new string[] { name1, price1 });

            var name2 = "item2";
            var price2 = "2.0";
            var item2 = itemFactory.CreateItem<T>(new string[] { name2, price2 });

            var itemsList = new List<T>() { item1, item2 };

            mockRepository.Setup(r => r.GetItem<T>()).Returns(itemsList);
        }
    }
}