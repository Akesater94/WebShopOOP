using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models;

public class UserAddress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int AddressId { get; set; }
    public Address Address{ get; set; } = null!;
}