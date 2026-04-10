using Entities.Models;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetShowCaseProductsAsync();
    Task<List<Product>> GetAllProductsByCategoryAsync(int categoryId);
    Task<List<Product>> GetProductsWithDetailsAsync();
    Task<Product?> GetProductByIdWithDetailsAsync(int id);
    Task UpdateAsync(Product product);
    Task RemoveAsync(Product product);
}
