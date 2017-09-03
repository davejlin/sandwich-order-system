using SandwichOrderingSystemConsoleApp.Db;
using SandwichOrderingSystemConsoleApp.Deserializer;
using SandwichOrderingSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataRetriever = new FileSystemManager();
            var dataParser = new DataParser();
            var dataInitializer = new DataInitializer(dataRetriever, dataParser);
            var itemFactory = new ItemFactory();

            using (var context = new Context(dataInitializer, itemFactory))
            {
                var sandwiches = context.Sandwiches.ToList();
                foreach (Sandwich sandwich in sandwiches)
                {
                    Console.WriteLine("{0} {1:C}", sandwich.Name, sandwich.Price);
                }

                Console.ReadLine();
            }
        }
    }
}
