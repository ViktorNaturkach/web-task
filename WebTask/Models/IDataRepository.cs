using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTask.Models
{
    public interface IDataRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
