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
    public partial class Productos2 : Form
    {
        private string cadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;";
        public Productos2()
        {
            InitializeComponent();
        }

        private void Productos2_Load(object sender, EventArgs e)
        {

            CargarProductos();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MostrarMensaje("Complete el nombre y el precio.", Color.Red);
                return;
            }


            if (!decimal.TryParse(txtPrecio.Text, out decimal precioValido))
            {
                MostrarMensaje("Ingrese un precio numérico válido.", Color.Red);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    string query = "INSERT INTO dbo.productos2 (Nombre, precio) VALUES (@Nombre, @Precio)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    comando.Parameters.AddWithValue("@Precio", precioValido);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }

                MostrarMensaje("Producto guardado correctamente.", Color.Green);
                LimpiarCampos();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al guardar: " + ex.Message, Color.Red);
            }
        }


        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    string query = "SELECT idProducto AS ID, Nombre, precio AS Precio FROM dbo.productos2";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);


                    dgvProductos2.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar tabla: " + ex.Message, Color.Red);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtNombre.Focus();
        }

        private void MostrarMensaje(string texto, Color color)
        {
            lblMensaje.Text = texto;
            lblMensaje.ForeColor = color;
        }

        private void dgvProductos2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


