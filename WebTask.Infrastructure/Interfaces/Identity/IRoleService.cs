using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<ChangeRoleDTO> GetUserRoles(string id);
        Task<bool> EditUserRoles(string userId, List<string> roles);
    }
}
