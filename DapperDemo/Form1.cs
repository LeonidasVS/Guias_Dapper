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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var obtenerId = customer.ObtenerPorId(txtBuscarID.Text);
            //dataGridView1.DataSource = new List<Customer> { obtenerId };
            ObtenerDatos(obtenerId);
        }

        private void ObtenerDatos(Customer customer)
        {
            txtCustomerID.Text = customer.CustomerID;
            txtCompaneName.Text = customer.CompanyName;
            txtContactName.Text = customer.ContactName;
            txtContacTitle.Text = customer.ContactTitle;
            txtAdress.Text = customer.Address;
        }

        private void Limpiar()
        {
            txtCustomerID.Text = "";
            txtCompaneName.Text = "";
            txtContactName.Text = "";
            txtContacTitle.Text = "";
            txtAdress.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Customer ObtenerCliente()
        {
            var nuevo = new Customer
            {
                CustomerID = txtCustomerID.Text,
                CompanyName = txtCompaneName.Text,
                ContactTitle=txtContacTitle.Text,
                ContactName=txtContactName.Text,
                Address=txtAdress.Text,
            };
            return nuevo;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = ObtenerCliente();
            var insertados = customer.InsertarClientes(nuevoCliente);
            MessageBox.Show("Se inserto");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminados = customer.EliminarCLiente(txtCustomerID.Text);

            if (eliminados == 1)
            { 
                MessageBox.Show("Eliminado");
                Limpiar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var actualiza = ObtenerCliente();
            var actualizados = customer.Actualizados(actualiza);

            if (actualizados==1)
            {
                MessageBox.Show("Actualizado");
                Limpiar();
            }
        }
    }
}
