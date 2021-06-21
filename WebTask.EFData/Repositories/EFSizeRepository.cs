using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.Infrastructure;
using WebTask.Infrastructure.Interfaces.Repository;

namespace WebTask.EFData.Repositories
{
    public class EFSizeRepository : EFBaseRepository<ProductSize>, ISizeRepository
    {
        public EFSizeRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<ProductSize> GetOneAsync(long id)
        {
            return await _context.Set<ProductSize>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
