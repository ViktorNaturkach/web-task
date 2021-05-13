using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Services.DTO;

namespace WebTask.Services.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<ChangeRoleDTO> GetUserRoles(string id);
        Task<bool> EditUserRoles(string userId, List<string> roles);
    }
}
