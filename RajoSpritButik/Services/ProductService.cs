using Entities.Models;
using Services.Interfaces;

namespace Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<List<Product>> GetAllProductsByCategoryAsync(int categoryId)
    {
        return await productRepository.GetAllProductsByCategoryAsync(categoryId);
    }

    public async Task<List<Product>> GetShowCaseProductsAsync()
    {
        return await productRepository.GetShowCaseProducts();
    }

    public async Task<List<Product>> GetProductsWithDetailsAsync()
    {
        return await productRepository.GetProductsWithDetailsAsync();
    }

    public async Task<Product?> GetProductByIdWithDetailsAsync(int id)
    {
        return await productRepository.GetProductByIdWithDetailsAsync(id);
    }

    public async Task UpdateAsync(Product product)
    {
        try
        {
            await productRepository.UpdateAsync(product);
        }
        catch
        {

        }
    }
    public async Task RemoveAsync(Product product)
    {
        await productRepository.RemoveAsync(product);
    }
}
