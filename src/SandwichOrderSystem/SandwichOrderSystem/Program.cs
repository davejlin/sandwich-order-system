using SandwichOrderSystem.DI;

namespace SandwichOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DIContainer.Container.InitContainer();
            var system = container.Resolve<ISandwichOrderSystem>();
            system.Start();
            container.Dispose();
        }
    }
}
