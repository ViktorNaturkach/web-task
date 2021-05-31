using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTask.ViewModels.Identity.Roles;

namespace WebTask.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name / Email")]
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AllRoles { get; set; }
 
    }
}
