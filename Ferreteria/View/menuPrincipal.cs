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

        // 📌 BOTÓN INICIO (button1)
        private void button1_Click(object sender, EventArgs e)
        {
        }

        // 📌 ESTE ES TU BOTÓN "CERRAR SESIÓN" (button12)
        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Limpiamos los datos del usuario en la memoria por seguridad
                UsuarioActivo.IdUsuario = null;
                UsuarioActivo.Nombre = null;
                UsuarioActivo.Rol = null;

                // Reabrimos el formulario de Login
                loginForm formularioLogin = new loginForm();
                formularioLogin.Show();

                // Cerramos este menú principal por completo
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        // 📌 CONFIGURACIÓN DE ROLES Y VISIBILIDAD AL CARGAR EL MENÚ
        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            // 1. Cambiamos el texto de tu button14 (arriba a la derecha) con el Rol real
            button14.Text = UsuarioActivo.Rol;

            // 2. Restablecemos todos los botones a su estado activo y color blanco original
            RestablecerEstiloBotones();

            // 3. Aplicamos las restricciones poniendo en gris lo que no corresponde a cada rol
            switch (UsuarioActivo.Rol)
            {
                case "Administrador":
                    // La administradora mantiene acceso completo a todo el menú
                    break;

                case "Vendedor":
                    // El vendedor NO accede a Proveedores, Compras, Usuarios ni Reportes
                    DeshabilitarBoton(button6);   // Oculta/Gris Proveedores
                    DeshabilitarBoton(button3);   // Oculta/Gris Compras
                    DeshabilitarBoton(button10);  // Oculta/Gris Usuarios
                    DeshabilitarBoton(button11);  // Oculta/Gris Reportes
                    break;

                case "Almacenero":
                    // El almacenero SOLO accede a Categorías, Productos e Inventario
                    DeshabilitarBoton(button2);   // Oculta/Gris Clientes
                    DeshabilitarBoton(button6);   // Oculta/Gris Proveedores
                    DeshabilitarBoton(button3);   // Oculta/Gris Compras
                    DeshabilitarBoton(button7);   // Oculta/Gris Ventas
                    DeshabilitarBoton(button8);   // Oculta/Gris Detalle de Ventas
                    DeshabilitarBoton(button10);  // Oculta/Gris Usuarios
                    DeshabilitarBoton(button11);  // Oculta/Gris Reportes
                    break;

                case "Cajero":
                    // El cajero maneja ventas, cobranza y reportes (No almacén ni compras ni gestión técnica)
                    DeshabilitarBoton(button4);   // Oculta/Gris Productos
                    DeshabilitarBoton(button5);   // Oculta/Gris Categorías
                    DeshabilitarBoton(button6);   // Oculta/Gris Proveedores
                    DeshabilitarBoton(button3);   // Oculta/Gris Compras
                    DeshabilitarBoton(button9);   // Oculta/Gris Inventario
                    DeshabilitarBoton(button10);  // Oculta/Gris Usuarios
                    break;

                default:
                    // Medida de seguridad si hay un rol extraño
                    MessageBox.Show("Rol no reconocido o sin permisos asignados.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                    break;
            }
        }

        // 📌 Función auxiliar para poner un botón en gris plano y bloquear su clic por completo
        private void DeshabilitarBoton(Button boton)
        {
            boton.Enabled = false;
            boton.ForeColor = Color.DarkGray; // Cambia las letras a un color plomo/gris
        }

        // 📌 Función para devolver los botones a su estado original al cerrar sesión
        private void RestablecerEstiloBotones()
        {
            Button[] botones = { button2, button6, button5, button4, button3, button7, button8, button9, button10, button11 };

            foreach (Button btn in botones)
            {
                btn.Visible = true;
                btn.Enabled = true;
                btn.ForeColor = Color.White; // Devuelve el texto a blanco original
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        // Botón Clientes (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            clienteForm ventanaClientes = new clienteForm();
            ventanaClientes.ShowDialog();
        }

        // Botón Proveedores (button6)
        private void button6_Click(object sender, EventArgs e)
        {
            ProveedoresForm ventanaProveedores = new ProveedoresForm();
            ventanaProveedores.ShowDialog();
        }

        // Botón Categorías (button5)
        private void button5_Click(object sender, EventArgs e)
        {
            categoriaForm ventanaCategorias = new categoriaForm();
            ventanaCategorias.ShowDialog();
        }

        // Botón Productos (button4)
        private void button4_Click(object sender, EventArgs e)
        {
            productos ventanaProductos = new productos();
            ventanaProductos.ShowDialog();
        }

        // Botón Usuarios (button10)
        private void button10_Click(object sender, EventArgs e)
        {
            usuariosForm ventanaUsuarios = new usuariosForm();
            ventanaUsuarios.ShowDialog();
        }

        // 📌 EVENTOS DE LOS BOTONES RESTANTES (Para que no fallen las referencias cruzadas de diseño)
        private void button3_Click(object sender, EventArgs e) { /* Compras */ }
        private void button7_Click(object sender, EventArgs e) { /* Ventas */ }
        private void button8_Click(object sender, EventArgs e) { /* Detalle de Ventas */ }
        private void button9_Click(object sender, EventArgs e) { /* Inventario */ }
        private void button11_Click(object sender, EventArgs e) { /* Reportes */ }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormCompras ventanaProductos = new FormCompras();
            ventanaProductos.ShowDialog();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Productos2 ventanaProductos = new Productos2();
            ventanaProductos.ShowDialog();

        }
    }
}