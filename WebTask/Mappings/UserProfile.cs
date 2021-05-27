using AutoMapper;
using WebTask.ViewModels;
using WebTask.ViewModels.Identity.Users;
using WebTask.InfrastructureDTO;
using WebTask.ViewModels.Identity.Auth;

namespace WebTask.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginViewModel, UserDTO>().ReverseMap();
            CreateMap<RegisterViewModel, UserDTO>().ReverseMap();
            CreateMap<UserIdentityViewModel, UserDTO>().ReverseMap();
            CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            CreateMap<EditUserViewModel, UserDTO>().ReverseMap();
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
            CreateMap<UsersListViewModel, UsersListDTO>().ReverseMap();
            CreateMap<ChangeRoleViewModel,ChangeRoleDTO>().ReverseMap();
        }
    }
}
