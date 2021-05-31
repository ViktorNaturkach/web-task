using System.Collections.Generic;
using System.Linq;
using WebTask.Common;
using WebTask.Common.Enums;
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

        public IQueryable<Product> GetEFProducts(int itemsCount, int itemsPerPage, PSort pSort)
        {
            IQueryable<Product> products = _context.Products;
            products = pSort switch
            {
                PSort.PriceAsc => products.OrderBy(s => s.SalePrice),
                PSort.PriceDesc => products.OrderByDescending(s => s.SalePrice),
                PSort.DateAsc => products.OrderBy(s => s.DateCreated),
                PSort.DateDesc => products.OrderByDescending(s => s.DateCreated),
                _ => products.OrderBy(s => s.SaleEndDate),
            };
            return products.Take(itemsCount + itemsPerPage);
        }
    }
}
