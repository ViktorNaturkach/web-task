using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Services.DTO;

namespace WebTask.Services.Interfaces
{
   public interface IRegisterService
    {
        Task<IdentityResult> RegisterAsync(UserDTO user);
    }
}
