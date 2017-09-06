using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewModels
{
    public interface IViewModel
    {
        IEnumerable<string> GetItemForMenuCommands<T>() where T : class, IItem;
    }
}
