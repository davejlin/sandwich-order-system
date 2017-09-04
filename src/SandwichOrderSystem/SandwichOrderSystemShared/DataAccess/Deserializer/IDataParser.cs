using System.Collections.Generic;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IDataParser
    {
        IEnumerable<string[]> ParseData(string contents);
    }
}
