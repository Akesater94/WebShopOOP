using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories;

public class ShoppingCartRepository(RajoDbContext context) : IShoppingCartRepository
{
    public async Task AddRowAsync(int shoppingCartId, int productId)
    {
        var rowToAdd = await context.ShoppingCartRows.FirstOrDefaultAsync(r => r.ShoppingCartId == shoppingCartId && r.ProductId == productId);
        if (rowToAdd == null)
        {
            var newrow = new ShoppingCartRow
            {
                ShoppingCartId = shoppingCartId,
                ProductId = productId,
                Quantity = 1
            };
            context.ShoppingCartRows.Add(newrow);
            
        }
        else
        {
            rowToAdd.Quantity +=1 ;
        }
        await context.SaveChangesAsync();

    }

    public async Task<ShoppingCart?> GetByUserIdAsync(int id)
    {
        var shoppingCart = await context.ShoppingCarts
            .Include(sc => sc.ShoppingCartRows)
            .ThenInclude(r => r.Product)
            .FirstOrDefaultAsync(sc => sc.UserId == id);

        return shoppingCart;
    }

    public async Task<ShoppingCart?> GetShoppingCartAsync(int shoppingCartId)
    {
        return await context.ShoppingCarts
            .Include(sc => sc.ShoppingCartRows)
            .ThenInclude(scr => scr.Product)
            .FirstOrDefaultAsync(sc => sc.Id == shoppingCartId);
            
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
