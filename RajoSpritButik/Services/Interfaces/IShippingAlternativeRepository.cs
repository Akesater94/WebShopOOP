using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IShippingAlternativeRepository
{
    Task<List<ShippingAlternative>> GetAllShippingAlternativesAsync();
}
