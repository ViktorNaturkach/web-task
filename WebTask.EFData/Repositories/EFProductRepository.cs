using System.Collections.Generic;
using WebTask.Common;

namespace WebTask.EFData
{
    public class EFProductRepository : IProductRepository
    {
        private AppDbContext context;

        public EFProductRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Product> GetProducts()
        {
            return (IEnumerable<Product>)context.Products;
        }
    }
}
