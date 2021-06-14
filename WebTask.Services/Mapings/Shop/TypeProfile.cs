using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.Services.Mapings.Shop
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<TypeDTO, ProductType>().ReverseMap();
        }
    }
}
