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
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage2 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage3 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage4 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionImage captionImage5 = new Syncfusion.Windows.Forms.CaptionImage();
            this.diagram1 = new Syncfusion.Windows.Forms.Diagram.Controls.Diagram(this.components);
            this.model1 = new Syncfusion.Windows.Forms.Diagram.Model(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripProcesoA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoA2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoA3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoA4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripProcesoB1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoB2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoB3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcesoB4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLinea = new System.Windows.Forms.ToolStripButton();
            this.toolStripTexto = new System.Windows.Forms.ToolStripButton();
            this.toolStripRectangulo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportToolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cortarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copiarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pegarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deshacerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rehacerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.propertyEditor1 = new Syncfusion.Windows.Forms.Diagram.Controls.PropertyEditor(this.components);
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
            this.diagram1.Location = new System.Drawing.Point(3, 33);
            this.diagram1.Model = this.model1;
            this.diagram1.Name = "diagram1";
            this.diagram1.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("diagram1.ScrollVirtualBounds")));
            this.diagram1.Size = new System.Drawing.Size(1024, 682);
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
            this.model1.DocumentSize.Height = 790F;
            this.model1.DocumentSize.Width = 1100F;
            this.model1.LineStyle.DashPattern = null;
            this.model1.LineStyle.LineColor = System.Drawing.Color.Black;
            this.model1.LogicalSize = new System.Drawing.SizeF(1100F, 790F);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 718);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripLinea,
            this.toolStripTexto,
            this.toolStripRectangulo,
            this.toolStripSeparator1,
            this.nuevoToolStripButton,
            this.abrirToolStripButton,
            this.guardarToolStripButton,
            this.imprimirToolStripButton,
            this.exportToolStripButton3,
            this.toolStripSeparator,
            this.cortarToolStripButton,
            this.copiarToolStripButton,
            this.pegarToolStripButton,
            this.deshacerToolStripButton,
            this.rehacerToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(91, 22);
            this.toolStripDropDownButton1.Text = "ProcesosA";
            // 
            // toolStripProcesoA1
            // 
            this.toolStripProcesoA1.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA1;
            this.toolStripProcesoA1.Name = "toolStripProcesoA1";
            this.toolStripProcesoA1.Size = new System.Drawing.Size(130, 22);
            this.toolStripProcesoA1.Text = "ProcesoA1";
            this.toolStripProcesoA1.Click += new System.EventHandler(this.toolStripProcesoA1_Click);
            // 
            // toolStripProcesoA2
            // 
            this.toolStripProcesoA2.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA2;
            this.toolStripProcesoA2.Name = "toolStripProcesoA2";
            this.toolStripProcesoA2.Size = new System.Drawing.Size(130, 22);
            this.toolStripProcesoA2.Text = "ProcesoA2";
            this.toolStripProcesoA2.Click += new System.EventHandler(this.toolStripProcesoA2_Click);
            // 
            // toolStripProcesoA3
            // 
            this.toolStripProcesoA3.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA3;
            this.toolStripProcesoA3.Name = "toolStripProcesoA3";
            this.toolStripProcesoA3.Size = new System.Drawing.Size(130, 22);
            this.toolStripProcesoA3.Text = "ProcesoA3";
            this.toolStripProcesoA3.Click += new System.EventHandler(this.toolStripProcesoA3_Click);
            // 
            // toolStripProcesoA4
            // 
            this.toolStripProcesoA4.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoA4;
            this.toolStripProcesoA4.Name = "toolStripProcesoA4";
            this.toolStripProcesoA4.Size = new System.Drawing.Size(130, 22);
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
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton2.Text = "ProcesoB";
            // 
            // toolStripProcesoB1
            // 
            this.toolStripProcesoB1.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoB1;
            this.toolStripProcesoB1.Name = "toolStripProcesoB1";
            this.toolStripProcesoB1.Size = new System.Drawing.Size(129, 22);
            this.toolStripProcesoB1.Text = "ProcesoB1";
            this.toolStripProcesoB1.Click += new System.EventHandler(this.toolStripProcesoB1_Click);
            // 
            // toolStripProcesoB2
            // 
            this.toolStripProcesoB2.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoB2;
            this.toolStripProcesoB2.Name = "toolStripProcesoB2";
            this.toolStripProcesoB2.Size = new System.Drawing.Size(129, 22);
            this.toolStripProcesoB2.Text = "ProcesoB2";
            this.toolStripProcesoB2.Click += new System.EventHandler(this.toolStripProcesoB2_Click);
            // 
            // toolStripProcesoB3
            // 
            this.toolStripProcesoB3.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoB3;
            this.toolStripProcesoB3.Name = "toolStripProcesoB3";
            this.toolStripProcesoB3.Size = new System.Drawing.Size(129, 22);
            this.toolStripProcesoB3.Text = "ProcesoB3";
            this.toolStripProcesoB3.Click += new System.EventHandler(this.toolStripProcesoB3_Click);
            // 
            // toolStripProcesoB4
            // 
            this.toolStripProcesoB4.Image = global::PresentacionEscritorio.Properties.Resources.ProcesoB4;
            this.toolStripProcesoB4.Name = "toolStripProcesoB4";
            this.toolStripProcesoB4.Size = new System.Drawing.Size(129, 22);
            this.toolStripProcesoB4.Text = "ProcesoB4";
            this.toolStripProcesoB4.Click += new System.EventHandler(this.toolStripProcesoB4_Click);
            // 
            // toolStripLinea
            // 
            this.toolStripLinea.Image = global::PresentacionEscritorio.Properties.Resources.linea;
            this.toolStripLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLinea.Name = "toolStripLinea";
            this.toolStripLinea.Size = new System.Drawing.Size(55, 22);
            this.toolStripLinea.Text = "Linea";
            this.toolStripLinea.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripTexto
            // 
            this.toolStripTexto.Image = global::PresentacionEscritorio.Properties.Resources.Texto;
            this.toolStripTexto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTexto.Name = "toolStripTexto";
            this.toolStripTexto.Size = new System.Drawing.Size(56, 22);
            this.toolStripTexto.Text = "Texto";
            this.toolStripTexto.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripRectangulo
            // 
            this.toolStripRectangulo.Image = global::PresentacionEscritorio.Properties.Resources.Rectangulo;
            this.toolStripRectangulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRectangulo.Name = "toolStripRectangulo";
            this.toolStripRectangulo.Size = new System.Drawing.Size(87, 22);
            this.toolStripRectangulo.Text = "Rectangulo";
            this.toolStripRectangulo.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // nuevoToolStripButton
            // 
            this.nuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripButton.Image")));
            this.nuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoToolStripButton.Name = "nuevoToolStripButton";
            this.nuevoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nuevoToolStripButton.Text = "&Nuevo";
            this.nuevoToolStripButton.Click += new System.EventHandler(this.nuevoToolStripButton_Click);
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.abrirToolStripButton.Text = "&Abrir";
            this.abrirToolStripButton.Click += new System.EventHandler(this.abrirToolStripButton_Click);
            // 
            // guardarToolStripButton
            // 
            this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton.Image")));
            this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripButton.Name = "guardarToolStripButton";
            this.guardarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.guardarToolStripButton.Text = "&Guardar";
            this.guardarToolStripButton.Click += new System.EventHandler(this.guardarToolStripButton_Click);
            // 
            // imprimirToolStripButton
            // 
            this.imprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripButton.Image")));
            this.imprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimirToolStripButton.Name = "imprimirToolStripButton";
            this.imprimirToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.imprimirToolStripButton.Text = "&Imprimir";
            this.imprimirToolStripButton.Click += new System.EventHandler(this.imprimirToolStripButton_Click);
            // 
            // exportToolStripButton3
            // 
            this.exportToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToolStripButton3.Image = global::PresentacionEscritorio.Properties.Resources.image_export;
            this.exportToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToolStripButton3.Name = "exportToolStripButton3";
            this.exportToolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.exportToolStripButton3.Text = "Export";
            this.exportToolStripButton3.Click += new System.EventHandler(this.exportToolStripButton3_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cortarToolStripButton
            // 
            this.cortarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cortarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cortarToolStripButton.Image")));
            this.cortarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortarToolStripButton.Name = "cortarToolStripButton";
            this.cortarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cortarToolStripButton.Text = "Cort&ar";
            this.cortarToolStripButton.Click += new System.EventHandler(this.cortarToolStripButton_Click);
            // 
            // copiarToolStripButton
            // 
            this.copiarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copiarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copiarToolStripButton.Image")));
            this.copiarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiarToolStripButton.Name = "copiarToolStripButton";
            this.copiarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copiarToolStripButton.Text = "&Copiar";
            this.copiarToolStripButton.Click += new System.EventHandler(this.copiarToolStripButton_Click);
            // 
            // pegarToolStripButton
            // 
            this.pegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pegarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pegarToolStripButton.Image")));
            this.pegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pegarToolStripButton.Name = "pegarToolStripButton";
            this.pegarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pegarToolStripButton.Text = "&Pegar";
            this.pegarToolStripButton.Click += new System.EventHandler(this.pegarToolStripButton_Click);
            // 
            // deshacerToolStripButton
            // 
            this.deshacerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deshacerToolStripButton.Image = global::PresentacionEscritorio.Properties.Resources.undo;
            this.deshacerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deshacerToolStripButton.Name = "deshacerToolStripButton";
            this.deshacerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deshacerToolStripButton.Text = "Deshacer";
            this.deshacerToolStripButton.Click += new System.EventHandler(this.deshacerToolStripButton_Click);
            // 
            // rehacerToolStripButton
            // 
            this.rehacerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rehacerToolStripButton.Image = global::PresentacionEscritorio.Properties.Resources.redo;
            this.rehacerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rehacerToolStripButton.Name = "rehacerToolStripButton";
            this.rehacerToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.rehacerToolStripButton.Text = "Rehacer";
            this.rehacerToolStripButton.Click += new System.EventHandler(this.rehacerToolStripButton_Click);
            // 
            // propertyEditor1
            // 
            this.propertyEditor1.Diagram = this.diagram1;
            this.propertyEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyEditor1.Location = new System.Drawing.Point(1033, 33);
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Size = new System.Drawing.Size(244, 682);
            this.propertyEditor1.TabIndex = 2;
            // 
            // ProcesosPrincipalesAvanzado
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
            captionImage1.ForeColor = System.Drawing.Color.Transparent;
            captionImage1.Image = global::PresentacionEscritorio.Properties.Resources.HOME;
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(64, 64);
            captionImage2.BackColor = System.Drawing.Color.Transparent;
            captionImage2.ForeColor = System.Drawing.Color.Transparent;
            captionImage2.Image = global::PresentacionEscritorio.Properties.Resources.REUNION;
            captionImage2.Location = new System.Drawing.Point(100, 4);
            captionImage2.Name = "CaptionImage2";
            captionImage2.Size = new System.Drawing.Size(64, 64);
            captionImage3.BackColor = System.Drawing.Color.Transparent;
            captionImage3.ForeColor = System.Drawing.Color.Transparent;
            captionImage3.Image = global::PresentacionEscritorio.Properties.Resources.TAREA;
            captionImage3.Location = new System.Drawing.Point(170, 4);
            captionImage3.Name = "CaptionImage3";
            captionImage3.Size = new System.Drawing.Size(64, 64);
            captionImage4.BackColor = System.Drawing.Color.Transparent;
            captionImage4.ForeColor = System.Drawing.Color.Transparent;
            captionImage4.Image = global::PresentacionEscritorio.Properties.Resources.EMPLEADO;
            captionImage4.Location = new System.Drawing.Point(240, 4);
            captionImage4.Name = "CaptionImage4";
            captionImage4.Size = new System.Drawing.Size(64, 64);
            captionImage5.BackColor = System.Drawing.Color.Transparent;
            captionImage5.ForeColor = System.Drawing.Color.Transparent;
            captionImage5.Image = global::PresentacionEscritorio.Properties.Resources.PROCESOS;
            captionImage5.Location = new System.Drawing.Point(310, 4);
            captionImage5.Name = "CaptionImage5";
            captionImage5.Size = new System.Drawing.Size(64, 64);
            this.CaptionImages.Add(captionImage1);
            this.CaptionImages.Add(captionImage2);
            this.CaptionImages.Add(captionImage3);
            this.CaptionImages.Add(captionImage4);
            this.CaptionImages.Add(captionImage5);
            this.ClientSize = new System.Drawing.Size(1280, 718);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1292, 798);
            this.Name = "ProcesosPrincipalesAvanzado";
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
        private System.Windows.Forms.ToolStripButton toolStripLinea;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA1;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA2;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA3;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoA4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB1;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB2;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB3;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcesoB4;
        private System.Windows.Forms.ToolStripButton toolStripTexto;
        private System.Windows.Forms.ToolStripButton toolStripRectangulo;
        private System.Windows.Forms.ToolStripButton deshacerToolStripButton;
        private System.Windows.Forms.ToolStripButton rehacerToolStripButton;
        private System.Windows.Forms.ToolStripButton exportToolStripButton3;
    }
}