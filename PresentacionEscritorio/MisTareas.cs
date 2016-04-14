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
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.GridHelperClasses;
using System.Text.RegularExpressions;
using Syncfusion.Drawing;

namespace PresentacionEscritorio
{
    public partial class MisTareas : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        GridDynamicFilter filter = new GridDynamicFilter();
        List<Tarea> tareas;

        public MisTareas()
        {
            InitializeComponent();
            user=System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;

            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            tareas=negocio.getTareasUsuario(user);

            gridGroupingControl1.DataSource = tareas;

            SampleCustomization();

            System.Collections.Specialized.StringCollection list1 = new System.Collections.Specialized.StringCollection();
            list1.Add("Retrasada");
            list1.Add("En curso");
            list1.Add("Terminada");
            list1.Add("Abandonada");
            list1.Add("Planificada");
            this.gridGroupingControl1.TableDescriptor.Columns[6].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl1.TableDescriptor.Columns[6].Appearance.AnyRecordFieldCell.ChoiceList = list1;
            this.gridGroupingControl1.TableDescriptor.Columns[6].Appearance.AnyRecordFieldCell.CellValue = "Trial1";
            gridGroupingControl1.TableDescriptor.Columns[0].ReadOnly = true;
            this.gridGroupingControl1.TableDescriptor.Columns[4].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.MonthCalendar;
            gridGroupingControl1.TableDescriptor.Columns[2].ReadOnly = true;
            gridGroupingControl1.TableDescriptor.Columns[7].ReadOnly = true;
            gridGroupingControl1.TableDescriptor.Columns[8].ReadOnly = true;
            gridGroupingControl1.TableDescriptor.Columns[9].ReadOnly = true;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            //Event hooking in constructor.
            this.gridGroupingControl1.TableModel.QueryRowHeight += new GridRowColSizeEventHandler(TableModel_QueryRowHeight);
        }

        //This event is triggered when the row height is changed.
        void TableModel_QueryRowHeight(object sender, GridRowColSizeEventArgs e)
        {
            if (e.Index > 0)
            {
                IGraphicsProvider graphicsProvider = this.gridGroupingControl1.TableModel.GetGraphicsProvider();
                Graphics g = graphicsProvider.Graphics;
                GridStyleInfo style = this.gridGroupingControl1.TableModel[e.Index, 2];
                GridCellModelBase model = style.CellModel;
                e.Size = model.CalculatePreferredCellSize(g, e.Index, 2, style, GridQueryBounds.Height).Height;
                e.Handled = true;
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
                //var form2 = new MisTareas();
                //form2.Closed += (s, args) => this.Close();
                //form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage4")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage5")
            {
                this.WindowState = FormWindowState.Minimized;
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

        private void gridGroupingControl1_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            ////DataGridViewImageCell cell = (DataGridViewImageCell) gridGroupingControl1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            ////MessageBox.Show(e.Inner.ColIndex+"-"+e.Inner.RowIndex);
            //Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            //if (el != null)
            //{
            //    GridTable table = el.ParentTable as GridTable;
            //    GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
            //                      (table.TableDescriptor.Name);
            //    GridCurrentCell cc = tableControl.CurrentCell;
            //    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
            //    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
            //    GridRecord rec = el as GridRecord;
            //    if (rec == null && el is GridRecordRow)
            //    {
            //        rec = el.ParentRecord as GridRecord;
            //    }
            //    if (rec != null)
            //    {
            //        MessageBox.Show(style.TableCellIdentity.Column.Name);
            //        MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
            //    }
            //}
        }

        void SampleCustomization()
        {
            this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowFilterBar = true;
            this.gridGroupingControl1.ChildGroupOptions.ShowFilterBar = true;
            //Enable the filter for each columns 
            for (int i = 0; i < gridGroupingControl1.TableDescriptor.Columns.Count; i++)
                gridGroupingControl1.TableDescriptor.Columns[i].AllowFilter = true;

            //Enable dynamic filter.
            this.gridGroupingControl1.TableModel.EnableLegacyStyle = false;
            filter.WireGrid(gridGroupingControl1);
            foreach (GridColumnDescriptor col in this.gridGroupingControl1.TableDescriptor.Columns)
            {
                Regex rex = new Regex(@"\p{Lu}");
                int index = rex.Match(col.MappingName.Substring(1)).Index;
                string name = "";
                while (index > 0)
                {
                    name += col.MappingName.Substring(0, index + 1) + " ";
                    string secondName = col.MappingName.Substring(index + 1);
                    index = rex.Match(secondName.Substring(1)).Index;
                    while (index > 0)
                    {
                        name += secondName.Substring(0, index + 1) + " ";
                        index = rex.Match(col.MappingName.Substring(name.Replace(" ", "").Length).Substring(1)).Index;
                    }
                }
                name += col.MappingName.Substring(name.Replace(" ", "").Length);
                col.HeaderText = name;
            }
        }

        private void gridGroupingControl1_RecordValueChanged(object sender, RecordValueChangedEventArgs e)
        {
            Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            
            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
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
                    int j=(int)rec.GetValue(styleID.TableCellIdentity.Column.Name);
                    string fila = style.TableCellIdentity.Column.Name, valor = rec.GetValue(style.TableCellIdentity.Column.Name).ToString();
                    if (fila.Equals("TiempoDedicado") && valor.Contains("."))
                    {
                        rec.SetValue(style.TableCellIdentity.Column.Name, valor);
                    }
                    if (negocio.setTareaFila(j, fila, valor) == 0)
                        MessageBox.Show("Error al actualizar la Tarea");
                }
            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                tareas = negocio.getTareasUsuarioTerminadas(user);
            else
                tareas = negocio.getTareasUsuario(user);
            gridGroupingControl1.DataSource = tareas;
        }

    }
}
