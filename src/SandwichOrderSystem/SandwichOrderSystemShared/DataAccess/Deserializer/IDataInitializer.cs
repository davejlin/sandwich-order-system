using SandwichOrderSystemShared.DataAccess.Db;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IDataInitializer
    {
        void InitData(Context context);
    }
}
