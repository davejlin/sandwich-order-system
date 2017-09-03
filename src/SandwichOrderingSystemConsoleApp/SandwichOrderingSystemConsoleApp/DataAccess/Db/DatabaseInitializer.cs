using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SandwichOrderingSystemConsoleApp.Deserializer;
using SandwichOrderingSystemConsoleApp.Models;
using System.Reflection;

namespace SandwichOrderingSystemConsoleApp.Db
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        IDataInitializer dataInitializer;

        public DatabaseInitializer(IDataInitializer dataInitializer)
        {
            this.dataInitializer = dataInitializer;
        }

        protected override void Seed(Context context)
        {
            dataInitializer.InitData(context);
        }
    }
}
