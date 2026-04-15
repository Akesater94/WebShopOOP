using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;

namespace EFCore.Repositories;

public class ProductRepository(RajoDbContext context) : IProductRepository
{
    public async Task<List<Product>> GetShowCaseProducts()
    {
        return await context.Products.Where(p => p.Showcase).ToListAsync();
    }

    public async Task<List<Product>> GetAllProductsByCategoryAsync(int categoryId)
    {
        return await context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<List<Product>> GetProductsWithDetailsAsync()
    {
        return await context.Products
            .Include(p => p.Category)
            .Include(p => p.Manufacturer)
            .ToListAsync();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await context.Products
            .Include(p => p.Category)
            .Include(p => p.Manufacturer)
            .ThenInclude(m => m.Country)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
    }


    public async Task RemoveAsync(Product product)
    {
        context.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<List<Product>> SearchProductsAsync(string searchWord)
    {
        return await context.Products
            .Where(p => p.Name.ToLower().Contains(searchWord.ToLower()))
            .ToListAsync();
    }

    public async Task<List<MostSoldProductDTO>> GetMostSoldProductsAsync(int count = 10)
    {
        return await context.Products
            .Select(p => new MostSoldProductDTO
            {
                Name = p.Name,
                NumberSold = p.OrderRows.Sum(or => or.Quantity)
            })
            .Where(p => p.NumberSold > 0)
            .OrderByDescending(p => p.NumberSold)
            .Take(count)
            .ToListAsync();
    }
}
