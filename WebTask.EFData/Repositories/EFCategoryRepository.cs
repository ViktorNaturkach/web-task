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
    }
}
