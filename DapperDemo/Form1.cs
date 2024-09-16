using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerRepository customer = new CustomerRepository();
        private void btnCargar_Click(object sender, EventArgs e)
        {
            var customerObtendiro = customer.obtenerTodo();
            dataGridView1.DataSource = customerObtendiro;
        }
    }
}
