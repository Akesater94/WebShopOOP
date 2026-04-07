using Entities.Models;

namespace Services.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetShowCaseProducts();
    Task<List<Product>> GetAllProductsByCategoryAsync(int categoryId);

}
