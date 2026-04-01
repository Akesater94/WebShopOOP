namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int ShippingAlternativeId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ShippingAlternative ShippingAlternative { get; set; } = null!;
        public ICollection<OrderRow> OrderRows { get; set; } = [];
    }
}
