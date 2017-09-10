using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;
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

        Mock<IFileSystemManager> mockFileSystemManager;
        Mock<IDataParser> mockDataParser;
        Mock<IItemFactory> mockItemFactory;
        Mock<DataInitializer> mockDataInitializer;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            databaseInstallerFactory = new DatabaseInitializerFactory(mockContainer.Object);
        }

        [TestMethod()]
        public void createDatabaseInitializerTest()
        {
            var databaseInitializer = databaseInstallerFactory.createDatabaseInitializer();
            Assert.AreEqual(mockDatabaseInitializer.Object, databaseInitializer, "should create database initializer");
        }

        private void setupMocks()
        {
            mockFileSystemManager = new Mock<IFileSystemManager>();
            mockDataParser = new Mock<IDataParser>();
            mockItemFactory = new Mock<IItemFactory>();

            mockDataInitializer = new Mock<DataInitializer>(mockFileSystemManager.Object, mockDataParser.Object, mockItemFactory.Object);
            mockDatabaseInitializer = new Mock<DatabaseInitializer>(mockDataInitializer.Object);

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