using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IUserAddressRepository
{
    Task<List<Address>> GetAllAddressesAsync(int id);
    Task AddUserAddressAsync(UserAddress userAddress);
}
