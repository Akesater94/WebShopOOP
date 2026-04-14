using Entities.Models;

namespace Services.Interfaces;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task AddOrderRowAsync(OrderRow orderRow);
    Task<Order?> GetOrderWithDetailsAsync(int orderId);
    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}