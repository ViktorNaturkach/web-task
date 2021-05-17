using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Shop
{
    public class ProductListViewModel
    {
        public List<ProductViewModel> products { get; set; }

        public ProductListViewModel()
        {
            products = new List<ProductViewModel>();
        }
    }
}
