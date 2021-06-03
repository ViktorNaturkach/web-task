using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Entities;

namespace WebTask.Infrastructure
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<int> CountAllAsync();
        Task<int> CountWhereAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
    }
}
