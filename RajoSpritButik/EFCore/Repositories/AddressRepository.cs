using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EFCore.Repositories;

public class AddressRepository (RajoDbContext context) : IAddressRepository
{
    public async Task AddAddressAsync(Address address)
    {
        context.Add(address);
        await context.SaveChangesAsync();
    }
}
