namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public bool Showcase { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public ICollection<OrderRow> OrderRows { get; set; } = [];
        public ICollection<ShoppingCartRow> ShoppingCartRows { get; set; } = [];

    }
}
