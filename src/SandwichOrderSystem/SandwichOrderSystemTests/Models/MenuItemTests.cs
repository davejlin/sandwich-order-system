using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System;

namespace SandwichOrderSystem.Models.Tests
{
    [TestClass()]
    public class MenuItemTests
    {
        IItemFactory itemFactory;

        [TestInitialize()]
        public void Setup()
        {
            itemFactory = new ItemFactory();
        }

        [TestMethod()]
        public void MenuItemTest()
        {
            var name = "sandwich";
            var price = "1.0";
            var menuCommand = "m";

            var item = itemFactory.CreateItem<SignatureSandwich>(new string[] { name, price });
            var menuItem = new MenuItem(item, menuCommand);

            Assert.AreEqual(name, menuItem.Name);
            Assert.AreEqual(Convert.ToDecimal(price), menuItem.Price);
            Assert.AreEqual(menuCommand, menuItem.MenuCommand);
        }
    }
}