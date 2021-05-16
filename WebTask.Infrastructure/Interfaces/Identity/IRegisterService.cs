using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebTask.InfrastructureDTO;

namespace WebTask.Infrastructure.Interfaces
{
   public interface IRegisterService
    {
        Task<IdentityResult> RegisterAsync(UserDTO user);
    }
}
