using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IAddressRepository
{
    Task AddAddressAsync(Address address);
}
