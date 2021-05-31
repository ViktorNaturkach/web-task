using AutoMapper;
using WebTask.InfrastructureDTO.DTO.Identity;
using WebTask.ViewModels.Identity.Roles;

namespace WebTask.Mappings
{
    public class RoleProfile : Profile
    {
        

        public RoleProfile()
        {
            CreateMap<RoleViewModel, RoleDTO>().ReverseMap();
            CreateMap<CreateRoleViewModel, RoleDTO>().ReverseMap();
        }
    }
}
