
using BusinessAccessLayer.DTO;
using BusinessAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippingService srv = new ShippingService();

            ShippingDTO shp = new ShippingDTO();
            shp.Address = "asd";
            shp.FirstName = "dasdqdwadqw";
            shp.LastName = "Asdasd";
            shp.Product_id = 2;

            srv.MakeShipping(shp);
        }
    }
}
