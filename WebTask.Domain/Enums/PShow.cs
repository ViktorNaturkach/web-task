using System.ComponentModel.DataAnnotations;

namespace WebTask.Common.Enums
{
    public enum PShow : byte
    {
        [Display(Name = "Show 9")]
        Show9 = 9,
        [Display(Name = "Show 18")]
        Show18 = 18,
        [Display(Name = "Show 36")]
        Show36 = 36
    }
}
