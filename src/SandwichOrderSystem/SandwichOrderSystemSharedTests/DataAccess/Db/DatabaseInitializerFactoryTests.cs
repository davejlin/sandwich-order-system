using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db.Tests
{
    [TestClass()]
    public class DatabaseInitializerFactoryTests
    {
        IDatabaseInitializerFactory databaseInstallerFactory;
        Mock<DISharedInstaller> mockDIInstaller;

        [TestInitialize()]
        public void Setup()
        {
            databaseInstallerFactory = new DatabaseInitializerFactory();
            mockDIInstaller = new Mock<DISharedInstaller>();
        }

        [TestMethod()]
        public void createDatabaseInitializerTest()
        {
            // TODO:
            //var databaseInitializer = databaseInstallerFactory.createDatabaseInitializer();
            Assert.IsTrue(true);
        }
    }
}