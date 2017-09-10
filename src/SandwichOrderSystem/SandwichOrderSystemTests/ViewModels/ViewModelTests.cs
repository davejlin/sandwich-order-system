using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystem.Services;
using SandwichOrderSystemShared.Services;

namespace SandwichOrderSystem.ViewModels.Tests
{
    [TestClass()]
    public class ViewModelTests
    {
        Mock<IMenuItemsFactory> mockMenuItemsFactory;
        Mock<IOrderManager> mockOrderManager;
        IViewModel viewModel;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();

            viewModel = new ViewModel(mockMenuItemsFactory.Object, mockOrderManager.Object);
        }

        [TestMethod()]
        public void GetItemCommandMenuTest()
        {

        }

        [TestMethod()]
        public void GetItemCommandsTest()
        {

        }

        [TestMethod()]
        public void GetOrdersCountTest()
        {

        }

        [TestMethod()]
        public void GetOrdersTest()
        {

        }

        [TestMethod()]
        public void GetCurrentOrderTest()
        {

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
        public void AddItemTest()
        {

        }

        [TestMethod()]
        public void AddOrderTest()
        {
            viewModel.AddOrder();

            mockOrderManager.Verify(om => om.AddCurrentOrderToOrders(), Times.Once, "should add order to orders");
        }

        [TestMethod()]
        public void ResetOrderTest()
        {
            viewModel.ResetOrder();

            mockOrderManager.Verify(om => om.ResetCurrentOrder(), Times.Once, "should reset order");
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

            mockOrderManager.Verify(om => om.FinishOrders(), Times.Once, "should finish order");
        }

        private void setupMocks()
        {
            mockMenuItemsFactory = new Mock<IMenuItemsFactory>();
            mockOrderManager = new Mock<IOrderManager>();
        }
    }
}