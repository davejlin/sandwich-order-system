using System;
using static SandwichOrderSystemShared.Constants;

namespace SandwichOrderSystemShared.Models
{
    public abstract class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format(ITEM_FORMAT, Name.ToString(), Price.ToString()); 
        }
    }
}
