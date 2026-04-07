using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await categoryRepository.GetAllCategoriesAsync();
    }
}
