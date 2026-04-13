using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class OrderService(IOrderRepository orderRepository, IShoppingCartService shoppingCartService) : IOrderService
{
    public async Task<Order> AddOrderAsync(int userId, int addressId, int paymentAlternativeId, int shippingAlternativeId, int shoppingCartId)
    {
        Order order = new Order()
        {
            UserId = userId,
            AddressId = addressId,
            PaymentAlternativeId = paymentAlternativeId,
            ShippingAlternativeId = shippingAlternativeId,
            Status = "Received"
        };

        await orderRepository.AddOrderAsync(order);

        ShoppingCart shoppingCart = (await shoppingCartService.GetShoppingCartAsync(shoppingCartId))!;

        foreach (var shoppingCartRow in shoppingCart.ShoppingCartRows)
        {
            await AddOrderRowAsync(shoppingCartRow.ProductId, order.Id, shoppingCartRow.Quantity);
        }

        await shoppingCartService.EmptyShoppingCartAsync(shoppingCartId);
        return order;
    }

    public async Task<OrderRow> AddOrderRowAsync(int productId, int orderId, int quantity)
    {
        OrderRow orderRow = new OrderRow()
        {
            ProductId = productId,
            OrderId = orderId,
            Quantity = quantity
        };

        await orderRepository.AddOrderRowAsync(orderRow);
        return orderRow;
    }
}
