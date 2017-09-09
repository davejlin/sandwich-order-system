using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public interface IOrder
    {
        ICollection<IItem> Items { get; set; }
        int Count { get; }
    }
}
