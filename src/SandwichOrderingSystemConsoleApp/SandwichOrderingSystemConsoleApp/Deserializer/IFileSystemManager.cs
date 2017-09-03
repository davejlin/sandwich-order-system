using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.Deserializer
{
    interface IFileSystemManager
    {
        string[] GetItemNames();
        string GetContents(string fileName);
    }
}
