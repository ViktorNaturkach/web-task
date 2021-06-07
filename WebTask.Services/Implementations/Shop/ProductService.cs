using Microsoft.EntityFrameworkCore;
using NPoco.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Common.Enums;
using WebTask.Infrastructure;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Services.Implementations.Shop
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private Expression<Func<Product, bool>> GetFilterExpression(ProductFilterDTO filter)
        {
            Expression<Func<Product, bool>> eFilter = null;
            if (filter.PCategory > 0)
            {
                eFilter = p => (p.Category.Id == filter.PCategory);
            }
            if (filter.pType > 0)
            {
                if (eFilter == null)
                {
                    eFilter = p => (p.ProductType.Id == filter.pType);
                }
                else
                {
                    eFilter = eFilter.And(p => (p.ProductType.Id == filter.pType));
                }
            }
            return eFilter;
        }

        public async Task<int> GetProductsCountWhereAsync(ProductFilterDTO filter)
        {
            var eFilter = GetFilterExpression(filter);
            if (eFilter == null)
            {
                return await _productRepository.CountAllAsync();
            }
            return await _productRepository.CountWhereAsync(eFilter);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync(ProductFilterDTO filter)
        {
            var products = filter.PCategory switch
            {
                0 => _productRepository.GetAll(),
                _ => _productRepository.GetWhere(c => (c.Category.Id == filter.PCategory))
            };
           products = filter.pType switch
            {
                0 => products,
                _ => products.Where(t => t.ProductType.Id == filter.pType)
            };
            products = filter.pSort switch
            {
                PSort.PriceAsc => products.OrderBy(s => s.SalePrice),
                PSort.PriceDesc => products.OrderByDescending(s => s.SalePrice),
                PSort.DateAsc => products.OrderBy(s => s.CreatedDate),
                PSort.DateDesc => products.OrderByDescending(s => s.CreatedDate),
                _ => products.OrderBy(s => s.SaleEndDate)
            };
            var model = await products.Take(filter.itemsCount + filter.itemsPerPage).ToListAsync();
            return model.Select (record => new ProductDTO
            {
                Id = record.Id,
                Name = record.Name,
                Price = record.Price,
                SalePrice = record.SalePrice,
                ImageSrc = record.ImageSrc
            });
        }
        public async Task<decimal> GetMinProductPriceAsync(ProductFilterDTO filter)
        {
            var eFilter = GetFilterExpression(filter);
            if (eFilter == null)
            {
                return (await _productRepository.GetMinAsync(x => (decimal?)x.SalePrice)) ?? 0;
            }
            return (await _productRepository.GetWhereMinAsync(eFilter, x => (decimal?)x.SalePrice)) ?? 0;
         }
        public async Task<decimal> GetMaxProductPriceAsync(ProductFilterDTO filter)
        {
            var eFilter = GetFilterExpression(filter);
            if (eFilter == null)
            {
                return (await _productRepository.GetMaxAsync(x => (decimal?)x.SalePrice)) ?? 0;
            }
            return (await _productRepository.GetWhereMaxAsync(eFilter, x => (decimal?)x.SalePrice)) ?? 0;
        }
    }
}
