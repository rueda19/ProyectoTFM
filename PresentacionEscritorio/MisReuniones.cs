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
using System.Text.RegularExpressions;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace PresentacionEscritorio
{
    public partial class MisReuniones : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private GridDynamicFilter filter = new GridDynamicFilter();
        private List<Reunion> reuniones;

        public MisReuniones()
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

            reuniones = negocio.getReunionUsuario(user);
            gridGroupingControl1.DataSource = reuniones;

            SampleCustomization();

            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            
            TextBox tb = new TextBox();

            this.gridGroupingControl1.TableDescriptor.Columns[2].Appearance.AnyCell.AutoSize=true;
            //this.gridGroupingControl1.TableDescriptor.Columns[5].Width = 25;

        }

        void image_ImageMouseUp(object sender, ImageMouseUpEventArgs e)
        {
            if ((sender as CaptionImage).Name == "CaptionImage1")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage2")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage3")
            {
                this.WindowState = FormWindowState.Minimized;
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
    }
}
