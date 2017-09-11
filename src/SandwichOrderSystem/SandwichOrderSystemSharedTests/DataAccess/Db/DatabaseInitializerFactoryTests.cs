using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DI;
using System;

namespace SandwichOrderSystemShared.DataAccess.Db.Tests
{
    [TestClass()]
    public class DatabaseInitializerFactoryTests
    {
        IDatabaseInitializerFactory databaseInstallerFactory;
        Mock<IDIContainerIWrapper> mockContainer;
        Mock<IWindsorContainer> mockWindsorContainer;
        Mock<DatabaseInitializer> mockDatabaseInitializer;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            databaseInstallerFactory = new DatabaseInitializerFactory(mockContainer.Object);
        }

        [TestMethod()]
        public void CreateDatabaseInitializerTest()
        {
            var databaseInitializer = databaseInstallerFactory.CreateDatabaseInitializer();
            Assert.AreEqual(mockDatabaseInitializer.Object, databaseInitializer, "should create database initializer");
        }

        private void setupMocks()
        {
            mockDatabaseInitializer = new Mock<DatabaseInitializer>();

            mockWindsorContainer = new Mock<IWindsorContainer>();

            Func<DatabaseInitializer> func = () =>
            {
                return mockDatabaseInitializer.Object;
            };

            mockWindsorContainer.Setup(c => c.Resolve<DatabaseInitializer>()).Returns(func);

            mockContainer = new Mock<IDIContainerIWrapper>();
            mockContainer.SetupGet(c => c.Container).Returns(mockWindsorContainer.Object);
        }
    }
}