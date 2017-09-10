using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystem.ViewModels;
using SandwichOrderSystem.Views;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.ViewControllers.Tests
{
    [TestClass()]
    public class ViewControllerTests
    {
        IViewController viewController;
        Mock<IViewState> mockViewState;
        Mock<IViewModel> mockViewModel;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            viewController = new ViewController(mockViewState.Object, mockViewModel.Object);
        }

        [TestMethod()]
        public void AdvanceViewCycleTest()
        {
            string menuTitle = EMPTY_STRING;
            IEnumerable<string> menuCommands = new List<string>();
            IEnumerable<string> output = new List<string>();

            mockViewState.Setup(vs => vs.GetMenuCommand(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(ADD_COMMAND)
                .Callback<string, IEnumerable<string>, IEnumerable<string>>((t, c, o) =>
                {
                    menuTitle = t;
                    menuCommands = c;
                    output = o;
                });

            var actualCommand = viewController.AdvanceViewCycle();

            Assert.IsTrue(menuTitle.Contains(MAIN_TITLE), "should have main title");

            bool hasAddCommand = false;
            bool hasQuitCommand = false;

            foreach (var line in menuCommands)
            {
                if (line.Contains(ADD_COMMAND))
                {
                    hasAddCommand = true;
                }

                if (line.Contains(QUIT_COMMAND))
                {
                    hasQuitCommand = true;
                }
            }

            Assert.IsTrue(hasAddCommand, "should have add command");
            Assert.IsTrue(hasQuitCommand, "should have quit command");

            var i = 0;
            foreach (var line in output)
            {
                Assert.Fail("should not have output");
            }

            Assert.AreEqual(0, i, "should not have output");

            Assert.AreEqual(ADD_COMMAND, actualCommand, "should return command");
        }

        private void setupMocks()
        {
            mockViewState = new Mock<IViewState>();
            mockViewModel = new Mock<IViewModel>();
        }
    }
}