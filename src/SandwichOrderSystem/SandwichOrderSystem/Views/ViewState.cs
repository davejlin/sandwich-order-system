using SandwichOrderSystem.Services;
using SandwichOrderSystem.ViewControllers;
using System.Collections.Generic;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views
{
    public class ViewState : IViewState
    {
        private IConsoleWrapper console;

        public ViewState(IConsoleWrapper console)
        {
            this.console = console;
        }

        public string GetMenuCommand(string menuTitle, IEnumerable<string> menuCommands, IEnumerable<string> output)
        {
            console.ClearOutput();
            console.OutputLine(menuTitle, true);
            console.OutputBlankLine();

            if (output != null)
            {
                foreach (var line in output)
                {
                    console.OutputLine(line);
                }
            }

            console.OutputLine(COMMANDS_TITLE, true);
            console.OutputBlankLine();

            foreach (var command in menuCommands)
            {
                console.OutputLine(command, false);
            }

            return console.ReadInput(ENTER_COMMAND_TITLE, true);
        }

        public void PromptInvalidCommand()
        {
            console.ClearOutput();
            console.OutputLine(CONSOLE_INVALID_COMMAND, true);
            PromptToContinue();
        }

        public void PromptToContinue()
        {
            console.OutputBlankLine();
            console.ReadInput(CONSOLE_PROMPT_TO_CONTINUE, false);
        }
    }
}
