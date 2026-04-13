namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int ShippingAlternativeId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int PaymentAlternativeId { get; set; }
        public PaymentAlternative PaymentAlternative { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public User User { get; set; } = null!;
        public ShippingAlternative ShippingAlternative { get; set; } = null!;
        public ICollection<OrderRow> OrderRows { get; set; } = [];
        //Efter lunch: lägg till slutpris metod.
    }
}
