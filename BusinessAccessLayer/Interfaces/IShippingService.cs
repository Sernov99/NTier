using BusinessAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Interfaces
{
    interface IShippingService
    {
        void MakeShipping(ShippingDTO shippingDto);
        ProductDTO GetProduct(int? id);
        List<ProductDTO> GetProducts();
    }
}
