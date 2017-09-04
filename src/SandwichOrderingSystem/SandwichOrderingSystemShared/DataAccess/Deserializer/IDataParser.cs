using System.Collections.Generic;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public interface IDataParser
    {
        IEnumerable<string[]> ParseData(string contents);
    }
}
