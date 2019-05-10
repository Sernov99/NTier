using BusinessAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.DTO;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace BusinessAccessLayer.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork DataBase { get; set; }
        private static ProductService instance;

        private ProductService(string connectionStr)
        {
            DataBase = new EFUnitOfWork(connectionStr);
        }
        public static ProductService getInstance(string connectionStr)
        {
            if (instance == null)
                instance = new ProductService(connectionStr);
            return instance;
        }

        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> all_products_result = new List<ProductDTO>();

            for (var i = 0; i < DataBase.Products.GetAll().Count; i++)
            {

                ProductDTO tmp = new ProductDTO();
                tmp.ID = DataBase.Products.GetAll()[i].ID;
                tmp.Name = DataBase.Products.GetAll()[i].Name;
                all_products_result.Add(tmp);
            }

            return all_products_result;
        }
    }
}
