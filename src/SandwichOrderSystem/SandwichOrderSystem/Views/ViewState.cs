using SandwichOrderSystem.ViewControllers;
using System;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views
{
    public class ViewState : IViewState
    {
        private string currentCommand = "";

        private IConsoleWrapper console;
        private IViewController viewController;
        private IViewContext context;

        public ViewState(IViewController viewController, IConsoleWrapper console)
        {
            this.console = console;
            this.viewController = viewController;
        }

        public void Action()
        {
            Action segueAction = viewController.GetSegueAction(currentCommand);
            if (segueAction != null)
            {
                segueAction();
            }
            else
            {
                PromptInvalidCommand();
            }
        }

        public string MenuCommands()
        {
            currentCommand = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);
            return currentCommand;
        }

        public void SetContext(IViewContext context)
        {
            this.context = context;
            viewController.SetContext(context);
        }

        private string menuPrompt(string title, IEnumerable<string> menuCommands)
        {
            console.ClearOutput();
            console.OutputLine(title, true);
            console.OutputLine(COMMANDS_TITLE, true);
            console.OutputBlankLine();

            foreach (var command in menuCommands)
            {
                console.OutputLine(command, false);
            }

            return console.ReadInput(ENTER_COMMAND_TITLE, true);
        }

        private void returnToMain()
        {
            context.ViewNumber = ViewStateNumber.Main;
        }

        public void PromptToContinue()
        {
            console.OutputBlankLine();
            console.ReadInput(CONSOLE_PROMPT_TO_CONTINUE, false);
        }

        public void PromptInvalidCommand()
        {
            console.ClearOutput();
            console.OutputLine(CONSOLE_INVALID_COMMAND, true);
            PromptToContinue();
        }
    }
}
