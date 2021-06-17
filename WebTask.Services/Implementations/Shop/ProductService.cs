using AutoMapper;
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
using WebTask.InfrastructureDTO.DTO.Product;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Services.Implementations.Shop
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        private Expression<Func<Product, bool>> GetFilterExpression(ProductFilterDTO filter)
        {
            Expression<Func<Product, bool>> eFilter = null;
            if (filter.PCategory > 0)
            {
                eFilter = p => (p.Category.Id == filter.PCategory);
            }
            if (filter.PType > 0)
            {
                if (eFilter == null)
                {
                    eFilter = p => (p.Types.Any(s => s.Id == filter.PType));
                }
                else
                {
                    eFilter = eFilter.And(p => p.Types.Any(s => s.Id == filter.PType));
                }
            }
            if (filter.MinPrice !=filter.MaxPrice)
            {
                if (eFilter == null)
                {
                    eFilter = p => ((p.SalePrice >= filter.MinPrice) && (p.SalePrice <= filter.MaxPrice));
                }
                else
                {
                    eFilter = eFilter.And(p => ((p.SalePrice >= filter.MinPrice) && (p.SalePrice <= filter.MaxPrice)));
                }

            }
            if (filter.PSize > 0)
            {
                if (eFilter == null)
                {
                    eFilter = p => (p.Sizes.Any(s => s.Id == filter.PSize));
                }
                else
                {
                    eFilter = eFilter.And(p => p.Sizes.Any(s => s.Id == filter.PSize));
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
            var eFilter = GetFilterExpression(filter);
            IQueryable<Product> products;
            if (eFilter == null)
            {
                products = _productRepository.GetAll();
            }
            else
            {
                products = _productRepository.GetWhere(eFilter);
            }
            products = filter.PSort switch
            {
                PSort.PriceAsc => products.OrderBy(s => s.SalePrice),
                PSort.PriceDesc => products.OrderByDescending(s => s.SalePrice),
                PSort.DateAsc => products.OrderBy(s => s.CreatedDate),
                PSort.DateDesc => products.OrderByDescending(s => s.CreatedDate),
                _ => products.OrderBy(s => s.SaleEndDate)
            };
            var model = await products.Take(filter.ItemsCount + filter.ItemsPerPage).ToListAsync();
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

        public async Task<DetailDTO> GetProductDetailAsync(long id)
        {
            var product = await _productRepository.GetOneWithIncludeAsync(id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<DetailDTO>(product);
        }

        public async Task<bool> UpdateProductAsync(DetailDTO detailDTO)
        {
            var product = _mapper.Map<Product>(detailDTO);

            return await _productRepository.UpdateProductAsync(product);
        }
    }
}
