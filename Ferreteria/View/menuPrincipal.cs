using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ferreteria.View
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clienteForm ventanaClientes = new clienteForm();

            // Hacemos que se muestre en la pantalla encima del menú
            ventanaClientes.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProveedoresForm ventanaClientes = new ProveedoresForm();

            // Hacemos que se muestre en la pantalla encima del menú
            ventanaClientes.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            categoriaForm ventanaClientes = new categoriaForm();

            // Hacemos que se muestre en la pantalla encima del menú
            ventanaClientes.ShowDialog();

        }
    }
}

