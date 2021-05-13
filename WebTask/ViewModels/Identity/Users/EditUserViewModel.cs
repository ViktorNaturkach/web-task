using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Name / Email")]
        public string Email { get; set; }
    }
}
