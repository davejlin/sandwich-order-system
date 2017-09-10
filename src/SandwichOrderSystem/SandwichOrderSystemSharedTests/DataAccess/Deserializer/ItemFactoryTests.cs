using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer.Tests
{
    [TestClass()]
    public class ItemFactoryTests
    {
        Mock<IErrorHandler> mockErrorHandler;
        IItemFactory itemFactory;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            itemFactory = new ItemFactory(mockErrorHandler.Object);
        }

        [TestMethod()]
        public void CreateItemTest()
        {
            var name = "my sandwich";
            var price = "1.00";

            var properties = new string[] { name, price };
            var actualItem = itemFactory.CreateItem<SignatureSandwich>(properties);

            Assert.AreEqual(name, actualItem.Name);
            Assert.AreEqual(Convert.ToDecimal(price), actualItem.Price);
            Assert.AreEqual("SignatureSandwich", actualItem.Type);
        }

        [TestMethod()]
        public void CreateItemTest_PriceIsNotNumberFormat()
        {
            var name = "my sandwich";
            var price = "not number";

            var properties = new string[] { name, price };
            var actualItem = itemFactory.CreateItem<SignatureSandwich>(properties);

            Assert.AreEqual(name, actualItem.Name);
            Assert.AreEqual(0, actualItem.Price);
            Assert.AreEqual("SignatureSandwich", actualItem.Type);

            mockErrorHandler.Verify(er => er.HandleError(It.IsAny<string>()), Times.Once, "should call error handler");
        }

        private void setupMocks()
        {
            mockErrorHandler = new Mock<IErrorHandler>();
        }
    }
}