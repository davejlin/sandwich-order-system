using SandwichOrderingSystemConsoleApp.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.Deserializer
{
    public interface IDataInitializer
    {
        void InitData(Context context);
    }
}
