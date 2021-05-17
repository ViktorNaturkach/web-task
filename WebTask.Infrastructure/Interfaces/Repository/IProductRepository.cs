using System.Collections.Generic;
using WebTask.Common;

namespace WebTask.Infrastructure
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetEFProducts();
    }
}
