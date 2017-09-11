using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Models.Items;

namespace SandwichOrderSystemShared.Services.Tests
{
    [TestClass()]
    public class DiscounterTests
    {
        IDiscounter discounter;
        IItemFactory itemFactory;

        [TestInitialize]
        public void Setup()
        {
            discounter = new Discounter();
            itemFactory = new ItemFactory();
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_HasDrinkAndChipsReturnsDiscountItem()
        {
            var order = new Order();
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", "1.0" });
            var chips = itemFactory.CreateItem<Chips>(new string[] { "chips", "1.0" });

            order.Items.Add(sandwich);
            order.Items.Add(drink);
            order.Items.Add(chips);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsTrue(discountItem.Type == typeof(DiscountItem).Name, "should return discount item");
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_HasDrinkButNotChipsReturnsNull()
        {
            var order = new Order();
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            var drink = itemFactory.CreateItem<Drink>(new string[] { "drink", "1.0" });

            order.Items.Add(sandwich);
            order.Items.Add(drink);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsNull(discountItem, "should return null");
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_HasChipsButNotDrinkReturnsNull()
        {
            var order = new Order();
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });
            var chips = itemFactory.CreateItem<Chips>(new string[] { "chips", "1.0" });

            order.Items.Add(sandwich);
            order.Items.Add(chips);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsNull(discountItem, "should return null");
        }

        [TestMethod()]
        public void GetDiscountItemConditionallyTest_NeitherDrinkNorChipsReturnsNull()
        {
            var order = new Order();
            var sandwich = itemFactory.CreateItem<SignatureSandwich>(new string[] { "sandwich", "1.0" });

            order.Items.Add(sandwich);

            var discountItem = discounter.GetDiscountItemConditionally(order);

            Assert.IsNull(discountItem, "should return null");
        }
    }
}