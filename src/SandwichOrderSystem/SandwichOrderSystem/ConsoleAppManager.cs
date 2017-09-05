using SandwichOrderSystem.Views.ViewStates;

namespace SandwichOrderSystem
{
    public class ConsoleAppManager : IConsoleAppManager
    {
        IViewContext level1Context;
        public ConsoleAppManager(IViewContext level1Context)
        {
            this.level1Context = level1Context;
        }

        public void start()
        {
            var command = "";
            while (command != "q")
            {
                command = level1Context.MenuCommands();
            }
        }
    }
}
