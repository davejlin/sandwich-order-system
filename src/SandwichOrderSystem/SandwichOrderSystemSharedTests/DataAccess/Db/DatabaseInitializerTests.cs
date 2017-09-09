using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;

namespace SandwichOrderSystemShared.DataAccess.Db.Tests
{
    [TestClass()]
    public class DatabaseInitializerTests
    {
        DatabaseInitializer databaseInitializer;
        Mock<IDataInitializer> mockDataInitializer;
        Mock<IDatabaseInitializerFactory> mockDataInitializerFactory;
        Mock<Context> mockContext;

        [TestInitialize()]
        public void Setup()
        {
            mockDataInitializerFactory = new Mock<IDatabaseInitializerFactory>();
            mockContext = new Mock<Context>(mockDataInitializerFactory.Object);
            mockDataInitializer = new Mock<IDataInitializer>();
            databaseInitializer = new DatabaseInitializer(mockDataInitializer.Object);
        }

        [TestMethod()]
        public void DatabaseInitializerTest()
        {
            // TODO:
            Assert.IsTrue(true);
        }
    }
}