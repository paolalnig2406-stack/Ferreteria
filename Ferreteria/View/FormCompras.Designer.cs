namespace Ferreteria.View
{
    partial class FormCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompras));
            pictureBox1 = new PictureBox();
            labelClientes = new Label();
            txtCodigo = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtNumeroComprobante = new TextBox();
            txtSerie = new TextBox();
            label7 = new Label();
            label6 = new Label();
            cmbTipoComprobante = new ComboBox();
            label5 = new Label();
            cmbUsuario = new ComboBox();
            label4 = new Label();
            cmbProveedor = new ComboBox();
            dtpFecha = new DateTimePicker();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtTotal = new TextBox();
            txtIgv = new TextBox();
            txtSubtotal = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            dgvDetalleCompra = new DataGridView();
            Producto = new DataGridViewComboBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(8, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // labelClientes
            // 
            labelClientes.AutoSize = true;
            labelClientes.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClientes.ForeColor = Color.FromArgb(0, 0, 64);
            labelClientes.Location = new Point(50, 9);
            labelClientes.Name = "labelClientes";
            labelClientes.Size = new Size(99, 30);
            labelClientes.TabIndex = 29;
            labelClientes.Text = "Compras";
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.Gainsboro;
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(96, 26);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(140, 25);
            txtCodigo.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(77, 17);
            label2.TabIndex = 31;
            label2.Text = "N° Compra:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNumeroComprobante);
            groupBox1.Controls.Add(txtSerie);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cmbTipoComprobante);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbUsuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbProveedor);
            groupBox1.Controls.Add(dtpFecha);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Navy;
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(860, 165);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la compra";
            // 
            // txtNumeroComprobante
            // 
            txtNumeroComprobante.Location = new Point(581, 94);
            txtNumeroComprobante.Name = "txtNumeroComprobante";
            txtNumeroComprobante.Size = new Size(228, 27);
            txtNumeroComprobante.TabIndex = 44;
            // 
            // txtSerie
            // 
            txtSerie.Location = new Point(581, 58);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(228, 27);
            txtSerie.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(421, 99);
            label7.Name = "label7";
            label7.Size = new Size(59, 17);
            label7.TabIndex = 42;
            label7.Text = "Número:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(421, 65);
            label6.Name = "label6";
            label6.Size = new Size(40, 17);
            label6.TabIndex = 41;
            label6.Text = "Serie:";
            // 
            // cmbTipoComprobante
            // 
            cmbTipoComprobante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoComprobante.FormattingEnabled = true;
            cmbTipoComprobante.Location = new Point(581, 18);
            cmbTipoComprobante.Name = "cmbTipoComprobante";
            cmbTipoComprobante.Size = new Size(228, 28);
            cmbTipoComprobante.TabIndex = 40;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(421, 23);
            label5.Name = "label5";
            label5.Size = new Size(141, 17);
            label5.TabIndex = 39;
            label5.Text = "Tipo de Comprobante:";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(97, 122);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(220, 28);
            cmbUsuario.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 128);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 37;
            label4.Text = "Usuario:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(96, 88);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(220, 28);
            cmbProveedor.TabIndex = 36;
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFecha.Location = new Point(96, 57);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(220, 25);
            dtpFecha.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 34;
            label3.Text = "Fecha:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 93);
            label1.Name = "label1";
            label1.Size = new Size(72, 17);
            label1.TabIndex = 33;
            label1.Text = "Proveedor:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(txtIgv);
            groupBox2.Controls.Add(txtSubtotal);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dgvDetalleCompra);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.Navy;
            groupBox2.Location = new Point(12, 233);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(860, 216);
            groupBox2.TabIndex = 34;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de productos";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(244, 175);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 54;
            btnEliminar.Text = "Cancelar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(126, 175);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 52;
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
            btnNuevo.Location = new Point(6, 175);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 51;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click_1;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(635, 101);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(174, 27);
            txtTotal.TabIndex = 50;
            // 
            // txtIgv
            // 
            txtIgv.Location = new Point(634, 60);
            txtIgv.Name = "txtIgv";
            txtIgv.ReadOnly = true;
            txtIgv.Size = new Size(174, 27);
            txtIgv.TabIndex = 49;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(634, 19);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(174, 27);
            txtSubtotal.TabIndex = 48;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(556, 98);
            label10.Name = "label10";
            label10.Size = new Size(39, 17);
            label10.TabIndex = 47;
            label10.Text = "Total:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(556, 65);
            label9.Name = "label9";
            label9.Size = new Size(68, 17);
            label9.TabIndex = 46;
            label9.Text = "IGV (18%):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(556, 24);
            label8.Name = "label8";
            label8.Size = new Size(59, 17);
            label8.TabIndex = 45;
            label8.Text = "Subtotal:";
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleCompra.Columns.AddRange(new DataGridViewColumn[] { Producto, Cantidad, PrecioCompra, Subtotal });
            dgvDetalleCompra.Location = new Point(6, 26);
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.Size = new Size(447, 143);
            dgvDetalleCompra.TabIndex = 0;
            dgvDetalleCompra.CellEndEdit += dgvDetalleCompra_CellEndEdit;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            Producto.Resizable = DataGridViewTriState.True;
            Producto.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            // 
            // PrecioCompra
            // 
            PrecioCompra.HeaderText = "Precio de compra";
            PrecioCompra.Name = "PrecioCompra";
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            // 
            // FormCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 461);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(labelClientes);
            Name = "FormCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compras";
            Load += FormCompras_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelClientes;
        private TextBox txtCodigo;
        private Label label2;
        private GroupBox groupBox1;
        private DateTimePicker dtpFecha;
        private Label label3;
        private Label label1;
        private ComboBox cmbProveedor;
        private Label label4;
        private ComboBox cmbTipoComprobante;
        private Label label5;
        private ComboBox cmbUsuario;
        private TextBox txtNumeroComprobante;
        private TextBox txtSerie;
        private Label label7;
        private Label label6;
        private GroupBox groupBox2;
        private DataGridView dgvDetalleCompra;
        private TextBox txtSubtotal;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtTotal;
        private TextBox txtIgv;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
        private DataGridViewComboBoxColumn Producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn Subtotal;
    }
}