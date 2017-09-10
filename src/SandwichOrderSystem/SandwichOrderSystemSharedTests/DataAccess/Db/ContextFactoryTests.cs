using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DI;
using System;

namespace SandwichOrderSystemShared.DataAccess.Db.Tests
{
    [TestClass()]
    public class ContextFactoryTests
    {
        IContextFactory contextFactory;
        Mock<IDIContainerIWrapper> mockContainer;
        Mock<IWindsorContainer> mockWindsorContainer;
        Mock<IDatabaseInitializerFactory> mockDatabaseInitializerFactory;
        Mock<Context> mockContext;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            contextFactory = new ContextFactory(mockContainer.Object);
        }

        [TestMethod()]
        public void createContextTest()
        {
            var context = contextFactory.CreateContext();
            Assert.AreEqual(mockContext.Object, context, "should create context");
        }

        private void setupMocks()
        {
            mockDatabaseInitializerFactory = new Mock<IDatabaseInitializerFactory>();
            mockContext = new Mock<Context>(mockDatabaseInitializerFactory.Object);

            mockWindsorContainer = new Mock<IWindsorContainer>();

            Func<Context> func = () =>
            {
                return mockContext.Object;
            };

            mockWindsorContainer.Setup(c => c.Resolve<Context>()).Returns(func);

            mockContainer = new Mock<IDIContainerIWrapper>();
            mockContainer.SetupGet(c => c.Container).Returns(mockWindsorContainer.Object);
        }
    }
}