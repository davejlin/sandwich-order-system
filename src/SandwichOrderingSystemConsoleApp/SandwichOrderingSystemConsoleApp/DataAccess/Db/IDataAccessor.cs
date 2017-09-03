using SandwichOrderingSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemConsoleApp.DataAccess.Db
{
    public interface IDataAccessor
    {
        IList<T> GetItem<T>() where T : class, IItem;
        void DisplayAllItems();
    }
}
