using BusinessAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.DTO;
using DataAccessLayer.Enteties;
using DataAccessLayer.Repositories;
using BusinessAccessLayer.Infrastructure;
using AutoMapper;

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

       public ProductDTO GetProduct(int id)
        {
            ProductDTO tmp = new ProductDTO();
            Product tmp1 = product_repo.Get(id);
            tmp.ID = tmp1.ID;
            tmp.Name = tmp1.Name;
            return tmp;
        }

        public List<ProductDTO> GetProducts()
        {
            List <Product> all_products = product_repo.GetAll();
            List<ProductDTO> all_products_result = new List <ProductDTO>();

            for (var i = 0; i < all_products.Count; i++)
            {

                ProductDTO tmp = new ProductDTO();
                tmp.ID = all_products[i].ID;
                tmp.Name = all_products[i].Name;
                all_products_result.Add(tmp);
            }

            return all_products_result;

                
        }

        public void MakeShipping(DTO.ShippingDTO shippingDto)
        {
            
            Product p = product_repo.Get(shippingDto.Product_id);

            if (p == null)
            {
                throw new ValidationException("Error phone ID!","");
            }

            Shipping newshp = new Shipping();
            newshp.Product_id = shippingDto.Product_id;
            if (shippingDto.FirstName == null)
            {
                throw new ValidationException("Error phone First Name!", "");
            }
            if (shippingDto.LastName==null)
            {
                throw new ValidationException("Error Last Name!", "");
            }
            if (shippingDto.Address==null)
            {
                throw new ValidationException("Error Address!", "");
            }

            newshp.FirstName = shippingDto.FirstName;
            newshp.LastName = shippingDto.LastName;
            newshp.Address = shippingDto.Address;
            
            shippings_repo.Create(newshp);

        }

       
    }
}
