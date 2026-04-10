using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories;

public class ShippingAlternativeRepository(RajoDbContext context) : IShippingAlternativeRepository
{
    public async Task<List<ShippingAlternative>> GetAllShippingAlternativesAsync()
    {
        return await context.ShippingAlternatives.ToListAsync();
    }
}
