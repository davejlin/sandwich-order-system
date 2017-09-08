using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class FileSystemManager : IFileSystemManager
    {
        public string[] GetItemNames()
        {
            var dataDirPath = Path.Combine(getCurrentDirectory().FullName, DATA_DIRECTORY_NAME);
            var files = Directory
                .GetFiles(dataDirPath)
                .Select(f => Regex.Matches(f, DATA_FILE_NAME_REGEX)[0].Groups[1].Value)
                .ToArray<string>();

            return files;
        }

        public string GetContents(string fileName)
        {
            fileName = DATA_FULL_PATH_NAME_PREFIX + fileName + DATA_FULL_PATH_NAME_SUFFIX;
            var filePath = Path.Combine(getCurrentDirectory().FullName, fileName);
            return readFile(filePath);
        }

        private DirectoryInfo getCurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return new DirectoryInfo(currentDirectory);
        }

        private string readFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
