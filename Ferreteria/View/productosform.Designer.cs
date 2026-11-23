namespace Ferreteria.View
{
    partial class productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(productos));
            pictureBox1 = new PictureBox();
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPrecioCompra = new TextBox();
            label3 = new Label();
            txtPrecioVenta = new TextBox();
            label5 = new Label();
            txtStock = new TextBox();
            label6 = new Label();
            txtStockMinimo = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cboUnidadMedida = new ComboBox();
            cboProveedor = new ComboBox();
            cboEstado = new ComboBox();
            cboMarca = new ComboBox();
            cboCategoria = new ComboBox();
            label11 = new Label();
            label12 = new Label();
            txtDescripcion = new TextBox();
            label13 = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            dgvProductos = new DataGridView();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(129, 96);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 23);
            txtNombre.TabIndex = 31;
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.Gainsboro;
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(129, 61);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(275, 25);
            txtCodigo.TabIndex = 29;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 98);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 27;
            label4.Text = "Nombre :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 69);
            label2.Name = "label2";
            label2.Size = new Size(58, 17);
            label2.TabIndex = 25;
            label2.Text = "Código :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(56, 18);
            label1.Name = "label1";
            label1.Size = new Size(113, 30);
            label1.TabIndex = 24;
            label1.Text = "Productos";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioCompra.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioCompra.Location = new Point(619, 61);
            txtPrecioCompra.Multiline = true;
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(161, 23);
            txtPrecioCompra.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(500, 63);
            label3.Name = "label3";
            label3.Size = new Size(96, 17);
            label3.TabIndex = 33;
            label3.Text = "Precio compra:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BorderStyle = BorderStyle.FixedSingle;
            txtPrecioVenta.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioVenta.Location = new Point(619, 90);
            txtPrecioVenta.Multiline = true;
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(161, 23);
            txtPrecioVenta.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(501, 92);
            label5.Name = "label5";
            label5.Size = new Size(82, 17);
            label5.TabIndex = 35;
            label5.Text = "Precio venta:";
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.FixedSingle;
            txtStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStock.Location = new Point(619, 119);
            txtStock.Multiline = true;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(161, 23);
            txtStock.TabIndex = 38;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(501, 121);
            label6.Name = "label6";
            label6.Size = new Size(42, 17);
            label6.TabIndex = 37;
            label6.Text = "Stock:";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.BorderStyle = BorderStyle.FixedSingle;
            txtStockMinimo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStockMinimo.Location = new Point(619, 148);
            txtStockMinimo.Multiline = true;
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(161, 23);
            txtStockMinimo.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(501, 150);
            label7.Name = "label7";
            label7.Size = new Size(89, 17);
            label7.TabIndex = 39;
            label7.Text = "Stock minimo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(501, 237);
            label8.Name = "label8";
            label8.Size = new Size(51, 17);
            label8.TabIndex = 43;
            label8.Text = "Estado:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(501, 208);
            label9.Name = "label9";
            label9.Size = new Size(72, 17);
            label9.TabIndex = 42;
            label9.Text = "Proveedor:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(501, 178);
            label10.Name = "label10";
            label10.Size = new Size(120, 17);
            label10.TabIndex = 41;
            label10.Text = "Unidad de medida:";
            // 
            // cboUnidadMedida
            // 
            cboUnidadMedida.FormattingEnabled = true;
            cboUnidadMedida.Location = new Point(619, 177);
            cboUnidadMedida.Name = "cboUnidadMedida";
            cboUnidadMedida.Size = new Size(244, 23);
            cboUnidadMedida.TabIndex = 44;
            // 
            // cboProveedor
            // 
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(619, 207);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(244, 23);
            cboProveedor.TabIndex = 45;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(619, 236);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(244, 23);
            cboEstado.TabIndex = 46;
            // 
            // cboMarca
            // 
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(129, 157);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(286, 23);
            cboMarca.TabIndex = 50;
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(129, 128);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(286, 23);
            cboCategoria.TabIndex = 49;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(17, 158);
            label11.Name = "label11";
            label11.Size = new Size(48, 17);
            label11.TabIndex = 48;
            label11.Text = "Marca:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(17, 129);
            label12.Name = "label12";
            label12.Size = new Size(68, 17);
            label12.TabIndex = 47;
            label12.Text = "Categoria:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcion.Location = new Point(129, 186);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(286, 50);
            txtDescripcion.TabIndex = 52;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(17, 188);
            label13.Name = "label13";
            label13.Size = new Size(79, 17);
            label13.TabIndex = 51;
            label13.Text = "Descripcion:";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(378, 255);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 56;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Orange;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(260, 255);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 55;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(140, 255);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 54;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LimeGreen;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(20, 255);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 53;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscar.Location = new Point(757, 13);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(39, 30);
            btnBuscar.TabIndex = 58;
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(501, 18);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(259, 23);
            txtBuscar.TabIndex = 57;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 296);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.Size = new Size(851, 164);
            dgvProductos.TabIndex = 59;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // productos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 461);
            Controls.Add(dgvProductos);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtDescripcion);
            Controls.Add(label13);
            Controls.Add(cboMarca);
            Controls.Add(cboCategoria);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(cboEstado);
            Controls.Add(cboProveedor);
            Controls.Add(cboUnidadMedida);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(txtStockMinimo);
            Controls.Add(label7);
            Controls.Add(txtStock);
            Controls.Add(label6);
            Controls.Add(txtPrecioVenta);
            Controls.Add(label5);
            Controls.Add(txtPrecioCompra);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "productos";
            Text = "Productos";
            Load += productosform_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtNombre;
        private TextBox txtCodigo;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtPrecioCompra;
        private Label label3;
        private TextBox txtPrecioVenta;
        private Label label5;
        private TextBox txtStock;
        private Label label6;
        private TextBox txtStockMinimo;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cboUnidadMedida;
        private ComboBox cboProveedor;
        private ComboBox cboEstado;
        private ComboBox cboMarca;
        private ComboBox cboCategoria;
        private Label label11;
        private Label label12;
        private TextBox txtDescripcion;
        private Label label13;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvProductos;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}