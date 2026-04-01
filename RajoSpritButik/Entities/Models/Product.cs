using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; } = [];
        
    }
}
