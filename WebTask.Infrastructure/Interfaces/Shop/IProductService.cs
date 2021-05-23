
using System.Collections.Generic;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Infrastructure.Interfaces.Shop
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
    }
}
