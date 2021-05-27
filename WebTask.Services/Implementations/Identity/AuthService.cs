using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.InfrastructureDTO;

namespace WebTask.Services.Implementations.Identity
{
    public class AuthService :IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<SignInResult> LoginAsync(UserDTO user, bool rememberMe)
        {
            var result =
                    await _signInManager.PasswordSignInAsync(user.Email, user.Password, rememberMe, false);
            return result;
        }

        public async Task LogoutAsync() => await _signInManager.SignOutAsync();

        public async Task<IdentityResult> RegisterAsync(UserDTO userDTO)
        {
            User user = new User { Email = userDTO.Email, UserName = userDTO.Email };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            return result;
        }
    }
}
