using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.ViewModels.Shop;

namespace WebTask.ViewModels.Product
{
    public class ViewDetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string ImageSrc { get; set; }
        public string BigImageSrc { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<TypeViewModel> Types { get; set; }
        public virtual ICollection<SizeViewModel> Sizes { get; set; }

        public ViewDetailsViewModel()
        {
            Sizes = new List<SizeViewModel>();
            Types = new List<TypeViewModel>();
            Category = new Category();
        }
    }
}
