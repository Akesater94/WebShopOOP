using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
