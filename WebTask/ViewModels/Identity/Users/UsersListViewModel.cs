using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Identity.Users
{
    public class UsersListViewModel
    {
        public List<UserViewModel> users { get; set; }

        public UsersListViewModel()
        {
            users = new List<UserViewModel>();
        }
    }
}
