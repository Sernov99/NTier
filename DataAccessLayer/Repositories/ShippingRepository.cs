﻿using DataAccessLayer.EF;
using DataAccessLayer.Enteties;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ShippingRepository : IRepository<Shipping>
    {
        DBContext db = new DBContext();

        public void Create(Shipping item)
        {
            db.openConnection();
            string command = "INSERT INTO `tbl_shippings` (`address`, `firstname`, `lastname`, `product_id`) VALUES (" + "'" + item.Address + "'," +
                      "'" + item.FirstName + "'," + "'" + item.LastName
                    + "'," + "'" + item.Address + "');";
            db.Create(command);
            
        }

        public Shipping Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shipping> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
