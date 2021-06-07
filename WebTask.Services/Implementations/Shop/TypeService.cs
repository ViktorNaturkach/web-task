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
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IEnumerable<TypeDTO>> GetTypesAsync()
        {
            var types = _typeRepository.GetAll().Select(record => new TypeDTO
            {
                Id = record.Id,
                Name = record.Name,
            });
            return await types.ToListAsync();
        }
    }
}
