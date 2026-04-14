using Entities.Models;
using Services.Interfaces;

namespace Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task AddCategoryAsync(Category category)
    {
        await categoryRepository.AddCategoryAsync(category);
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await categoryRepository.GetAllCategoriesAsync();
    }

    public async Task<Category?> GetCategoryAsync(int id)
    {
        return await categoryRepository.GetCategoryAsync(id);
    }

    public async Task RemoveCategoryAsync(int id)
    {
        await categoryRepository.RemoveCategoryAsync(id);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        await categoryRepository.UpdateCategoryAsync(category);
    }
}
