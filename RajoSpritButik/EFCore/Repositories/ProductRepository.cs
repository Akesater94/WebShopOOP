using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
}
