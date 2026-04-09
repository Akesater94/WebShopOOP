using Entities.Models;
using Services.Interfaces;

namespace Services;

public class ShoppingCartService(IShoppingCartRepository shoppingCartRepository) : IShoppingCartService
{
    public async Task AddRowAsync(int shoppingCartId, int productId)
    {
        // Hämta raden från repot
        // Finns inte raden, skapa ny rad
        // Finns raden, lägg till ett på kvantitet
        // await shoppingCartRepository.AddRowAsync(row)
        await shoppingCartRepository.AddRowAsync(shoppingCartId, productId);
    }

    public async Task<ShoppingCart?> GetByUserIdAsync(int id)
    {
        return await shoppingCartRepository.GetByUserIdAsync(id);
    }

    public async Task RemoveRowAsync(int rowId)
    {
        await shoppingCartRepository.RemoveRowAsync(rowId);
    }

}
