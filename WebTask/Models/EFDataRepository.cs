using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.Models
{
    public class EFDataRepository : IDataRepository
    {
        private AppDbContext context;

        public EFDataRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;

        public IEnumerable<Product> GetProducts()
        {
            return context.Products   .ToArray();
        }
    }
}
