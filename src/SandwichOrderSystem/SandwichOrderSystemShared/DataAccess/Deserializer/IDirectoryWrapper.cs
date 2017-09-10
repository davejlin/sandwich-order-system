using System.Collections.Generic;
using System.IO;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IDirectoryWrapper
    {
        IEnumerable<string> GetFiles(string dirPath);
        DirectoryInfo GetCurrentDirectory();
        string ReadFile(string fileName);
    }
}
