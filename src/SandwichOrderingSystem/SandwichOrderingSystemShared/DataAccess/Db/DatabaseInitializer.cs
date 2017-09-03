using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SandwichOrderingSystemShared.DataAccess.Deserializer;
using SandwichOrderingSystemShared.Models;
using System.Reflection;

namespace SandwichOrderingSystemShared.DataAccess.Db
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
