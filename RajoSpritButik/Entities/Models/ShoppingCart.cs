namespace Entities.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<ShoppingCartRow> ShoppingCartRows { get; set; } = [];
        public User User { get; set; } = null!;
    }
}
