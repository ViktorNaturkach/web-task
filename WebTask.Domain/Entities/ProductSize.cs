using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.Common.Entities
{
    public class ProductSize :BaseEntity
    {
       public virtual ICollection<Product> Products { get; set; }
    }
}
