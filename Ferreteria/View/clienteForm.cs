using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ferreteria.View
{
    public partial class clienteForm : Form
    {
        private string cadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;";
        public clienteForm()
        {
            InitializeComponent();
        }
        private string GenerarSiguienteCodigo()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(id_cliente, 5, LEN(id_cliente)) AS INT)) FROM dbo.clientes WHERE id_cliente LIKE 'CLI-%'";
            string nuevoCodigo = "CLI-001";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        object resultado = comando.ExecuteScalar();
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            int ultimoNumero = Convert.ToInt32(resultado);
                            int siguienteNumero = ultimoNumero + 1;
                            nuevoCodigo = "CLI-" + siguienteNumero.ToString("D3");
                        }
                    }
                }
                catch (Exception?)
                {
                    nuevoCodigo = "CLI-004";
                }
            }
            return nuevoCodigo;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                txtCodigo.Text = fila.Cells["Código"].Value.ToString();
                txtDniRuc.Text = fila.Cells["DNI/RUC"].Value.ToString();
                txtNombres.Text = fila.Cells["Nombres / Razón social"].Value.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                txtTelefono.Text = fila.Cells["Teléfono"].Value.ToString();
                txtDireccion.Text = fila.Cells["Dirección"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            }
        }
        // Método para traer los datos desde SQL Server a tu dgvClientes
        private void MostrarClientes()
        {
            // La orden SQL usando los nombres reales de tu tabla de la imagen 3
            string query = "SELECT id_cliente AS [Código], dni_ruc AS [DNI/RUC], nombres AS [Nombres / Razón social], apellidos AS [Apellidos], telefono AS [Teléfono], direccion AS [Dirección], correo AS [Correo] FROM dbo.clientes";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open(); // Abrimos la base de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable(); // Tabla virtual
                    adapter.Fill(dt); // Llenamos la tabla virtual con los datos

                    dgvClientes.DataSource = dt; // Jala los datos directamente a tu dgvClientes
                }
                catch (Exception? ex)
                {
                    MessageBox.Show("Error al cargar datos de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clienteForm_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar campos obligatorios básicos
            if (string.IsNullOrEmpty(txtDniRuc.Text) || string.IsNullOrEmpty(txtNombres.Text))
            {
                MessageBox.Show("Por favor, llene los campos obligatorios (DNI/RUC y Nombres).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. GENERAMOS EL CÓDIGO AUTOMÁTICO JUSTO AQUÍ
            string codigoAutomatico = GenerarSiguienteCodigo();

            string query = "INSERT INTO dbo.clientes (id_cliente, dni_ruc, nombres, apellidos, telefono, direccion, correo) " +
                           "VALUES (@id, @dni, @nombres, @apellidos, @telefono, @direccion, @correo)";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // 3. PASAMOS EL CÓDIGO GENERADO AUTOMÁTICAMENTE A SQL
                        comando.Parameters.AddWithValue("@id", codigoAutomatico);
                        comando.Parameters.AddWithValue("@dni", txtDniRuc.Text);
                        comando.Parameters.AddWithValue("@nombres", txtNombres.Text);
                        comando.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                        comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        comando.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        comando.Parameters.AddWithValue("@correo", txtCorreo.Text);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cliente guardado con el código: " + codigoAutomatico, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarClientes();
                    LimpiarCampos();
                }
                catch (Exception? ex)
                {
                    MessageBox.Show("Error al guardar el cliente: " + ex?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtDniRuc.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // 1. Validar que la caja del código no esté vacía (es vital para saber a quién editar)
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, seleccione primero un cliente de la tabla para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Sentencia SQL para actualizar los datos del cliente según su Código (id_cliente)
            string query = "UPDATE dbo.clientes SET dni_ruc = @dni, nombres = @nombres, apellidos = @apellidos, " +
                           "telefono = @telefono, direccion = @direccion, correo = @correo WHERE id_cliente = @id";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // 3. Pasamos los nuevos datos de las cajas de texto
                        comando.Parameters.AddWithValue("@id", txtCodigo.Text); // El ID se usa en el WHERE
                        comando.Parameters.AddWithValue("@dni", txtDniRuc.Text);
                        comando.Parameters.AddWithValue("@nombres", txtNombres.Text);
                        comando.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                        comando.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        comando.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        comando.Parameters.AddWithValue("@correo", txtCorreo.Text);

                        int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta la actualización

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 4. Refrescamos la tabla para ver los cambios de inmediato
                            MostrarClientes();

                            // 5. Limpiamos las cajas
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún cliente con ese código.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception? ex)
                {
                    MessageBox.Show("Error al modificar el cliente: " + ex?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya un código seleccionado
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, seleccione primero un cliente de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Preguntar al usuario si realmente está seguro de borrarlo
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar a este cliente? Esta acción no se puede deshacer.",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si responde que SÍ, procedemos a borrarlo de SQL
            if (resultado == DialogResult.Yes)
            {
                // 3. Sentencia SQL para eliminar usando el Código (id_cliente)
                string query = "DELETE FROM dbo.clientes WHERE id_cliente = @id";

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlCommand comando = new SqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue("@id", txtCodigo.Text);

                            int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta el borrado

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 4. Refrescamos la tabla y limpiamos las cajas de texto
                                MostrarClientes();
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el cliente en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    catch (Exception? ex)
                    {
                        MessageBox.Show("Error al eliminar el cliente: " + ex?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Llamamos al método que borra el texto de todas las cajas
            LimpiarCampos();

            // Opcional: Ponemos el cursor parpadeando directamente en la caja de DNI
            txtDniRuc.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // 1. Si la barra de búsqueda se vacía, volvemos a mostrar a todos los clientes
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                MostrarClientes();
                return;
            }

            // 2. Consulta SQL para buscar coincidencias por DNI, Nombres o Apellidos
            string query = "SELECT id_cliente AS [Código], dni_ruc AS [DNI/RUC], nombres AS [Nombres / Razón social], apellidos AS [Apellidos], " +
                           "telefono AS [Teléfono], direccion AS [Dirección], correo AS [Correo] FROM dbo.clientes " +
                           "WHERE dni_ruc LIKE @buscar OR nombres LIKE @buscar OR apellidos LIKE @buscar";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // El '%' sirve para buscar la palabra en cualquier parte del texto
                        comando.Parameters.AddWithValue("@buscar", "%" + txtBuscar.Text + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Actualiza tu tabla gris con los resultados de la búsqueda
                        dgvClientes.DataSource = dt;
                    }
                }
                catch (Exception? ex)
                {
                    MessageBox.Show("Error al realizar la búsqueda: " + ex?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

