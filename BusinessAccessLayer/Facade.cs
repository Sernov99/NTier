using BusinessAccessLayer.DTO;
using BusinessAccessLayer.Infrastructure;
using BusinessAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<ProductDTO> product_list()
        {
            if(lproducts == null)
            {
                lproducts = srv_prod.GetProducts();
                return lproducts;
            }
            return lproducts;
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
