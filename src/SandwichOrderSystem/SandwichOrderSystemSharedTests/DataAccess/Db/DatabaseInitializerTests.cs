using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DataAccess.Deserializer;

namespace SandwichOrderSystemShared.DataAccess.Db.Tests
{
    [TestClass()]
    public class DatabaseInitializerTests
    {
        DatabaseInitializerForTest databaseInitializer;
        Mock<IDataInitializer> mockDataInitializer;
        Mock<IDatabaseInitializerFactory> mockDatabaseInitializerFactory;
        Mock<Context> mockContext;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            databaseInitializer = new DatabaseInitializerForTest(mockDataInitializer.Object);
        }

        [TestMethod()]
        public void DatabaseInitializerTest()
        {
            databaseInitializer.Seed(mockContext.Object);
            mockDataInitializer.Verify(m => m.InitData(It.Is<Context>(c => c == mockContext.Object)), "should have passed context");
        }

        private class DatabaseInitializerForTest : DatabaseInitializer
        {
            public DatabaseInitializerForTest(IDataInitializer dataInitializer) : base(dataInitializer){ }

            // need this because base Seed is a protected override method
            public void Seed(Context context)
            {
                base.Seed(context);
            }
        }

        private void setupMocks()
        {
            mockDatabaseInitializerFactory = new Mock<IDatabaseInitializerFactory>();
            mockContext = new Mock<Context>(mockDatabaseInitializerFactory.Object);
            mockDataInitializer = new Mock<IDataInitializer>();
        }
    }
}