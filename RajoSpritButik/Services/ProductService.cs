using Entities.Models;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<List<Product>> GetShowCaseProductsAsync()
    {
        return await productRepository.GetShowCaseProducts();
    }
}
