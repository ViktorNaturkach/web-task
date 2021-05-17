using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTask.InfrastructureDTO.DTO.Shop
{
    public class ProductListDTO
    {
        public List<ProductDTO> products { get; set; }

        public ProductListDTO()
        {
            products = new List<ProductDTO>();
        }
    }
}
