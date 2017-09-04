namespace SandwichOrderSystemShared.Models
{
    public abstract class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
