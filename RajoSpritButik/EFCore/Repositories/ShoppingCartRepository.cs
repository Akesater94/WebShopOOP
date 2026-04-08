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

    public async Task RemoveRowAsync(int rowId)
    {
        var rowToRemove = await context.ShoppingCartRows.FindAsync(rowId);

        if (rowToRemove != null)
        {
            context.Remove(rowToRemove);
            await context.SaveChangesAsync();
        }
    }
}
