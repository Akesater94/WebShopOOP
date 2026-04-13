using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories;

public class OrderRepository(RajoDbContext context) : IOrderRepository
{
    public async Task AddOrderAsync(Order order)
    {
        await context.AddAsync(order);
        await context.SaveChangesAsync();
    }

    public async Task AddOrderRowAsync(OrderRow orderRow)
    {
        await context.AddAsync(orderRow);
        await context.SaveChangesAsync();
    }
}
