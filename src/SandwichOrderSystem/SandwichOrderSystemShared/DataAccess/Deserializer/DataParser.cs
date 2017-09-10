using System;
using System.Collections.Generic;
using System.Linq;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public class DataParser : IDataParser
    {
        public IEnumerable<string[]> ParseData(string contents)
        {
            List<string[]> propertiesList = new List<string[]>();

            var lines = contents.Split(new string[] { NEW_LINE1, NEW_LINE2 }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var properties = line.Split(COMMA)
                    .Select(p => p.Trim())
                    .Where(p => !string.IsNullOrEmpty(p))
                    .ToArray();

                if (properties.Count() > 0)
                {
                    propertiesList.Add(properties);
                }
            }

            return propertiesList;
        }
    }
}
