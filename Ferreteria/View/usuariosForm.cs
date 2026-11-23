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
    public partial class usuariosForm : Form
    {
        public usuariosForm()
        {
            InitializeComponent();
            // Esta línea obliga a la tabla a escuchar los clics en cualquier parte de la fila
            dgvUsuarios.CellClick += new DataGridViewCellEventHandler(dgvUsuarios_CellClick);
        }


        private void usuariosForm_Load(object sender, EventArgs e)
        {
            // Llamamos a la función para traer los datos apenas abra la ventana
            CargarUsuarios();
            GenerarSiguienteID();
        }

        private void CargarUsuarios()
        {
            // Tu cadena de conexión observada anteriormente
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            // Consulta SQL adaptada exactamente a las columnas de tu tabla dbo.usuarios
            string query = "SELECT id_usuario, nombre, usuario_login, rol, estado FROM dbo.usuarios";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Llenamos el DataGridView con los datos de SQL
                    dgvUsuarios.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerarSiguienteID()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            // Esta consulta busca el número más alto dentro del formato 'USR-XXX'
            string query = "SELECT MAX(CAST(SUBSTRING(id_usuario, 5, 3) AS INT)) FROM dbo.usuarios WHERE id_usuario LIKE 'USR-%'";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        object result = cmd.ExecuteScalar();
                        int siguienteNumero = 1; // Si la tabla está vacía, empieza en 1

                        if (result != DBNull.Value && result != null)
                        {
                            siguienteNumero = Convert.ToInt32(result) + 1;
                        }

                        // Le damos el formato con ceros a la izquierda (ej: USR-004)
                        txtIdUsuario.Text = "USR-" + siguienteNumero.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el ID automático: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // EVENTO CLAVE: Este método se encarga de subir los datos de la tabla a los controles superiores
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Verifica que el clic sea en una fila válida y no en los encabezados
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                // Pasamos los datos usando los índices correctos de tus columnas
                txtIdUsuario.Text = fila.Cells[0].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
                txtUsuarioLogin.Text = fila.Cells[2].Value?.ToString() ?? "";

                if (fila.Cells[3].Value != null)
                    cbRol.SelectedItem = fila.Cells[3].Value.ToString();

                if (fila.Cells[4].Value != null)
                    cbEstado.SelectedItem = fila.Cells[4].Value.ToString();

                // Limpiamos la contraseña por seguridad al seleccionar uno existente
                txtContrasena.Clear();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Puedes dejarlo vacío o llamarlo igual, pero el importante es dgvUsuarios_CellClick
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            // 1. Validar que tengamos un ID válido seleccionado
            if (string.IsNullOrEmpty(txtIdUsuario.Text.Trim()))
            {
                MessageBox.Show("Por favor, seleccione un usuario de la tabla para desactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idUsuario = txtIdUsuario.Text.Trim();

            // 2. Pedir confirmación al usuario
            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de que desea cambiar el estado del usuario '{idUsuario}' a INACTIVO?",
                                                        "Confirmar Desactivación",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                return; // Cancelar operación
            }

            // 3. Conexión y consulta de actualización (Pasamos el estado a Inactivo)
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";
            string query = "UPDATE dbo.usuarios SET estado = 'Inactivo' WHERE id_usuario = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("El usuario ha sido desactivado (Inactivo) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 4. Actualizar la tabla y limpiar la interfaz
                            CargarUsuarios();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún usuario con ese ID en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar cambiar el estado del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar que ninguna caja de texto importante esté vacía
            if (string.IsNullOrEmpty(txtIdUsuario.Text.Trim()) ||
                string.IsNullOrEmpty(txtNombre.Text.Trim()) ||
                string.IsNullOrEmpty(txtUsuarioLogin.Text.Trim()) ||
                string.IsNullOrEmpty(txtContrasena.Text.Trim()))
            {
                MessageBox.Show("Por favor, rellene todos los campos de texto.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que se haya seleccionado un Rol y un Estado
            if (cbRol.SelectedIndex == -1 || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un Rol y un Estado de la lista.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Cadena de conexión e Insert SQL
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";
            string query = "INSERT INTO dbo.usuarios (id_usuario, nombre, usuario_login, contrasena, rol, estado) " +
                           "VALUES (@id, @nombre, @login, @pass, @rol, @estado)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Pasamos los valores que escribiste en la interfaz
                        cmd.Parameters.AddWithValue("@id", txtIdUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@login", txtUsuarioLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtContrasena.Text.Trim()); // Texto plano temporal
                        cmd.Parameters.AddWithValue("@rol", cbRol.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());

                        // Ejecutamos el comando en SQL
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Actualizar la tabla y limpiar controles
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarCampos()
        {
            GenerarSiguienteID();
            txtNombre.Clear();
            txtUsuarioLogin.Clear();
            txtContrasena.Clear();
            cbRol.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            // 1. Validar que tengamos un ID seleccionado para saber a quién modificar
            if (string.IsNullOrEmpty(txtIdUsuario.Text.Trim()))
            {
                MessageBox.Show("Por favor, seleccione un usuario de la tabla para editar sus datos.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que los campos de texto obligatorios no estén vacíos
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtUsuarioLogin.Text.Trim()))
            {
                MessageBox.Show("Por favor, rellene el Nombre y el Usuario.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Validar la selección de Rol y Estado
            if (cbRol.SelectedIndex == -1 || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un Rol y un Estado válidos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

            // Evaluamos si el usuario escribió una nueva contraseña o si la dejó en blanco (para no sobreescribirla por error)
            string query;
            bool cambiaContrasena = !string.IsNullOrEmpty(txtContrasena.Text.Trim());

            if (cambiaContrasena)
            {
                // Si escribió algo en contraseña, la actualizamos también
                query = "UPDATE dbo.usuarios SET nombre = @nombre, usuario_login = @login, contrasena = @pass, rol = @rol, estado = @estado WHERE id_usuario = @id";
            }
            else
            {
                // Si la dejó en blanco, actualizamos todo MENOS la contraseña actual
                query = "UPDATE dbo.usuarios SET nombre = @nombre, usuario_login = @login, rol = @rol, estado = @estado WHERE id_usuario = @id";
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Pasamos los parámetros actualizados desde la interfaz
                        cmd.Parameters.AddWithValue("@id", txtIdUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@login", txtUsuarioLogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", cbRol.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());

                        if (cambiaContrasena)
                        {
                            cmd.Parameters.AddWithValue("@pass", txtContrasena.Text.Trim());
                        }

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 4. Refrescamos los cambios en la pantalla
                            CargarUsuarios();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el usuario para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar editar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}