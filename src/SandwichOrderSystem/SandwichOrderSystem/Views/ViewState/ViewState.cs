using SandwichOrderSystem.ViewControllers;
using static SandwichOrderSystem.Constants;

namespace SandwichOrderSystem.Views.ViewState
{
    public class ViewState : IViewState
    {
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

        }
        public string MenuCommands()
        {
            string command = menuPrompt(viewController.MenuTitle, viewController.MenuCommands);

            if (!viewController.ExecuteUserCommand(command))
            {
                PromptInvalidCommand();
            }

            return command;
        }

        public void SetContext(IViewContext context)
        {
            this.context = context;
            viewController.SetContext(context);
        }

        private string menuPrompt(string title, string commands)
        {
            console.ClearOutput();
            console.OutputLine(title, true);
            console.OutputBlankLine();
            console.Output(VIEW_STATE_COMMANDS_TITLE);
            console.OutputLine(commands, false);

            return console.ReadInput(VIEW_STATE_ENTER_COMMAND_TITLE, true);
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
