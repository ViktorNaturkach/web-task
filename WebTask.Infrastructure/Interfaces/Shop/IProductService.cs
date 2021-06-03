
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Enums;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Infrastructure.Interfaces.Shop
{
    public interface IProductService
    {
        Task<int> GetAllProductsCount();
        Task<IEnumerable<ProductDTO>> GetProductsAsync(int itemsCount, int itemsPerPage, PSort pSort);
    }
}
