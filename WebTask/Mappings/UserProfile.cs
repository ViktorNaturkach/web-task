using AutoMapper;
using WebTask.EFData.Entities;
using WebTask.Services.DTO;
using WebTask.ViewModels;
using WebTask.ViewModels.Identity.Users;

namespace WebTask.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginViewModel, UserDTO>().ReverseMap();
            CreateMap<RegisterViewModel, UserDTO>().ReverseMap();
            CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
            CreateMap<EditUserViewModel, UserDTO>().ReverseMap();
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
            CreateMap<UsersListViewModel, UsersListDTO>().ReverseMap();
            CreateMap<ChangeRoleViewModel,ChangeRoleDTO>().ReverseMap();
        }
    }
}
