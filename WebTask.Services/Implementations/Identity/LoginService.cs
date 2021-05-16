using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common;
using WebTask.Infrastructure.Interfaces;
using WebTask.InfrastructureDTO;

namespace WebTask.Services.Implementations
{
   public class LoginService : ILoginService
    {
        private readonly SignInManager<User> _signInManager;

        public LoginService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(UserDTO user, bool rememberMe)
        {
            
            var result =
                    await _signInManager.PasswordSignInAsync(user.Email, user.Password, rememberMe, false);

            return result;
        }
    }
}
