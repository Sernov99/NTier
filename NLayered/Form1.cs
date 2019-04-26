using BusinessAccessLayer.DTO;
using BusinessAccessLayer.Infrastructure;
using BusinessAccessLayer.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NLayered
{
    public partial class Form1 : Form
    {
        static string connectionString = "datasource=10.8.0.1;port=3306;username=for_progs;password=;database=Shipping_mon;";
        ShippingService srv = new ShippingService(connectionString);
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
                label5.Text = "Done!";
            }
            catch (ValidationException ex){
                label5.Text = ex.Message;
                return;
            }

        }
    }
}
