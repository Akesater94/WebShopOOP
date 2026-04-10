using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class CountryService(ICountryRepository countryRepository) : ICountryService
{
    public async Task AddCountryAsync(Country country)
    {
        await countryRepository.AddCountryAsync(country);
    }

    public async Task<Country?> GetCountryByNameAsync(string name)
    {

        return await countryRepository.GetCountryByNameAsync(name);
        
    }

    public async Task<Country> GetOrCreateCountryAsync(string name)
    {
        Country? country = await GetCountryByNameAsync(name);
        if (country == null)
        {
            country = new Country()
            {
                Name = name,
            };

            await AddCountryAsync(country);
        }

        return country;
    }
}
