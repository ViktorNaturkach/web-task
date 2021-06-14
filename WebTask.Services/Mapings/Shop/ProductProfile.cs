using AutoMapper;
using WebTask.Common;
using WebTask.InfrastructureDTO.DTO.Product;

namespace WebTask.Services.Mapings.Shop
{
    class ProductProfile :Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, DetailDTO>().ReverseMap();
        }
    }
}
