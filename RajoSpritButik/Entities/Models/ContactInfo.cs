namespace Entities.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ContactTypeId { get; set; }
        public int UserId { get; set; }
        public ContactType ContactType { get; set; }

        public User User { get; set; }
    }
}
