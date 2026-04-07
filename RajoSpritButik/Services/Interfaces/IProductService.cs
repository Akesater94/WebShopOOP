using Entities.Models;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetShowCaseProductsAsync();
    Task<List<Product>> GetAllProductsByCategoryAsync(int categoryId);
}
