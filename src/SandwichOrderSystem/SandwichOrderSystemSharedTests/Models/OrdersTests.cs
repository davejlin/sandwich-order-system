using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichOrderSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderSystemShared.Models.Tests
{
    [TestClass()]
    public class OrdersTests
    {
        IOrders orders;

        [TestInitialize()]
        public void Setup()
        {
            orders = new Orders();
            assertOrdersIsEmpty();
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            var order = new Order();
            orders.Add(order);

            Assert.AreEqual(1, orders.OrderCollection.Count, "should have an order");
        }

        [TestMethod()]
        public void ResetOrdersTest()
        {
            var order = new Order();
            orders.Add(order);

            Assert.AreEqual(1, orders.OrderCollection.Count, "should have an order");

            orders.Reset();

            assertOrdersIsEmpty();
        }

        private void assertOrdersIsEmpty()
        {
            Assert.AreEqual(0, orders.OrderCollection.Count, "should be empty");
        }
    }
}