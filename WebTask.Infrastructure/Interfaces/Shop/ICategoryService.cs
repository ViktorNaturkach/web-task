using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Infrastructure.Interfaces.Shop
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    }
}
