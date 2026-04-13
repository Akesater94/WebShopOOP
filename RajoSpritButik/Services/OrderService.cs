using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class OrderService(IOrderRepository orderRepository, IShoppingCartService shoppingCartService) : IOrderService
{
    public async Task<Order?> AddOrderAsync(int userId, int addressId, int paymentAlternativeId, int shippingAlternativeId, int shoppingCartId)
    {
        Order order = new Order()
        {
            UserId = userId,
            AddressId = addressId,
            PaymentAlternativeId = paymentAlternativeId,
            ShippingAlternativeId = shippingAlternativeId,
            Status = "Received",
            OrderRows = new List<OrderRow>()
        };


        ShoppingCart shoppingCart = (await shoppingCartService.GetShoppingCartAsync(shoppingCartId))!;

        foreach (var shoppingCartRow in shoppingCart.ShoppingCartRows)
        {
            order.OrderRows.Add(new OrderRow()
            {
                ProductId = shoppingCartRow.ProductId,
                Quantity = shoppingCartRow.Quantity,
                Product = shoppingCartRow.Product,
            });

        }

        await orderRepository.AddOrderAsync(order);

        await shoppingCartService.EmptyShoppingCartAsync(shoppingCartId);

        return await GetOrderWithDetailsAsync(order.Id);
    }

    public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
    {
        return await orderRepository.GetOrderWithDetailsAsync(orderId);
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
