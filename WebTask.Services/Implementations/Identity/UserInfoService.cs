
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.InfrastructureDTO;

namespace WebTask.Services.Implementations.Identity
{
    public class UserInfoService : IUserInfoService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public UserInfoService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserDTO> GetIdentityUserAsync(ClaimsPrincipal user)
        {
            if (_signInManager.IsSignedIn(user))
            {
                var userIdentity = await _userManager.GetUserAsync(user);

                return new UserDTO{Email=userIdentity.Email};
            }
            else
            {
                return null;
            }
        }
    }
}
