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
            using (var context = new Context())
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
