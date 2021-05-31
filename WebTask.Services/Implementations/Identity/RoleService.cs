using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTask.InfrastructureDTO.DTO;
using WebTask.Infrastructure.Interfaces.Identity;
using WebTask.Common;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;
using WebTask.InfrastructureDTO.DTO.Identity;

namespace WebTask.Services.Implementations.Identity
{
   public class RoleService : IRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleDTO role)
        {
            return await _roleManager.CreateAsync(new IdentityRole(role.Name));
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                return await _roleManager.DeleteAsync(role);
            }
            return IdentityResult.Failed(new IdentityError() { Description = "Role not found!" });
        }

        public async Task<bool> EditUserRoles(string userId, List<string> roles)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return true;
            }

            return false;
        }

        public IEnumerable<RoleDTO> GetIdentityRoles()
        {
            return _roleManager.Roles.Select(item => new RoleDTO
            {
                Id = item.Id,
                Name = item.Name
            });
        }

        public async Task<ChangeRoleDTO> GetUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {

                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleDTO changwRoleDTO = new ChangeRoleDTO
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return changwRoleDTO;
            }

            return null;
        }
    }
}
