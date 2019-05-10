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
        private static ShippingService instance;
        public static ShippingService getInstance(string connectionStr)
        {
            if (instance == null)
                instance = new ShippingService(connectionStr);
            return instance;
        }


        private ShippingService(string connectionStr)
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

        public ShippingDTO GetShipping(int id)
        {
            ShippingDTO tmp = new ShippingDTO();
            tmp.Address = DataBase.Shippings.Get(id).Address;
            tmp.FirstName = DataBase.Shippings.Get(id).FirstName;
            tmp.LastName = DataBase.Shippings.Get(id).LastName;
            tmp.Product_id = DataBase.Shippings.Get(id).Product_id;
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

        public List<ShippingDTO> GetShippings()
        {

            List<ShippingDTO> all__result = new List<ShippingDTO>();

            for (var i = 0; i < DataBase.Shippings.GetAll().Count; i++)
            {

                ShippingDTO tmp = new ShippingDTO();
                
                tmp.Address = DataBase.Shippings.GetAll()[i].Address;
                tmp.FirstName = DataBase.Shippings.GetAll()[i].FirstName;
                tmp.LastName = DataBase.Shippings.GetAll()[i].LastName;
                tmp.Product_id = DataBase.Shippings.GetAll()[i].Product_id;
                all__result.Add(tmp);
            }

            return all__result;

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
                throw new ValidationException("Error First Name!", "");
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
