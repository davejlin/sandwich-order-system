using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Db;
using SandwichOrderSystemShared.Models;
using SandwichOrderSystemShared.Services;
using System.Collections.Generic;

namespace SandwichOrderSystemShared.DataAccess.Deserializer.Tests
{
    [TestClass()]
    public class DataInitializerTests
    {
        IDataInitializer dataInitializer;
        Mock<IFileSystemManager> mockFileSystemManager;
        Mock<IDataParser> mockDataParser;
        Mock<IItemFactory> mockItemFactory;
        Mock<Context> mockContext;
        Mock<IErrorHandler> mockErrorHandler;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            dataInitializer = new DataInitializer(mockFileSystemManager.Object, mockDataParser.Object, mockItemFactory.Object, mockErrorHandler.Object);
        }

        [TestMethod()]
        public void InitDataTest()
        {
            mockFileSystemManager.Setup(fs => fs.GetItemNames())
                .Returns(new string[] {
                    "SignatureSandwich",
                    "Bread",
                    "Filling",
                    "Cheese",
                    "Vegetable",
                    "Condiment",
                    "Drink",
                    "Chips"
            });

            mockFileSystemManager.Setup(fs => fs.GetContents(It.IsAny<string>())).Returns(It.IsAny<string>);

            mockDataParser.Setup(p => p.ParseData(It.IsAny<string>()))
                .Returns(new List<string[]>() {
                    new string[] { "name1", "price1" }
                });

            dataInitializer.InitData(mockContext.Object);

            mockContext.Verify(c => c.SaveChanges(), Times.Exactly(8), "should save changes to context");
        }

        [TestMethod()]
        public void InitDataTest_SeedTypesDoNotMatchDbSetTypesWillNotBeSaved()
        {
            mockFileSystemManager.Setup(fs => fs.GetItemNames())
                .Returns(new string[] {
                    "Bad type",
                    "???",
                    "Filling", // valid type
                    "Mistype",
                    "Non existant type",
                    "Erroneous type",
                    "Mystery type",
                    "Condiment", // valid type
                    "Invalid type"
            });

            mockFileSystemManager.Setup(fs => fs.GetContents(It.IsAny<string>())).Returns(It.IsAny<string>);

            mockDataParser.Setup(p => p.ParseData(It.IsAny<string>()))
                .Returns(new List<string[]>() {
                    new string[] { "name1", "price1" }
                });

            dataInitializer.InitData(mockContext.Object);

            mockContext.Verify(c => c.SaveChanges(), Times.Exactly(2), "should save changes to context");
        }

        private void setupMocks()
        {
            mockFileSystemManager = new Mock<IFileSystemManager>();
            mockDataParser = new Mock<IDataParser>();
            mockItemFactory = new Mock<IItemFactory>();
            mockErrorHandler = new Mock<IErrorHandler>();

            mockContext = new Mock<Context>();

            mockItemFactory.Setup(f => f.CreateItem<SignatureSandwich>(It.IsAny<string[]>())).Returns(new SignatureSandwich());
            mockItemFactory.Setup(f => f.CreateItem<Bread>(It.IsAny<string[]>())).Returns(new Bread());
            mockItemFactory.Setup(f => f.CreateItem<Filling>(It.IsAny<string[]>())).Returns(new Filling());
            mockItemFactory.Setup(f => f.CreateItem<Cheese>(It.IsAny<string[]>())).Returns(new Cheese());
            mockItemFactory.Setup(f => f.CreateItem<Vegetable>(It.IsAny<string[]>())).Returns(new Vegetable());
            mockItemFactory.Setup(f => f.CreateItem<Condiment>(It.IsAny<string[]>())).Returns(new Condiment());
            mockItemFactory.Setup(f => f.CreateItem<Drink>(It.IsAny<string[]>())).Returns(new Drink());
            mockItemFactory.Setup(f => f.CreateItem<Chips>(It.IsAny<string[]>())).Returns(new Chips());
        }
    }
}