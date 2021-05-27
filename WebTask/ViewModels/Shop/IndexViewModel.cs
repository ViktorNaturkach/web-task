﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.ViewModels.Shop
{
    public class IndexViewModel
    {
        public int LastProduct { get; set; }
        public int TotalProducts { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
