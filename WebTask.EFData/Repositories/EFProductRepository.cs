using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Common.Enums;
using WebTask.EFData.Repositories;
using WebTask.Infrastructure;

namespace WebTask.EFData
{
    public class EFProductRepository : EFBaseRepository<Product>, IProductRepository
    {
        public EFProductRepository(AppDbContext context) : base(context)
        {
        }
        public IQueryable<Product> GetProductsWhereAsync(int itemsCount, int itemsPerPage, PSort pSort)
        {
            var products = GetAll().Take(itemsCount + itemsPerPage);
            products = pSort switch
            {
                PSort.PriceAsc => products.OrderBy(s => s.SalePrice),
                PSort.PriceDesc => products.OrderByDescending(s => s.SalePrice),
                PSort.DateAsc => products.OrderBy(s => s.CreatedDate),
                PSort.DateDesc => products.OrderByDescending(s => s.CreatedDate),
                _ => products.OrderBy(s => s.SaleEndDate),
            };

            return  products;
        }
    }
}
