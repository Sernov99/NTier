using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.DTO;
using System.Diagnostics;
using System.Collections.Generic;
using BusinessAccessLayer.Infrastructure;

namespace UnitTestProject1
{
    [TestClass]
    public class ShippingServiceTests
    {
        static string connectionString = "datasource=10.8.0.1;port=3306;username=for_progs;password=;database=Shipping_mon;";

 
        ShippingService srv = ShippingService.getInstance(connectionString);
        ProductService srv1 = ProductService.getInstance(connectionString);
        [TestMethod]
        public void TestShippingCreate()
        {
            ShippingDTO shp = new ShippingDTO();
            // Arrange
            shp.Address = "dddddddd";
            shp.FirstName = "SSSSSS";
            shp.LastName = "SSSSSS";
            shp.Product_id = 2;
            
            int num = srv.GetShippings().Count;
            // Act
            srv.MakeShipping(shp);

            // Assert
            Assert.AreEqual(srv.GetShippings().Count, num + 1);
        }

        [TestMethod]
        public void TestPruductsGet()
        {
            //Arrange
            ProductDTO tmp = null;
            List<ProductDTO> lproducts = srv1.GetProducts();
            int to = lproducts.Count;
            int i = 1;
            //ACT
            for (i = 1; i< to; i++)
            {
                try
                {
                    tmp = srv.GetProduct(i);

                }
                catch { break; }
            }
            //Assert
            Trace.WriteLine("Got " + i.ToString() + " objects");
            Assert.AreEqual(i, to);

        }

        [TestMethod]
        public void TestShippingDataValidation()
        {
            ShippingDTO shp = new ShippingDTO();
            // Arrange
            shp.Product_id = 223;
            shp.Address = "3";
            shp.FirstName = "d";
            shp.LastName = "4";
            

            //ACT
            try
            {
                
                srv.MakeShipping(shp);
             
            }
            //Assert
            catch (ValidationException ex)
            {
                Trace.WriteLine(ex.Message);
                return;
            }

            Assert.Fail();
            
        }
    }
}
