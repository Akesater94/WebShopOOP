using Entities.Models;

namespace Services.Interfaces;

public interface IShoppingCartService
{
    Task<ShoppingCart?> GetByUserIdAsync(int id);
}
