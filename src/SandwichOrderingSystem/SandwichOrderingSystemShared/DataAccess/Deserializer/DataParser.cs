using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public class DataParser : IDataParser
    {
        public IEnumerable<string[]> ParseData(string contents)
        {
            List<string[]> propertiesList = new List<string[]>();

            var lines = contents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var properties = line.Split(',');
                if (properties.Count() > 0)
                {
                    propertiesList.Add(properties);
                }
            }

            return propertiesList;
        }
    }
}
