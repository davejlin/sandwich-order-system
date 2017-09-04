using SandwichOrderingSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderingSystemShared.DataAccess
{
    public interface IRepository
    {
        IEnumerable<T> GetItem<T>() where T : class, IItem;
        void DisplayAllItems();
    }
}
