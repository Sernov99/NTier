using BusinessAccessLayer.DTO;
using BusinessAccessLayer.Infrastructure;
using BusinessAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayered
{
    public partial class Form1 : Form
    {
        ShippingService srv = new ShippingService();
        List<ProductDTO> lproducts = new List<ProductDTO>();

        public Form1()
        {
            InitializeComponent();
            
            lproducts = srv.GetProducts();           
            foreach (var item in lproducts)
            {
                comboBox1.Items.Add(item.Name);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ShippingDTO shp = new ShippingDTO();
            try {
                shp.Address = textBox_address.Text;
                shp.FirstName = textBox_fn.Text;
                shp.LastName = textBox_ln.Text;
                int get_id = lproducts.Find(x => x.Name == comboBox1.SelectedItem.ToString()).ID;
                shp.Product_id = get_id;
            }
            catch { }
           
            try {
                srv.MakeShipping(shp);

            }
            catch (ValidationException ex){
                return;
            }

        }
    }
}
