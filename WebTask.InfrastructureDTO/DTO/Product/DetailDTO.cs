using System;
using System.Collections.Generic;
using WebTask.Common.Entities;
using WebTask.InfrastructureDTO.DTO.Shop;

namespace WebTask.InfrastructureDTO.DTO.Product
{
    public class DetailDTO
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public DateTimeOffset SaleEndDate { get; set; }
        public string ImageSrc { get; set; }
        public string BigImageSrc { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<TypeDTO> Types { get; set; }
        public virtual ICollection<SizeDTO> Sizes { get; set; }

        public DetailDTO()
        {
            Sizes = new List<SizeDTO>();
            Types = new List<TypeDTO>();
        }
    }
}
