using SandwichOrderSystem.Views.ViewStates;

namespace SandwichOrderSystem
{
    public class ConsoleAppManager : IConsoleAppManager
    {
        IViewContext viewContext;
        public ConsoleAppManager(IViewContext viewContext)
        {
            this.viewContext = viewContext;
        }

        public void start()
        {
            string command = "";
            while (command != Constants.VIEW_STATE_COMMAND_QUIT)
            {
                command = viewContext.MenuCommands();
            }
        }
    }
}
