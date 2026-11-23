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
                txtCodigo.Text = fila.Cells["Código"].Value?.ToString();
                txtDniRuc.Text = fila.Cells["DNI_RUC"].Value?.ToString();
                txtNombres.Text = fila.Cells["razonSocial"].Value.ToString();
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
            string query = "SELECT id_cliente AS [Código], dni_ruc AS [DNI_RUC], nombres AS [razonSocial], apellidos AS [Apellidos], telefono AS [Teléfono], direccion AS [Dirección], correo AS [Correo], Activo FROM dbo.clientes";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open(); // Abrimos la base de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); // Llenamos la tabla virtual con los datos
                    dgvClientes.AutoGenerateColumns = false;
                    dgvClientes.DataSource = dt; // Jala los datos directamente a tu dgvClientes
                }
                catch (Exception? ex)
                {
                    MessageBox.Show("Error al cargar datos de clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "EsActivo")
            {
                string usuarioId = dgvClientes.Rows[e.RowIndex].Cells["Código"].Value.ToString();
                bool nuevoEstado = !Convert.ToBoolean(dgvClientes.Rows[e.RowIndex].Cells["EsActivo"].Value);
                string nombreUsuario = dgvClientes.Rows[e.RowIndex].Cells["razonSocial"].Value.ToString();
                bool exito = ActualizarEstadoCliente(usuarioId, nuevoEstado);

                if (exito)
                {
                    string mensaje = nuevoEstado ? "activada" : "desactivada";
                    MessageBox.Show($"La cuenta de {nombreUsuario} ha sido {mensaje}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvClientes.Rows[e.RowIndex].Cells["EsActivo"].Value = nuevoEstado;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado en el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Revertir el CheckBox visualmente si la base de datos falló
                    dgvClientes.Rows[e.RowIndex].Cells["EsActivo"].Value = !nuevoEstado;
                }
            }



        }
        private void clienteForm_Load(object sender, EventArgs e)
        {
            CargarDniRucExistentes(); // <- ESTA LÍNEA SE ENCARGA DE TRAER LOS DOCUMENTOS
            MostrarClientes();        // Tu función para rellenar la tabla inferior
            LimpiarCampos();
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
           // txtDniRuc.Clear();
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
        private bool ActualizarEstadoCliente(string IdCliente, bool NuevoEstado)
        {
            int NuevoEstadoNumero = (int)Convert.ToInt16(NuevoEstado);
            string query = "update  dbo.clientes set Activo=@NuevoEstado WHERE id_cliente = @id";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@NuevoEstado", NuevoEstadoNumero);
                        comando.Parameters.AddWithValue("@id", IdCliente);

                        int filasAfectadas = comando.ExecuteNonQuery(); // Ejecuta el borrado
                        return filasAfectadas > 0;

                    }
                }
                catch (Exception? ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
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
                string query = "update  dbo.clientes set  =0 WHERE id_cliente = @id";

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

        private void txtDniRuc_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            string documento = txtDniRuc.Text.Trim();

            string miConexionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            if (string.IsNullOrEmpty(documento))
            {
                MostrarClientes();
                return;
            }

            // PASO A: FILTRAR TU DATAGRIDVIEW ACTUAL DE CLIENTES
            string queryFiltro = @"SELECT id_cliente, dni_ruc, nombre_razon_social, apellidos, telefono, direccion, correo 
                           FROM dbo.clientes 
                           WHERE dni_ruc LIKE @doc";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(queryFiltro, conexion);
                    adapter.SelectCommand.Parameters.AddWithValue("@doc", documento + "%");
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvClientes.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Filtro visual: " + ex.Message);
                }
            }

            // PASO B: INTENTAR AUTOCOMPLETAR DESDE CLIENTES
            string queryClienteExacto = @"SELECT id_cliente, nombre_razon_social, apellidos, telefono, direccion, correo 
                                   FROM dbo.clientes WHERE dni_ruc = @docExacto";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(queryClienteExacto, conexion))
                    {
                        cmd.Parameters.AddWithValue("@docExacto", documento);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCodigo.Text = reader["id_cliente"].ToString();
                                txtNombres.Text = reader["nombre_razon_social"].ToString();
                                txtApellidos.Text = reader["apellidos"].ToString();
                                txtTelefono.Text = reader["telefono"].ToString();
                                txtDireccion.Text = reader["direccion"].ToString();
                                txtCorreo.Text = reader["correo"].ToString();

                                txtDniRuc.BackColor = Color.LightGreen; // Cliente encontrado
                                return; // Salimos de la función ya que se autocompletó con éxito
                            }
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }

            // PASO C: SI NO ERA CLIENTE, BUSCAR E AUTOCOMPLETAR DESDE PROVEEDORES
            string queryProveedorExacto = @"SELECT id_proveedor, razon_social, telefono, direccion, correo 
                                     FROM dbo.proveedores WHERE ruc = @docExacto";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(queryProveedorExacto, conexion))
                    {
                        cmd.Parameters.AddWithValue("@docExacto", documento);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCodigo.Text = reader["id_proveedor"].ToString();
                                txtNombres.Text = reader["razon_social"].ToString();
                                txtApellidos.Text = "PROVEEDOR REGISTRADO"; // Marcador visual para el campo apellido
                                txtTelefono.Text = reader["telefono"].ToString();
                                txtDireccion.Text = reader["direccion"].ToString();
                                txtCorreo.Text = reader["correo"].ToString();

                                txtDniRuc.BackColor = Color.LightCyan; // Color diferente para distinguir que viene de proveedores
                            }
                            else
                            {
                                txtDniRuc.BackColor = Color.White; // No existe en ningún lado
                            }
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
        }

      private void CargarDniRucExistentes()
        {
            string miConexionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            // Usamos UNION para traer de manera única los documentos de clientes y proveedores
            string query = @"SELECT dni_ruc FROM dbo.clientes 
                     UNION 
                     SELECT ruc FROM dbo.proveedores";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Desvinculamos temporalmente el evento para evitar errores en la carga inicial
                    txtDniRuc.TextChanged -= txtDniRuc_SelectedIndexChanged;

                    txtDniRuc.DataSource = tabla;
                    txtDniRuc.DisplayMember = "dni_ruc";
                    txtDniRuc.ValueMember = "dni_ruc";

                    // === ESTO SOLUCIONA LO DEL NÚMERO 9 (MINIMIZAR LA LISTA EN TIEMPO REAL) ===
                    txtDniRuc.DropDownStyle = ComboBoxStyle.DropDown;
                    txtDniRuc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtDniRuc.AutoCompleteSource = AutoCompleteSource.ListItems;

                    txtDniRuc.SelectedIndex = -1;
                    txtDniRuc.Text = "";

                    // Volvemos a activar el evento
                    txtDniRuc.TextChanged += txtDniRuc_SelectedIndexChanged;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el listado de documentos unificado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }

}
