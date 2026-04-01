namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RoleId { get; set; }
        public int AddressId { get; set; }
        public Role Role { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<ContactInfo> ContactInfos { get; set; } = [];
    }
}
