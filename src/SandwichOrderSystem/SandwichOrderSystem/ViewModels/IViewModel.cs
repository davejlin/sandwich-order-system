using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderSystem.ViewModels
{
    public interface IViewModel
    {
        IEnumerable<string> GetItemCommandMenu<T>() where T : class, IItem;
        IEnumerable<string> GetItemCommands<T>() where T : class, IItem;
    }
}
