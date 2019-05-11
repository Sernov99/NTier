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

        public DBContext(string connectionString)
        {
            try {
                this.conn = new MySqlConnection(connectionString);
                this.conn.Open();
            }
            catch
            {

            }
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

        virtual public string Get(string comm)
        {
            MySqlCommand cmd = new MySqlCommand(comm, conn);
            string res = cmd.ExecuteScalar().ToString();
            return res;
        }
        public MySqlDataReader GetAll(string tablename)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * from " + tablename, conn);
            MySqlDataReader res = cmd.ExecuteReader();
            return res;
        }

    }

}
