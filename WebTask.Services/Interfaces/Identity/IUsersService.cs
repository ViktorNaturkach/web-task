using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.EFData.Entities;
using WebTask.Services.DTO;

namespace WebTask.Services.Interfaces
{
    public interface IUsersService
    {
        UsersListDTO GetUsers();
        Task<UserDTO> GetUserAsync(string id);
        Task<IdentityResult> UpdateUserAsync(UserDTO user);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
