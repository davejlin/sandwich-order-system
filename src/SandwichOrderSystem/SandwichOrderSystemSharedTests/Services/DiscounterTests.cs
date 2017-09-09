using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Models.Items;

namespace SandwichOrderSystemShared.Services.Tests
{
    [TestClass()]
    public class DiscounterTests
    {
        IItemFactory itemFactory = new ItemFactory();
        IDiscounter discounter;

        [TestInitialize]
        public void Setup()
        {
            discounter = new Discounter();
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_HasDrinkAndChipsReturnsDiscountItem()
        {
            var order = new Order();
            var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", "1.0" });
            var chips = itemFactory.CreateItem<Chips>(new string[] { "chips", "1.0" });

            order.Items.Add(drink);
            order.Items.Add(chips);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsTrue(discountItem.Type == typeof(DiscountItem).ToString(), "should return discount item");
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_HasDrinkButNotChipsDoesReturnsNull()
        {
            var order = new Order();
            var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", "1.0" });

            order.Items.Add(drink);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsNull(discountItem, "should return null");
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_HasChipsButNotDrinkDoesReturnsNull()
        {
            var order = new Order();
            var chips = itemFactory.CreateItem<Chips>(new string[] { "chips", "1.0" });

            order.Items.Add(chips);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsNull(discountItem, "should return null");
        }
    }
}