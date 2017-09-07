using System.Collections.Generic;
using System.Linq;

namespace SandwichOrderSystemShared.Models
{
    public class Order : IOrder
    {
        public IEnumerable<IItem> Items { get; set; }

        public override string ToString()
        {
            var itemsStrings = Items.Select(i => i.ToString());
            return string.Join("\n", itemsStrings);
        }
    }
}
