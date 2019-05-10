using BusinessAccessLayer;
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
        Facade BL = new Facade(ShippingService.getInstance(connectionString), ProductService.getInstance(connectionString));

        public Form1()
        {
            InitializeComponent();

            foreach (var item in BL.product_list())
            {
                comboBox1.Items.Add(item.Name);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                
               label5.Text = BL.MakeShipping(textBox_address.Text, textBox_fn.Text, textBox_ln.Text, BL.product_list().Find(x => x.Name == comboBox1.SelectedItem.ToString()).ID);
                //label5.Text = BL.product_list().Find(x => x.Name == comboBox1.SelectedItem.ToString()).ID.ToString();
            }
            catch
            {
                label5.Text = "Empty Product ID!";
            }
        }
    }
}
