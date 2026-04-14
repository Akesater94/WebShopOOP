using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories;

public class CategoryRepository(RajoDbContext context) : ICategoryRepository
{
    public async Task AddCategoryAsync(Category category)
    {
        await context.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryAsync(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task RemoveCategoryAsync(int id)
    {
        Category? category = await GetCategoryAsync(id);
        if (category != null)
        {
            context.Remove(category);
        }
        await context.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        context.Update(category);
        await context.SaveChangesAsync();
    }
}
