using System.Collections.Generic;
using System.Linq;
using WebTask.Common;

namespace WebTask.Infrastructure
{
    public interface IProductRepository
    {
        IQueryable<Product> GetEFProducts();
    }
}
