using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;

namespace SandwichOrderSystemShared.DataAccess.Deserializer.Tests
{
    [TestClass()]
    public class DataInitializerTests
    {
        IDataInitializer dataInitializer;
        Mock<IFileSystemManager> mockFileSystemManager;
        Mock<IDataParser> mockDataParser;
        Mock<IItemFactory> mockItemFactory;

        [TestInitialize()]
        public void Setup()
        {
            mockFileSystemManager = new Mock<IFileSystemManager>();
            mockDataParser = new Mock<IDataParser>();
            mockItemFactory = new Mock<IItemFactory>();

            dataInitializer = new DataInitializer(mockFileSystemManager.Object, mockDataParser.Object, mockItemFactory.Object);
        }

        [TestMethod()]
        public void InitDataTest()
        {
            Assert.IsTrue(true);
        }
    }
}