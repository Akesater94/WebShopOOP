using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ShoppingCartRow
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
    }
}
