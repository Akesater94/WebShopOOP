using Entities.Models;

namespace Services.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task AddCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(int id);
    Task RemoveCategoryAsync(int id);
    Task UpdateCategoryAsync(Category category);
}
