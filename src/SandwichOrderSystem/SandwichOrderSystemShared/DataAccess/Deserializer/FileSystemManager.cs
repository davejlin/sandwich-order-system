using SandwichOrderSystemShared.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class FileSystemManager : IFileSystemManager
    {
        IDirectoryWrapper directory;
        IErrorHandler errorHandler;

        public FileSystemManager(IDirectoryWrapper directory, IErrorHandler errorHandler)
        {
            this.directory = directory;
            this.errorHandler = errorHandler;
        }

        public IEnumerable<string> GetItemNames()
        {
            var dataDirPath = Path.Combine(directory.GetCurrentDirectory().FullName, DATA_DIRECTORY_NAME);
            var fileNames = directory.GetFiles(dataDirPath);
            var itemNames = new List<string>();

            foreach (var fileName in fileNames)
            {
                try
                {
                    var itemName = Regex.Matches(fileName, DATA_FILE_NAME_REGEX)[0].Groups[1].Value;
                    itemNames.Add(itemName);
                }
                catch (Exception ex)
                {
                    errorHandler.HandleError(ex.Message);
                }
            }
            return itemNames;
        }

        public string GetContents(string fileName)
        {
            fileName = DATA_FULL_PATH_NAME_PREFIX + fileName + DATA_FULL_PATH_NAME_SUFFIX;
            var filePath = Path.Combine(directory.GetCurrentDirectory().FullName, fileName);
            return directory.ReadFile(filePath);
        }
    }
}
