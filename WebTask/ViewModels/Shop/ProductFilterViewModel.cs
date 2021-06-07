using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Entities;

namespace WebTask.ViewModels.Shop
{
    public class ProductFilterViewModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<TypeViewModel> Types { get; set; }
        public IEnumerable<SizeViewModel> Sizes { get; set; }
    }
}
