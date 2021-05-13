using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.EFData.Entities;
using WebTask.Services.DTO;
using WebTask.Services.Interfaces;

namespace WebTask.Services.Implementations.Identity
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;

        public UsersService(UserManager<User> userManager)
        {
            _userManager = userManager;
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
            return new UserDTO() { Id = user.Id, Email = user.Email };
        }

        public UsersListDTO GetUsers()
        {
            var usersList = from record in _userManager.Users.ToList()
                   select new UserDTO
                   {
                       Id = record.Id,
                       Email = record.Email
                   };
            return new UsersListDTO() { users = usersList.ToList()};
        }

        public async Task<IdentityResult> UpdateUserAsync(UserDTO userDTO)
        {
            User user = await _userManager.FindByIdAsync(userDTO.Id);
            if (user != null)
            {
                user.Email = userDTO.Email;
                user.UserName = userDTO.Email;

                var result = await _userManager.UpdateAsync(user);
                return result;
            }
            return IdentityResult.Failed(new IdentityError() { Description = "User not found!" });
        } 
    }
}
