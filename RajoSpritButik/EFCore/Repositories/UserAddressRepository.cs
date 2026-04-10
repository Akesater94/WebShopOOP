using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories;

public class UserAddressRepository(RajoDbContext context) : IUserAddressRepository
{
    public async Task<List<Address>> GetAllAddressesAsync(int id)
    {
        return await context.UserAddresses.Where(ua => ua.UserId == id).Include(ua => ua.Address.Country).Select(ua => ua.Address).ToListAsync();
    }

    public async Task AddUserAddressAsync(UserAddress userAddress)
    {
        await context.AddAsync(userAddress);
        await context.SaveChangesAsync();
    }
}
