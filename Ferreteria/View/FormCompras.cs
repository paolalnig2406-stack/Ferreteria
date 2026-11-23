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
    public partial class FormCompras : Form
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ferreteria;Integrated Security=True;Encrypt=False;";

        public FormCompras()
        {
            InitializeComponent();
        }

        private void FormCompras_Load_1(object sender, EventArgs e)
        {
            CargarConfiguracionInicial();
            LimpiarFormulario();
        }

        // =========================================================================
        // 1. CONFIGURACIÓN INICIAL (Cargar Listas Desplegables y Productos)
        // =========================================================================
        private void CargarConfiguracionInicial()
        {
            cmbTipoComprobante.Items.Clear();
            cmbTipoComprobante.Items.AddRange(new string[] { "Boleta", "Factura", "Ticket" });
            cmbTipoComprobante.SelectedIndex = 0;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    // 1. Cargar Proveedores Activos
                    string queryProv = "SELECT id_proveedor, razon_social FROM dbo.proveedores WHERE estado = 'Activo'";
                    SqlDataAdapter daProv = new SqlDataAdapter(queryProv, conexion);
                    DataTable dtProv = new DataTable();
                    daProv.Fill(dtProv);

                    cmbProveedor.DataSource = dtProv;
                    cmbProveedor.DisplayMember = "razon_social";
                    cmbProveedor.ValueMember = "id_proveedor";
                    cmbProveedor.SelectedIndex = -1;

                    // 2. Cargar Usuarios Activos (USR-001, etc.)
                    string queryUsu = "SELECT id_usuario, nombre FROM dbo.usuarios WHERE estado = 'Activo'";
                    SqlDataAdapter daUsu = new SqlDataAdapter(queryUsu, conexion);
                    DataTable dtUsu = new DataTable();
                    daUsu.Fill(dtUsu);

                    cmbUsuario.DataSource = dtUsu;
                    cmbUsuario.DisplayMember = "nombre";
                    cmbUsuario.ValueMember = "id_usuario";
                    cmbUsuario.SelectedIndex = 0;

                    // 3. Cargar Productos Activos en la columna 0 del DataGridView
                    // 3. Cargar Productos Activos en la columna 0 del DataGridView
                    string queryProd = "SELECT id_producto, nombre FROM dbo.productos WHERE estado = 'Activo'";
                    SqlDataAdapter daProd = new SqlDataAdapter(queryProd, conexion);
                    DataTable dtProd = new DataTable();
                    daProd.Fill(dtProd);

                    if (dgvDetalleCompra.Columns[0] is DataGridViewComboBoxColumn colProducto)
                    {
                        colProducto.DataSource = dtProd;
                        colProducto.DisplayMember = "nombre";
                        colProducto.ValueMember = "id_producto";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // 2. GENERAR ID AUTOMÁTICO (COMP-001 en n_compra)
        // =========================================================================
        private void GenerarSiguienteID()
        {
            string query = "SELECT MAX(CAST(SUBSTRING(n_compra, 6, 3) AS INT)) FROM dbo.compras WHERE n_compra LIKE 'COMP-%'";

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
                        txtCodigo.Text = "COMP-" + siguienteNumero.ToString("D3");
                    }
                }
                catch
                {
                    txtCodigo.Text = "COMP-001";
                }
            }
        }

        // =========================================================================
        // 3. CALCULAR LOS TOTALES AUTOMÁTICAMENTE (Subtotal, IGV, Total)
        // =========================================================================
        private void dgvDetalleCompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            {
                DataGridViewRow row = dgvDetalleCompra.Rows[e.RowIndex];

                if (row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    try
                    {
                        decimal cantidad = Convert.ToDecimal(row.Cells[1].Value);
                        decimal precio = Convert.ToDecimal(row.Cells[2].Value);
                        row.Cells[3].Value = (cantidad * precio).ToString("0.00");
                    }
                    catch
                    {
                        row.Cells[3].Value = "0.00";
                    }
                }
                CalcularTotales1();
            }
        }

        private void CalcularTotales1()
        {
            decimal subtotalGeneral = 0;

            foreach (DataGridViewRow row in dgvDetalleCompra.Rows)
            {
                if (!row.IsNewRow && row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "")
                {
                    subtotalGeneral += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            decimal igv = subtotalGeneral * 0.18m;
            decimal total = subtotalGeneral + igv;

            txtSubtotal.Text = subtotalGeneral.ToString("0.00");
            txtIgv.Text = igv.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");
        }

        // =========================================================================
        // 4. ACCIÓN DE LOS BOTONES
        // =========================================================================
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
            GenerarSiguienteID();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Está seguro de que desea cancelar la operación actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                LimpiarFormulario();
            }
        }

        // BOTÓN GUARDAR EN SQL SERVER
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Presione el botón Nuevo para generar el número de compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProveedor.SelectedIndex == -1 || dgvDetalleCompra.Rows.Count <= 1)
            {
                MessageBox.Show("Por favor, seleccione un proveedor y agregue al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // 1. Insertar cabecera en dbo.compras
                    string queryCompra = @"INSERT INTO dbo.compras (n_compra, fecha, id_proveedor, id_usuario, tipo_comprobante, serie, numero, total) 
                                           VALUES (@n_compra, @fecha, @id_proveedor, @id_usuario, @tipo_comprobante, @serie, @numero, @total);
                                           SELECT SCOPE_IDENTITY();";

                    int idCompraGenerado = 0;

                    using (SqlCommand cmdCompra = new SqlCommand(queryCompra, conexion, transaccion))
                    {
                        cmdCompra.Parameters.AddWithValue("@n_compra", txtCodigo.Text);
                        cmdCompra.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);
                        cmdCompra.Parameters.AddWithValue("@id_proveedor", cmbProveedor.SelectedValue.ToString());
                        cmdCompra.Parameters.AddWithValue("@id_usuario", cmbUsuario.SelectedValue.ToString());
                        cmdCompra.Parameters.AddWithValue("@tipo_comprobante", cmbTipoComprobante.Text);
                        cmdCompra.Parameters.AddWithValue("@serie", txtSerie.Text);
                        cmdCompra.Parameters.AddWithValue("@numero", txtNumeroComprobante.Text);
                        cmdCompra.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));

                        idCompraGenerado = Convert.ToInt32(cmdCompra.ExecuteScalar());
                    }

                    // 2. Insertar filas en dbo.detalle_compras y actualizar stock
                    string queryDetalle = @"INSERT INTO dbo.detalle_compras (id_compra, id_producto, cantidad, precio_compra, subtotal) 
