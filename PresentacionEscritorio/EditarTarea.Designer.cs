﻿namespace PresentacionEscritorio
{
    partial class EditarTarea
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
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable2 = new Syncfusion.Windows.Forms.MetroColorTable();
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable3 = new Syncfusion.Windows.Forms.MetroColorTable();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FechaFin = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.FechaInicio = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.tbReunionID = new System.Windows.Forms.TextBox();
            this.tbReunionNombre = new System.Windows.Forms.TextBox();
            this.cbEstado = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.cbResponsable = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTiempoDedicado = new System.Windows.Forms.TextBox();
            this.FechaEjecucion = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAcepta = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ComboBoxPuntoRojoID = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.textBoxPuntoRojoProceso = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ComboBoxTareaPadre = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.textBoxTareaPadre = new System.Windows.Forms.TextBox();
            this.comboBoxTipo = new Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbResponsable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEjecucion)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxPuntoRojoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxTareaPadre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTipo.AutoCompleteControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FechaFin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.FechaInicio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbDescripcion, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.tbReunionID, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbReunionNombre, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbEstado, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.cbResponsable, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.tbTiempoDedicado, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.FechaEjecucion, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxPuntoRojoID, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPuntoRojoProceso, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.ComboBoxTareaPadre, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTareaPadre, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTipo, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 17;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882793F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882792F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.880439F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.880848F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.880848F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882008F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882353F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 536);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // FechaFin
            // 
            this.FechaFin.BorderColor = System.Drawing.Color.Empty;
            this.FechaFin.CalendarSize = new System.Drawing.Size(189, 176);
            this.tableLayoutPanel1.SetColumnSpan(this.FechaFin, 2);
            this.FechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FechaFin.DropDownImage = null;
            this.FechaFin.DropDownNormalColor = System.Drawing.SystemColors.Control;
            this.FechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaFin.Location = new System.Drawing.Point(153, 100);
            this.FechaFin.Margin = new System.Windows.Forms.Padding(7);
            this.FechaFin.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.FechaFin.MinValue = new System.DateTime(((long)(0)));
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.ShowCheckBox = false;
            this.FechaFin.Size = new System.Drawing.Size(328, 17);
            this.FechaFin.TabIndex = 0;
            this.FechaFin.Value = new System.DateTime(2016, 4, 14, 11, 44, 43, 483);
            this.FechaFin.ValueChanged += new System.EventHandler(this.FechaFin_ValueChanged);
            // 
            // FechaInicio
            // 
            this.FechaInicio.BorderColor = System.Drawing.Color.Empty;
            this.FechaInicio.CalendarSize = new System.Drawing.Size(189, 176);
            this.tableLayoutPanel1.SetColumnSpan(this.FechaInicio, 2);
            this.FechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FechaInicio.DropDownImage = null;
            this.FechaInicio.DropDownNormalColor = System.Drawing.SystemColors.Control;
            this.FechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaInicio.Location = new System.Drawing.Point(153, 69);
            this.FechaInicio.Margin = new System.Windows.Forms.Padding(7);
            this.FechaInicio.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.FechaInicio.MinValue = new System.DateTime(((long)(0)));
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.ShowCheckBox = false;
            this.FechaInicio.Size = new System.Drawing.Size(328, 17);
            this.FechaInicio.TabIndex = 1;
            this.FechaInicio.Value = new System.DateTime(2016, 4, 14, 11, 47, 21, 730);
            this.FechaInicio.ValueChanged += new System.EventHandler(this.FechaInicio_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.tableLayoutPanel1.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(482, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "Editar Tarea";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de Inicio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Prevista de Finalizacion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "Reunion";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tipo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 31);
            this.label6.TabIndex = 7;
            this.label6.Text = "Estado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 372);
            this.label7.Name = "label7";
            this.tableLayoutPanel1.SetRowSpan(this.label7, 4);
            this.label7.Size = new System.Drawing.Size(140, 124);
            this.label7.TabIndex = 8;
            this.label7.Text = "Descripción";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbDescripcion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbDescripcion, 2);
            this.tbDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescripcion.Location = new System.Drawing.Point(153, 379);
            this.tbDescripcion.Margin = new System.Windows.Forms.Padding(7);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tableLayoutPanel1.SetRowSpan(this.tbDescripcion, 4);
            this.tbDescripcion.Size = new System.Drawing.Size(328, 110);
            this.tbDescripcion.TabIndex = 11;
            this.tbDescripcion.TextChanged += new System.EventHandler(this.tbDescripcion_TextChanged);
            // 
            // tbReunionID
            // 
            this.tbReunionID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReunionID.Enabled = false;
            this.tbReunionID.Location = new System.Drawing.Point(153, 131);
            this.tbReunionID.Margin = new System.Windows.Forms.Padding(7);
            this.tbReunionID.Name = "tbReunionID";
            this.tbReunionID.Size = new System.Drawing.Size(83, 20);
            this.tbReunionID.TabIndex = 14;
            // 
            // tbReunionNombre
            // 
            this.tbReunionNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReunionNombre.Enabled = false;
            this.tbReunionNombre.Location = new System.Drawing.Point(250, 131);
            this.tbReunionNombre.Margin = new System.Windows.Forms.Padding(7);
            this.tbReunionNombre.Name = "tbReunionNombre";
            this.tbReunionNombre.Size = new System.Drawing.Size(231, 20);
            this.tbReunionNombre.TabIndex = 15;
            // 
            // cbEstado
            // 
            this.cbEstado.BeforeTouchSize = new System.Drawing.Size(328, 21);
            this.tableLayoutPanel1.SetColumnSpan(this.cbEstado, 2);
            this.cbEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.Items.AddRange(new object[] {
            "Retrasada",
            "En curso",
            "Terminada",
            "Abandonada",
            "Planificada"});
            this.cbEstado.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbEstado, "Retrasada"));
            this.cbEstado.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbEstado, "En curso"));
            this.cbEstado.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbEstado, "Terminada"));
            this.cbEstado.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbEstado, "Abandonada"));
            this.cbEstado.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbEstado, "Planificada"));
            this.cbEstado.Location = new System.Drawing.Point(153, 255);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(7);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(328, 21);
            this.cbEstado.TabIndex = 16;
            this.cbEstado.TextChanged += new System.EventHandler(this.cbEstado_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 31);
            this.label8.TabIndex = 17;
            this.label8.Text = "Responsable";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbResponsable
            // 
            this.cbResponsable.BeforeTouchSize = new System.Drawing.Size(328, 21);
            this.tableLayoutPanel1.SetColumnSpan(this.cbResponsable, 2);
            this.cbResponsable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbResponsable.Location = new System.Drawing.Point(153, 348);
            this.cbResponsable.Margin = new System.Windows.Forms.Padding(7);
            this.cbResponsable.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.cbResponsable.Name = "cbResponsable";
            metroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable1.ArrowInActive = System.Drawing.Color.White;
            metroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ArrowNormalBackGround = System.Drawing.Color.Empty;
            metroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ArrowPushedBackGround = System.Drawing.Color.Empty;
            metroColorTable1.ScrollerBackground = System.Drawing.Color.White;
            metroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable1.ThumbInActive = System.Drawing.Color.White;
            metroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ThumbPushedBorder = System.Drawing.Color.Empty;
            this.cbResponsable.ScrollMetroColorTable = metroColorTable1;
            this.cbResponsable.Size = new System.Drawing.Size(328, 21);
            this.cbResponsable.TabIndex = 18;
            this.cbResponsable.Text = "multiColumnComboBox1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 31);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tiempo Dedicado";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 310);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 31);
            this.label10.TabIndex = 20;
            this.label10.Text = "Fecha de Realización";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTiempoDedicado
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbTiempoDedicado, 2);
            this.tbTiempoDedicado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTiempoDedicado.Location = new System.Drawing.Point(153, 286);
            this.tbTiempoDedicado.Margin = new System.Windows.Forms.Padding(7);
            this.tbTiempoDedicado.Name = "tbTiempoDedicado";
            this.tbTiempoDedicado.Size = new System.Drawing.Size(328, 20);
            this.tbTiempoDedicado.TabIndex = 21;
            this.tbTiempoDedicado.TextChanged += new System.EventHandler(this.tbTiempoDedicado_TextChanged);
            // 
            // FechaEjecucion
            // 
            this.FechaEjecucion.BorderColor = System.Drawing.Color.Empty;
            this.FechaEjecucion.CalendarSize = new System.Drawing.Size(189, 176);
            this.tableLayoutPanel1.SetColumnSpan(this.FechaEjecucion, 2);
            this.FechaEjecucion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FechaEjecucion.DropDownImage = null;
            this.FechaEjecucion.DropDownNormalColor = System.Drawing.SystemColors.Control;
            this.FechaEjecucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaEjecucion.Location = new System.Drawing.Point(153, 317);
            this.FechaEjecucion.Margin = new System.Windows.Forms.Padding(7);
            this.FechaEjecucion.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.FechaEjecucion.MinValue = new System.DateTime(((long)(0)));
            this.FechaEjecucion.Name = "FechaEjecucion";
            this.FechaEjecucion.ShowCheckBox = false;
            this.FechaEjecucion.Size = new System.Drawing.Size(328, 17);
            this.FechaEjecucion.TabIndex = 22;
            this.FechaEjecucion.Value = new System.DateTime(2016, 4, 25, 12, 53, 15, 999);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnAcepta, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 496);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(488, 40);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // btnAcepta
            // 
            this.btnAcepta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAcepta.Location = new System.Drawing.Point(7, 7);
            this.btnAcepta.Margin = new System.Windows.Forms.Padding(7);
            this.btnAcepta.Name = "btnAcepta";
            this.btnAcepta.Size = new System.Drawing.Size(148, 26);
            this.btnAcepta.TabIndex = 0;
            this.btnAcepta.Text = "Actualizar";
            this.btnAcepta.UseVisualStyleBackColor = true;
            this.btnAcepta.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.Location = new System.Drawing.Point(331, 7);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 26);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(169, 7);
            this.button3.Margin = new System.Windows.Forms.Padding(7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 26);
            this.button3.TabIndex = 2;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 31);
            this.label11.TabIndex = 24;
            this.label11.Text = "Proceso";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBoxPuntoRojoID
            // 
            this.ComboBoxPuntoRojoID.BeforeTouchSize = new System.Drawing.Size(83, 21);
            this.ComboBoxPuntoRojoID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxPuntoRojoID.Location = new System.Drawing.Point(153, 162);
            this.ComboBoxPuntoRojoID.Margin = new System.Windows.Forms.Padding(7);
            this.ComboBoxPuntoRojoID.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.ComboBoxPuntoRojoID.Name = "ComboBoxPuntoRojoID";
            metroColorTable2.ArrowChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable2.ArrowInActive = System.Drawing.Color.White;
            metroColorTable2.ArrowNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable2.ArrowNormalBackGround = System.Drawing.Color.Empty;
            metroColorTable2.ArrowPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable2.ArrowPushedBackGround = System.Drawing.Color.Empty;
            metroColorTable2.ScrollerBackground = System.Drawing.Color.White;
            metroColorTable2.ThumbChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable2.ThumbInActive = System.Drawing.Color.White;
            metroColorTable2.ThumbNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable2.ThumbPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable2.ThumbPushedBorder = System.Drawing.Color.Empty;
            this.ComboBoxPuntoRojoID.ScrollMetroColorTable = metroColorTable2;
            this.ComboBoxPuntoRojoID.Size = new System.Drawing.Size(83, 21);
            this.ComboBoxPuntoRojoID.TabIndex = 25;
            this.ComboBoxPuntoRojoID.Text = "multiColumnComboBox1";
            // 
            // textBoxPuntoRojoProceso
            // 
            this.textBoxPuntoRojoProceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPuntoRojoProceso.Enabled = false;
            this.textBoxPuntoRojoProceso.Location = new System.Drawing.Point(250, 162);
            this.textBoxPuntoRojoProceso.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxPuntoRojoProceso.Name = "textBoxPuntoRojoProceso";
            this.textBoxPuntoRojoProceso.Size = new System.Drawing.Size(231, 20);
            this.textBoxPuntoRojoProceso.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 31);
            this.label12.TabIndex = 27;
            this.label12.Text = "TareaPadre";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBoxTareaPadre
            // 
            this.ComboBoxTareaPadre.BeforeTouchSize = new System.Drawing.Size(83, 21);
            this.ComboBoxTareaPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxTareaPadre.Location = new System.Drawing.Point(153, 193);
            this.ComboBoxTareaPadre.Margin = new System.Windows.Forms.Padding(7);
            this.ComboBoxTareaPadre.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.ComboBoxTareaPadre.Name = "ComboBoxTareaPadre";
            metroColorTable3.ArrowChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable3.ArrowInActive = System.Drawing.Color.White;
            metroColorTable3.ArrowNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable3.ArrowNormalBackGround = System.Drawing.Color.Empty;
            metroColorTable3.ArrowPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable3.ArrowPushedBackGround = System.Drawing.Color.Empty;
            metroColorTable3.ScrollerBackground = System.Drawing.Color.White;
            metroColorTable3.ThumbChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable3.ThumbInActive = System.Drawing.Color.White;
            metroColorTable3.ThumbNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable3.ThumbPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable3.ThumbPushedBorder = System.Drawing.Color.Empty;
            this.ComboBoxTareaPadre.ScrollMetroColorTable = metroColorTable3;
            this.ComboBoxTareaPadre.Size = new System.Drawing.Size(83, 21);
            this.ComboBoxTareaPadre.TabIndex = 28;
            this.ComboBoxTareaPadre.Text = "multiColumnComboBox1";
            // 
            // textBoxTareaPadre
            // 
            this.textBoxTareaPadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTareaPadre.Enabled = false;
            this.textBoxTareaPadre.Location = new System.Drawing.Point(250, 193);
            this.textBoxTareaPadre.Margin = new System.Windows.Forms.Padding(7);
            this.textBoxTareaPadre.Name = "textBoxTareaPadre";
            this.textBoxTareaPadre.Size = new System.Drawing.Size(231, 20);
            this.textBoxTareaPadre.TabIndex = 29;
            // 
            // comboBoxTipo
            // 
            // 
            // 
            // 
            this.comboBoxTipo.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.comboBoxTipo.AutoCompleteControl.HeaderFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.comboBoxTipo.AutoCompleteControl.ItemFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.comboBoxTipo.AutoCompleteControl.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.comboBoxTipo.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxTipo.AutoCompleteControl.ParentForm = this.tableLayoutPanel1;
            this.comboBoxTipo.AutoCompleteControl.Style = Syncfusion.Windows.Forms.Tools.AutoCompleteStyle.Default;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxTipo, 2);
            this.comboBoxTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTipo.DropDownWidth = 121;
            this.comboBoxTipo.Location = new System.Drawing.Point(153, 224);
            this.comboBoxTipo.Margin = new System.Windows.Forms.Padding(7);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.ParentForm = this.tableLayoutPanel1;
            this.comboBoxTipo.Size = new System.Drawing.Size(328, 21);
            this.comboBoxTipo.TabIndex = 30;
            this.comboBoxTipo.Text = "comboBoxAutoComplete1";
            // 
            // EditarTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.BorderThickness = 10;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(207)))), ((int)(((byte)(96)))));
            this.CaptionFont = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(488, 536);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(500, 524);
            this.Name = "EditarTarea";
            this.Text = "Editar Tarea";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbResponsable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FechaEjecucion)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxPuntoRojoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxTareaPadre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTipo.AutoCompleteControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv FechaFin;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv FechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.TextBox tbReunionID;
        private System.Windows.Forms.TextBox tbReunionNombre;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbEstado;
        private System.Windows.Forms.Label label8;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox cbResponsable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTiempoDedicado;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv FechaEjecucion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAcepta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label11;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox ComboBoxPuntoRojoID;
        private System.Windows.Forms.TextBox textBoxPuntoRojoProceso;
        private System.Windows.Forms.Label label12;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox ComboBoxTareaPadre;
        private System.Windows.Forms.TextBox textBoxTareaPadre;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete comboBoxTipo;
    }
}