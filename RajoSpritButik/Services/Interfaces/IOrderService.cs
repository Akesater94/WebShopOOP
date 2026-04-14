using Entities.Models;

namespace Services.Interfaces;

public interface IOrderService
{
    Task<Order?> AddOrderAsync(int userId, int addressId, int paymentAlternativeId, int shippingAlternativeId, int shoppingCartId);
    Task<OrderRow> AddOrderRowAsync(int productId, int orderId, int quantity);
    Task<Order?> GetOrderWithDetailsAsync(int orderId);
    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}
