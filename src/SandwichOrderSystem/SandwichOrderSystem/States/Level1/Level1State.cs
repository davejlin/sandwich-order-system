using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1
{
    public abstract class Level1State : ILevel1State
    {
        protected IConsoleWrapper console;
        protected ILevel1Context context;

        public Level1State(IConsoleWrapper console)
        {
            this.console = console;
        }

        public abstract void Action();
        public abstract string MenuCommands();

        public void SetContext(ILevel1Context context)
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
