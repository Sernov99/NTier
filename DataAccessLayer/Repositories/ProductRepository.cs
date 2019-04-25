using DataAccessLayer.EF;
using DataAccessLayer.Enteties;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        DBContext db = new DBContext();
        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Product result = new Product();
            db.openConnection();
            string comm = "SELECT id FROM tbl_products WHERE id = " + id.ToString();
            result.ID = Int32.Parse(db.Get(comm));
            comm = "SELECT name FROM tbl_products WHERE id =" + id.ToString();
            result.Name = db.Get(comm);
            return result;
        }

        public List<Product> GetAll()
        {
            List<Product> result = new List<Product>();
            db.openConnection();
            MySqlDataReader dr = db.GetAll();
            if (dr.HasRows)
            {
                int count = dr.FieldCount;
               
                while (dr.Read())
                {
                    for (var i = 1; i < count; i+=2)
                    {
                        Product tmp = new Product();
                        tmp.ID = Int32.Parse(dr.GetValue(i-1).ToString());
                        tmp.Name = dr.GetValue(i).ToString();
                        result.Add(tmp);
                    }
                  
                }
            }
            return result;

        }
    }
}
