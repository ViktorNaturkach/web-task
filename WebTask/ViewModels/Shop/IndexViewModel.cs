﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Shop
{
    public class IndexViewModel
    {
        public int TotalProducts { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
