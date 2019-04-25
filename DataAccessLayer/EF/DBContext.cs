using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class DBContext
    {
        private MySqlConnection conn;
        public void openConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=userdb;";
            this.conn = new MySqlConnection(connectionString);
            this.conn.Open();
        }
        public void closeConnection()
        {
            this.conn.Close();
        }

        public void Create(string comm)
        {
            MySqlCommand cmd = new MySqlCommand(comm, conn);
            cmd.ExecuteScalar();
        }

        public string Get(string comm)
        {
            MySqlCommand cmd = new MySqlCommand(comm, conn);
            string res = cmd.ExecuteScalar().ToString();
            return res;
        }
        public MySqlDataReader GetAll()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * from tbl_products", conn);
            MySqlDataReader res = cmd.ExecuteReader();
            return res;
        }

    }

}
