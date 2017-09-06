using System.Collections.Generic;

namespace SandwichOrderSystemShared.Models
{
    public class Order : IOrder
    {
        public IEnumerable<IItem> Items { get; set; }
    }
}
