using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Infrastructure.Interfaces.Repository;
using WebTask.Infrastructure.Interfaces.Shop;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Services.Implementations.Shop
{
    public class SizeService :ISizeService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<SizeDTO>> GetSizesAsync()
        {
            var sizes = _sizeRepository.GetAll().Select(record => new SizeDTO
            {
                Id = record.Id,
                Name = record.Name,
            });
            return await sizes.ToListAsync();
        }
    }
}
