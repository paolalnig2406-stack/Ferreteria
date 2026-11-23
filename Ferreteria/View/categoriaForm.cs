using Ferreteria.View;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ferreteria.View
{
    public partial class categoriaForm : Form
    {

        // Conexión compartida
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

        public categoriaForm()
        {
            InitializeComponent();
            // Escucha los clics de la tabla visual
            dgvCategorias.CellClick += new DataGridViewCellEventHandler(dgvCategorias_CellClick);
        }

        private void categoriaForm_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            LimpiarCampos();
        }

        // 1. CARGAR: Muestra solo las categorías con estado 'Activo'
        private void CargarCategorias()
        {
            string query = "SELECT id_categoria, nombre, descripcion, estado FROM dbo.categorias WHERE estado = 'Activo'";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvCategorias.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. ID AUTOMÁTICO (Ejemplo para CAT-001)
        private void GenerarSiguienteID()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(id_categoria, 5, 3) AS INT)) FROM dbo.categorias WHERE id_categoria LIKE 'CAT-%'";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        object result = cmd.ExecuteScalar();
                        int siguienteNumero = 1;
                        if (result != DBNull.Value && result != null)
                        {
                            siguienteNumero = Convert.ToInt32(result) + 1;
                        }
                        txtCodigo.Text = "CAT-" + siguienteNumero.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el ID automático: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. REGISTRAR / GUARDAR
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerarSiguienteID(); // Genera el código justo antes de insertar

            string query = "INSERT INTO dbo.categorias (id_categoria, nombre, descripcion, estado) VALUES (@id, @nombre, @descripcion, 'Activo')";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Categoría registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 4. EDITAR
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Seleccione una categoría de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE dbo.categorias SET nombre = @nombre, descripcion = @descripcion, estado = @estado WHERE id_categoria = @id";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 5. ELIMINAR (Baja Lógica)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, seleccione una categoría de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea dar de baja a esta categoría?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                string query = "UPDATE dbo.categorias SET estado = 'Inactivo' WHERE id_categoria = @id";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("La categoría ha sido desactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarCategorias();
                            LimpiarCampos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al desactivar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 6. BUSCADOR (Evento TextChanged del TextBox superior)
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            string query = @"SELECT id_categoria, nombre, descripcion, estado 
                             FROM dbo.categorias 
                             WHERE estado = 'Activo' 
                             AND (nombre LIKE @criterio OR descripcion LIKE @criterio)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + (criterio ?? string.Empty) + "%");

                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvCategorias.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Botón Lupa (Opcional por si hacen clic en él, ejecuta la misma acción)
        private void btnBuscar_Click(object sender, EventArgs e)

        {
           
        }

        // Botón NUEVO / LIMPIAR
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

            LimpiarCampos();
            GenerarSiguienteID();
        }

        // Al hacer clic en un registro del DataGridView
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategorias.Rows[e.RowIndex];
                txtCodigo.Text = row.Cells["id_categoria"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();
                cmbEstado.Text = row.Cells["estado"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtBuscar.Clear();
            cmbEstado.SelectedIndex = 0; // O "Activo" por defecto
        }

   
    }
}
