using SandwichOrderSystem.DI;

namespace SandwichOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DIContainer.Container.InitContainer();
            var orderManager = container.Resolve<IOrderManager>();
            orderManager.start();
            container.Dispose();
        }
    }
}
