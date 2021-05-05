using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        [Required(ErrorMessage = "Please enter a product name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a descrition!")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positiv price!")]
        public decimal Price { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positiv price!")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Please specify a category!")]
        public DateTimeOffset SaleEndDate { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please specify a brand!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please specify a tag!")]
        public string Tag { get; set; }
        [Required(ErrorMessage = "Please specify a color!")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please specify a size!")]
        public string Size { get; set; }
        public string ImageSrc { get; set; }



    }
}
