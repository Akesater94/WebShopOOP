using Entities.Models;
using Services.DTOs;
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

    public async Task<Product?> GetProductAsync(int id)
    {
        return await productRepository.GetProductAsync(id);
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

    public async Task<List<Product>> SearchProductsAsync(string searchWord)
    {
        return await productRepository.SearchProductsAsync(searchWord);
    }

    public async Task<List<MostSoldProductDTO>> GetMostSoldProductsAsync()
    {
        return await productRepository.GetMostSoldProductsAsync();
    }
}
