using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class ShippingAlternativeService(IShippingAlternativeRepository shippingAlternativeRepository) : IShippingAlternativeService
{
    public async Task<List<ShippingAlternative>> GetAllShippingAlternativesAsync()
    {
        return await shippingAlternativeRepository.GetAllShippingAlternativesAsync();
    }
}
