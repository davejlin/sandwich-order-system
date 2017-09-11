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
            string actualMenuTitle = EMPTY_STRING;
            IEnumerable<string> actualMenuCommands = new List<string>();
            IEnumerable<string> actualOutput = new List<string>();

            mockViewState.Setup(vs => vs.GetMenuCommand(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns(ADD_COMMAND)
                .Callback<string, IEnumerable<string>, IEnumerable<string>>((t, c, o) =>
                {
                    actualMenuTitle = t;
                    actualMenuCommands = c;
                    actualOutput = o;
                });

            var actualCommand = viewController.AdvanceViewCycle();

            Assert.IsTrue(actualMenuTitle.Contains(MAIN_TITLE), "should have main title");

            bool hasAddCommand = false;
            bool hasQuitCommand = false;

            foreach (var line in actualMenuCommands)
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
            Assert.IsNull(actualOutput.GetEnumerator().Current, "should be empty");
            Assert.AreEqual(ADD_COMMAND, actualCommand, "should return command");
        }

        [TestMethod()]
        public void AdvanceViewCycleTest_NullCommandDoesNotCrashSystem()
        {
            mockViewState.Setup(vs => vs.GetMenuCommand(It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>()))
                .Returns((string)null);

            var actualCommand = viewController.AdvanceViewCycle();

            Assert.IsNull(actualCommand);
        }

        private void setupMocks()
        {
            mockViewState = new Mock<IViewState>();
            mockViewModel = new Mock<IViewModel>();
        }
    }
}