using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTask.Infrastructure.Interfaces;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.ViewModels.Identity.Auth;

namespace WebTask.Components
{
    public class LoginStatus : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;

        public LoginStatus(IUsersService usersService, IUserInfoService userInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userDTO = await _userInfoService.GetIdentityUserAsync(HttpContext.User);
            UserIdentityViewModel model = _mapper.Map<UserIdentityViewModel>(userDTO);

            if (model != null)
            {
                return View("LoggedIn", model);
            }
            else
            {
                return View();
            }
        }
    }
}
