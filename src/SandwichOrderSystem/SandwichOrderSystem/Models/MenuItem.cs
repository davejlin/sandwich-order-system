namespace SandwichOrderSystem.Models
{
    public class MenuItem : IMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string MenuCommand { get; set; }
    }
}
