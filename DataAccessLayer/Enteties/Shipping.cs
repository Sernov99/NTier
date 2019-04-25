using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Enteties
{
    public class Shipping
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        List <Product> Products { get; set; }

    }
}
