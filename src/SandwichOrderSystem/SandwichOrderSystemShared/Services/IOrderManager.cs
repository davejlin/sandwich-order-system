using SandwichOrderSystemShared.Models;
using System.Collections.Generic;

namespace SandwichOrderSystemShared.Services
{
    public interface IOrderManager
    {
        IOrders Orders { get; }
    }
}
