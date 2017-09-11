using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystem.Models;
using SandwichOrderSystem.Services;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewModels.Tests
{
    [TestClass()]
    public class ViewModelTests
    {
        Mock<IMenuItemsFactory> mockMenuItemsFactory;
        Mock<IOrderManager> mockOrderManager;
        IMenuItemsFactory menuItemsFactory;
        IItemFactory itemFactory;
        IViewModel viewModel;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();

            viewModel = new ViewModel(mockMenuItemsFactory.Object, mockOrderManager.Object);

            itemFactory = new ItemFactory();
            menuItemsFactory = new MenuItemsFactory(null);
        }

        [TestMethod()]
        public void GetMenuItemCommandStringsTest()
        {
            var name1 = "name1";
            var price1 = "1.0";
            var menuCommand1 = "1";
            var menuItem1 = createMenuItem<SignatureSandwich>(name1, price1, menuCommand1);
            var menuItemCommandString1 = createMenuItemCommandString(menuItem1);

            var name2 = "name2";
            var price2 = "2.0";
            var menuCommand2 = "2";
            var menuItem2 = createMenuItem<SignatureSandwich>(name2, price2, menuCommand2);
            var menuItemCommandString2 = createMenuItemCommandString(menuItem2);

            var expectedCommandMenusStrings = new string[] { menuItemCommandString1, menuItemCommandString2 };

            setupMockMenuItemDictReturn(new List<IMenuItem>() { menuItem1, menuItem2 });

            var actualCommandMenuStrings = viewModel.GetMenuItemCommandStrings<SignatureSandwich>();

            var i = 0;
            foreach (var itemCommandMenu in actualCommandMenuStrings)
            {
                Assert.AreEqual(expectedCommandMenusStrings[i], itemCommandMenu, "should be menu command string");
                i++;
            }
        }

        [TestMethod()]
        public void GetMenuItemCommandStringsTest_ShouldReturnEmptyEnumerableIfMenuItemsDictIsNull()
        {
            var actualCommandMenuStrings = viewModel.GetMenuItemCommandStrings<SignatureSandwich>();

            Assert.IsNull(actualCommandMenuStrings.GetEnumerator().Current);
        }

        [TestMethod()]
        public void GetMenuItemCommandStringsTest_ShouldReturnEmptyEnumerableIfMenuItemsDictIsEmpty()
        {
            mockMenuItemsFactory.Setup(f => f.GetMenuItems()).Returns(new Dictionary<Type, List<IMenuItem>>());
            viewModel = new ViewModel(mockMenuItemsFactory.Object, mockOrderManager.Object);

            var actualCommandMenuStrings = viewModel.GetMenuItemCommandStrings<SignatureSandwich>();

            Assert.IsNull(actualCommandMenuStrings.GetEnumerator().Current);
        }

        [TestMethod()]
        public void GetMenuItemCommandsTest()
        {
            var name1 = "name1";
            var price1 = "1.0";
            var menuCommand1 = "1";
            var menuItem1 = createMenuItem<SignatureSandwich>(name1, price1, menuCommand1);
            var menuItemCommand1 = menuCommand1;

            var name2 = "name2";
            var price2 = "2.0";
            var menuCommand2 = "2";
            var menuItem2 = createMenuItem<SignatureSandwich>(name2, price2, menuCommand2);
            var menuItemCommand2 = menuCommand2;

            var expectedCommands = new string[] { menuItemCommand1, menuItemCommand2 };

            setupMockMenuItemDictReturn(new List<IMenuItem>() { menuItem1, menuItem2 });

            var actualItemCommands = viewModel.GetMenuItemCommands<SignatureSandwich>();

            var i = 0;
            foreach (var itemCommandMenu in actualItemCommands)
            {
                Assert.AreEqual(expectedCommands[i], itemCommandMenu, "should be command");
                i++;
            }
        }

        [TestMethod()]
        public void GettemMenuCommandsTest_ShouldReturnEmptyEnumerableIfMenuItemsDictIsNull()
        {
            var actualItemCommands = viewModel.GetMenuItemCommands<SignatureSandwich>();

            Assert.IsNull(actualItemCommands.GetEnumerator().Current);
        }

        [TestMethod()]
        public void GetMenuItemCommandsTest_ShouldReturnEmptyEnumerableIfMenuItemsDictIsEmpty()
        {
            mockMenuItemsFactory.Setup(f => f.GetMenuItems()).Returns(new Dictionary<Type, List<IMenuItem>>());
            viewModel = new ViewModel(mockMenuItemsFactory.Object, mockOrderManager.Object);

            var actualItemCommands = viewModel.GetMenuItemCommands<SignatureSandwich>();

            Assert.IsNull(actualItemCommands.GetEnumerator().Current);
        }

        [TestMethod()]
        public void AddItemTest()
        {
            var name1 = "name1";
            var price1 = "1.0";
            var menuCommand1 = "1";
            var menuItem1 = createMenuItem<SignatureSandwich>(name1, price1, menuCommand1);

            var name2 = "name2";
            var price2 = "2.0";
            var menuCommand2 = "2";
            var menuItem2 = createMenuItem<SignatureSandwich>(name2, price2, menuCommand2);

            setupMockMenuItemDictReturn(new List<IMenuItem>() { menuItem1, menuItem2 });

            viewModel.AddItem<SignatureSandwich>(menuCommand2);

            mockOrderManager.Verify(om => om.AddItemToCurrentOrder(It.Is<IMenuItem>(s => s.Name == name2)), "should add order");
        }

        [TestMethod()]
        public void AddItemTest_ShouldNotAddItemIfCommanIsInvalid()
        {
            var name1 = "name1";
            var price1 = "1.0";
            var menuCommand1 = "1";
            var menuItem1 = createMenuItem<SignatureSandwich>(name1, price1, menuCommand1);

            var name2 = "name2";
            var price2 = "2.0";
            var menuCommand2 = "2";
            var menuItem2 = createMenuItem<SignatureSandwich>(name2, price2, menuCommand2);

            setupMockMenuItemDictReturn(new List<IMenuItem>() { menuItem1, menuItem2 });

            viewModel.AddItem<SignatureSandwich>("invalid command");

            mockOrderManager.Verify(om => om.AddItemToCurrentOrder(It.IsAny<IMenuItem>()), Times.Never, "should not add order");
        }

        [TestMethod()]
        public void GetOrdersCountTest()
        {
            viewModel.GetOrdersCount();

            mockOrderManager.VerifyGet(om => om.Count, "should get orders count");
        }

        [TestMethod()]
        public void GetOrdersTest()
        {
            viewModel.GetOrders();

            mockOrderManager.VerifyGet(om => om.Orders, "should get all orders");
        }

        [TestMethod()]
        public void GetCurrentOrderTest()
        {
            viewModel.GetCurrentOrder();

            mockOrderManager.VerifyGet(om => om.CurrentOrder, "should get current order");
        }

        [TestMethod()]
        public void GetOrdersPriceTest()
        {
            viewModel.GetOrdersPrice();

            mockOrderManager.VerifyGet(om => om.OrdersPrice, "should get all orders price");
        }

        [TestMethod()]
        public void GetCurrentOrderPriceTest()
        {
            viewModel.GetCurrentOrderPrice();

            mockOrderManager.VerifyGet(om => om.CurrentOrderPrice, "should get current order price");
        }

        [TestMethod()]
        public void AddCurrentOrderToOrdersTest()
        {
            viewModel.AddCurrentOrderToOrders();

            mockOrderManager.Verify(om => om.AddCurrentOrderToOrders(), Times.Once, "should add current order to orders");
        }

        [TestMethod()]
        public void ResetCurrentOrderTest()
        {
            viewModel.ResetCurrentOrder();

            mockOrderManager.Verify(om => om.ResetCurrentOrder(), Times.Once, "should reset current order");
        }

        [TestMethod()]
        public void ResetOrdersTest()
        {
            viewModel.ResetOrders();

            mockOrderManager.Verify(om => om.ResetOrders(), Times.Once, "should reset all orders");
        }

        [TestMethod()]
        public void FinishOrders()
        {
            viewModel.FinishOrders();

            mockOrderManager.Verify(om => om.FinishOrders(), Times.Once, "should finish orders");
        }

        private void setupMocks()
        {
            mockMenuItemsFactory = new Mock<IMenuItemsFactory>();
            mockOrderManager = new Mock<IOrderManager>();
        }

        private IMenuItem createMenuItem<T>(string name, string price, string menuCommand) where T : class, IItem
        {
            var item = itemFactory.CreateItem<T>(new string[] { name, price });
            return menuItemsFactory.CreateMenuItem(item, menuCommand);
        }

        private string createMenuItemCommandString(IMenuItem menuItem)
        {
            return string.Format(MENU_COMMAND_FORMAT, menuItem.MenuCommand, menuItem.Name, menuItem.Price);
        }

        private void setupMockMenuItemDictReturn(List<IMenuItem> returnList)
        {
            var menuItemsDict = new Dictionary<Type, List<IMenuItem>>();
            menuItemsDict.Add(typeof(SignatureSandwich), returnList);

            mockMenuItemsFactory.Setup(f => f.GetMenuItems()).Returns(menuItemsDict);

            viewModel = new ViewModel(mockMenuItemsFactory.Object, mockOrderManager.Object);
        }
    }
}