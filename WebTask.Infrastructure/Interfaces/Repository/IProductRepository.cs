using System.Collections.Generic;
using WebTask.Common;

namespace WebTask.EFData
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
