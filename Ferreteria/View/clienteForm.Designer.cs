namespace Ferreteria.View
{
    partial class clienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clienteForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtCodigo = new TextBox();
            txtDniRuc = new TextBox();
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtCorreo = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            dgvClientes = new DataGridView();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            pictureBox1 = new PictureBox();
            Código = new DataGridViewTextBoxColumn();
            DNI_RUC = new DataGridViewTextBoxColumn();
            razonSocial = new DataGridViewTextBoxColumn();
            Apellidos = new DataGridViewTextBoxColumn();
            Teléfono = new DataGridViewTextBoxColumn();
            Dirección = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            EsActivo = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(53, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 0;
            label1.Text = "Clientes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(54, 17);
            label2.TabIndex = 1;
            label2.Text = "Código:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 92);
            label3.Name = "label3";
            label3.Size = new Size(63, 17);
            label3.TabIndex = 2;
            label3.Text = "DNI/RUC:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(11, 121);
            label4.Name = "label4";
            label4.Size = new Size(63, 17);
            label4.TabIndex = 3;
            label4.Text = "Nombres";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(11, 169);
            label5.Name = "label5";
            label5.Size = new Size(65, 17);
            label5.TabIndex = 4;
            label5.Text = "Apellidos:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(11, 204);
            label6.Name = "label6";
            label6.Size = new Size(61, 17);
            label6.TabIndex = 5;
            label6.Text = "Teléfono:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(11, 138);
            label7.Name = "label7";
            label7.Size = new Size(85, 17);
            label7.TabIndex = 6;
            label7.Text = "Razón Social:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(404, 60);
            label8.Name = "label8";
            label8.Size = new Size(65, 17);
            label8.TabIndex = 7;
            label8.Text = "Dirección:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(404, 92);
            label9.Name = "label9";
            label9.Size = new Size(52, 17);
            label9.TabIndex = 8;
            label9.Text = "Correo:";
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.Gainsboro;
            txtCodigo.BorderStyle = BorderStyle.FixedSingle;
            txtCodigo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(102, 52);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(140, 25);
            txtCodigo.TabIndex = 9;
            // 
            // txtDniRuc
            // 
            txtDniRuc.BorderStyle = BorderStyle.FixedSingle;
            txtDniRuc.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDniRuc.Location = new Point(102, 90);
            txtDniRuc.Name = "txtDniRuc";
            txtDniRuc.Size = new Size(258, 25);
            txtDniRuc.TabIndex = 10;
            // 
            // txtNombres
            // 
            txtNombres.BorderStyle = BorderStyle.FixedSingle;
            txtNombres.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(103, 131);
            txtNombres.Multiline = true;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(258, 23);
            txtNombres.TabIndex = 11;
            // 
            // txtApellidos
            // 
            txtApellidos.BorderStyle = BorderStyle.FixedSingle;
            txtApellidos.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.Location = new Point(102, 167);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(258, 25);
            txtApellidos.TabIndex = 12;
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(102, 202);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(258, 25);
            txtTelefono.TabIndex = 13;
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            txtDireccion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(486, 52);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(258, 25);
            txtDireccion.TabIndex = 14;
            // 
            // txtCorreo
            // 
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            txtCorreo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(486, 90);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(258, 25);
            txtCorreo.TabIndex = 15;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LimeGreen;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(404, 195);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 16;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(524, 195);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Orange;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(644, 195);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 18;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { Código, DNI_RUC, razonSocial, Apellidos, Teléfono, Dirección, Correo, EsActivo });
            dgvClientes.Location = new Point(12, 247);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.Size = new Size(851, 202);
            dgvClientes.TabIndex = 20;
            dgvClientes.CellClick += dgvClientes_CellClick;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(449, 21);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(259, 23);
            txtBuscar.TabIndex = 21;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscar.Location = new Point(705, 16);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(39, 30);
            btnBuscar.TabIndex = 22;
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Código
            // 
            Código.DataPropertyName = "Código";
            Código.HeaderText = "Código";
            Código.Name = "Código";
            Código.ReadOnly = true;
            // 
            // DNI_RUC
            // 
            DNI_RUC.DataPropertyName = "DNI_RUC";
            DNI_RUC.HeaderText = "DNI/RUC";
            DNI_RUC.Name = "DNI_RUC";
            DNI_RUC.ReadOnly = true;
            // 
            // razonSocial
            // 
            razonSocial.DataPropertyName = "razonSocial";
            razonSocial.HeaderText = "Nombres / Razón social";
            razonSocial.Name = "razonSocial";
            razonSocial.ReadOnly = true;
            // 
            // Apellidos
            // 
            Apellidos.DataPropertyName = "Apellidos";
            Apellidos.HeaderText = "Apellidos";
            Apellidos.Name = "Apellidos";
            Apellidos.ReadOnly = true;
            // 
            // Teléfono
            // 
            Teléfono.DataPropertyName = "Teléfono";
            Teléfono.HeaderText = "Teléfono";
            Teléfono.Name = "Teléfono";
            Teléfono.ReadOnly = true;
            // 
            // Dirección
            // 
            Dirección.DataPropertyName = "Dirección";
            Dirección.HeaderText = "Dirección";
            Dirección.Name = "Dirección";
            Dirección.ReadOnly = true;
            // 
            // Correo
            // 
            Correo.DataPropertyName = "Correo";
            Correo.HeaderText = "Correo";
            Correo.Name = "Correo";
            Correo.ReadOnly = true;
            // 
            // EsActivo
            // 
            EsActivo.DataPropertyName = "Activo";
            EsActivo.HeaderText = "¿Cuenta Activa?";
            EsActivo.Name = "EsActivo";
            EsActivo.ReadOnly = true;
            EsActivo.Resizable = DataGridViewTriState.True;
            EsActivo.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // clienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 461);
            Controls.Add(pictureBox1);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvClientes);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtCorreo);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombres);
            Controls.Add(txtDniRuc);
            Controls.Add(txtCodigo);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "clienteForm";
            Text = "Cliente";
            Load += clienteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtCodigo;
        private TextBox txtDniRuc;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtCorreo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private DataGridView dgvClientes;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn Código;
        private DataGridViewTextBoxColumn DNI_RUC;
        private DataGridViewTextBoxColumn razonSocial;
        private DataGridViewTextBoxColumn Apellidos;
        private DataGridViewTextBoxColumn Teléfono;
        private DataGridViewTextBoxColumn Dirección;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewCheckBoxColumn EsActivo;
    }
}