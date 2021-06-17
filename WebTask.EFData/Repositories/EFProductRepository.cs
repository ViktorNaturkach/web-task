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
using WebTask.InfrastructureDTO.DTO.Product;

namespace WebTask.EFData
{
    public class EFProductRepository : EFBaseRepository<Product>, IProductRepository
    {
        public EFProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<decimal?> GetMinAsync(Expression<Func<Product, decimal?>> selector) => await _context.Set<Product>().AsNoTracking().MinAsync(selector);

        public async Task<decimal?> GetMaxAsync(Expression<Func<Product, decimal?>> selector) => await _context.Set<Product>().AsNoTracking().MaxAsync(selector);

        public async Task<decimal?> GetWhereMinAsync(Expression<Func<Product, bool>> expression, Expression<Func<Product, decimal?>> selector)
        {
             return await _context.Set<Product>().Where(expression).AsNoTracking().MinAsync(selector);
        }

        public async Task<decimal?> GetWhereMaxAsync(Expression<Func<Product, bool>> expression, Expression<Func<Product, decimal?>> selector)
        {
            return await _context.Set<Product>().Where(expression).AsNoTracking().MaxAsync(selector);
        }
        public async Task<Product> GetOneWithIncludeAsync(long id)
        {
            return await _context.Set<Product>().Include(p => p.Types).Include(p => p.Sizes).Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> UpdateProductAsync(Product _product)
        {
            var product = await _context.Products.Include(p => p.Types).Include(p => p.Sizes).FirstOrDefaultAsync(m => m.Id == _product.Id);
            if (product == null)
            {
                return false;
            }
            product.BigImageSrc = _product.BigImageSrc;
            product.Category = _product.Category;
            product.Description = _product.Description;
            product.Name = _product.Name;
            product.Price = _product.Price;
            product.SalePrice = _product.SalePrice;
           // product.Sizes = _product.Sizes;
            //product.Types = _product.Types;
            _context.SaveChanges(); 
            return true;
           
        }
    }
}
