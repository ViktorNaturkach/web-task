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
        public async Task<decimal?> GetMinAsync(Expression<Func<Product, decimal?>> selector) => await _context.Set<Product>().MinAsync(selector);

        public async Task<decimal?> GetMaxAsync(Expression<Func<Product, decimal?>> selector) => await _context.Set<Product>().MaxAsync(selector);

        public async Task<decimal?> GetWhereMinAsync(Expression<Func<Product, bool>> expression, Expression<Func<Product, decimal?>> selector)
        {
             return await _context.Set<Product>().Where(expression).MinAsync(selector);
        }

        public async Task<decimal?> GetWhereMaxAsync(Expression<Func<Product, bool>> expression, Expression<Func<Product, decimal?>> selector)
        {
            return await _context.Set<Product>().Where(expression).MaxAsync(selector);
        }
    }
}
