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
    }
}
