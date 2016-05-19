namespace PresentacionEscritorio
{
    partial class DetallesEmpleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDepartamento = new System.Windows.Forms.TextBox();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(227, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(119, 232);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(263, 23);
            this.buttonAceptar.TabIndex = 2;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NombreCompleto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Departamento";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Enabled = false;
            this.textBoxUsuario.Location = new System.Drawing.Point(230, 38);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(246, 20);
            this.textBoxUsuario.TabIndex = 5;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(230, 103);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(246, 20);
            this.textBoxNombre.TabIndex = 6;
            this.textBoxNombre.Leave += new System.EventHandler(this.textBoxNombre_Leave);
            // 
            // textBoxDepartamento
            // 
            this.textBoxDepartamento.Location = new System.Drawing.Point(230, 169);
            this.textBoxDepartamento.Name = "textBoxDepartamento";
            this.textBoxDepartamento.Size = new System.Drawing.Size(246, 20);
            this.textBoxDepartamento.TabIndex = 7;
            this.textBoxDepartamento.Leave += new System.EventHandler(this.textBoxDepartamento_Leave);
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.ErrorImage = global::PresentacionEscritorio.Properties.Resources.anonimo;
            this.pictureBoxFoto.Image = global::PresentacionEscritorio.Properties.Resources.anonimo;
            this.pictureBoxFoto.InitialImage = global::PresentacionEscritorio.Properties.Resources.anonimo;
            this.pictureBoxFoto.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(188, 214);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFoto.TabIndex = 0;
            this.pictureBoxFoto.TabStop = false;
            this.pictureBoxFoto.DoubleClick += new System.EventHandler(this.pictureBoxFoto_DoubleClick);
            // 
            // DetallesEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.BorderThickness = 10;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.CaptionFont = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(488, 271);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxDepartamento);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxFoto);
            this.MaximumSize = new System.Drawing.Size(500, 310);
            this.MinimumSize = new System.Drawing.Size(500, 310);
            this.Name = "DetallesEmpleado";
            this.Text = "DetallesEmpleado";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDepartamento;
    }
}