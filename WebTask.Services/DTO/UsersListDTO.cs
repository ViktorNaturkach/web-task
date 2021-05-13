using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.Services.DTO
{
    public class UsersListDTO
    {
        public List<UserDTO> users { get; set; }

        public UsersListDTO()
        {
            users = new List<UserDTO>();
        }
    }
}
