using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace EFCore.Repositories;

public class PaymentAlternativeRepository(RajoDbContext context) : IPaymentAlternativeRepository
{
    public async Task<List<PaymentAlternative>> GetAllPaymentAlternativesAsync()
    {
        return await context.PaymentAlternatives.ToListAsync();
    }
}
