using System;
using System.Collections.Generic;
using System.Linq;

namespace WebTask.InfrastructureDTO.DTO.Shop
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public DateTimeOffset SaleEndDate { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Tag { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ImageSrc { get; set; }
    }
}
