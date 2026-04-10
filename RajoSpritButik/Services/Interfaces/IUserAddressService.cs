using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IUserAddressService
{
    Task<List<Address>> GetAllAddressesAsync(int id);
    Task AddUserAddressAsync(int userId, int addressId);


}
