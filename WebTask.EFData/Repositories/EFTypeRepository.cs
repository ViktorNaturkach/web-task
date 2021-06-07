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
    }
}
