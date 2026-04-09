namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<ContactInfo> ContactInfos { get; set; } = [];
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = [];
        public ICollection<UserAddress> UserAddresses { get; set; } = [];
    }
}
