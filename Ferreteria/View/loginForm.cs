using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Ferreteria.View
{
    public partial class loginForm : Form
    {
        bool contraseñaOculta = true;

        public loginForm()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (contraseñaOculta)
            {
                txtcontrasena.UseSystemPasswordChar = false;
                contraseñaOculta = false;
            }
            else
            {
                txtcontrasena.UseSystemPasswordChar = true;
                contraseñaOculta = true;
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // 1. Validar campos vacíos en la interfaz
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()) || string.IsNullOrEmpty(txtcontrasena.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            // 2. Consulta limpia en texto plano (sin HASHBYTES ni CONVERT)
            string query = "SELECT nombre, usuario_login, rol FROM dbo.usuarios WHERE usuario_login = @user AND contrasena = @pass AND estado = 'Activo'";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtcontrasena.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 3. CONEXIÓN CON TU MENÚ: Guardamos los datos en tus variables originales
                                UsuarioActivo.Nombre = reader["nombre"].ToString();
                                UsuarioActivo.IdUsuario = reader["usuario_login"].ToString();
                                UsuarioActivo.Rol = reader["rol"].ToString(); // Aquí viajará "Administrador"

                                MessageBox.Show($"¡Bienvenido al Sistema, {UsuarioActivo.Nombre}!\nRol: {UsuarioActivo.Rol}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 4. Abrimos tu menú principal original
                                menuPrincipal principal = new menuPrincipal();
                                principal.Show();

                                this.Hide(); // Ocultamos el login
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos, o el usuario está Inactivo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
