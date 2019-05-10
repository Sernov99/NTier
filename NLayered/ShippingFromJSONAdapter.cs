using BusinessAccessLayer;
using BusinessAccessLayer.DTO;
using BusinessAccessLayer.Infrastructure;
using BusinessAccessLayer.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayered
{
    class ShippingFromJSONAdapter
    {
        private ShippingService srv;
      
        public ShippingFromJSONAdapter(ShippingService srv)
        {
            this.srv = srv;           
        }

        public string MakeShipping(string filepath)
        {
            string json = System.IO.File.ReadAllText(filepath);
            ShippingDTO shp = JsonConvert.DeserializeObject<ShippingDTO>(json);

            try
            {
                srv.MakeShipping(shp);
                return "Done!";
            }
            catch (ValidationException ex)
            {
                return ex.Message;

            }
        }
    }
}
