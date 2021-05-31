using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.Common.Enums
{
    public enum PSort
    {
        [Display(Name = "First promotional")]
        Promotional,
        [Display(Name = "Price : low to high")]
        PriceAsc,
        [Display(Name = "Price : high to low")]
        PriceDesc,
        [Display(Name = "Date : oldest to newest")]
        DateAsc,
        [Display(Name = "Date : newest to oldest")]
        DateDesc
    }
}
