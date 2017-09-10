using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystem.ViewControllers;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Tests
{
    [TestClass()]
    public class SandwichOrderSystemTests
    {
        Mock<IViewController> mockViewController;
        ISandwichOrderSystem sos;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            sos = new SandwichOrderSystem(mockViewController.Object);
        }

        [TestMethod()]
        public void StartTest()
        {
            sos.Start();

            mockViewController.Verify(vc => vc.AdvanceViewCycle(), Times.Once);
        }

        private void setupMocks()
        {
            mockViewController = new Mock<IViewController>();
            mockViewController.Setup(vc => vc.AdvanceViewCycle()).Returns(QUIT_COMMAND);
        }
    }
}