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
    public class ShippingRepository : IRepository<Shipping>
    {
        DBContext db;
        
        public ShippingRepository(DBContext db)
        {
            this.db = db;
        }

        public void Create(Shipping item)
        {
  
            string command = "INSERT INTO `tbl_shippings` (`address`, `firstname`, `lastname`, `product_id`) VALUES (" + "'" + item.Address + "'," +
                      "'" + item.FirstName + "'," + "'" + item.LastName
                    + "'," + "'" + item.Product_id + "');";
            db.Create(command);
            
        }

        public Shipping Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shipping> GetAll()
        {
            List<Shipping> result = new List<Shipping>();

            MySqlDataReader dr = db.GetAll();
            if (dr.HasRows)
            {
                int count = dr.FieldCount;

                while (dr.Read())
                {
                    for (var i = 4; i < count; i += 2)
                    {
                        Shipping tmp = new Shipping();
                        tmp.Address= dr.GetValue(i - 4).ToString();
                        tmp.FirstName = dr.GetValue(i-3).ToString();
                        tmp.LastName = dr.GetValue(i-2).ToString();
                        tmp.Address = dr.GetValue(i - 1).ToString();
                        tmp.Product_id = Int32.Parse(dr.GetValue(i).ToString());
                        result.Add(tmp);
                    }

                }
            }
            dr.Close();
            return result;
        }
    }
}
