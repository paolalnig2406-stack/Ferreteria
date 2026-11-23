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
    public partial class ProveedoresForm : Form
    {
        // Conexión compartida
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

        public ProveedoresForm()
        {
            InitializeComponent();
            // Escucha los clics de la tabla visual
            dgvProveedores.CellClick += new DataGridViewCellEventHandler(dgvProveedores_CellClick);
        }

        private void ProveedoresForm_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            LimpiarCampos();
            CargarRucExistentes();
        }

        // 1. CARGAR: Ahora solo muestra los proveedores con estado 'Activo'
        private void CargarProveedores()
        {
            string query = "SELECT id_proveedor, ruc, razon_social, contacto, telefono, direccion, correo, estado FROM dbo.proveedores WHERE estado = 'Activo'";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProveedores.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. ID AUTOMÁTICO
        private void GenerarSiguienteID()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(id_proveedor, 6, 3) AS INT)) FROM dbo.proveedores WHERE id_proveedor LIKE 'PROV-%'";

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

                        txtCodigo.Text = "PROV-" + siguienteNumero.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el ID automático: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. GUARDAR: Ahora inserta el estado 'Activo' por defecto


        // 4. EDITAR: Permite modificar todos los campos incluyendo el estado
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string query = "UPDATE dbo.proveedores SET ruc = @ruc, razon_social = @razon, contacto = @contacto, " +
                           "telefono = @telefono, direccion = @direccion, correo = @correo, estado = @estado WHERE id_proveedor = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@ruc", cmbRuc.Text);//aqui**************************
                        cmd.Parameters.AddWithValue("@razon", txtRazonSocial.Text);
                        cmd.Parameters.AddWithValue("@contacto", txtContacto.Text);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarProveedores();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 5. ELIMINAR (Baja Lógica): Cambia el estado a 'Inactivo' de forma segura sin borrar filas
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea dar de baja a este proveedor?",
                                                     "Confirmar Acción",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Hacemos un UPDATE en lugar de un DELETE
                string query = "UPDATE dbo.proveedores SET estado = 'Inactivo' WHERE id_proveedor = @id";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("El proveedor ha sido desactivado del sistema correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CargarProveedores(); // Ocultará al proveedor de la lista visual
                            LimpiarCampos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al desactivar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 6. NUEVO / LIMPIAR
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            //cmbRuc.Clear();
            txtRazonSocial.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            cmbEstado.SelectedIndex = 0; // Selecciona 'Activo' por defecto

            GenerarSiguienteID();
        }

        // 7. SELECCIONAR FILA
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

                txtCodigo.Text = fila.Cells["id_proveedor"].Value.ToString();
                cmbRuc.Text = fila.Cells["ruc"].Value.ToString();//aquiiii*****
                txtRazonSocial.Text = fila.Cells["razon_social"].Value.ToString();
                txtContacto.Text = fila.Cells["contacto"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                cmbEstado.Text = fila.Cells["estado"].Value.ToString(); // Carga el estado en el ComboBox
            }
        }
        private void label1_Click(object sender, EventArgs e) { 
        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GenerarSiguienteID();
            string query = "INSERT INTO dbo.proveedores (id_proveedor, ruc, razon_social, contacto, telefono, direccion, correo, estado) " +
                         "VALUES (@id, @ruc, @razon, @contacto, @telefono, @direccion, @correo, @estado)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@ruc", cmbRuc.Text);//aquii**********************************
                        cmd.Parameters.AddWithValue("@razon", txtRazonSocial.Text);
                        cmd.Parameters.AddWithValue("@contacto", txtContacto.Text);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.Text); // Toma el valor del ComboBox

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarProveedores();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Obtenemos el texto del buscador y eliminamos espacios vacíos
            string criterio = textBox4.Text.Trim();

            // Buscaremos coincidencias por RUC o Razón Social manteniendo solo los Activos
            string query = @"SELECT id_proveedor, ruc, razon_social, contacto, telefono, direccion, correo, estado 
                     FROM dbo.proveedores 
                     WHERE estado = 'Activo' 
                     AND (ruc LIKE @criterio OR razon_social LIKE @criterio)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);

                    // Pasamos el parámetro asegurando que no sea nulo asignando un string vacío si lo fuera
                    adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + (criterio ?? string.Empty) + "%");

                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProveedores.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = textBox4.Text.Trim();

            string query = @"SELECT id_proveedor, ruc, razon_social, contacto, telefono, direccion, correo, estado 
                     FROM dbo.proveedores 
                     WHERE estado = 'Activo' 
                     AND (ruc LIKE @criterio OR razon_social LIKE @criterio)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + (criterio ?? string.Empty) + "%");

                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProveedores.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
        private void CargarRucExistentes()
        {
            string miConexionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            // Unimos los documentos de ambas tablas de manera única
            string query = @"SELECT ruc AS documento FROM dbo.proveedores 
                     UNION 
                     SELECT dni_ruc AS documento FROM dbo.clientes";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Vinculamos la información al ComboBox usando su nombre real: cmbRuc
                    cmbRuc.DataSource = tabla;
                    cmbRuc.DisplayMember = "documento";
                    cmbRuc.ValueMember = "documento";

                    // CONFIGURACIÓN DE FILTRADO DINÁMICO (Soluciona la reducción de lista al escribir)
                    cmbRuc.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbRuc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbRuc.AutoCompleteSource = AutoCompleteSource.ListItems;

                    cmbRuc.SelectedIndex = -1;
                    cmbRuc.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los RUC existentes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbRuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string documento = cmbRuc.Text.Trim();
            string miConexionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            if (string.IsNullOrEmpty(documento)) return;

            // PASO 1: BUSCAR PRIMERO EN PROVEEDORES
            string queryProveedor = "SELECT id_proveedor, razon_social, contacto, telefono, direccion, correo, estado FROM dbo.proveedores WHERE ruc = @ruc";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(queryProveedor, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ruc", documento);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCodigo.Text = reader["id_proveedor"].ToString();
                                txtRazonSocial.Text = reader["razon_social"].ToString();
                                txtContacto.Text = reader["contacto"].ToString();
                                txtTelefono.Text = reader["telefono"].ToString();
                                txtDireccion.Text = reader["direccion"].ToString();
                                txtCorreo.Text = reader["correo"].ToString();
                                cmbEstado.Text = reader["estado"].ToString();
                                cmbRuc.BackColor = Color.LightGreen;
                                return; // Si existe en proveedores, termina aquí
                            }
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }

            // PASO 2: SOLUCIÓN DEFINITIVA PARA EVITAR EL ERROR DE COLUMNA INVALIDA
            // Seleccionamos todo (*) para no fallar por nombres de columnas cambiados
            string queryCliente = "SELECT * FROM dbo.clientes WHERE dni_ruc = @ruc";

            using (SqlConnection conexion = new SqlConnection(miConexionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(queryCliente, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ruc", documento);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obligamos a generar un código PROV-XXX nuevo al guardar
                                txtCodigo.Text = "";

                                // LEEMOS POR ÍNDICES (POSICIONES), ASÍ NO IMPORTA CÓMO SE LLAME LA COLUMNA:
                                // posición 0 = id_cliente, posición 1 = dni_ruc, posición 2 = Nombre/Razón Social
                                txtRazonSocial.Text = reader.GetValue(2).ToString();
                                txtContacto.Text = reader.GetValue(3).ToString(); // Apellidos
                                txtTelefono.Text = reader.GetValue(4).ToString(); // Teléfono
                                txtDireccion.Text = reader.GetValue(5).ToString(); // Dirección
                                txtCorreo.Text = reader.GetValue(6).ToString(); // Correo

                                cmbEstado.Text = "Activo";
                                cmbRuc.BackColor = Color.LightCyan; // Cambia a celeste indicando que viene de clientes

                                MessageBox.Show("Se han importado con éxito los datos del cliente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                cmbRuc.BackColor = Color.White;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la tabla clientes de la base de datos: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}

        

    





    

