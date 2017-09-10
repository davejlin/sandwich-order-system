using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class FileSystemManager : IFileSystemManager
    {
        IDirectoryWrapper directory;
        public FileSystemManager(IDirectoryWrapper directory)
        {
            this.directory = directory;
        }

        public string[] GetItemNames()
        {
            var dataDirPath = Path.Combine(directory.GetCurrentDirectory().FullName, DATA_DIRECTORY_NAME);
            var files = directory
                .GetFiles(dataDirPath)
                .Select(f => Regex.Matches(f, DATA_FILE_NAME_REGEX)[0].Groups[1].Value)
                .ToArray();

            return files;
        }

        public string GetContents(string fileName)
        {
            fileName = DATA_FULL_PATH_NAME_PREFIX + fileName + DATA_FULL_PATH_NAME_SUFFIX;
            var filePath = Path.Combine(directory.GetCurrentDirectory().FullName, fileName);
            return directory.ReadFile(filePath);
        }
    }
}
