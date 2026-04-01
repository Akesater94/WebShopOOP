namespace Entities.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = [];
    }
}
