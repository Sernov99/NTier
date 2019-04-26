using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Enteties;
using DataAccessLayer.EF;

namespace DataAccessLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DBContext db;
        private ProductRepository productRepository;
        private ShippingRepository shippingRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new DBContext(connectionString);
        }

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public ShippingRepository Shippings
        {
            get
            {
                if (shippingRepository == null)
                    shippingRepository = new ShippingRepository(db);
                return shippingRepository;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    
    
}
