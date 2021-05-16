using System.Collections.Generic;


namespace WebTask.InfrastructureDTO
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
