namespace Ferreteria.View
{
    partial class Productos2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos2));
            txtNombre = new TextBox();
            label6 = new Label();
            labelClientes = new Label();
            txtPrecio = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnGuardar = new Button();
            dgvProductos2 = new DataGridView();
            lblMensaje = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos2).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(358, 59);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(228, 23);
            txtNombre.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(277, 65);
            label6.Name = "label6";
            label6.Size = new Size(60, 17);
            label6.TabIndex = 44;
            label6.Text = "Nombre:";
            // 
            // labelClientes
            // 
            labelClientes.AutoSize = true;
            labelClientes.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClientes.ForeColor = Color.FromArgb(0, 0, 64);
            labelClientes.Location = new Point(442, 9);
            labelClientes.Name = "labelClientes";
            labelClientes.Size = new Size(113, 30);
            labelClientes.TabIndex = 46;
            labelClientes.Text = "Productos";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(358, 97);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(228, 23);
            txtPrecio.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 103);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 47;
            label1.Text = "Precio:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 399);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 49;
            pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 0, 64);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(414, 126);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 55;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // dgvProductos2
            // 
            dgvProductos2.AllowUserToAddRows = false;
            dgvProductos2.AllowUserToDeleteRows = false;
            dgvProductos2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos2.Location = new Point(255, 203);
            dgvProductos2.Name = "dgvProductos2";
            dgvProductos2.ReadOnly = true;
            dgvProductos2.Size = new Size(438, 180);
            dgvProductos2.TabIndex = 60;
            dgvProductos2.CellContentClick += dgvProductos2_CellContentClick;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.FromArgb(255, 192, 255);
            lblMensaje.Location = new Point(358, 185);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(38, 15);
            lblMensaje.TabIndex = 61;
            lblMensaje.Text = "label2";
            // 
            // Productos2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(705, 405);
            Controls.Add(lblMensaje);
            Controls.Add(dgvProductos2);
            Controls.Add(btnGuardar);
            Controls.Add(pictureBox1);
            Controls.Add(txtPrecio);
            Controls.Add(label1);
            Controls.Add(labelClientes);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Name = "Productos2";
            Text = "PRODUCTOS";
            Load += Productos2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label label6;
        private Label labelClientes;
        private TextBox txtPrecio;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnGuardar;
        private DataGridView dgvProductos2;
        private Label lblMensaje;
    }
}