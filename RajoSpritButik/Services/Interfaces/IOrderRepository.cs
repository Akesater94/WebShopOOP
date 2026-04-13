using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task AddOrderRowAsync(OrderRow orderRow);
}