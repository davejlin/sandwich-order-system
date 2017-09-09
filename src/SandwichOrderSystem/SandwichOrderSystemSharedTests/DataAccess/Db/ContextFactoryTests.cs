using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db.Tests
{
    [TestClass()]
    public class ContextFactoryTests
    {
        IContextFactory contextFactory;
        Mock<DISharedInstaller> mockDIInstaller;

        [TestInitialize()]
        public void Setup()
        {
            contextFactory = new ContextFactory();
            mockDIInstaller = new Mock<DISharedInstaller>();
        }

        [TestMethod()]
        public void createContextTest()
        {
            //TODO:
            //var context = contextFactory.createContext();
            Assert.IsTrue(true);
        }
    }
}