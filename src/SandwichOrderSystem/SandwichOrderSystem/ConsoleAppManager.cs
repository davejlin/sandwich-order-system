using SandwichOrderSystem.Views;

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
            while (command != Constants.QUIT_COMMAND)
            {
                command = viewContext.MenuCommands();
                viewContext.Action();
            }
        }
    }
}
