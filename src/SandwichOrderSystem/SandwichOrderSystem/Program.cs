using SandwichOrderSystem.DI;
using SandwichOrderSystemShared.DataAccess;
using System;

namespace SandwichOrderSystem
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
