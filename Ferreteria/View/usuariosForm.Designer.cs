namespace Ferreteria.View
{
    partial class usuariosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usuariosForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtUsuarioLogin = new TextBox();
            txtNombre = new TextBox();
            txtIdUsuario = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtContrasena = new TextBox();
            label9 = new Label();
            label8 = new Label();
            btnBuscar = new Button();
            textBox5 = new TextBox();
            label2 = new Label();
            cbRol = new ComboBox();
            cbEstado = new ComboBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            dgvUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(54, 16);
            label1.Name = "label1";
            label1.Size = new Size(97, 30);
            label1.TabIndex = 24;
            label1.Text = "Usuarios";
            // 
            // txtUsuarioLogin
            // 
            txtUsuarioLogin.BorderStyle = BorderStyle.FixedSingle;
            txtUsuarioLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuarioLogin.Location = new Point(107, 133);
            txtUsuarioLogin.Name = "txtUsuarioLogin";
            txtUsuarioLogin.Size = new Size(258, 25);
            txtUsuarioLogin.TabIndex = 31;
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(107, 98);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(258, 25);
            txtNombre.TabIndex = 30;
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtIdUsuario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIdUsuario.Location = new Point(108, 62);
            txtIdUsuario.Multiline = true;
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.ReadOnly = true;
            txtIdUsuario.Size = new Size(258, 23);
            txtIdUsuario.TabIndex = 29;
            txtIdUsuario.TextChanged += txtIdUsuario_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 69);
            label7.Name = "label7";
            label7.Size = new Size(72, 17);
            label7.TabIndex = 28;
            label7.Text = "ID Usuario:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 135);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 27;
            label6.Text = "Usuario:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 100);
            label5.Name = "label5";
            label5.Size = new Size(60, 17);
            label5.TabIndex = 26;
            label5.Text = "Nombre:";
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasena.Location = new Point(537, 66);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(258, 25);
            txtContrasena.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(455, 100);
            label9.Name = "label9";
            label9.Size = new Size(30, 17);
            label9.TabIndex = 33;
            label9.Text = "Rol:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(455, 68);
            label8.Name = "label8";
            label8.Size = new Size(77, 17);
            label8.TabIndex = 32;
            label8.Text = "Contraseña:";
            // 
            // btnBuscar
            // 
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscar.Location = new Point(746, 18);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(39, 30);
            btnBuscar.TabIndex = 60;
            btnBuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(490, 23);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(259, 23);
            textBox5.TabIndex = 59;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(456, 135);
            label2.Name = "label2";
            label2.Size = new Size(51, 17);
            label2.TabIndex = 61;
            label2.Text = "Estado:";
            // 
            // cbRol
            // 
            cbRol.AutoCompleteCustomSource.AddRange(new string[] { "Administrador", "Cajero", "Vendedor", "Almacenero" });
            cbRol.FormattingEnabled = true;
            cbRol.Items.AddRange(new object[] { "Administrador", "Vendedor", "Cajero", "Almacenero", "admin" });
            cbRol.Location = new Point(537, 100);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(286, 23);
            cbRol.TabIndex = 62;
            cbRol.SelectedIndexChanged += cbRol_SelectedIndexChanged;
            // 
            // cbEstado
            // 
            cbEstado.AutoCompleteCustomSource.AddRange(new string[] { "Activo", "Inactivo" });
            cbEstado.FormattingEnabled = true;
            cbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cbEstado.Location = new Point(537, 129);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(286, 23);
            cbEstado.TabIndex = 63;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Crimson;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(377, 185);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 67;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Orange;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(259, 185);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 66;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(139, 185);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 65;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.LimeGreen;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(19, 185);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 64;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 240);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(851, 209);
            dgvUsuarios.TabIndex = 68;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // usuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 461);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(cbEstado);
            Controls.Add(cbRol);
            Controls.Add(label2);
            Controls.Add(btnBuscar);
            Controls.Add(textBox5);
            Controls.Add(txtContrasena);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtUsuarioLogin);
            Controls.Add(txtNombre);
            Controls.Add(txtIdUsuario);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "usuariosForm";
            Text = "usuariosForm";
            Load += usuariosForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtUsuarioLogin;
        private TextBox txtNombre;
        private TextBox txtIdUsuario;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox txtContrasena;
        private Label label9;
        private Label label8;
        private Button btnBuscar;
        private TextBox textBox5;
        private Label label2;
        private ComboBox cbRol;
        private ComboBox cbEstado;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Button btnNuevo;
        private DataGridView dgvUsuarios;
    }
}