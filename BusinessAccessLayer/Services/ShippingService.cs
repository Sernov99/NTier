using BusinessAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.DTO;
using DataAccessLayer.Enteties;
using DataAccessLayer.Repositories;

namespace BusinessAccessLayer.Services
{
    public class ShippingService : IShippingService
    {
        ShippingRepository shippings_repo;
        ProductRepository product_repo;

        public ShippingService()
        {
            shippings_repo = new ShippingRepository();
            product_repo = new ProductRepository();
        }

        ProductDTO IShippingService.GetProduct(int? id)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void MakeShipping(DTO.ShippingDTO shippingDto)
        {
            //TODO: Data Validation
            Product p = product_repo.Get(shippingDto.Product_id);
            if(p == null)
            {
                throw new NotImplementedException();
            }

            ////////////////////
            DataAccessLayer.Enteties.Shipping newshp = new DataAccessLayer.Enteties.Shipping();
            newshp.FirstName = shippingDto.FirstName;
            newshp.LastName = shippingDto.LastName;
            newshp.Address = shippingDto.Address;
            newshp.Product_id = shippingDto.Product_id;
            shippings_repo.Create(newshp);

        }

       
    }
}
