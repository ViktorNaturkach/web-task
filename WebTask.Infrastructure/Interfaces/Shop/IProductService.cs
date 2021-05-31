
using System.Collections.Generic;
using WebTask.Common.Enums;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Infrastructure.Interfaces.Shop
{
    public interface IProductService
    {
        int GetAllProductsCount();
        IEnumerable<ProductDTO> GetProducts(int itemsCount, int itemsPerPage, PSort pSort);
    }
}
