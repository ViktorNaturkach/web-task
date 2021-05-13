using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.EFData.Entities;
using WebTask.Services.DTO;
using WebTask.Services.Interfaces;

namespace WebTask.Services.Implementations
{
   public class RegisterService : IRegisterService
    {
        private readonly UserManager<User> _userManager;

        public RegisterService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterAsync(UserDTO userDTO)
        {
            User user = new User { Email = userDTO.Email, UserName = userDTO.Email };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            return result;
        }
    }
}
