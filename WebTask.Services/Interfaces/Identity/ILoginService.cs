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
    public interface ILoginService
    {
        Task<SignInResult> LoginAsync(UserDTO user, bool rememberMe);
    }
}
