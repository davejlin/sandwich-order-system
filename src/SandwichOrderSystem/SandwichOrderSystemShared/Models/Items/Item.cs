namespace SandwichOrderSystemShared.Models
{
    public abstract class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        private string FORMAT = " {0,-20} {1}";
        public override string ToString()
        {
            return string.Format(FORMAT, Name.ToString(), Price.ToString()); 
        }
    }
}
