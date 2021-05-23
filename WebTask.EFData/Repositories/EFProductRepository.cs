using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Product> GetEFProducts()
        {
            return context.Products;
        }
    }
}
