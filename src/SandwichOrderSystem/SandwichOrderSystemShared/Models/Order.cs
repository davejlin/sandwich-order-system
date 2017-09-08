using System.Collections.Generic;
using System.Linq;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.Models
{
    public class Order : IOrder
    {
        public ICollection<IItem> Items { get; set; }

        public Order()
        {
            Items = new List<IItem>();
        }

        public override string ToString()
        {
            var itemsStrings = Items.Select(i => i.ToString());
            return string.Join(NEW_LINE1, itemsStrings);
        }
    }
}
