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
using DataAccessLayer.Interfaces;

namespace BusinessAccessLayer.Services
{
    public class ShippingService : IShippingService
    {
        IUnitOfWork DataBase { get; set; }

        public ShippingService(string connectionStr)
        {
            DataBase = new EFUnitOfWork(connectionStr);
        }

       public ProductDTO GetProduct(int id)
        {

            ProductDTO tmp = new ProductDTO();
            tmp.ID = DataBase.Products.Get(id).ID;
            tmp.Name = DataBase.Products.Get(id).Name;
            return tmp;
        }

        public List<ProductDTO> GetProducts()
        {
        
            List<ProductDTO> all_products_result = new List <ProductDTO>();

            for (var i = 0; i < DataBase.Products.GetAll().Count; i++)
            {

                ProductDTO tmp = new ProductDTO();
                tmp.ID = DataBase.Products.GetAll()[i].ID;
                tmp.Name = DataBase.Products.GetAll()[i].Name;
                all_products_result.Add(tmp);
            }

            return all_products_result;


                
        }

        public void MakeShipping(ShippingDTO shippingDto)
        {
              

            if (DataBase.Products.Get(shippingDto.Product_id) == null)
            {
                throw new ValidationException("Error product ID!","");
            }

            Shipping newshp = new Shipping();
            newshp.Product_id = shippingDto.Product_id;
            if (shippingDto.FirstName == "")
            {
                throw new ValidationException("Error phone First Name!", "");
            }
            if (shippingDto.LastName== "")
            {
                throw new ValidationException("Error Last Name!", "");
            }
            if (shippingDto.Address== "")
            {
                throw new ValidationException("Error Address!", "");
            }

            newshp.FirstName = shippingDto.FirstName;
            newshp.LastName = shippingDto.LastName;
            newshp.Address = shippingDto.Address;

            DataBase.Shippings.Create(newshp);

        }

       
    }
}
