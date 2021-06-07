using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTask.Common.Constants;
using WebTask.Common.Enums;

namespace WebTask.InfrastructureDTO.DTO.Shop
{
    public class ProductFilterDTO
    {
        public ProductFilterDTO()
        {
            itemsCount = 0;
            itemsPerPage = ProductFilterConstans.ITEMS_PER_PAGE;
            pSort = ProductFilterConstans.SORT_BY_DEFAULT;
            PCategory = 0;
            pType = 0;
            MinPrice = 0;
            MaxPrice = 0;
        }
        public int itemsCount { get; set; } 
        public int itemsPerPage { get; set;} 
        public PSort pSort { get; set; } 
        public  int PCategory { get; set; } 
        public int pType { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
