namespace Entities.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ShoppingCartRow> ShoppingCartRows { get; set; } = [];
    }
}
