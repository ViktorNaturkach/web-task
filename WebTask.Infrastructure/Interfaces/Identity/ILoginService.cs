using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces
{
    public interface ILoginService
    {
        Task<SignInResult> LoginAsync(UserDTO user, bool rememberMe);
    }
}
