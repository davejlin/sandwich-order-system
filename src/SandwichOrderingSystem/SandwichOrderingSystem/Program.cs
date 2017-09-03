using SandwichOrderingSystem.DI;
using SandwichOrderingSystemShared.DataAccess;
using SandwichOrderingSystemShared.DataAccess.Deserializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
