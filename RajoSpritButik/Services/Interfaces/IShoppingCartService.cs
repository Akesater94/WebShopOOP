using Entities.Models;

namespace Services.Interfaces;

public interface IShoppingCartService
{
    Task<ShoppingCart?> GetByUserIdAsync(int id);
    Task RemoveRowAsync(int rowId);
    Task AddRowAsync(int shoppingCartId, int productId);
    Task EmptyShoppingCartAsync(int shoppingCartId);
    Task<ShoppingCart?> GetShoppingCartAsync(int shoppingCartId);
    Task UpdateRowAsync(ShoppingCartRow cartRow);
}