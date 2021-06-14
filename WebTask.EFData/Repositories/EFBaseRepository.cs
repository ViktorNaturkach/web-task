using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.Infrastructure;

namespace WebTask.EFData.Repositories
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected AppDbContext _context;

        public EFBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAllAsync() => await _context.Set<T>().CountAsync();

        public async Task<int> CountWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().CountAsync(expression);
        }
        public IQueryable<T> GetAll() => _context.Set<T>().AsNoTracking();
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression) => _context.Set<T>()
                .Where(expression).AsNoTracking();
    }
}
