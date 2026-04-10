using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories;

public class CountryRepository(RajoDbContext context) : ICountryRepository
{
    public async Task AddCountryAsync(Country country)
    {
        context.Add(country);
        await context.SaveChangesAsync();
    }

    public async Task<Country?> GetCountryByNameAsync(string name)
    {
        return await context.Countries
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}
