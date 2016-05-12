namespace PresentacionEscritorio
{
    partial class ProcesosPrincipales
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
            this.components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.Diagram.Binding binding1 = new Syncfusion.Windows.Forms.Diagram.Binding();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesosPrincipales));
            Syncfusion.Windows.Forms.CaptionImage captionImage11 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage12 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage13 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage14 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage15 = new Syncfusion.Windows.Forms.CaptionImage();
            this.diagram1 = new Syncfusion.Windows.Forms.Diagram.Controls.Diagram(this.components);
            this.model1 = new Syncfusion.Windows.Forms.Diagram.Model(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxResponsable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonEDitar = new System.Windows.Forms.Button();
            this.buttonIndicadores = new System.Windows.Forms.Button();
            this.buttonPr = new System.Windows.Forms.Button();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.buttonExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.diagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagram1
            // 
            binding1.DefaultConnector = null;
            binding1.DefaultNode = null;
            binding1.Diagram = this.diagram1;
            binding1.Id = null;
            binding1.Label = ((System.Collections.Generic.List<string>)(resources.GetObject("binding1.Label")));
            binding1.ParentId = null;
            this.diagram1.Binding = binding1;
            this.tableLayoutPanel1.SetColumnSpan(this.diagram1, 4);
            this.diagram1.Controller.PasteOffset = new System.Drawing.SizeF(10F, 10F);
            this.diagram1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagram1.LayoutManager = null;
            this.diagram1.Location = new System.Drawing.Point(3, 153);
            this.diagram1.Model = this.model1;
            this.diagram1.Name = "diagram1";
            this.tableLayoutPanel1.SetRowSpan(this.diagram1, 8);
            this.diagram1.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("diagram1.ScrollVirtualBounds")));
            this.diagram1.Size = new System.Drawing.Size(702, 664);
            this.diagram1.SmartSizeBox = false;
            this.diagram1.TabIndex = 6;
            this.diagram1.Text = "diagram1";
            // 
            // 
            // 
            this.diagram1.View.ClientRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.diagram1.View.Controller = this.diagram1.Controller;
            this.diagram1.View.Grid.MinPixelSpacing = 4F;
            this.diagram1.View.Grid.Visible = false;
            this.diagram1.View.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("resource.ScrollVirtualBounds")));
            this.diagram1.View.ZoomType = Syncfusion.Windows.Forms.Diagram.ZoomType.Center;
            // 
            // model1
            // 
            this.model1.AlignmentType = AlignmentType.SelectedNode;
            this.model1.BackgroundStyle.PathBrushStyle = Syncfusion.Windows.Forms.Diagram.PathGradientBrushStyle.RectangleCenter;
            this.model1.DocumentScale.DisplayName = "No Scale";
            this.model1.DocumentScale.Height = 1F;
            this.model1.DocumentScale.Width = 1F;
            this.model1.DocumentSize.DisplayName = "SameAsPrinter";
            this.model1.DocumentSize.Height = 1100F;
            this.model1.DocumentSize.Width = 790F;
            this.model1.LineStyle.DashPattern = null;
            this.model1.LineStyle.LineColor = System.Drawing.Color.Black;
            this.model1.LogicalSize = new System.Drawing.SizeF(790F, 1100F);
            this.model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxResponsable, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.diagram1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxID, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNombre, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTipo, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 820);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBoxResponsable
            // 
            this.textBoxResponsable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResponsable.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.textBoxResponsable.Location = new System.Drawing.Point(711, 714);
            this.textBoxResponsable.Multiline = true;
            this.textBoxResponsable.Name = "textBoxResponsable";
            this.textBoxResponsable.Size = new System.Drawing.Size(174, 103);
            this.textBoxResponsable.TabIndex = 15;
            this.textBoxResponsable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxResponsable.Leave += new System.EventHandler(this.textBoxResponsable_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.label4.Location = new System.Drawing.Point(711, 651);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 60);
            this.label4.TabIndex = 14;
            this.label4.Text = "Responsable";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitulo, 5);
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.labelTitulo.Location = new System.Drawing.Point(3, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(882, 75);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Titulo";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.label1.Location = new System.Drawing.Point(711, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 60);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.label2.Location = new System.Drawing.Point(711, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 60);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.label3.Location = new System.Drawing.Point(711, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 60);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // textBoxID
            // 
            this.textBoxID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxID.Enabled = false;
            this.textBoxID.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.textBoxID.Location = new System.Drawing.Point(711, 213);
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(174, 101);
            this.textBoxID.TabIndex = 10;
            this.textBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNombre.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.textBoxNombre.Location = new System.Drawing.Point(711, 380);
            this.textBoxNombre.Multiline = true;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(174, 101);
            this.textBoxNombre.TabIndex = 11;
            this.textBoxNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNombre.Leave += new System.EventHandler(this.textBoxNombre_Leave);
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTipo.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.textBoxTipo.Location = new System.Drawing.Point(711, 547);
            this.textBoxTipo.Multiline = true;
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(174, 101);
            this.textBoxTipo.TabIndex = 12;
            this.textBoxTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTipo.Leave += new System.EventHandler(this.textBoxTipo_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 5);
            this.flowLayoutPanel1.Controls.Add(this.buttonEDitar);
            this.flowLayoutPanel1.Controls.Add(this.buttonIndicadores);
            this.flowLayoutPanel1.Controls.Add(this.buttonPr);
            this.flowLayoutPanel1.Controls.Add(this.buttonImprimir);
            this.flowLayoutPanel1.Controls.Add(this.buttonExportar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(888, 75);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // buttonEDitar
            // 
            this.buttonEDitar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonEDitar.Image = global::PresentacionEscritorio.Properties.Resources.Editar1;
            this.buttonEDitar.Location = new System.Drawing.Point(3, 3);
            this.buttonEDitar.Name = "buttonEDitar";
            this.buttonEDitar.Size = new System.Drawing.Size(150, 69);
            this.buttonEDitar.TabIndex = 6;
            this.buttonEDitar.Text = "Editar Diagrama";
            this.buttonEDitar.UseVisualStyleBackColor = true;
            this.buttonEDitar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonIndicadores
            // 
            this.buttonIndicadores.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonIndicadores.Image = global::PresentacionEscritorio.Properties.Resources.indicadores1;
            this.buttonIndicadores.Location = new System.Drawing.Point(159, 3);
            this.buttonIndicadores.Name = "buttonIndicadores";
            this.buttonIndicadores.Size = new System.Drawing.Size(150, 69);
            this.buttonIndicadores.TabIndex = 2;
            this.buttonIndicadores.Text = "Ver Indicadores del Proceso";
            this.buttonIndicadores.UseVisualStyleBackColor = true;
            this.buttonIndicadores.Click += new System.EventHandler(this.buttonIndicadores_Click);
            // 
            // buttonPr
            // 
            this.buttonPr.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonPr.Image = global::PresentacionEscritorio.Properties.Resources.PuntoRojo;
            this.buttonPr.Location = new System.Drawing.Point(315, 3);
            this.buttonPr.Name = "buttonPr";
            this.buttonPr.Size = new System.Drawing.Size(150, 69);
            this.buttonPr.TabIndex = 3;
            this.buttonPr.Text = "Ver Puntos Rojos del Diagrama";
            this.buttonPr.UseVisualStyleBackColor = true;
            this.buttonPr.Click += new System.EventHandler(this.buttonPr_Click);
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonImprimir.Image = global::PresentacionEscritorio.Properties.Resources.imprimir;
            this.buttonImprimir.Location = new System.Drawing.Point(471, 3);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(150, 69);
            this.buttonImprimir.TabIndex = 4;
            this.buttonImprimir.Text = "Imprimir Diagrama";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // buttonExportar
            // 
            this.buttonExportar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExportar.Image = global::PresentacionEscritorio.Properties.Resources.exportar;
            this.buttonExportar.Location = new System.Drawing.Point(627, 3);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(150, 69);
            this.buttonExportar.TabIndex = 5;
            this.buttonExportar.Text = "Exportar Diagrama";
            this.buttonExportar.UseVisualStyleBackColor = true;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // ProcesosPrincipales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.BorderThickness = 10;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.CaptionBarHeight = 74;
            this.CaptionFont = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            captionImage11.BackColor = System.Drawing.Color.Transparent;
            captionImage11.Image = global::PresentacionEscritorio.Properties.Resources.HOME;
            captionImage11.Name = "CaptionImage1";
            captionImage11.Size = new System.Drawing.Size(64, 64);
            captionImage12.BackColor = System.Drawing.Color.Transparent;
            captionImage12.Image = global::PresentacionEscritorio.Properties.Resources.REUNION;
            captionImage12.Location = new System.Drawing.Point(100, 4);
            captionImage12.Name = "CaptionImage2";
            captionImage12.Size = new System.Drawing.Size(64, 64);
            captionImage13.BackColor = System.Drawing.Color.Transparent;
            captionImage13.Image = global::PresentacionEscritorio.Properties.Resources.TAREA;
            captionImage13.Location = new System.Drawing.Point(170, 4);
            captionImage13.Name = "CaptionImage3";
            captionImage13.Size = new System.Drawing.Size(64, 64);
            captionImage14.BackColor = System.Drawing.Color.Transparent;
            captionImage14.Image = global::PresentacionEscritorio.Properties.Resources.EMPLEADO;
            captionImage14.Location = new System.Drawing.Point(240, 4);
            captionImage14.Name = "CaptionImage4";
            captionImage14.Size = new System.Drawing.Size(64, 64);
            captionImage15.BackColor = System.Drawing.Color.Transparent;
            captionImage15.ForeColor = System.Drawing.Color.Transparent;
            captionImage15.Image = global::PresentacionEscritorio.Properties.Resources.PROCESOS;
            captionImage15.Location = new System.Drawing.Point(310, 4);
            captionImage15.Name = "CaptionImage5";
            captionImage15.Size = new System.Drawing.Size(64, 64);
            this.CaptionImages.Add(captionImage11);
            this.CaptionImages.Add(captionImage12);
            this.CaptionImages.Add(captionImage13);
            this.CaptionImages.Add(captionImage14);
            this.CaptionImages.Add(captionImage15);
            this.ClientSize = new System.Drawing.Size(888, 820);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(900, 900);
            this.Name = "ProcesosPrincipales";
            this.ShowIcon = false;
            this.Text = "ProcesosPrincipales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.diagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonIndicadores;
        private System.Windows.Forms.Button buttonPr;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonExportar;
        private Syncfusion.Windows.Forms.Diagram.Controls.Diagram diagram1;
        private Syncfusion.Windows.Forms.Diagram.Model model1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.TextBox textBoxResponsable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonEDitar;
    }
}