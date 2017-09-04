using System.Data.Entity;
using SandwichOrderSystemShared.DataAccess.Deserializer;
using SandwichOrderSystemShared.DI;

namespace SandwichOrderSystemShared.DataAccess.Db
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            DISharedInstaller.Container.Resolve<IDataInitializer>().InitData(context);
        }
    }
}
