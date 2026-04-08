using Entities.Models;

namespace Services.Interfaces;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetByUserIdAsync(int id);

    Task RemoveRowAsync(int rowId);
    Task AddRowAsync(int shoppingCartId, int productId);
}
