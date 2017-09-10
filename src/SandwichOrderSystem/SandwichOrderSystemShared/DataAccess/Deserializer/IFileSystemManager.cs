using System.Collections.Generic;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IFileSystemManager
    {
        IEnumerable<string> GetItemNames();
        string GetContents(string fileName);
    }
}
