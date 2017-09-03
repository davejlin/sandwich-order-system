using SandwichOrderingSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.Deserializer
{
    public interface IItemFactory
    {
        T CreateItem<T>(string[] properties) where T : class;
    }
}
