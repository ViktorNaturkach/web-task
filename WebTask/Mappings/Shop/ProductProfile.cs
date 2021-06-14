using AutoMapper;
using WebTask.InfrastructureDTO.DTO.Product;
using WebTask.InfrastructureDTO.DTO.Shop;
using WebTask.ViewModels.Product;
using WebTask.ViewModels.Shop;

namespace WebTask.Mappings
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<ViewDetailsViewModel, DetailDTO>().ReverseMap();
        }
    }
}
