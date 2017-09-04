using System.Data.Entity;
using SandwichOrderingSystemShared.DataAccess.Deserializer;

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
