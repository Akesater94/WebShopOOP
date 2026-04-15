using Entities.Models;
using Services.DTOs;

namespace Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetShowCaseProductsAsync();
    Task<List<Product>> GetAllProductsByCategoryAsync(int categoryId);
    Task<List<Product>> GetProductsWithDetailsAsync();
    Task<Product?> GetProductAsync(int id);
    Task<List<Product>> SearchProductsAsync(string searchWord);
    Task UpdateAsync(Product product);
    Task RemoveAsync(Product product);
    Task<List<MostSoldProductDTO>> GetMostSoldProductsAsync(int count);
}
