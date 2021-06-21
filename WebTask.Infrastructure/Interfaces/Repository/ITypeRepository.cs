using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Entities;

namespace WebTask.Infrastructure.Interfaces.Repository
{
    public interface ITypeRepository :IBaseRepository<ProductType>
    {
        Task<ProductType> GetOneAsync(long id);
     }
}
