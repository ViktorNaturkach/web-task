using System.Collections.Generic;
using System.Linq;
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

        public int GetAllProductsCount()
        {
            return _productRepository.GetEFAllProductsCount();
        }

        public IEnumerable<ProductDTO> GetProducts(int itemsCount, int itemsPerPage, PSort pSort)
        {
            var productsList = _productRepository.GetEFProducts(itemsCount, itemsPerPage, pSort).Select(record => new ProductDTO
            {
                ProductID = record.ProductID,
                Name = record.Name,
                Price = record.Price,
                SalePrice = record.SalePrice,
                Category = record.Category,
                ImageSrc = record.ImageSrc
            });
            return productsList;
        }
    }
}
