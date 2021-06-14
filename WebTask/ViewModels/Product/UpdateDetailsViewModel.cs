using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTask.Common.Entities;
using WebTask.ViewModels.Shop;

namespace WebTask.ViewModels.Product
{
    public class UpdateDetailsViewModel
    {
        public ViewDetailsViewModel ViewDetails { get; set; }
        public SelectList AllCategories { get; set; }
        public virtual IEnumerable<TypeViewModel> AllTypes { get; set; }
        public virtual IEnumerable<SizeViewModel> AllSizes { get; set; }
    }
}
