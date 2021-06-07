using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Common.Enums;

namespace WebTask.Infrastructure
{
    public interface IProductRepository :IBaseRepository<Product>
    {
        Task<decimal?> GetMinAsync(Expression<Func<Product, decimal?>> selector);
        Task<decimal?> GetMaxAsync(Expression<Func<Product, decimal?>> selector);
        Task<decimal?> GetWhereMinAsync(Expression<Func<Product, bool>> expression,Expression<Func<Product, decimal?>> selector);
        Task<decimal?> GetWhereMaxAsync(Expression<Func<Product, bool>> expression, Expression<Func<Product, decimal?>> selector);

    }
}
