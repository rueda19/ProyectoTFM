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
using System.Text.RegularExpressions;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;

namespace PresentacionEscritorio
{
    public partial class ListaEmpleados : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        GridExcelFilter filter = new GridExcelFilter();

        public ListaEmpleados()
        {
            InitializeComponent(); 
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;

            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            gridGroupingControl1.DataSource = negocio.getEmpleadosFoto();
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl1.TableModel.RowHeights[0] = 300;
            this.gridGroupingControl1.TableDescriptor.Columns[0].Width = 300;

            for (int i = 1; i < gridGroupingControl1.TableDescriptor.Columns.Count; i++)
                gridGroupingControl1.TableDescriptor.Columns[i].AllowFilter = true;
            filter.WireGrid(gridGroupingControl1);
            gridGroupingControl1.TableModel.EnableLegacyStyle = false;
            gridGroupingControl1.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center;
            gridGroupingControl1.Appearance.AnyCell.Font.Size = 15;

            foreach (GridColumnDescriptor gtd in gridGroupingControl1.TableDescriptor.Columns)
                gtd.ReadOnly = true;
            //gridGroupingControl1.TableDescriptor.Columns[0].ReadOnly = true;
            //gridGroupingControl1.TableDescriptor.Columns[1].ReadOnly = true;
            //gridGroupingControl1.TableDescriptor.Columns[6].ReadOnly = true;
            this.gridGroupingControl1.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridGroupingControl1_TableControlCellDoubleClick);
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
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    DetallesEmpleado formIT = new DetallesEmpleado((string)rec.GetValue(style.TableCellIdentity.Column.Name));
                    formIT.ShowDialog();
                    gridGroupingControl1.DataSource = negocio.getEmpleadosFoto();
                    gridGroupingControl1.Update();
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
                //this.Hide();
                //var form2 = new ListaEmpleados();
                //form2.Closed += (s, args) => this.Close();
                //form2.Show();
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
    }
}
