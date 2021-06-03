using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Common.Enums;

namespace WebTask.Infrastructure
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        IQueryable<Product> GetProductsWhereAsync(int itemsCount, int itemsPerPage, PSort pSort);
       
    }
}
