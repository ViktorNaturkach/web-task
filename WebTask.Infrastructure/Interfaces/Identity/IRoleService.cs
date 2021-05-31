using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;
using WebTask.InfrastructureDTO.DTO.Identity;

namespace WebTask.Infrastructure.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<ChangeRoleDTO> GetUserRoles(string id);
        Task<bool> EditUserRoles(string userId, List<string> roles);
        IEnumerable<RoleDTO> GetIdentityRoles();
        Task<IdentityResult> CreateRoleAsync(RoleDTO role);
        Task<IdentityResult> DeleteRoleAsync(string id);
    }
}
