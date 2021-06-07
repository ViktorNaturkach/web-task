using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO.DTO.Shop;
using WebTask.ViewModels.Shop;

namespace WebTask.Mappings
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, CategoryDTO>().ReverseMap();
        }
    }
}
