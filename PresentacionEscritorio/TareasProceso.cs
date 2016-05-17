﻿using System;
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

        public TareasProceso(string idProc)
        {
            InitializeComponent();
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

            ObtenerDatos();
            MostrarGridGroupingControl();

            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            this.gridGroupingControl1.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo);
            this.gridGroupingControl1.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridGroupingControl1_TableControlCellDoubleClick);
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
                var form2 = new MisTareas();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage4")
            {
                this.WindowState = FormWindowState.Minimized;
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
}
