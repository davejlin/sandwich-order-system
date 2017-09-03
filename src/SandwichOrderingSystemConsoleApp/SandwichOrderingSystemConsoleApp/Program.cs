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
            var itemFactory = new ItemFactory();
            var dataInitializer = new DataInitializer(dataRetriever, dataParser, itemFactory);

            using (var context = new Context(dataInitializer))
            {
                var sandwiches = context.SignatureSandwichSet.ToList();
                foreach (SignatureSandwich sandwich in sandwiches)
                {
                    Console.WriteLine("{0} {1:C}", sandwich.Name, sandwich.Price);
                }

                Console.ReadLine();
            }
        }
    }
}
