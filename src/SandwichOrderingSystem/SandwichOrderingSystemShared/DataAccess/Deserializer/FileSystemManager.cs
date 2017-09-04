using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public class FileSystemManager : IFileSystemManager
    {
        public string[] GetItemNames()
        {
            var dataDirPath = Path.Combine(getCurrentDirectory().FullName, "Data");
            var files = Directory
                .GetFiles(dataDirPath)
                .Select(f => Regex.Matches(f, @"(\w+).txt$")[0].Groups[1].Value)
                .ToArray<string>();

            return files;
        }

        public string GetContents(string fileName)
        {
            fileName = "Data\\" + fileName + ".txt";
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
