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
            ItemsCount = 0;
            ItemsPerPage = ProductFilterConstans.ITEMS_PER_PAGE;
            PSort = ProductFilterConstans.SORT_BY_DEFAULT;
            PCategory = 0;
            PType = 0;
            MinPrice = 0;
            MaxPrice = 0;
            PSize = 0;
        }
        public int ItemsCount { get; set; } 
        public int ItemsPerPage { get; set;} 
        public PSort PSort { get; set; } 
        public  int PCategory { get; set; } 
        public int PType { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int PSize { get; set; }
    }
}
