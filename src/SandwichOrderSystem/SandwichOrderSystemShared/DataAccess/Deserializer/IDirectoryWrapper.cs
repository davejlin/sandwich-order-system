using System.IO;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IDirectoryWrapper
    {
        string[] GetFiles(string dirPath);
        DirectoryInfo GetCurrentDirectory();
        string ReadFile(string fileName);
    }
}
