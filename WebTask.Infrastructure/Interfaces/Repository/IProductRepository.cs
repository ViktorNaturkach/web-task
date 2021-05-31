using System.Collections.Generic;
using System.Linq;
using WebTask.Common;
using WebTask.Common.Enums;

namespace WebTask.Infrastructure
{
    public interface IProductRepository
    {
        int GetEFAllProductsCount();
        IQueryable<Product> GetEFProducts(int page, int itemsPerPage, PSort pSort);
       
    }
}
