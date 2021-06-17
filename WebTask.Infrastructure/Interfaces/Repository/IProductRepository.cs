using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Common.Enums;
using WebTask.InfrastructureDTO.DTO.Product;

namespace WebTask.Infrastructure
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        Task<decimal?> GetMinAsync(Expression<Func<Product, decimal?>> selector);
        Task<decimal?> GetMaxAsync(Expression<Func<Product, decimal?>> selector);
        Task<decimal?> GetWhereMinAsync(Expression<Func<Product, bool>> expression,Expression<Func<Product, decimal?>> selector);
        Task<decimal?> GetWhereMaxAsync(Expression<Func<Product, bool>> expression, Expression<Func<Product, decimal?>> selector);
        Task<Product> GetOneWithIncludeAsync(long id);
        Task<bool> UpdateProductAsync(Product product);
    }
}
