using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models;

public class PaymentAlternative
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Fee { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
