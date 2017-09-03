using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystem.Deserializer
{
    public interface IDataParser
    {
        List<string[]> ParseData(string contents);
    }
}
