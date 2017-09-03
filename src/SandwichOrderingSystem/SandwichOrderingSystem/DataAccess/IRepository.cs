using SandwichOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystem.DataAccess
{
    public interface IRepository
    {
        IList<T> GetItem<T>() where T : class, IItem;
        void DisplayAllItems();
    }
}
