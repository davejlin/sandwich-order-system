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
            console.Output(" Commands:\n\n");
            console.OutputLine(commands, false);

            return console.ReadInput(" Enter a Command: ", true);
        }

        protected void returnToMain()
        {
            context.State = context.MainState;
        }
    }
}
