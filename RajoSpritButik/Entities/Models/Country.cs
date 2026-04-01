using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
    }
}
