using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces
{
    public interface IUsersService
    {
        UsersListDTO GetUsers();
        Task<UserDTO> GetUserAsync(string id);
        Task<IdentityResult> UpdateUserAsync(UserDTO user);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
