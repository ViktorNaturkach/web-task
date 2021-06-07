using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Entities;

namespace WebTask.Common
{
    public class Product :BaseEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleEndDate { get; set; }
        public string ImageSrc { get; set; }

        public Category Category { get; set; }
        public ProductType ProductType { get; set; }
        public virtual ICollection<ProductSize> Sizes { get; set; }
    }
}
