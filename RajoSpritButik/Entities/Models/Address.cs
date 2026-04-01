namespace Entities.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<User> Users { get; set; } = [];
    }
}
