using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class AddressService (IAddressRepository addressRepository, ICountryService countryService) : IAddressService
{
    public async Task AddAddressAsync(Address newAddress)
    {
        newAddress.Country = await countryService.GetOrCreateCountryAsync(newAddress.Country.Name);

        await addressRepository.AddAddressAsync(newAddress);
    }
}
