using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderSystemShared.DataAccess
{
    public interface IRepository
    {
        IEnumerable<T> GetItem<T>() where T : class, IItem;
    }
}
