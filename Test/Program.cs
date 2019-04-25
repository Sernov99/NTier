using DataAccessLayer.Enteties;
using DataAccessLayer.Repositories;
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
            Shipping shp = new Shipping();
            shp.Address = "adsa";
            ShippingRepository repo = new ShippingRepository();

            ProductRepository repo1 = new ProductRepository();
            Console.WriteLine(repo1.GetAll().ElementAt(1).Name);
            Console.ReadLine();
            repo.Create(shp);
        }
    }
}
