using System.IO;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public DirectoryInfo GetCurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return new DirectoryInfo(currentDirectory);
        }

        public string[] GetFiles(string dirPath)
        {
            return Directory.GetFiles(dirPath);
        }

        public string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
