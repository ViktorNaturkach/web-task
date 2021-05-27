using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.Common
{
    public class Product
    {
        public int ProductID { get; set; }
        public DateTime  DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleEndDate { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Tag { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ImageSrc { get; set; }



    }
}
