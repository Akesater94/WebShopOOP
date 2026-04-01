namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoleId { get; set; }
        public string AddressId { get; set; }
        public Role Role { get; set; }
        public Address Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<ContactInfo> ContactInfos { get; set; } = [];
    }
}
