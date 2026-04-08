using Entities.Models;
using Services.Interfaces;

namespace Services;

public class ShoppingCartService(IShoppingCartRepository shoppingCartRepository) : IShoppingCartService
{
    public async Task<ShoppingCart?> GetByUserIdAsync(int id)
    {
        return await shoppingCartRepository.GetByUserIdAsync(id);
    }

    public async Task RemoveRowAsync(int rowId)
    {
        await shoppingCartRepository.RemoveRowAsync(rowId);
    }
}
