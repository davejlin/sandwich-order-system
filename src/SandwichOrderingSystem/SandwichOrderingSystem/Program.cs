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
            var dataRetriever = new FileSystemManager();
            var dataParser = new DataParser();
            var itemFactory = new ItemFactory();
            var dataInitializer = new DataInitializer(dataRetriever, dataParser, itemFactory);
            var dataAccessor = new Repository(dataInitializer);

            dataAccessor.DisplayAllItems();
            Console.ReadLine();
        }
    }
}
