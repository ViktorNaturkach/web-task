using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces;
using WebTask.InfrastructureDTO;

namespace WebTask.Services.Implementations.Identity
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;

        public UsersService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserDTO userDTO)
        {
            if (_userManager.FindByEmailAsync(userDTO.Email).Result == null)
            {
                User user = new User { Email = userDTO.Email, UserName = userDTO.Email };
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    return await _userManager.AddToRolesAsync(user, userDTO.Roles);
                }
                else
                {
                    return result;
                }
            }
            return IdentityResult.Failed(new IdentityError() { Description = "User allready exist!" });

        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Description = "User not found!" });
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserDTO() { Id = user.Id, Email = user.Email, Roles = await GetUserRoles(user) };
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDTO = new List<UserDTO>();
            foreach (var item in users)
            {
                var userDTO = new UserDTO
                {
                    Id = item.Id,
                    Email = item.Email,
                    Roles = await GetUserRoles(item)
                };
                usersDTO.Add(userDTO);
            }
            return usersDTO;
        }

        public async Task<IdentityResult> UpdateUserAsync(UserDTO userDTO)
        {
            User user = await _userManager.FindByIdAsync(userDTO.Id);
            if (user != null)
            {
                user.Email = userDTO.Email;
                user.UserName = userDTO.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var addedRoles = userDTO.Roles.Except(userRoles);
                    var removedRoles = userRoles.Except(userDTO.Roles);
                    await _userManager.AddToRolesAsync(user, addedRoles);
                    await _userManager.RemoveFromRolesAsync(user, removedRoles);
                }
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Description = "User not found!" });
        }
        private async Task<List<string>> GetUserRoles(User user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
