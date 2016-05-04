namespace PresentacionEscritorio
{
    partial class AbrirDiagrama
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
            this.comboBoxDiagramas = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDiagramas
            // 
            this.comboBoxDiagramas.FormattingEnabled = true;
            this.comboBoxDiagramas.Location = new System.Drawing.Point(78, 32);
            this.comboBoxDiagramas.Name = "comboBoxDiagramas";
            this.comboBoxDiagramas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDiagramas.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 78);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(147, 78);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID del Diagrama";
            // 
            // AbrirDiagrama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.BorderThickness = 10;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.comboBoxDiagramas);
            this.MaximumSize = new System.Drawing.Size(296, 149);
            this.MinimumSize = new System.Drawing.Size(296, 149);
            this.Name = "AbrirDiagrama";
            this.Text = "AbrirDiagrama";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDiagramas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;

    }
}