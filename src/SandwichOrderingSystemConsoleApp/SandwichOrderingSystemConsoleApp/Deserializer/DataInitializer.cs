using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.Deserializer
{
    class DataInitializer : IDataInitializer
    {
        IFileSystemManager fileSystemManager;
        IDataParser dataParser;

        public DataInitializer(IFileSystemManager fileSystemManager, IDataParser dataParser)
        {
            this.fileSystemManager = fileSystemManager;
            this.dataParser = dataParser;
        }
        
        public Dictionary<string, List<string[]>> GetItemsDict()
        {
            Dictionary<string, List<string[]>> results = new Dictionary<string, List<string[]>>();

            var itemNames = fileSystemManager.GetItemNames();
            foreach (var itemName in itemNames)
            {
                var contents = fileSystemManager.GetContents(itemName);
                var properties = dataParser.ParseData(contents);
                results[itemName] = properties;
            }

            return results;
        }
    }
}
