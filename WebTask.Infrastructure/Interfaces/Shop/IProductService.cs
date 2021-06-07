
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Enums;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Infrastructure.Interfaces.Shop
{
    public interface IProductService
    {
        Task<int> GetProductsCountWhereAsync(ProductFilterDTO filter);
        Task<IEnumerable<ProductDTO>> GetProductsAsync(ProductFilterDTO filter);
        Task<decimal> GetMinProductPriceAsync(ProductFilterDTO filter);
        Task<decimal> GetMaxProductPriceAsync(ProductFilterDTO filter);
    }
}
