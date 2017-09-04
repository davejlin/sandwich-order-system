using SandwichOrderSystem.Views;

namespace SandwichOrderSystem.States.Level1States
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
        public abstract void MenuCommands();
        public abstract void ReturnToMain();

        public void SetContext(ILevel1Context context)
        {
            this.context = context;
        }
    }
}
