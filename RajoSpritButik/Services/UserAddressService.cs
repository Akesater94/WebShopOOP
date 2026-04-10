using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class UserAddressService(IUserAddressRepository userAddressRepository) : IUserAddressService
{
    public async Task<List<Address>> GetAllAddressesAsync(int id)
    {
        return await userAddressRepository.GetAllAddressesAsync(id);
    }

    public async Task AddUserAddressAsync(int userId, int addressId)
    {
        UserAddress userAddress = new UserAddress()
        {
            UserId = userId,
            AddressId = addressId
        };

        await userAddressRepository.AddUserAddressAsync(userAddress);
    }
}
