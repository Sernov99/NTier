using BusinessAccessLayer.DTO;
using BusinessAccessLayer.Infrastructure;
using BusinessAccessLayer.Iterators;
using BusinessAccessLayer.Services;
using System.Collections.Generic;

namespace BusinessAccessLayer
{
    public class Facade
    {
        private ShippingService srv_ship;
        private ProductService srv_prod;
        List<ProductDTO> lproducts = null;

        public Facade(ShippingService srv_sh, ProductService srv_pr)
        {
            srv_ship = srv_sh;
            srv_prod = srv_pr;
        }

        virtual public List<ProductDTO> product_list()
        {
            if(lproducts == null)
            {
                lproducts = srv_prod.GetProducts();
                return lproducts;
            }
            return lproducts;
        }

        public ProductCollection products_collection()
        {
            var _collection = new ProductCollection();

            foreach (var item in product_list())
            {
                _collection.AddItem(item);
            }
            return _collection;

        }

        public string MakeShipping(string address, string fn, string ln, int pr_id)
        {
            ShippingDTO shp = new ShippingDTO() {
                 Address = address, FirstName = fn, LastName = ln, Product_id = pr_id
            };

            try
            {           
                srv_ship.MakeShipping(shp);
                return "Done!";
            }
            catch (ValidationException ex)
            {
                return ex.Message;

            }
        }



    }
}
