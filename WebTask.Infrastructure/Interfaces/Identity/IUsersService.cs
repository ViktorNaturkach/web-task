using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetUserAsync(string id);
        Task<IdentityResult> CreateUserAsync(UserDTO user);
        Task<IdentityResult> UpdateUserAsync(UserDTO user);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
