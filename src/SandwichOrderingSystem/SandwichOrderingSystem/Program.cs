using SandwichOrderingSystem.DI;
using SandwichOrderingSystemShared.DataAccess;
using System;

namespace SandwichOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DIContainer.Container.InitContainer();

            var repository = container.Resolve<IRepository>();
            repository.DisplayAllItems();

            Console.ReadLine();

            container.Dispose();
        }
    }
}
