using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ferreteria.View
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Creamos una instancia o copia de tu Menú Principal en la memoria
            menuPrincipal ventanaMenu = new menuPrincipal();

            // 2. Le ordenamos a la computadora que muestre el Menú Principal en la pantalla
            ventanaMenu.Show();

            // 3. Ocultamos este formulario de Login para que no estorbe al fondo
            this.Hide();
        }
    }
}
