using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.Views.ViewStates
{
    public abstract class ViewState : IViewState
    {
        protected IConsoleWrapper console;
        protected IViewContext context;

        public ViewState(IConsoleWrapper console)
        {
            this.console = console;
        }

        public abstract string MenuCommands();

        public void SetContext(IViewContext context)
        {
            this.context = context;
        }

        protected string menuPrompt(string title, string commands)
        {
            console.ClearOutput();
            console.OutputLine(title, true);
            console.OutputBlankLine();
            console.Output(Constants.VIEW_STATE_COMMANDS_TITLE);
            console.OutputLine(commands, false);

            return console.ReadInput(Constants.VIEW_STATE_ENTER_COMMAND_TITLE, true);
        }

        protected void returnToMain()
        {
            context.State = context.MainState;
        }
    }
}
