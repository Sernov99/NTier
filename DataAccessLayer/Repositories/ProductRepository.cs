using DataAccessLayer.EF;
using DataAccessLayer.Enteties;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        DBContext db;
        public ProductRepository(DBContext db)
        {
            this.db = db;
        }

        public void Create(Product item)
        {
            string comm = "INSERT INTO tbl_products (Name) VALUES (" + item.Name + ")";
            db.Create(comm);
        }

        public Product Get(int id)
        {
            Product result = new Product() { ID = 0, Name = "" };
           
            try {
                string comm = "SELECT id FROM tbl_products WHERE id = " + id.ToString();            
                result.ID = Int32.Parse(db.Get(comm));
                comm = "SELECT name FROM tbl_products WHERE id = " + id.ToString();
                result.Name = db.Get(comm);
                Trace.Write(result.ID.ToString());
                return result;
            }
            catch
            {
                
                return result;
            }
            
           
        }

        public List<Product> GetAll()
        {
            List<Product> result = new List<Product>();
  
            MySqlDataReader dr = db.GetAll("tbl_products");
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
            dr.Close();
            return result;

        }
    }
}
