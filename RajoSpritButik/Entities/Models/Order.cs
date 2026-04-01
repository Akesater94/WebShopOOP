using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int ShippingAlternativeId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ShippingAlternative ShippingAlternative { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; } = [];
    }
}
