using SandwichOrderSystem.DI;
using SandwichOrderSystem.ViewControllers;

namespace SandwichOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DIContainer.Container.InitContainer();
            var viewController = container.Resolve<IViewController>();
            viewController.Start();
            container.Dispose();
        }
    }
}
