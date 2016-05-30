namespace PresentacionEscritorio
{
    partial class ListaEmpleados
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
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage2 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage3 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage4 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage5 = new Syncfusion.Windows.Forms.CaptionImage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.gridGroupingControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 610);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridGroupingControl1
            // 
            this.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window;
            this.gridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroupingControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridGroupingControl1.FreezeCaption = false;
            this.gridGroupingControl1.Location = new System.Drawing.Point(3, 3);
            this.gridGroupingControl1.Name = "gridGroupingControl1";
            this.gridGroupingControl1.Size = new System.Drawing.Size(882, 604);
            this.gridGroupingControl1.TabIndex = 0;
            this.gridGroupingControl1.Text = "gridGroupingControl1";
            this.gridGroupingControl1.VersionInfo = "13.4350.0.53";
            // 
            // ListaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.BorderThickness = 10;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.CaptionBarHeight = 74;
            this.CaptionFont = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = global::PresentacionEscritorio.Properties.Resources.HOME;
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(64, 64);
            captionImage2.BackColor = System.Drawing.Color.Transparent;
            captionImage2.Image = global::PresentacionEscritorio.Properties.Resources.REUNION;
            captionImage2.Location = new System.Drawing.Point(100, 4);
            captionImage2.Name = "CaptionImage2";
            captionImage2.Size = new System.Drawing.Size(64, 64);
            captionImage3.BackColor = System.Drawing.Color.Transparent;
            captionImage3.Image = global::PresentacionEscritorio.Properties.Resources.TAREA;
            captionImage3.Location = new System.Drawing.Point(170, 4);
            captionImage3.Name = "CaptionImage3";
            captionImage3.Size = new System.Drawing.Size(64, 64);
            captionImage4.BackColor = System.Drawing.Color.Transparent;
            captionImage4.Image = global::PresentacionEscritorio.Properties.Resources.EMPLEADO;
            captionImage4.Location = new System.Drawing.Point(240, 4);
            captionImage4.Name = "CaptionImage4";
            captionImage4.Size = new System.Drawing.Size(64, 64);
            captionImage5.BackColor = System.Drawing.Color.Transparent;
            captionImage5.Image = global::PresentacionEscritorio.Properties.Resources.PROCESOS;
            captionImage5.Location = new System.Drawing.Point(310, 4);
            captionImage5.Name = "CaptionImage5";
            captionImage5.Size = new System.Drawing.Size(64, 64);
            this.CaptionImages.Add(captionImage1);
            this.CaptionImages.Add(captionImage2);
            this.CaptionImages.Add(captionImage3);
            this.CaptionImages.Add(captionImage4);
            this.CaptionImages.Add(captionImage5);
            this.ClientSize = new System.Drawing.Size(888, 610);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MinimumSize = new System.Drawing.Size(900, 657);
            this.Name = "ListaEmpleados";
            this.Text = "ListaEmpleados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl1;
    }
}