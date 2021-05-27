using System.Collections.Generic;
using System.Linq;
using WebTask.Common;

namespace WebTask.Infrastructure
{
    public interface IProductRepository
    {
        int GetEFAllProductsCount();
        IQueryable<Product> GetEFProducts(int page, int itemsPerPage);
       
    }
}
