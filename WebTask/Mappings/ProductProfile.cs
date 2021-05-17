using AutoMapper;
using WebTask.InfrastructureDTO.DTO.Shop;
using WebTask.ViewModels.Shop;

namespace WebTask.Mappings
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<ProductListViewModel, ProductListDTO>().ReverseMap();
        }
    }
}