VALUES (@id_compra, @id_producto, @cantidad, @precio_compra, @subtotal)";
                    string queryStock = @"UPDATE dbo.productos SET stock = stock + @cantidad WHERE id_producto = @id_producto";
                    foreach (DataGridViewRow row in dgvDetalleCompra.Rows)
                    {
                        if (!row.IsNewRow && row.Cells[0].Value != null)
                        {
                            string idProducto = row.Cells[0].Value.ToString();
                            int cantidad = Convert.ToInt32(row.Cells[1].Value);
                            decimal precioCompra = Convert.ToDecimal(row.Cells[2].Value);
                            decimal subtotal = Convert.ToDecimal(row.Cells[3].Value);
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                cmdDetalle.Parameters.AddWithValue("@id_compra", idCompraGenerado);
                                cmdDetalle.Parameters.AddWithValue("@id_producto", idProducto);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precio_compra", precioCompra);
                                cmdDetalle.Parameters.AddWithValue("@subtotal", subtotal);
                                cmdDetalle.ExecuteNonQuery();
                            }
                            using (SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaccion))
                            {
                                cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdStock.Parameters.AddWithValue("@id_producto", idProducto);
                                cmdStock.ExecuteNonQuery();
                            }
                        }
                    }
                    transaccion.Commit();
                    MessageBox.Show("Compra registrada correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtSerie.Clear();
            txtNumeroComprobante.Clear();
            txtSubtotal.Text = "0.00";
            txtIgv.Text = "0.00";
            txtTotal.Text = "0.00";
            if (cmbProveedor.Items.Count > 0) cmbProveedor.SelectedIndex = -1;
            if (cmbTipoComprobante.Items.Count > 0) cmbTipoComprobante.SelectedIndex = 0;
            dgvDetalleCompra.Rows.Clear();
        }
    }
}