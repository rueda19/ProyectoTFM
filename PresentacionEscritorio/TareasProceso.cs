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
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.XlsIO;

namespace PresentacionEscritorio
{
    public partial class TareasProceso : MetroForm
    {
        GridExcelFilter filter = new GridExcelFilter();
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        //List<Proceso> procesos = new List<Proceso>();
        //List<TareaAux> tareas = new List<TareaAux>();
        private string IDProc;
        List<List<Tarea>> tareas = new List<List<Tarea>>();
        List<Proceso> procesos = new List<Proceso>();
        private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        
        public TareasProceso(string idProc)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icono;
            this.MetroColor = Color.FromArgb(179, 207, 96);
            IDProc = idProc;
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;
            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            dateTimeDesde.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);//DateTime.Parse(DateTime.Now.Year+"/1/1");
            dateTimeHasta.Value = new DateTime(DateTime.Now.Year + 1, 1, 1, 0, 0, 0);

            gridConditionalFormatDescriptor1.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            gridConditionalFormatDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            gridConditionalFormatDescriptor1.Expression = "[FechaFin] <= '" + d + "' and [FechaEjecutado] = ''";

            gridConditionalFormatDescriptor2.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))));
            gridConditionalFormatDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            gridConditionalFormatDescriptor2.Expression = "[FechaEjecutado] <> ''";

            ObtenerDatos();
            MostrarGridGroupingControl();

            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            this.gridGroupingControl1.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo);
            this.gridGroupingControl1.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridGroupingControl1_TableControlCellDoubleClick);
            this.gridGroupingControl1.TableControlCellClick += new GridTableControlCellClickEventHandler(gridGroupingControl1_TableControlCellClick);

            this.listBox1.AllowDrop = true;
            this.listBox2.AllowDrop = true;

            this.listBox1.MouseDown += new MouseEventHandler(this.listBox1_MouseDown);
            this.listBox2.DragDrop += new DragEventHandler(listBox2_DragDrop);
            this.listBox2.DragOver += new DragEventHandler(listBox2_DragOver);
            this.listBox2.MouseDown += new MouseEventHandler(this.listBox1_MouseDown);
            this.listBox1.DragDrop += new DragEventHandler(listBox2_DragDrop);
            this.listBox1.DragOver += new DragEventHandler(listBox2_DragOver);
        }

        private void listBox2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                ((ListBox)sender).Items.Add(str);
            }

        }

        private void listBox2_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (((ListBox)sender).Items.Count == 0)
                return;
            if (((ListBox)sender).IndexFromPoint(e.X, e.Y) == -1)
                return;
            string s = ((ListBox)sender).Items[((ListBox)sender).IndexFromPoint(e.X, e.Y)].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                ((ListBox)sender).Items.RemoveAt(((ListBox)sender).IndexFromPoint(e.X, e.Y));
                MostrarGridGroupingControl();
                //MostrarGridGroupingControl();
                //if (listBox1.Items.Count == 1)
                //    this.gridGroupingControl1.TableModel.QueryRowHeight += new GridRowColSizeEventHandler(TableModel_QueryRowHeight);
                //else
                //    this.gridGroupingControl1.TableModel.QueryRowHeight += null;
            }

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
                    if (!(style.Text.StartsWith("P") && style.Text.Length == 3))
                    {
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
                            else
                            {
                                DetallesTarea formIT = new DetallesTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                                formIT.ShowDialog();
                            }
                            ObtenerDatos();
                            MostrarGridGroupingControl();
                        }
                    }
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
                this.Hide();
                //var form2 = new MisTareas();
                var form2 = new TodasTareas();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
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
            tareas = negocio.getTareasProcesos(IDProc, dateTimeDesde.Value, dateTimeHasta.Value);
            if (IDProc == "GBL")
                procesos = negocio.getProcesos();
            else
            {
                procesos = new List<Proceso>();
                procesos.Add(negocio.getProceso(IDProc));
            }
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

            gridGroupingControl1.TableDescriptor.Columns.Reset();

            if (listBox1.Items.Count==0)
                this.gridGroupingControl1.DataSource = null;

            if (listBox1.Items.Contains("Procesos"))
            {
                this.gridGroupingControl1.DataSource = procesos;
                this.gridGroupingControl1.Engine.SourceListSet.Add("Procesos", procesos);
            }

            if (listBox1.Items.Contains("Tareas"))
            {
                GridRelationDescriptor childToChildRelationDescriptor = null;
                for (int i = 0; i < tareas.Count; i++)
                {
                    if (tareas[0] != null)
                    if (i == 0)
                    {
                        if (listBox1.Items.Contains("Procesos"))
                        {
                            GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
                            parentToChildRelationDescriptor.ChildTableName = "lista" + i;    // same as SourceListSetEntry.Name for childTable (see below)
                            parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
                            parentToChildRelationDescriptor.ChildTableDescriptor.TopLevelGroupOptions.ShowCaption = false;

                            parentToChildRelationDescriptor.RelationKeys.Add("ID", "IDProceso");

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

                            parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                            parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                            childToChildRelationDescriptor = parentToChildRelationDescriptor;
                            //this.gridGroupingControl1.DataSource = tareas[0];
                        }
                        else
                        {
                            this.gridGroupingControl1.DataSource = tareas[0];
                            this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);

                            gridGroupingControl1.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "dd-MM-yyyy";
                            gridGroupingControl1.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "dd-MM-yyyy";
                            gridGroupingControl1.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "dd-MM-yyyy";

                            this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                            this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                        }
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

                        parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                        parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                        childToChildRelationDescriptor = parentToChildRelationDescriptor;
                    }
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
            this.gridGroupingControl1.OptimizeFilterPerformance = true;

            filter.WireGrid(gridGroupingControl1);
        }

        private void MostrarGridGroupingControl1()
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

            gridGroupingControl1.TableDescriptor.Columns.Reset();

            GridRelationDescriptor childToChildRelationDescriptor = null;
            for (int i = 0; i < tareas.Count; i++ )
            {
                if (i == 0)
                {
                    this.gridGroupingControl1.DataSource = tareas[0];
                    this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);
                }
                else
                {
                    GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
                    parentToChildRelationDescriptor.ChildTableName = "lista" + i;    // same as SourceListSetEntry.Name for childTable (see below)
                    parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;

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
                    //filter.WireGrid(parentToChildRelationDescriptor);

                    childToChildRelationDescriptor = parentToChildRelationDescriptor;
                }
            }

            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
            {
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = true;
                gridGroupingControl1.TableDescriptor.Columns[j].ReadOnly = true;
            }
            this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowFilterBar = true;
            this.gridGroupingControl1.ChildGroupOptions.ShowFilterBar = true;

            // Enable Optimized Filter in GridGRoupingControl.
            this.gridGroupingControl1.OptimizeFilterPerformance = true;

            filter.WireGrid(gridGroupingControl1);

            //filter.UnWireGrid(gridGroupingControl1);
            //filter.ClearFilters(gridGroupingControl1);
            //for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
            //    gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = false;

            //this.gridGroupingControl1.Table.CollapseAllRecords();
            //this.gridGroupingControl1.Engine.SourceListSet.Clear();
            //gridGroupingControl1.TableDescriptor.Relations.Clear();
            //gridGroupingControl1.Update();
            //this.gridGroupingControl1.Refresh();

            //gridGroupingControl1.TableDescriptor.Columns.Reset();

            //int i = listBox1.Items.Count;
            //if (i > 0)
            //{
            //    setDataSource();
            //    setLista(0);

            //    if (i > 1)
            //    {
            //        GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
            //        parentToChildRelationDescriptor.ChildTableName = listBox1.Items[1].ToString();    // same as SourceListSetEntry.Name for childTable (see below)
            //        parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;

            //        parentToChildRelationDescriptor.RelationKeys.Add(getID1(listBox1.Items[0].ToString(), listBox1.Items[1].ToString()), getID2(listBox1.Items[0].ToString(), listBox1.Items[1].ToString()));

            //        // Add relation to ParentTable 
            //        gridGroupingControl1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);
            //        setLista(1);

            //        for (int j = 0; j < parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
            //            parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;

            //        if (i > 2)
            //        {
            //            GridRelationDescriptor childToGrandChildRelationDescriptor = new GridRelationDescriptor();
            //            childToGrandChildRelationDescriptor.ChildTableName = listBox1.Items[2].ToString();  // same as SourceListSetEntry.Name for grandChhildTable (see below)
            //            childToGrandChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;

            //            childToGrandChildRelationDescriptor.RelationKeys.Add(getID1(listBox1.Items[1].ToString(), listBox1.Items[2].ToString()), getID2(listBox1.Items[1].ToString(), listBox1.Items[2].ToString()));

            //            // Add relation to ChildTable 
            //            parentToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor);
            //            setLista(2);

            //            for (int j = 0; j < childToGrandChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
            //                childToGrandChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
            //        }
            //    }

            //    for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
            //    {
            //        gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = true;
            //        gridGroupingControl1.TableDescriptor.Columns[j].ReadOnly = true;
            //    }

            //    filter.WireGrid(gridGroupingControl1);
            //}
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
                if (!(style.Text.StartsWith("P") && style.Text.Length == 3))
                {
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
                        else
                        {
                            EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                            formIT.ShowDialog();
                        }
                        ObtenerDatos();
                        MostrarGridGroupingControl();
                    }
                }
            }
        }

        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new EstadisticasTareas(IDProc);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void buttonAnadirTarea_Click(object sender, EventArgs e)
        {
            if (IDProc != "GBL")
            {
                AnadirTarea formIT = new AnadirTarea(null, procesos.Single(s => s.ID == IDProc), null);
                formIT.ShowDialog();
            }
            else
            {
                AnadirTarea formIT = new AnadirTarea(null, null, null);
                formIT.ShowDialog();
            }
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void buttonExportarExcel_Click(object sender, EventArgs e)
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
    }
}
