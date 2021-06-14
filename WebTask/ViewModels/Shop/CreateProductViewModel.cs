using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Shop
{
    public class CreateProductViewModel
    {
        public int ProductID { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        [Required(ErrorMessage = "Please enter a product name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description!")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positiv price!")]
        public decimal Price { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positiv price!")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Please specify a category!")]
        public DateTimeOffset SaleEndDate { get; set; }
        public string Size { get; set; }
        public string ImageSrc { get; set; }
    }
}
