using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories;

public class ShoppingCartRepository(RajoDbContext context) : IShoppingCartRepository
{
    public async Task<ShoppingCart?> GetByUserIdAsync(int id)
    {
        var shoppingCart = await context.ShoppingCarts
            .Include(sc => sc.ShoppingCartRows)
            .ThenInclude(r => r.Product)
            .FirstOrDefaultAsync(sc => sc.UserId == id);

        return shoppingCart;
    }
}
