using SandwichOrderSystem.Services;
using SandwichOrderSystem.ViewControllers;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views
{
    public class ViewState : IViewState
    {
        private IViewController viewController;
        private IConsoleWrapper console;
        private string currentCommand = "";

        public ViewState(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void SetViewController(IViewController viewController)
        {
            this.viewController = viewController;
        }

        public void Action()
        {
            var segueAction = viewController.GetSegueAction();
            if (segueAction != null)
            {
                segueAction();
            }
            else
            {
                promptInvalidCommand();
            }
        }

        public string GetMenuCommand(string menuTitle, IEnumerable<string> menuCommands)
        {
            console.ClearOutput();
            console.OutputLine(menuTitle, true);
            console.OutputLine(COMMANDS_TITLE, true);
            console.OutputBlankLine();

            foreach (var command in menuCommands)
            {
                console.OutputLine(command, false);
            }

            return console.ReadInput(ENTER_COMMAND_TITLE, true);
        }

        private void promptToContinue()
        {
            console.OutputBlankLine();
            console.ReadInput(CONSOLE_PROMPT_TO_CONTINUE, false);
        }

        public void promptInvalidCommand()
        {
            console.ClearOutput();
            console.OutputLine(CONSOLE_INVALID_COMMAND, true);
            promptToContinue();
        }
    }
}
