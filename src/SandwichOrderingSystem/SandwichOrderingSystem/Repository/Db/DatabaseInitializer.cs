using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SandwichOrderingSystem.Deserializer;
using SandwichOrderingSystem.Models;
using System.Reflection;

namespace SandwichOrderingSystem.Db
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
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
