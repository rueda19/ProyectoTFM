using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Negocio;
using Modelo;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Drawing;
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.XlsIO;

namespace PresentacionEscritorio
{
    public partial class TodasTareas : MetroForm
    {
        GridExcelFilter filter = new GridExcelFilter();
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        List<List<Tarea>> tareas = new List<List<Tarea>>();
        private string empleado, tipo, proceso;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        private string filtrarPor = "Todas";
        private int tamanioLetra = 8;

        public TodasTareas()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icono;
            this.MetroColor = Color.FromArgb(179, 207, 96);
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;
            empleado = user.ToUpper();
            tipo = "Tarea";
            proceso = "";
            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            gridConditionalFormatDescriptor1.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            gridConditionalFormatDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            //DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, 0, 0, 0);
            DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            d = d.AddDays(1);
            DateTime d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            d1 = d1.AddDays(16);
            gridConditionalFormatDescriptor1.Expression = "[FechaFin] <= '" + d + "' and [FechaEjecutado] = ''";

            gridConditionalFormatDescriptor2.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))));
            gridConditionalFormatDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            gridConditionalFormatDescriptor2.Expression = "[FechaEjecutado] <> ''";

            gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(0))))));
            gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            gridConditionalFormatDescriptor3.Expression = "[FechaFin] <= '" + d1 + "' and [FechaEjecutado] = ''"; ;

            this.comboBoxTipo.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.comboBoxTipo.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxTipo.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxTipo.AutoCompleteControl.DataSource = negocio.getTiposTareas();
            comboBoxTipo.Text = tipo;

            this.comboBoxUsuario.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.comboBoxUsuario.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxUsuario.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxUsuario.AutoCompleteControl.DataSource = negocio.getUsuariosDepartamentos();
            comboBoxUsuario.Text = empleado;

            this.comboBoxProceso.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.comboBoxProceso.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxProceso.AutoCompleteControl.OverrideCombo = true;
            List<String> procesos = negocio.getProcesosListado();
            procesos.Add("");
            this.comboBoxProceso.AutoCompleteControl.DataSource = procesos;
            comboBoxProceso.Text = proceso;

            dateTimeDesde.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);//DateTime.Parse(DateTime.Now.Year+"/1/1");
            dateTimeHasta.Value = new DateTime(DateTime.Now.Year + 1, 1, 1, 0, 0, 0);

            ObtenerDatos();

            MostrarGridGroupingControl();

            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            this.gridGroupingControl1.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo);
            //gridGroupingControl1.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells);
            this.gridGroupingControl1.TableControlCellClick += new GridTableControlCellClickEventHandler(gridGroupingControl1_TableControlCellClick);
            this.gridGroupingControl1.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridGroupingControl1_TableControlCellDoubleClick);

            this.gridGroupingControl1.RecordExpanding += new Syncfusion.Grouping.RecordEventHandler(this.gridGroupingControl1_RecordExpanding);
        }

        void gridGroupingControl1_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            if (e.Inner.MouseEventArgs.Button == MouseButtons.Right)
            {
                Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();

                if (el != null)
                {
                    GridTable table = el.ParentTable as GridTable;
                    GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                      (table.TableDescriptor.Name);
                    GridCurrentCell cc = tableControl.CurrentCell;
                    //GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                    GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        if (styleID.TableCellIdentity.Column != null)
                        {
                            DetallesTarea formIT = new DetallesTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                            formIT.ShowDialog();
                        }
                        else if (style.TableCellIdentity.Column != null)
                        {
                            DetallesTarea formIT = new DetallesTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                            formIT.ShowDialog();
                        }
                        else
                        {
                            DetallesTarea formIT = new DetallesTarea(negocio.getTarea((int)rec.GetValue("ID")));
                            formIT.ShowDialog();
                        }
                        ObtenerDatos();
                        MostrarGridGroupingControl();
                    }
                }
            }
        }

        private void gridGroupingControl1_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();

            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                //GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    if (styleID.TableCellIdentity.Column != null)
                    {
                        EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                        formIT.ShowDialog();
                    }
                    else if (style.TableCellIdentity.Column != null)
                    {
                        EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                        formIT.ShowDialog();
                    }
                    else
                    {
                        EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue("ID")));
                        formIT.ShowDialog();
                    }
                    ObtenerDatos();
                    MostrarGridGroupingControl();
                }
            }
        }

        void gridGroupingControl1_QueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.TableCellType == GridTableCellType.RecordPlusMinusCell)
            {
                Element cell = e.TableCellIdentity.DisplayElement;
                Record r = cell.ParentRecord as Record;
                bool makeStatic = true;
                if (r != null && r.NestedTables.Count > 0)
                {
                    foreach (NestedTable nt in r.NestedTables)
                    {
                        if (nt.ChildTable.GetFilteredRecordCount() != 0)
                            makeStatic = false;
                    }
                }
                if (makeStatic)
                {
                    e.Style.CellType = "Static";
                    e.Style.Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.FromArgb(208, 215, 229));
                }
            }
        }

        void image_ImageMouseUp(object sender, ImageMouseUpEventArgs e)
        {
            if ((sender as CaptionImage).Name == "CaptionImage1")
            {
                this.Hide();
                var form2 = new Form1();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage2")
            {
                this.Hide();
                var form2 = new MisReuniones();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage3")
            {
                //this.Hide();
                ////var form2 = new MisTareas();
                //var form2 = new TodasTareas();
                //form2.Closed += (s, args) => this.Close();
                //form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage4")
            {
                this.Hide();
                var form2 = new ListaEmpleados();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage5")
            {
                this.Hide();
                var form2 = new ProcesosPrincipales("GBL");
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        void image_ImageMouseEnter(object sender, ImageMouseEnterEventArgs e)
        {
            e.BackColor = Color.Red;
        }

        void image_ImageMouseLeave(object sender, ImageMouseLeaveEventArgs e)
        {
            e.BackColor = Color.Transparent;
        }

        private void ObtenerDatos()
        {
            tareas = negocio.getTareasTipoUsuario(tipo, empleado, dateTimeDesde.Value, dateTimeHasta.Value, filtrarPor, proceso);
            MostrarIndicadores();
        }

        private void MostrarIndicadores()
        {
            int tareasTotales=0;
            int tareasPasadas = 0;
            int tareasCercanas = 0;
            int tareasTerminadas = 0;
            foreach (List<Tarea> tar in tareas)
            {
                tareasTotales += tar.Where(t => t.Tipo == "Tarea").Count();
                tareasPasadas += tar.Where(t => t.FechaFin < DateTime.Now && t.FechaEjecutado == null && t.Tipo=="Tarea").Count();
                tareasCercanas += tar.Where(t => t.FechaFin < DateTime.Now.AddDays(15) && t.FechaEjecutado == null && t.Tipo == "Tarea").Count();
                tareasTerminadas += tar.Where(t => t.FechaEjecutado != null && t.Tipo == "Tarea").Count();
            }
            tareasCercanas = tareasCercanas - tareasPasadas;

            labelTotales.Text = tareasTotales.ToString();
            labelPasadas.Text = tareasPasadas.ToString();
            labelCeranas.Text = tareasCercanas.ToString();
            labelTerminadas.Text = tareasTerminadas.ToString();
        }

        private void MostrarGridGroupingControl()
        {
            filter.UnWireGrid(gridGroupingControl1);
            filter.ClearFilters(gridGroupingControl1);
            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = false;

            gridGroupingControl1.TableDescriptor.Relations.Clear();
            this.gridGroupingControl1.Table.CollapseAllRecords();
            this.gridGroupingControl1.Engine.SourceListSet.Clear();
            gridGroupingControl1.Update();
            this.gridGroupingControl1.Refresh();
            gridGroupingControl1.Appearance.AnyRecordFieldCell.Font.Size = tamanioLetra;

            gridGroupingControl1.TableDescriptor.Columns.Reset();
            this.gridGroupingControl1.DataSource = tareas[0];

            GridRelationDescriptor childToChildRelationDescriptor = null;
            for (int i = 0; i < tareas.Count; i++)
            {
                if (tareas[0] != null)
                if (i == 0)
                {
                    //this.gridGroupingControl1.DataSource = tareas[0];
                    this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);
                    gridGroupingControl1.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    gridGroupingControl1.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    gridGroupingControl1.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "dd-MM-yyyy";

                    this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                    this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                    this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor3);
                }
                else
                {
                    GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
                    parentToChildRelationDescriptor.ChildTableName = "lista" + i;    // same as SourceListSetEntry.Name for childTable (see below)
                    parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
                    parentToChildRelationDescriptor.ChildTableDescriptor.TopLevelGroupOptions.ShowCaption = false;

                    parentToChildRelationDescriptor.RelationKeys.Add("ID", "IDTareaPadre");

                    // Add relation to ParentTable 
                    if (childToChildRelationDescriptor == null)
                        gridGroupingControl1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);
                    else
                        childToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(parentToChildRelationDescriptor);

                    this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);

                    for (int j = 0; j < parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
                    //parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                    {
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].AllowFilter = true;
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                    }
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[5].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[3].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[4].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    //filter.WireGrid(parentToChildRelationDescriptor);

                    //gridGroupingControl1.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells);

                    //this.gridGroupingControl1.GetTableDescriptor("lista" + i).AllowCalculateMaxColumnWidth = false; 
                    //GridTableModel tm = this.gridGroupingControl1.GetTableModel("lista"+i); 
                    ////tm.Table.FilteredChildTable = null; 
                    //tm.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);
                    parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                    parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                    parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor3);
                    childToChildRelationDescriptor = parentToChildRelationDescriptor;
                    //this.gridGroupingControl1.TableModel.QueryRowHeight += TableModel_QueryRowHeight;
                    //parentToChildRelationDescriptor.ChildTableDescriptor.Columns[0].hei
                }
            }

            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
            {
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = true;
                gridGroupingControl1.TableDescriptor.Columns[j].ReadOnly = true;
            }
            //this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            //this.gridGroupingControl1.NestedTableGroupOptions.ShowFilterBar = true;
            //this.gridGroupingControl1.ChildGroupOptions.ShowFilterBar = true;

            // Enable Optimized Filter in GridGRoupingControl.
            this.gridGroupingControl1.OptimizeFilterPerformance = true;

            filter.WireGrid(gridGroupingControl1);
            if (checkBoxExpandir.Checked)
                this.gridGroupingControl1.Table.ExpandAllRecords();
            else
                this.gridGroupingControl1.Table.CollapseAllRecords();
        }

        private void comboBoxTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            tipo = comboBoxTipo.Text;
        }

        private void comboBoxUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            empleado = comboBoxUsuario.Text;
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void buttonAnadirTarea_Click(object sender, EventArgs e)
        {
            AnadirTarea formIT = new AnadirTarea(null, null, null);
            formIT.ShowDialog();
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files(*.xlsx)|*xlsx|Files(*.xls)|*.xls";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.FileName = "Untitled";
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
            {
                GridGroupingExcelConverterControl excelConverter = new GridGroupingExcelConverterControl();
                ExcelExportingOptions exportingOptions = new ExcelExportingOptions(); 
                
                excelConverter.ExportBorders = true;
                excelConverter.ApplyExcelFilter = true;
                excelConverter.CanExportColumnWidth = true;
                excelConverter.CanExportRowHeight = true;
                excelConverter.AllowGroupOutlining = true;
                excelConverter.AllowNestedTableOutling = true;
                //This property is used to export the GGc with optimized manner. If you enable this property, the grid will be exported without creating the styles. 
                //The data will be taken from Table.Records and number format will be set as column wise.
                excelConverter.EnableOptimization = true;

                excelConverter.ExportNestedTableCaption = true;
                excelConverter.ShowGridLines = true;

                exportingOptions.ExportGroupSummary = true;
                exportingOptions.ExportTableSummary = true;

                excelConverter.QueryExportRowRange += new GridGroupingExcelConverterControl.QueryExportRowRangeEventHandler(excelConverter_QueryExportRowRange);
                excelConverter.QueryExportNestedTable += new GridGroupingExcelConverterControl.ExportNestedTableEventHandler(gridExcelConverter_QueryExportNestedTable);
                
                excelConverter.ExportStyle = true;
                excelConverter.ExportNestedTableCaption = false; 
                excelConverter.ExportToExcel(this.gridGroupingControl1, saveFileDialog.FileName, exportingOptions);
                if (MessageBox.Show("¿Queires abrir el fichero xlsx ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = saveFileDialog.FileName;
                    proc.Start();
                }
            }
        }

        void gridExcelConverter_QueryExportNestedTable(object sender, ExportNestedTableEventArgs e)
        {
            // Hide the empty elements being exported to Excel.
            if (e.NestedTable.Records.Count == 0)
                e.Cancel = true;
        }

        private void excelConverter_QueryExportRowRange(object sender, QueryExportRowRangeEventArgs e)
        {
            GridTableDescriptor tableDescriptor = (GridTableDescriptor)e.Element.ParentTableDescriptor;
            int excelRowIndex = e.ExcelRange.Row;
            if (e.Element.Kind == DisplayElementKind.ColumnHeader)
            {
                for (int columnIndex = 0; columnIndex < tableDescriptor.VisibleColumns.Count; columnIndex++)
                {
                    IRange range = e.ExcelRange[excelRowIndex, e.ExcelRange.Column + columnIndex];
                    //range.CellStyle.ColorIndex = Syncfusion.XlsIO.ExcelKnownColors.Light_blue;
                    //range.CellStyle.Font.RGBColor = Color.DarkRed;
                    range.CellStyle.Font.FontName = "Segoe UI";
                    range.CellStyle.Font.Size = 10;
                    range.CellStyle.Font.Bold = true;
                    range.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                }
            }
        }

        private void buttonTareasFecha_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new TareasEnFecha();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void radioButtonTodas_CheckedChanged(object sender, EventArgs e)
        {
            var buttons = groupBoxFiltrar.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            //var buttons = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            if (buttons.Name != filtrarPor)
            {
                if (buttons.Name == "Todas" || buttons.Name == "TodasTerminadas")
                {
                    dateTimeDesde.Enabled = true;
                    dateTimeHasta.Enabled = true;
                }
                else
                {
                    dateTimeDesde.Enabled = false;
                    dateTimeHasta.Enabled = false;
                }
                filtrarPor = buttons.Name;
                ObtenerDatos();
                MostrarGridGroupingControl();
            }
        }

        private void gridGroupingControl1_RecordExpanding(object sender, Syncfusion.Grouping.RecordEventArgs e)
        {
            if (e.Record != null && e.Record.NestedTables.Count > 0 && e.Record.NestedTables[0].ChildTable.Records.Count == 0)
                e.Cancel = true;
        }

        private void checkBoxExpandir_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxExpandir.Checked)
                this.gridGroupingControl1.Table.ExpandAllRecords();
            else
                this.gridGroupingControl1.Table.CollapseAllRecords();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            int tam;
            if (!Int32.TryParse(cbTamanoLetra.Text, out tam))
            {
                MessageBox.Show("Debe ser un tipo numerico");
            }
            else if (tam > 72)
            {
                MessageBox.Show("El tamaño de letra no puede ser mayor de 72");
            }
            else if (tam < 6)
            {
                MessageBox.Show("El tamaño de letra no puede ser menor de 6");
            }
            else
            {
                tamanioLetra = tam;
                gridGroupingControl1.Appearance.AnyRecordFieldCell.Font.Size = tamanioLetra;
            }
        }

        private void comboBoxProceso_TextChanged(object sender, EventArgs e)
        {
            proceso = comboBoxProceso.Text;
        }
    }
}
