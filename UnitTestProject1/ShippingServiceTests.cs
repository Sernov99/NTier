using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.DTO;
using System.Diagnostics;
using System.Collections.Generic;
using BusinessAccessLayer.Infrastructure;
using Moq;
using DataAccessLayer.Repositories;
using DataAccessLayer.Enteties;
using BusinessAccessLayer;
using DataAccessLayer.EF;

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
            // Arrange
            ShippingDTO shp = new ShippingDTO()
            {
                Address = "dddddd",
                FirstName = "Asdasdad",
                LastName = "das",
                Product_id = 2,
            };
                   
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

        [TestMethod]
        public void MoqProdRepoTest()
        {
            // Arrange
            var mock = new Mock<DBContext>(connectionString);
            List<Product> test_list = new List<Product>
            {
                new Product() {ID = 1, Name = "First" },
                 new Product() {ID = 2, Name = "Second" },
                 new Product() {ID = 1, Name = "Third" },
            };

            string sql_command = "SELECT id FROM tbl_products WHERE id = 1";
            string sql_command1 = "SELECT name FROM tbl_products WHERE id = 1";
            string result_name = "Product 1";
            mock.Setup(a => a.Get(sql_command)).Returns("1");
            mock.Setup(a => a.Get(sql_command1)).Returns(result_name);

            Facade facade = new Facade(ShippingService.getInstance(connectionString), ProductService.getInstance(connectionString));          

            //Act
            ProductRepository pr = new ProductRepository(mock.Object);
            Trace.WriteLine(pr.Get(1));

            //Assert
            Assert.AreEqual(pr.Get(1).ID, 1);


        }
        [TestMethod]
        public void ShippingFactoryDetails()
        {
            //Arrange
            Shipping shp = new Shipping();
            string testString = "QA Tester";
            shp.FirstName = testString;

            //Act
            List<ShippingDetail> list = shp.shippingDetails;
            ShippingNameDetails nd = (ShippingNameDetails)list[0];

            //Assert
            Assert.AreEqual(nd.FirstName, testString);

        }

    }

}
