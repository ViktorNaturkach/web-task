using System.Collections.Generic;
using System.Linq;
using WebTask.Common;
using WebTask.Infrastructure;

namespace WebTask.EFData
{
    public class EFProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public EFProductRepository(AppDbContext ctx)
        {
            _context = ctx;
        }

        public int GetEFAllProductsCount()
        {
            return _context.Products.Count();
        }

        public IQueryable<Product> GetEFProducts(int page, int itemsPerPage)
        {
            IQueryable<Product> products = _context.Products;
            return  products.Take(page * itemsPerPage);
        }
    }
}
