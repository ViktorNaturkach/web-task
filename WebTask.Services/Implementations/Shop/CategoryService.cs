using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Infrastructure.Interfaces.Repository;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Services.Implementations.Shop
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository  _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = _categoryRepository.GetAll().Select(record => new CategoryDTO
            {
                Id = record.Id,
                Name = record.Name,
            });
            return await categories.ToListAsync();
        }
    }
}
