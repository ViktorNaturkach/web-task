using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.ViewModels.Shop;

namespace WebTask.ViewModels.Product
{
    public class UpdateDetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal SalePrice { get; set; }
        public string ImageSrc { get; set; }
        public string BigImageSrc { get; set; }
        [Required]
        public Category Category { get; set; }
        public virtual List<TypeViewModel> Types { get; set; }
        public virtual List<SizeViewModel> Sizes { get; set; }
        public SelectList AllCategories { get; set; }
        public virtual List<TypeViewModel> AllTypes { get; set; }
        public virtual List<SizeViewModel> AllSizes { get; set; }
    }
}
