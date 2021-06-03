using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Enums;
using WebTask.Infrastructure;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Services.Implementations.Shop
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> GetAllProductsCount()
        {
            return await _productRepository.CountAllAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync(int itemsCount, int itemsPerPage, PSort pSort)
        {
            var productsList = _productRepository.GetProductsWhereAsync(itemsCount, itemsPerPage, pSort).Select (record => new ProductDTO
            {
                Id = record.Id,
                Name = record.Name,
                Price = record.Price,
                SalePrice = record.SalePrice,
                ImageSrc = record.ImageSrc
            });
            return await productsList.ToListAsync();
        }

    }
}
