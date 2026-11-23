using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // O System.Data.SqlClient según tu configuración

namespace Ferreteria.View
{
    public partial class productos : Form
    {
        // Conexión compartida
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

        public productos()
        {
            InitializeComponent();
            // Vinculamos el evento clic de la tabla visual de manera dinámica
            dgvProductos.CellClick += new DataGridViewCellEventHandler(dgvProductos_CellClick);
        }

        private void productosform_Load(object sender, EventArgs e)
        {
            CargarCombos(); // Llena las listas desplegables (Categorías, Marcas, Proveedores)
            CargarProductos();
            LimpiarCampos();
        }

        // ==========================================
        // 1. CARGAR LISTAS DESPLEGABLES (COMBOBOX)
        // ==========================================
        private void CargarCombos()
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    // Cargar Categorías
                    SqlDataAdapter daCat = new SqlDataAdapter("SELECT id_categoria, nombre FROM dbo.categorias WHERE estado = 'Activo'", conexion);
                    DataTable dtCat = new DataTable();
                    daCat.Fill(dtCat);
                    cboCategoria.DataSource = dtCat;
                    cboCategoria.DisplayMember = "nombre";
                    cboCategoria.ValueMember = "id_categoria";

                    // Cargar Proveedores
                    SqlDataAdapter daProv = new SqlDataAdapter("SELECT id_proveedor, razon_social FROM dbo.proveedores WHERE estado = 'Activo'", conexion);
                    DataTable dtProv = new DataTable();
                    daProv.Fill(dtProv);
                    cboProveedor.DataSource = dtProv;
                    cboProveedor.DisplayMember = "razon_social";
                    cboProveedor.ValueMember = "id_proveedor";

                    // Configurar unidades de medida estáticas por defecto
                    cboUnidadMedida.Items.Clear();
                    cboUnidadMedida.Items.AddRange(new string[] { "Unidad", "Kg", "Litro", "Metros", "Paquete" });
                    cboUnidadMedida.SelectedIndex = 0;

                    // Configurar estado por defecto
                    cboEstado.Items.Clear();
                    cboEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });
                    cboEstado.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los listados secundarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 2. CARGAR PRODUCTOS EN EL DATAGRIDVIEW
        // ==========================================
        private void CargarProductos()
        {
            string query = @"SELECT id_producto, nombre, id_categoria, marca, descripcion, 
                             precio_compra, precio_venta, stock, stock_minimo, unidad_medida, id_proveedor, estado 
                             FROM dbo.productos WHERE estado = 'Activo'";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProductos.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 3. GENERAR ID AUTOMÁTICO (PROD-001)
        // ==========================================
        private void GenerarSiguienteID()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(id_producto, 6, 3) AS INT)) FROM dbo.productos WHERE id_producto LIKE 'PROD-%'";
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
                        txtCodigo.Text = "PROD-" + siguienteNumero.ToString("D3");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar el ID automático: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 4. REGISTRAR / GUARDAR PRODUCTO
        // ==========================================
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                MessageBox.Show("El nombre y el precio de venta son campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerarSiguienteID(); // Genera el código correspondiente

            string query = @"INSERT INTO dbo.productos (id_producto, nombre, id_categoria, marca, descripcion, precio_compra, precio_venta, stock, stock_minimo, unidad_medida, id_proveedor, estado) 
                             VALUES (@id, @nombre, @id_categoria, @marca, @descripcion, @precio_compra, @precio_venta, @stock, @stock_minimo, @unidad_medida, @id_proveedor, 'Activo')";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_categoria", cboCategoria.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@marca", cboMarca.Text.Trim()); // Cambiar a SelectedValue si manejas una tabla externa para marcas
                        cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio_compra", Convert.ToDecimal(string.IsNullOrEmpty(txtPrecioCompra.Text) ? "0" : txtPrecioCompra.Text));
                        cmd.Parameters.AddWithValue("@precio_venta", Convert.ToDecimal(txtPrecioVenta.Text));
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(string.IsNullOrEmpty(txtStock.Text) ? "0" : txtStock.Text));
                        cmd.Parameters.AddWithValue("@stock_minimo", Convert.ToInt32(string.IsNullOrEmpty(txtStockMinimo.Text) ? "0" : txtStockMinimo.Text));
                        cmd.Parameters.AddWithValue("@unidad_medida", cboUnidadMedida.Text);
                        cmd.Parameters.AddWithValue("@id_proveedor", cboProveedor.SelectedValue ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Producto registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 5. EDITAR PRODUCTO
        // ==========================================
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Seleccione un producto de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE dbo.productos SET nombre = @nombre, id_categoria = @id_categoria, marca = @marca, descripcion = @descripcion, 
                             precio_compra = @precio_compra, precio_venta = @precio_venta, stock = @stock, stock_minimo = @stock_minimo, 
                             unidad_medida = @unidad_medida, id_proveedor = @id_proveedor, estado = @estado WHERE id_producto = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_categoria", cboCategoria.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@marca", cboMarca.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio_compra", Convert.ToDecimal(txtPrecioCompra.Text));
                        cmd.Parameters.AddWithValue("@precio_venta", Convert.ToDecimal(txtPrecioVenta.Text));
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));
                        cmd.Parameters.AddWithValue("@stock_minimo", Convert.ToInt32(txtStockMinimo.Text));
                        cmd.Parameters.AddWithValue("@unidad_medida", cboUnidadMedida.Text);
                        cmd.Parameters.AddWithValue("@id_proveedor", cboProveedor.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@estado", cboEstado.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // ==========================================
        // 6. ELIMINAR (Baja Lógica)
        // ==========================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea dar de baja a este producto?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                string query = "UPDATE dbo.productos SET estado = 'Inactivo' WHERE id_producto = @id";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("El producto ha sido desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarProductos();
                            LimpiarCampos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al desactivar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // ==========================================
        // 7. BUSCADOR EN TIEMPO REAL
        // ==========================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();
            string query = @"SELECT id_producto, nombre, id_categoria, marca, descripcion,
precio_compra, precio_venta, stock, stock_minimo, unidad_medida, id_proveedor, estado
FROM dbo.productos
WHERE estado = 'Activo'
AND (nombre LIKE @criterio OR marca LIKE @criterio OR id_producto LIKE @criterio)";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    adapter.SelectCommand.Parameters.AddWithValue("@criterio", "%" + (criterio ?? string.Empty) + "%");
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProductos.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            GenerarSiguienteID();
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                txtCodigo.Text = row.Cells["id_producto"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                cboCategoria.SelectedValue = row.Cells["id_categoria"].Value;
                cboMarca.Text = row.Cells["marca"].Value.ToString();
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();
                txtPrecioCompra.Text = row.Cells["precio_compra"].Value.ToString();
                txtPrecioVenta.Text = row.Cells["precio_venta"].Value.ToString();
                txtStock.Text = row.Cells["stock"].Value.ToString();
                txtStockMinimo.Text = row.Cells["stock_minimo"].Value.ToString();
                cboUnidadMedida.Text = row.Cells["unidad_medida"].Value.ToString();
                cboProveedor.SelectedValue = row.Cells["id_proveedor"].Value;
                cboEstado.Text = row.Cells["estado"].Value.ToString();
            }
        }
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();
            txtBuscar.Clear();
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            cboMarca.Text = "";
            if (cboUnidadMedida.Items.Count > 0) cboUnidadMedida.SelectedIndex = 0;
            if (cboProveedor.Items.Count > 0) cboProveedor.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }
    }
}

