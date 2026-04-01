using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
