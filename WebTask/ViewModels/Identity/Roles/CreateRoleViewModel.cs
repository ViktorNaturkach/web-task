using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Identity.Roles
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string Name { get; set; }
    }
}
