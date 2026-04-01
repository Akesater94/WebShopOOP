namespace Entities.Models
{
    public class ShippingAlternative
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
    }
}
