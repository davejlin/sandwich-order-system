using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public interface IOrder
    {
        IEnumerable<IItem> Items { get; set; }
    }
}
