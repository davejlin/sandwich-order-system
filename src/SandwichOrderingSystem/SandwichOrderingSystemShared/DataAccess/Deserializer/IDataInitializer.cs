using SandwichOrderingSystemShared.DataAccess.Db;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public interface IDataInitializer
    {
        void InitData(Context context);
    }
}
