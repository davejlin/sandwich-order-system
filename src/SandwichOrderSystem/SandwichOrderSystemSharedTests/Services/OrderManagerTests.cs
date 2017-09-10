using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Models.Items;
using System;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.Services.Tests
{
    [TestClass()]
    public class OrderManagerTests
    {
        IOrderManager orderManager;
        Mock<IDiscounter> mockDiscounter;
        IItemFactory itemFactory;

        [TestInitialize()]
        public void Setup()
        {
            mockDiscounter = new Mock<IDiscounter>();
            orderManager = new OrderManager(mockDiscounter.Object);

            itemFactory = new ItemFactory();

            assertOrdersAndCurrentOrdersAreEmpty();
        }

        [TestMethod()]
        public void OrderManagerTest_PropertiesInitialized()
        {
            Assert.AreEqual(0, orderManager.Orders.Count, "should have no orders");
            Assert.AreEqual(orderManager.Orders.Count, orderManager.Count, "should have the same count");
            Assert.AreEqual(0, orderManager.CurrentOrder.Count, "should have no items in current order");
        }

        [TestMethod()]
        public void AddItemToCurrentOrderTest()
        {
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            orderManager.AddItemToCurrentOrder(sandwich);

            Assert.AreEqual(1, orderManager.CurrentOrder.Count, "should have added an item");
            Assert.IsTrue(orderManager.CurrentOrder.Items.Contains(sandwich));

            var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", "1.0" });
            orderManager.AddItemToCurrentOrder(drink);

            Assert.AreEqual(2, orderManager.CurrentOrder.Count, "should have added another item");
            Assert.IsTrue(orderManager.CurrentOrder.Items.Contains(drink));
        }

        [TestMethod()]
        public void AddCurrentOrderToOrdersTest()
        {
            var expectedName = "sandwich";
            var expectedPrice = "1.0";
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { expectedName, expectedPrice });
            orderManager.AddItemToCurrentOrder(sandwich);

            Assert.AreEqual(1, orderManager.CurrentOrder.Count, "should have an item in current order");

            orderManager.AddCurrentOrderToOrders();

            Assert.AreEqual(1, orderManager.Count, "should have added an order");
            Assert.IsTrue(orderManager.Orders.ToString().Contains(expectedName), "should have added item name");
            Assert.IsTrue(orderManager.Orders.ToString().Contains(expectedPrice), "should have added item price");
            Assert.AreEqual(0, orderManager.CurrentOrder.Count, "shoud have no items in current order after adding to orders");
        }

        [TestMethod()]
        public void AddCurrentOrderToOrdersTest_ShouldNotAddIfNoItemsInCurrentOrder()
        {
            orderManager.AddCurrentOrderToOrders();
            assertOrdersAndCurrentOrdersAreEmpty();
        }


        [TestMethod()]
        public void ResetCurrentOrderTest()
        {
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            orderManager.AddItemToCurrentOrder(sandwich);

            Assert.AreEqual(1, orderManager.CurrentOrder.Count, "should have an item in current order");

            orderManager.ResetCurrentOrder();

            assertOrdersAndCurrentOrdersAreEmpty();
        }

        [TestMethod()]
        public void ResetOrdersTest()
        {
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            orderManager.AddItemToCurrentOrder(sandwich);

            Assert.AreEqual(1, orderManager.CurrentOrder.Count, "should have an item in current order");

            orderManager.AddCurrentOrderToOrders();

            Assert.AreEqual(1, orderManager.Count, "should have added an order");

            orderManager.ResetOrders();

            assertOrdersAndCurrentOrdersAreEmpty();
        }

        [TestMethod()]
        public void FinishOrdersTest()
        {
            // TODO: add test when finish sequence is further developed
            // currently just tests that orders are reset upon calling FinishOrders()

            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            orderManager.AddItemToCurrentOrder(sandwich);

            Assert.AreEqual(1, orderManager.CurrentOrder.Count, "should have an item in current order");

            orderManager.AddCurrentOrderToOrders();

            Assert.AreEqual(1, orderManager.Count, "should have added an order");

            orderManager.FinishOrders();

            assertOrdersAndCurrentOrdersAreEmpty();
        }

        [TestMethod()]
        public void DiscountItemAddedToCurentOrdersTest()
        {
            mockDiscounter.Setup(d => d.GetDiscountItemConditionally(It.IsAny<IOrder>())).Returns(new DiscountItem());

            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            orderManager.AddItemToCurrentOrder(sandwich);

            Assert.AreEqual(2, orderManager.CurrentOrder.Count, "should have added both an item and a discount item in current order");
            Assert.IsTrue(orderManager.CurrentOrder.ToString().Contains(DISCOUNT_ITEM_NAME));
        }

        [TestMethod()]
        public void CurrentOrderPriceTest()
        {
            var priceSandwich = 2.50;
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", priceSandwich.ToString() });
            orderManager.AddItemToCurrentOrder(sandwich);

            var priceDrink = 1.75;
            var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", priceDrink.ToString() });
            orderManager.AddItemToCurrentOrder(drink);

            var priceChips = 1.50;
            var chips = itemFactory.CreateItem<Chips>(new string[] { "chips", priceChips.ToString() });
            orderManager.AddItemToCurrentOrder(chips);

            var expectedPriceTotal = Convert.ToDecimal(priceSandwich + priceDrink + priceChips);

            Assert.AreEqual(expectedPriceTotal, orderManager.CurrentOrderPrice);
        }

        [TestMethod()]
        public void OrdersPriceTest()
        {
            var priceSandwich = 2.50;
            var priceDrink = 1.75;
            var priceChips = 1.50;

            var nOrders = 3;

            for (var i = 0; i < nOrders; i++)
            {
                var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", priceSandwich.ToString() });
                orderManager.AddItemToCurrentOrder(sandwich);

                var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", priceDrink.ToString() });
                orderManager.AddItemToCurrentOrder(drink);

                var chips = itemFactory.CreateItem<Chips>(new string[] { "chips", priceChips.ToString() });
                orderManager.AddItemToCurrentOrder(chips);

                orderManager.AddCurrentOrderToOrders();
            }

            var expectedPriceTotal = Convert.ToDecimal(nOrders * (priceSandwich + priceDrink + priceChips));

            Assert.AreEqual(expectedPriceTotal, orderManager.OrdersPrice);
        }

        private void assertOrdersAndCurrentOrdersAreEmpty()
        {
            Assert.AreEqual(0, orderManager.Count, "should have no orders");
            Assert.AreEqual(0, orderManager.CurrentOrder.Count, "shoud have no items in current order");
        }
    }
}