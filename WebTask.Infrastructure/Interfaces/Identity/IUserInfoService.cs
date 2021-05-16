using System.Security.Claims;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces.Identity
{
    public interface IUserInfoService
    {
        Task<UserDTO> GetIdentityUserAsync(ClaimsPrincipal user);
    }
}
