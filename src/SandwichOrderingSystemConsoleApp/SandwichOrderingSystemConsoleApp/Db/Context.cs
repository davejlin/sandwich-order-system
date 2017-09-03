using SandwichOrderingSystemConsoleApp.Deserializer;
using SandwichOrderingSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.Db
{
    class Context : DbContext
    {
        internal Context(IDataInitializer dataInitializer, IItemFactory itemFactory)
        {
            Database.SetInitializer(new DatabaseInitializer(dataInitializer, itemFactory));
        }

        public DbSet<Sandwich> Sandwiches { get; set; }
    }
}
