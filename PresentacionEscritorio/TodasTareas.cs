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
        List<List<TareaCompleta>> tareas = new List<List<TareaCompleta>>();
        private string empleado, tipo, proceso;
        //private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        //private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        //private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
        private string filtrarPor = "Todas";
        private int tamanioLetra = 8;
        private string valorAntiguo = "";

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

            //gridConditionalFormatDescriptor1.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            //gridConditionalFormatDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            ////DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, 0, 0, 0);
            //DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            //d = d.AddDays(1);
            //DateTime d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            //d1 = d1.AddDays(16);
            //gridConditionalFormatDescriptor1.Expression = "[FechaFin] <= '" + d + "' and [FechaEjecutado] = ''";

            //gridConditionalFormatDescriptor2.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))));
            //gridConditionalFormatDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            //gridConditionalFormatDescriptor2.Expression = "[FechaEjecutado] <> ''";

            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(0))))));
            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            //gridConditionalFormatDescriptor3.Expression = "[FechaFin] <= '" + d1 + "' and [FechaEjecutado] = ''"; ;

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

            //ObtenerDatos();

            //MostrarGridGroupingControl();

            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            this.gridGroupingControl1.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo);
            //gridGroupingControl1.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells);
            this.gridGroupingControl1.TableControlCellClick += new GridTableControlCellClickEventHandler(gridGroupingControl1_TableControlCellClick);
            this.gridGroupingControl1.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridGroupingControl1_TableControlCellDoubleClick);

            this.gridGroupingControl1.RecordValueChanged += new RecordValueChangedEventHandler(gridGroupingControl1_RecordValueChanged);
            this.gridGroupingControl1.RecordValueChanging += new RecordValueChangingEventHandler(gridGroupingControl1_RecordValueChanging);

            this.gridGroupingControl1.RecordExpanding += new Syncfusion.Grouping.RecordEventHandler(this.gridGroupingControl1_RecordExpanding);

            ObtenerDatos();

            MostrarGridGroupingControl();
        }

        private void gridGroupingControl1_RecordValueChanging(object sender, RecordValueChangingEventArgs e)
        {
            //Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            if (sender.GetType() == typeof(GridGroupingControl))
            {
                GridGroupingControl ggcAux = (GridGroupingControl)sender;
                Element el = ggcAux.Table.GetInnerMostCurrentElement();

                if (el != null)
                {
                    GridTable table = el.ParentTable as GridTable;
                    GridTableControl tableControl = ggcAux.GetTableControl
                                      (table.TableDescriptor.Name);
                    GridCurrentCell cc = tableControl.CurrentCell;
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        string fila = style.TableCellIdentity.Column.Name;
                        if (fila.StartsWith("20"))
                           valorAntiguo = rec.GetValue(style.TableCellIdentity.Column.MappingName).ToString();
                        else
                           valorAntiguo = (rec.GetValue(style.TableCellIdentity.Column.Name) == null) ? "" : rec.GetValue(style.TableCellIdentity.Column.Name).ToString();
                    }
                }
            }
        }

        private void gridGroupingControl1_RecordValueChanged(object sender, RecordValueChangedEventArgs e)
        {
            //Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            if (sender.GetType() == typeof(GridGroupingControl))
            {
                GridGroupingControl ggcAux = (GridGroupingControl)sender;
                Element el = ggcAux.Table.GetInnerMostCurrentElement();

                if (el != null)
                {
                    GridTable table = el.ParentTable as GridTable;
                    GridTableControl tableControl = ggcAux.GetTableControl
                                      (table.TableDescriptor.Name);
                    GridCurrentCell cc = tableControl.CurrentCell;
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                    //GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        //MessageBox.Show(style.TableCellIdentity.Column.Name);
                        //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                        //MessageBox.Show(rec.GetValue(styleID.TableCellIdentity.Column.Name).ToString());

                        //int j = (int)rec.GetValue(styleID.TableCellIdentity.Column.Name);
                        int j = (int)rec.GetValue("ID");

                        string fila = style.TableCellIdentity.Column.Name;

                        if (fila.StartsWith("20"))
                        {
                            string valor = (rec.GetValue(style.TableCellIdentity.Column.MappingName) == null) ? "" : rec.GetValue(style.TableCellIdentity.Column.MappingName).ToString();
                            if (negocio.setTareaFilaMeses(j, fila, valor) == 0)
                            {
                                rec.SetValue(style.TableCellIdentity.Column.MappingName, valorAntiguo);
                                MessageBox.Show("Error al actualizar la Tarea");
                            }
                        }
                        else
                        {
                            string valor = (rec.GetValue(style.TableCellIdentity.Column.Name) == null) ? "" : rec.GetValue(style.TableCellIdentity.Column.Name).ToString();
                            //if (fila.Equals("Descripcion")) valor = EliminarCaracteresRTF(valor);
                            if (negocio.setTareaFila(j, fila, valor) == 0)
                            {
                                rec.SetValue(style.TableCellIdentity.Column.Name,valorAntiguo);
                                MessageBox.Show("Error al actualizar la Tarea");
                            }
                        }
                        ObtenerDatos();
                        if (fila.Equals("FechaEjecutado")) MostrarIndicadores();
                    }
                }
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
                    EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue("ID")));
                    formIT.ShowDialog();
                    //if (styleID.TableCellIdentity.Column != null)
                    //{
                    //    EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                    //    formIT.ShowDialog();
                    //}
                    //else if (style.TableCellIdentity.Column != null)
                    //{
                    //    EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                    //    formIT.ShowDialog();
                    //}
                    //else
                    //{
                    //    EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue("ID")));
                    //    formIT.ShowDialog();
                    //}
                    ObtenerDatos();
                    MostrarGridGroupingControl();
                }
            }
        }

        void gridGroupingControl1_QueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.TableCellType != GridTableCellType.AnyIndentCell && e.TableCellIdentity.DisplayElement.IsRecord())
            {
                if (e.TableCellIdentity.ColIndex == 8 || e.TableCellIdentity.ColIndex == 9 || e.TableCellIdentity.ColIndex == 10)
                {
                    if (e.Style.CellValue != null)
                    {
                        if (e.Style.CellValue.ToString() == "Retrasada" || e.Style.CellValue.ToString() == "En curso" || e.Style.CellValue.ToString() == "Planificada" || e.Style.CellValue.ToString() == "Abandonada" || e.Style.CellValue.ToString() == "Terminada")
                        if (sender.GetType() == typeof(GridGroupingControl))
                        {
                            Element el = e.TableCellIdentity.DisplayElement as Element;

                            if (el != null)
                            {
                                GridRecordRow rec = el as GridRecordRow;

                                if (rec != null)
                                {
                                    TareaCompleta tc = rec.GetData() as TareaCompleta;
                                    
                                    if (tc.FechaEjecutado != null)
                                    {
                                        e.Style.Font.Bold = true;
                                        e.Style.BackColor = Color.Lime;
                                        e.Style.TextColor = Color.Black;
                                    }
                                    else if (tc.FechaFin < DateTime.Now)
                                    {
                                        e.Style.Font.Bold = true;
                                        e.Style.BackColor = Color.Red;
                                        e.Style.TextColor = Color.Black;
                                    }
                                    else if (tc.FechaFin < DateTime.Now.AddDays(15))
                                    {
                                        e.Style.Font.Bold = true;
                                        e.Style.BackColor = Color.Orange;
                                        e.Style.TextColor = Color.Black;
                                    }
                                }
                            }
                        }

                        //if (e.Style.CellValue.ToString() == "Retrasada" || e.Style.CellValue.ToString() == "En curso" || e.Style.CellValue.ToString() == "Planificada" || e.Style.CellValue.ToString() == "Abandonada")
                        //{
                        //    //e.Style.Font.Bold = true;
                        //    //e.Style.BackColor = Color.Red;
                        //    //e.Style.TextColor = Color.Black;
                        //}
                        //else if (e.Style.CellValue.ToString() == "En curso")
                        //{
                        //    e.Style.Font.Bold = true;
                        //    e.Style.BackColor = Color.Yellow;
                        //}
                        //else if (e.Style.CellValue.ToString() == "Terminada")
                        //{
                        //    e.Style.Font.Bold = true;
                        //    e.Style.BackColor = Color.GreenYellow;
                        //}
                        //else if (e.Style.CellValue.ToString() == "Planificada")
                        //{
                        //    e.Style.Font.Bold = true;
                        //    e.Style.BackColor = Color.Gray;
                        //    e.Style.TextColor = Color.White;
                        //}
                        //else if (e.Style.CellValue.ToString() == "Abandonada")
                        //{
                        //    e.Style.Font.Bold = true;
                        //    e.Style.BackColor = Color.BurlyWood;
                        //}
                    }
                }
                else if (e.TableCellIdentity.ColIndex > 12)
                {
                    if (e.Style.CellValue!=null)
                    if (e.Style.CellValue.ToString() == "p")
                    {
                        e.Style.BackColor = Color.Gray;
                        e.Style.TextColor = Color.White;
                        e.Style.Font.Bold = true;
                        e.Style.Font.Size = 10;
                        //e.Style.Font.Orientation = 90;
                        
                        //e.Style.TextColor = Color.DarkOliveGreen;
                    }
                    else if (e.Style.CellValue.ToString() == "1")
                    {
                        e.Style.BackColor = Color.Red;
                        e.Style.Font.Bold = true;
                        e.Style.Font.Size = 10;
                    }
                    else if (e.Style.CellValue.ToString() == "2")
                    {
                        e.Style.BackColor = Color.Yellow;
                        e.Style.Font.Bold = true;
                        e.Style.Font.Size = 10;
                    }
                    else if (e.Style.CellValue.ToString() == "3")
                    {
                        e.Style.BackColor = Color.GreenYellow;
                        e.Style.Font.Bold = true;
                        e.Style.Font.Size = 10;
                    }
                    else if (e.Style.CellValue.ToString() == "a")
                    {
                        e.Style.BackColor = Color.BurlyWood;
                        e.Style.Font.Bold = true;
                        e.Style.Font.Size = 10;
                    }
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 7)
                    //{
                    //    e.Style.BackColor = ColorTranslator.FromHtml("#00B0F0");
                    //    e.Style.TextColor = Color.DarkOliveGreen;
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 8)
                    //{
                    //    e.Style.BackColor = Color.Red;
                    //    e.Style.TextColor = Color.Yellow;
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 9)
                    //{
                    //    e.Style.BackColor = Color.Orange;
                    //    e.Style.TextColor = Color.Brown;
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 10)
                    //{
                    //    e.Style.BackColor = Color.Yellow;
                    //    e.Style.TextColor = Color.Brown;
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 11)
                    //{
                    //    e.Style.BackColor = ColorTranslator.FromHtml("#92D050");
                    //    e.Style.TextColor = ColorTranslator.FromHtml("#00B050");
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 12)
                    //{
                    //    e.Style.BackColor = Color.LightGreen;
                    //    e.Style.BackColor = ColorTranslator.FromHtml("#92D050");
                    //    //e.Style.TextColor = Color.Brown;
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 13)
                    //{
                    //    e.Style.BackColor = Color.Gold;
                    //    // e.Style.TextColor = Color.Red;
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 14)
                    //{
                    //    e.Style.BackColor = Color.DarkSeaGreen;
                    //    // e.Style.TextColor = Color.Red;
                    //    //e.Style.BackColor = Color.Brown;
                    //    //e.Style.TextColor = ColorTranslator.FromHtml("#00B050");
                    //}
                    //if (e.TableCellIdentity.DisplayElement.GetRecord().Id == 15)
                    //{
                    //    e.Style.BackColor = Color.Blue;
                    //    //e.Style.TextColor = Color.BurlyWood;
                    //}
                }
            }
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
            tareas = negocio.getTareasTipoUsuarioNuevo(tipo, empleado, dateTimeDesde.Value, dateTimeHasta.Value, filtrarPor, proceso);
            MostrarIndicadores();
        }

        private void MostrarIndicadores()
        {
            int tareasTotales=0;
            int tareasPasadas = 0;
            int tareasCercanas = 0;
            int tareasTerminadas = 0;
            foreach (List<TareaCompleta> tar in tareas)
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

            labelTotalesPor.Text = "100%";
            labelPasadasPor.Text = (tareasPasadas * 100 / tareasTotales) + "%";
            labelCeranasPor.Text = (tareasCercanas * 100 / tareasTotales) + "%";
            labelTerminadasPor.Text = (tareasTerminadas * 100 / tareasTotales) + "%";
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

            gridGroupingControl1.TableDescriptor.VisibleColumns.Reset();
            gridGroupingControl1.TableDescriptor.Columns.Reset();
            this.gridGroupingControl1.DataSource = tareas[0];

            System.Collections.Specialized.StringCollection list1 = new System.Collections.Specialized.StringCollection();
            list1.Add("Abandonada");
            list1.Add("En curso");
            list1.Add("Planificada");
            list1.Add("Retrasada");
            list1.Add("Terminada");
            this.gridGroupingControl1.TableDescriptor.Columns[7].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[7].Appearance.AnyRecordFieldCell.ChoiceList = list1;
            this.gridGroupingControl1.TableDescriptor.Columns[5].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.MonthCalendar;
            this.gridGroupingControl1.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.RichText;
            System.Collections.Specialized.StringCollection list2 = new System.Collections.Specialized.StringCollection();
            list2.AddRange(negocio.getTiposTareas().ToArray());
            this.gridGroupingControl1.TableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.ChoiceList = list2;
            System.Collections.Specialized.StringCollection list3 = new System.Collections.Specialized.StringCollection();
            list3.AddRange(negocio.getProcesosListado().ToArray());
            this.gridGroupingControl1.TableDescriptor.Columns[10].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[10].Appearance.AnyRecordFieldCell.ChoiceList = list3;
            System.Collections.Specialized.StringCollection list4 = new System.Collections.Specialized.StringCollection();
            list4.Add("1");
            list4.Add("2");
            list4.Add("3");
            list4.Add("a");
            list4.Add("p");
            this.gridGroupingControl1.TableDescriptor.Columns[12].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[12].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[13].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[13].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[14].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[14].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[15].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[15].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[16].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[16].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[17].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[17].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[18].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[18].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[19].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[19].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[20].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[20].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[21].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[21].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[22].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[22].Appearance.AnyRecordFieldCell.ChoiceList = list4;
            this.gridGroupingControl1.TableDescriptor.Columns[23].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[23].Appearance.AnyRecordFieldCell.ChoiceList = list4;

            //gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("ID");

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

                    //this.gridGroupingControl1.TableDescriptor.Columns[12].Appearance.AnyRecordFieldCell.Format = "dd/MM/yyyy";

                    //this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                    //this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                    //this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor3);
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

                    int n = 1;
                    for (int j = 0; j < parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
                    //parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                    {
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].AllowFilter = true;
                        //parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                        if (parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].Name == "Mes" + n)
                        {
                            parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].Name = DateTime.Now.AddMonths(n - 6).Year + "-" + (DateTime.Now.AddMonths(n - 6).Month < 10 ? "0" + DateTime.Now.AddMonths(n - 6).Month : "" + DateTime.Now.AddMonths(n - 6).Month);
                            n++;
                        }
                    }
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[5].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[3].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[4].Appearance.AnyCell.Format = "dd-MM-yyyy";

                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[7].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[7].Appearance.AnyRecordFieldCell.ChoiceList = list1;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[5].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.MonthCalendar;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.RichText;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.ChoiceList = list2;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[10].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[10].Appearance.AnyRecordFieldCell.ChoiceList = list3;
                    parentToChildRelationDescriptor.ChildTableDescriptor.Columns[12].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[12].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[13].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[13].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[14].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[14].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[15].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[15].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[16].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[16].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[17].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[17].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[18].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[18].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[19].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[19].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[20].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[20].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[21].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[21].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[22].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[22].Appearance.AnyRecordFieldCell.ChoiceList = list4;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[11].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
                   parentToChildRelationDescriptor.ChildTableDescriptor.Columns[11].Appearance.AnyRecordFieldCell.ChoiceList = list4;


                   this.gridGroupingControl1.TableDescriptor.Columns[0].Width = 20;
                   this.gridGroupingControl1.TableDescriptor.Columns[1].Width = 80;
                   this.gridGroupingControl1.TableDescriptor.Columns[2].Width = 300;
                   this.gridGroupingControl1.TableDescriptor.Columns[3].Width = 75;
                   this.gridGroupingControl1.TableDescriptor.Columns[4].Width = 75;
                   this.gridGroupingControl1.TableDescriptor.Columns[5].Width = 100;
                   this.gridGroupingControl1.TableDescriptor.Columns[5].HeaderText = "Fecha Hecho";
                   this.gridGroupingControl1.TableDescriptor.Columns[6].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[7].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[8].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[9].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[10].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[11].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[12].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[13].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[14].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[15].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[16].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[17].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[18].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[19].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[20].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[21].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[22].Width = 200;
                   this.gridGroupingControl1.TableDescriptor.Columns[23].Width = 200;
                    //filter.WireGrid(parentToChildRelationDescriptor);

                    //gridGroupingControl1.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells);

                    //this.gridGroupingControl1.GetTableDescriptor("lista" + i).AllowCalculateMaxColumnWidth = false; 
                    //GridTableModel tm = this.gridGroupingControl1.GetTableModel("lista"+i); 
                    ////tm.Table.FilteredChildTable = null; 
                    //tm.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);


                    //parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor1);
                    //parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor2);
                    //parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor3);

                    parentToChildRelationDescriptor.ChildTableDescriptor.RecordValueChanged += new RecordValueChangedEventHandler(gridGroupingControl1_RecordValueChanged);
                    childToChildRelationDescriptor = parentToChildRelationDescriptor;
                    //this.gridGroupingControl1.TableModel.QueryRowHeight += TableModel_QueryRowHeight;
                    //parentToChildRelationDescriptor.ChildTableDescriptor.Columns[0].hei
                }
            }

            if (comboBoxTipo.Text == "Tarea")
            {
                int m = 1;
                for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
                {
                    gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = true;
                    //gridGroupingControl1.TableDescriptor.Columns[j].ReadOnly = true;
                    if (gridGroupingControl1.TableDescriptor.Columns[j].Name == "Mes" + (m))
                    {
                        gridGroupingControl1.TableDescriptor.Columns[j].Name = DateTime.Now.AddMonths(m - 6).Year + "-" + (DateTime.Now.AddMonths(m - 6).Month < 10 ? "0" + DateTime.Now.AddMonths(m - 6).Month : "" + DateTime.Now.AddMonths(m - 6).Month);
                        //gridGroupingControl1.TableDescriptor.VisibleColumns.Add(DateTime.Now.AddMonths(m - 6).Year + "-" + (DateTime.Now.AddMonths(m - 6).Month < 10 ? "0" + DateTime.Now.AddMonths(m - 6).Month : "" + DateTime.Now.AddMonths(m - 6).Month));
                        m++;
                    }
                }
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("ID");
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("FechaInicio");
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("FechaFin");
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("FechaEjecutado");
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("TiempoDedicado");
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("Estado");
                //gridGroupingControl1.TableDescriptor.VisibleColumns.Add("IDTareaPadre");
            }
            else
            {
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("ID");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("FechaInicio");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("FechaFin");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("FechaEjecutado");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("TiempoDedicado");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Estado");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("IDTareaPadre");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes1");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes2");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes3");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes4");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes5");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes6");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes7");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes8");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes9");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes10");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes11");
                gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("Mes12");
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
                if (buttons.Name == "Todas" || buttons.Name == "TodasTerminadas" || buttons.Name == "PasadasCercanasTerminadas")
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

        public String EliminarCaracteresRTF(string cadenaRTF)
        {
            System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
            rtBox.Rtf = cadenaRTF;
            return rtBox.Text;
        }
    }
}
