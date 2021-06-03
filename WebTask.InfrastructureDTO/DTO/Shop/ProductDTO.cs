using System;
using System.Collections.Generic;
using System.Linq;

namespace WebTask.InfrastructureDTO.DTO.Shop
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public DateTimeOffset SaleEndDate { get; set; }
        public string ImageSrc { get; set; }
    }
}
