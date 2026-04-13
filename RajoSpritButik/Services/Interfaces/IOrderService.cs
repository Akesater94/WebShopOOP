using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IOrderService
{
    Task<Order> AddOrderAsync(int userId, int addressId, int paymentAlternativeId, int shippingAlternativeId, int shoppingCartId);
    Task<OrderRow> AddOrderRowAsync(int productId, int orderId, int quantity);
}
