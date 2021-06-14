using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.Common.Entities
{
    public class ProductType :BaseEntity
    {
        public virtual ICollection<Product> Products { get; set; }

        public ProductType()
        {
            Products = new List<Product>();
        }
    }
}
