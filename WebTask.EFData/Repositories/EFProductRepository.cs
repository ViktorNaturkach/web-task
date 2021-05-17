using System.Collections.Generic;
using WebTask.Common;
using WebTask.Infrastructure;

namespace WebTask.EFData
{
    public class EFProductRepository : IProductRepository
    {
        private AppDbContext context;

        public EFProductRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Product> GetEFProducts()
        {
            return (IEnumerable<Product>)context.Products;
        }
    }
}
