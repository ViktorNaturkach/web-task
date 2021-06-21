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
    public class EFTypeRepository : EFBaseRepository<ProductType>, ITypeRepository
    {
        public EFTypeRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<ProductType> GetOneAsync(long id)
        {
            return await _context.Set<ProductType>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
