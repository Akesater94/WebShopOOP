using Entities.Models;
using Services.Interfaces;

namespace Services;

public class ShoppingCartService(IShoppingCartRepository shoppingCartRepository) : IShoppingCartService
{
    public async Task AddRowAsync(int shoppingCartId, int productId)
    {
        await shoppingCartRepository.AddRowAsync(shoppingCartId, productId);
    }

    public async Task EmptyShoppingCartAsync(int shoppingCartId)
    {
        await shoppingCartRepository.EmptyShoppingCartAsync(shoppingCartId);
    }

    public async Task<ShoppingCart?> GetByUserIdAsync(int id)
    {
        return await shoppingCartRepository.GetByUserIdAsync(id);
    }

    public async Task<ShoppingCart?> GetShoppingCartAsync(int shoppingCartId)
    {
        return await shoppingCartRepository.GetShoppingCartAsync(shoppingCartId);
    }

    public async Task RemoveRowAsync(int rowId)
    {
        await shoppingCartRepository.RemoveRowAsync(rowId);
    }

    public async Task UpdateRowAsync(ShoppingCartRow cartRow)
    {
        if (cartRow.Quantity <= 0)
        {
            await RemoveRowAsync(cartRow.Id);
        }
        else
        {
            await shoppingCartRepository.UpdateRowAsync(cartRow);
        }
    }
}
