namespace Entities.Models
{
    public class ContactType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ContactInfo> ContactInfos { get; set; } = [];
    }
}
