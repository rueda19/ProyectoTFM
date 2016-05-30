namespace PresentacionEscritorio
{
    partial class TareasEnFecha
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
            this.scheduleControl1 = new Syncfusion.Windows.Forms.Schedule.ScheduleControl();
            this.SuspendLayout();
            // 
            // scheduleControl1
            // 
            this.scheduleControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.scheduleControl1.Culture = new System.Globalization.CultureInfo("");
            this.scheduleControl1.DataSource = null;
            this.scheduleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleControl1.ISO8601CalenderFormat = false;
            this.scheduleControl1.Location = new System.Drawing.Point(0, 0);
            this.scheduleControl1.Name = "scheduleControl1";
            this.scheduleControl1.NavigationPanelPosition = Syncfusion.Schedule.CalendarNavigationPanelPosition.Left;
            this.scheduleControl1.Size = new System.Drawing.Size(888, 820);
            this.scheduleControl1.TabIndex = 0;
            // 
            // TareasEnFecha
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
            this.ClientSize = new System.Drawing.Size(888, 820);
            this.Controls.Add(this.scheduleControl1);
            this.MinimumSize = new System.Drawing.Size(900, 900);
            this.Name = "TareasEnFecha";
            this.Text = "TareasEnFecha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Schedule.ScheduleControl scheduleControl1;
    }
}