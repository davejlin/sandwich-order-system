using SandwichOrderSystem.Models;
using SandwichOrderSystemShared.Models;
using System;
using System.Collections.Generic;

namespace SandwichOrderSystem.Services
{
    public interface IMenuItemsFactory
    {
        IMenuItem CreateMenuItem(IItem item, string menuCommand);
        IDictionary<Type, List<IMenuItem>> CreateMenuItems();
    }
}
