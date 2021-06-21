using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Common.Entities;
using WebTask.Common.Enums;
using WebTask.EFData.Repositories;
using WebTask.Infrastructure;
using WebTask.Infrastructure.Interfaces.Repository;
using WebTask.InfrastructureDTO.DTO.Product;

namespace WebTask.EFData
{
    public class EFProductRepository : EFBaseRepository<Product>, IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ITypeRepository _typeRepository;
        public EFProductRepository(AppDbContext context, ICategoryRepository categoryRepository, ISizeRepository sizeRepository, ITypeRepository typeRepository) : base(context)
        {
            _categoryRepository = categoryRepository;
            _sizeRepository = sizeRepository;
            _typeRepository = typeRepository;
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
            var product = await _context.Products.Include(p => p.Sizes).Include(p => p.Types).FirstOrDefaultAsync(m => m.Id == _product.Id);
            if (product == null)
            {
                return false;
            }
            var category = await _categoryRepository.GetOneAsync(_product.Category.Id);
            if (category == null)
            {
                return false;
            }
            var newSizeIds = _product.Sizes.Select(s => s.Id).ToList();
            foreach (var item in product.Sizes.ToList())
            {
                if (!newSizeIds.Contains(item.Id))
                    product.Sizes.Remove(item);
            }
            foreach (var newSizeId in newSizeIds)
            {
                if (!product.Sizes.Any(s => s.Id == newSizeId))
                {
                    var productSize = await _sizeRepository.GetOneAsync(newSizeId);
                    if (productSize == null)
                    {
                        return false;
                    }
                    product.Sizes.Add(productSize);
                }
            }
            var newTypeIds = _product.Types.Select(t => t.Id).ToList();
            foreach (var item in product.Types.ToList())
            {
                if (!newTypeIds.Contains(item.Id))
                    product.Types.Remove(item);
            }
            foreach (var newTypeId in newTypeIds)
            {
                if (!product.Types.Any(t => t.Id == newTypeId))
                {
                    var productType = await _typeRepository.GetOneAsync(newTypeId);
                    if (productType == null)
                    {
                        return false;
                    }
                    product.Types.Add(productType);
                }
            }

            product.BigImageSrc = _product.BigImageSrc;
            product.Category = category;
            product.Description = _product.Description;
            product.Name = _product.Name;
            product.Price = _product.Price;
            product.SalePrice = _product.SalePrice;
           //_context.Entry(_product).State = EntityState.Detached;

        _context.Entry(product).State = EntityState.Modified;

            _context.SaveChanges(); 
            return true;
           
        }
    }
}
