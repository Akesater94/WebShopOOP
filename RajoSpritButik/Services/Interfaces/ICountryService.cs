using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface ICountryService
{
    Task<Country?> GetCountryByNameAsync(string name);
    Task AddCountryAsync(Country country);
    Task<Country> GetOrCreateCountryAsync(string name);
}
