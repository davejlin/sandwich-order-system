using SandwichOrderSystemShared.Services;
using System;
using System.Collections.Generic;
using System.IO;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        IErrorHandler errorHandler;

        public DirectoryWrapper(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public DirectoryInfo GetCurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return new DirectoryInfo(currentDirectory);
        }

        public IEnumerable<string> GetFiles(string dirPath)
        {
            try
            {
                return Directory.GetFiles(dirPath);
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(ex.Message);
            }

            return new List<string>(); ;
        }

        public string ReadFile(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(ex.Message);
            }

            return EMPTY_STRING;
        }
    }
}
