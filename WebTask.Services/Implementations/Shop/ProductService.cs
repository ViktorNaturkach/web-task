using System.Linq;
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

        public ProductListDTO GetProducts()
        {
            var productsList = from record in _productRepository.GetEFProducts().ToList()
                            select new ProductDTO
                            {
                                ProductID = record.ProductID,
                                Name = record.Name,
                                Price = record.Price,
                                SalePrice =record.SalePrice,
                                Category=record.Category,
                                ImageSrc=record.ImageSrc
                                 
                            };
            
            return new ProductListDTO() { products = productsList.ToList() };

        }
    }
}
