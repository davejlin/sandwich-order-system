using SandwichOrderSystem.DI;

namespace SandwichOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DIContainer.Container.InitContainer();
            var consoleAppManager = container.Resolve<IConsoleAppManager>();
            consoleAppManager.start();
            container.Dispose();
        }
    }
}
