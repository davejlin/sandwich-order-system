using SandwichOrderingSystemConsoleApp.Deserializer;
using SandwichOrderingSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.Db
{
    public class Context : DbContext
    {
        public DbSet<SignatureSandwich> SignatureSandwichSet { get; set; }

        public Context(IDataInitializer dataInitializer)
        {
            Database.SetInitializer(new DatabaseInitializer(dataInitializer));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
