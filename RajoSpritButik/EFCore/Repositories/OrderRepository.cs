using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
    {
        return await context.Orders
             .Include(o => o.ShippingAlternative)
             .Include(o => o.Address)
             .ThenInclude(a => a.Country)
             .Include(o => o.PaymentAlternative)
             .Include(o => o.OrderRows)
             .ThenInclude(or => or.Product)
             .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}
