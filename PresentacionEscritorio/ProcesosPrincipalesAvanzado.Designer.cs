namespace PresentacionEscritorio
{
    partial class ProcesosPrincipalesAvanzado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesosPrincipalesAvanzado));
            this.diagram1 = new Syncfusion.Windows.Forms.Diagram.Controls.Diagram(this.components);
            this.model1 = new Syncfusion.Windows.Forms.Diagram.Model(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.propertyEditor1 = new Syncfusion.Windows.Forms.Diagram.Controls.PropertyEditor(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cortarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copiarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pegarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripProcesoA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoA2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoA3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoA4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripProcesoB1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoB2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoB3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoB4 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.diagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.tableLayoutPanel1.SetColumnSpan(this.diagram1, 2);
            this.diagram1.Controller.PasteOffset = new System.Drawing.SizeF(10F, 10F);
            this.diagram1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagram1.LayoutManager = null;
            this.diagram1.Location = new System.Drawing.Point(3, 67);
            this.diagram1.Model = this.model1;
            this.diagram1.Name = "diagram1";
            this.diagram1.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("diagram1.ScrollVirtualBounds")));
            this.diagram1.Size = new System.Drawing.Size(1332, 644);
            this.diagram1.SmartSizeBox = false;
            this.diagram1.TabIndex = 0;
            this.diagram1.Text = "diagram1";
            // 
            // 
            // 
            this.diagram1.View.ClientRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.diagram1.View.Controller = this.diagram1.Controller;
            this.diagram1.View.Grid.MinPixelSpacing = 4F;
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
            this.model1.DocumentSize.Height = 827F;
            this.model1.DocumentSize.Width = 1169F;
            this.model1.LineStyle.DashPattern = null;
            this.model1.LineStyle.LineColor = System.Drawing.Color.Black;
            this.model1.LogicalSize = new System.Drawing.SizeF(1169F, 827F);
            this.model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.diagram1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyEditor1, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1588, 714);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripButton3,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.nuevoToolStripButton,
            this.abrirToolStripButton,
            this.guardarToolStripButton,
            this.imprimirToolStripButton,
            this.toolStripSeparator,
            this.cortarToolStripButton,
            this.copiarToolStripButton,
            this.pegarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1338, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // propertyEditor1
            // 
            this.propertyEditor1.Diagram = this.diagram1;
            this.propertyEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyEditor1.Location = new System.Drawing.Point(1341, 67);
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Size = new System.Drawing.Size(244, 644);
            this.propertyEditor1.TabIndex = 2;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(84, 24);
            this.toolStripButton1.Text = "rectangule";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton1.ToolTipText = "rectangule tool";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(84, 24);
            this.toolStripButton2.Text = "proceso";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.toolStripButton2.ToolTipText = "proceso tool";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // nuevoToolStripButton
            // 
            this.nuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripButton.Image")));
            this.nuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoToolStripButton.Name = "nuevoToolStripButton";
            this.nuevoToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.nuevoToolStripButton.Text = "&Nuevo";
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.abrirToolStripButton.Text = "&Abrir";
            // 
            // guardarToolStripButton
            // 
            this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton.Image")));
            this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripButton.Name = "guardarToolStripButton";
            this.guardarToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.guardarToolStripButton.Text = "&Guardar";
            // 
            // imprimirToolStripButton
            // 
            this.imprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripButton.Image")));
            this.imprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimirToolStripButton.Name = "imprimirToolStripButton";
            this.imprimirToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.imprimirToolStripButton.Text = "&Imprimir";
            // 
            // cortarToolStripButton
            // 
            this.cortarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cortarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cortarToolStripButton.Image")));
            this.cortarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortarToolStripButton.Name = "cortarToolStripButton";
            this.cortarToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.cortarToolStripButton.Text = "Cort&ar";
            // 
            // copiarToolStripButton
            // 
            this.copiarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copiarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copiarToolStripButton.Image")));
            this.copiarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiarToolStripButton.Name = "copiarToolStripButton";
            this.copiarToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.copiarToolStripButton.Text = "&Copiar";
            // 
            // pegarToolStripButton
            // 
            this.pegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pegarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pegarToolStripButton.Image")));
            this.pegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pegarToolStripButton.Name = "pegarToolStripButton";
            this.pegarToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.pegarToolStripButton.Text = "&Pegar";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProcesoA1,
            this.toolStripProcesoA2,
            this.toolStripProcesoA3,
            this.toolStripProcesoA4});
            this.toolStripDropDownButton1.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA1;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(91, 24);
            this.toolStripDropDownButton1.Text = "ProcesosA";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripProcesoA1
            // 
            this.toolStripProcesoA1.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA1;
            this.toolStripProcesoA1.Name = "toolStripProcesoA1";
            this.toolStripProcesoA1.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoA1.Text = "ProcesoA1";
            this.toolStripProcesoA1.Click += new System.EventHandler(this.toolStripProcesoA1_Click);
            // 
            // toolStripProcesoA2
            // 
            this.toolStripProcesoA2.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA2;
            this.toolStripProcesoA2.Name = "toolStripProcesoA2";
            this.toolStripProcesoA2.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoA2.Text = "ProcesoA2";
            this.toolStripProcesoA2.Click += new System.EventHandler(this.toolStripProcesoA2_Click);
            // 
            // toolStripProcesoA3
            // 
            this.toolStripProcesoA3.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA3;
            this.toolStripProcesoA3.Name = "toolStripProcesoA3";
            this.toolStripProcesoA3.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoA3.Text = "ProcesoA3";
            this.toolStripProcesoA3.Click += new System.EventHandler(this.toolStripProcesoA3_Click);
            // 
            // toolStripProcesoA4
            // 
            this.toolStripProcesoA4.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA4;
            this.toolStripProcesoA4.Name = "toolStripProcesoA4";
            this.toolStripProcesoA4.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoA4.Text = "ProcesoA4";
            this.toolStripProcesoA4.Click += new System.EventHandler(this.toolStripProcesoA4_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProcesoB1,
            this.toolStripProcesoB2,
            this.toolStripProcesoB3,
            this.toolStripProcesoB4});
            this.toolStripDropDownButton2.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoB1;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(85, 24);
            this.toolStripDropDownButton2.Text = "ProcesoB";
            // 
            // toolStripProcesoB1
            // 
            this.toolStripProcesoB1.Name = "toolStripProcesoB1";
            this.toolStripProcesoB1.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoB1.Text = "ProcesoB1";
            // 
            // toolStripProcesoB2
            // 
            this.toolStripProcesoB2.Name = "toolStripProcesoB2";
            this.toolStripProcesoB2.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoB2.Text = "ProcesoB2";
            // 
            // toolStripProcesoB3
            // 
            this.toolStripProcesoB3.Name = "toolStripProcesoB3";
            this.toolStripProcesoB3.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoB3.Text = "ProcesoB3";
            // 
            // toolStripProcesoB4
            // 
            this.toolStripProcesoB4.Name = "toolStripProcesoB4";
            this.toolStripProcesoB4.Size = new System.Drawing.Size(152, 22);
            this.toolStripProcesoB4.Text = "ProcesoB4";
            // 
            // ProcesosPrincipalesAvanzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.BorderThickness = 10;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.CaptionBarHeight = 78;
            this.ClientSize = new System.Drawing.Size(1588, 714);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcesosPrincipalesAvanzado";
            this.ShowIcon = false;
            this.Text = "ProcesosPrincipalesAvanzado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.diagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Diagram.Controls.Diagram diagram1;
        private Syncfusion.Windows.Forms.Diagram.Model model1;
        private Syncfusion.Windows.Forms.Diagram.Controls.PropertyEditor propertyEditor1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton nuevoToolStripButton;
        private System.Windows.Forms.ToolStripButton abrirToolStripButton;
        private System.Windows.Forms.ToolStripButton guardarToolStripButton;
        private System.Windows.Forms.ToolStripButton imprimirToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cortarToolStripButton;
        private System.Windows.Forms.ToolStripButton copiarToolStripButton;
        private System.Windows.Forms.ToolStripButton pegarToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA1;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA2;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA3;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB1;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB2;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB3;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB4;
    }
}