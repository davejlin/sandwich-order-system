using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Db;
using SandwichOrderSystemShared.DI;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;

namespace SandwichOrderSystemShared.DataAccess.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        IRepository repository;
        Mock<ContextFactory> mockContextFactory;
        Mock<IErrorHandler> mockErrorHandler;
        Mock<IDIContainerIWrapper> mockContainer;
        Mock<IDatabaseInitializerFactory> mockDatabaseInitializerFactory;
        Mock<Context> mockContext;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            repository = new Repository(mockContextFactory.Object, mockErrorHandler.Object);
        }

        [TestMethod()]
        public void GetItemTest()
        {
            // TODO: need to figure out how to setup reflection returns
            var item = repository.GetItem<SignatureSandwich>();
            Assert.IsNull(item);
        }

        private void setupMocks()
        {
            mockErrorHandler = new Mock<IErrorHandler>();
            mockContainer = new Mock<IDIContainerIWrapper>();
            mockContextFactory = new Mock<ContextFactory>(mockContainer.Object);

            mockDatabaseInitializerFactory = new Mock<IDatabaseInitializerFactory>();
            mockContext = new Mock<Context>(mockDatabaseInitializerFactory.Object);

            // this doesn't work because GetType() is not virtual.
            // mockContext.Setup(c => c.GetType()
            //  .GetProperty(It.IsAny<string>())
            //  .GetValue(It.IsAny<object>()))
            //  .Returns(mockContext.Object.SignatureSandwichSet);

            mockContextFactory.Setup(cf => cf.CreateContext()).Returns(mockContext.Object);
        }
    }
}