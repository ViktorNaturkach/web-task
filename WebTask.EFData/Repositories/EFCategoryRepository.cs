using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.Infrastructure.Interfaces.Repository;

namespace WebTask.EFData.Repositories
{
    class EFCategoryRepository : EFBaseRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Category> GetOneAsync(long id)
        {
            return await _context.Set<Category>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
