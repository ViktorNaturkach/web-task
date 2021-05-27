using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces.Identity
{
    public interface IAuthService
    {
        Task<SignInResult> LoginAsync(UserDTO user, bool rememberMe);
        Task<IdentityResult> RegisterAsync(UserDTO user);

        Task LogoutAsync();
    }
}
