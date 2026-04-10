using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface ICountryRepository
{
    Task<Country?> GetCountryByNameAsync(string name);
    Task AddCountryAsync(Country country);

}
