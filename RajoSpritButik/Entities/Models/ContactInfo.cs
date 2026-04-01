namespace Entities.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public int ContactTypeId { get; set; }
        public int UserId { get; set; }
        public ContactType ContactType { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
