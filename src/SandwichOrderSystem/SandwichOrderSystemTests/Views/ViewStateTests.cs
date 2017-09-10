using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichOrderSystem.Services;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views.Tests
{
    [TestClass()]
    public class ViewStateTests
    {
        IViewState viewState;
        Mock<IConsoleWrapper> mockConsole;

        [TestInitialize()]
        public void Setup()
        {
            setupMocks();
            viewState = new ViewState(mockConsole.Object);
        }

        [TestMethod()]
        public void GetMenuCommandTest()
        {
            mockConsole.Setup(c => c.ReadInput(It.IsAny<string>(), It.IsAny<bool>())).Returns(ADD_COMMAND);

            var actualCommand = viewState.GetMenuCommand("", new List<string>(), new List<string>() );

            Assert.AreEqual(ADD_COMMAND, actualCommand, "should return inputted command");

            mockConsole.Verify(c => c.OutputLine(It.IsAny<string>(), It.IsAny<bool>()), Times.AtLeastOnce, "should write out to console at least once");
        }

        [TestMethod()]
        public void PromptToContinueTest()
        {
            viewState.PromptToContinue();

            mockConsole.Verify(c => c.ReadInput(It.Is<string>(s => s == CONSOLE_PROMPT_TO_CONTINUE), It.IsAny<bool>()), "should output prompt to continue message");
        }

        [TestMethod()]
        public void PromptInvalidCommandTest()
        {
            viewState.PromptInvalidCommand();

            mockConsole.Verify(c => c.OutputLine(It.Is<string>(s => s == CONSOLE_INVALID_COMMAND), It.IsAny<bool>()), "should output invalid command message");
            mockConsole.Verify(c => c.ReadInput(It.Is<string>(s => s == CONSOLE_PROMPT_TO_CONTINUE), It.IsAny<bool>()), "should output prompt to continue message");
        }

        private void setupMocks()
        {
            mockConsole = new Mock<IConsoleWrapper>();
        }
    }
}