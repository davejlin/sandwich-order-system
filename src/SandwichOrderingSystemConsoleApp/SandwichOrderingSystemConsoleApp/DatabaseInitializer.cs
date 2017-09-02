using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SandwichOrderingSystemConsoleApp.Models;

namespace SandwichOrderingSystemConsoleApp
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var sandwich1 = new Sandwich()
            {
                Name = "sandwich1",
                Price = 1.00M
            };

            var sandwich2 = new Sandwich()
            {
                Name = "sandwich2",
                Price = 2.00M
            };

            var sandwich3 = new Sandwich()
            {
                Name = "sandwich3",
                Price = 3.00M
            };

            var sandwich4 = new Sandwich()
            {
                Name = "sandwich4",
                Price = 4.00M
            };

            context.Sandwiches.Add(sandwich1);
            context.Sandwiches.Add(sandwich2);
            context.Sandwiches.Add(sandwich3);
            context.Sandwiches.Add(sandwich4);

            context.SaveChanges();
        }
    }
}
