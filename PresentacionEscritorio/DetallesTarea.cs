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

namespace PresentacionEscritorio
{
    public partial class DetallesTarea : MetroForm
    {
        private Tarea tarea;
        List<List<Tarea>> tareas = new List<List<Tarea>>();
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor gridConditionalFormatDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
            
        public DetallesTarea(Tarea t)
        {
            InitializeComponent();
            tarea = t;
            label1.Text = label1.Text + " ID=" + t.ID;

            gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(52))))));
            gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White;
            gridConditionalFormatDescriptor3.Expression = "[ID]  LIKE \'" + tarea.ID + "\'";
            //gridConditionalFormatDescriptor3.Name = "ConditionalFormat 1";

            ObtenerDatos();
            MostrarGridGroupingControl();

            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            this.gridGroupingControl1.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo);

            this.gridGroupingControl1.TableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor3);
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAñadirHijo_Click(object sender, EventArgs e)
        {
            AnadirTarea at = new AnadirTarea(null, null, tarea);
            at.ShowDialog();
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void ObtenerDatos()
        {
            tareas = negocio.getTareaRama(tarea.ID);
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

        private void MostrarGridGroupingControl()
        {
            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = false;

            gridGroupingControl1.TableDescriptor.Relations.Clear();
            this.gridGroupingControl1.Table.CollapseAllRecords();
            this.gridGroupingControl1.Engine.SourceListSet.Clear();
            gridGroupingControl1.Update();
            this.gridGroupingControl1.Refresh();

            gridGroupingControl1.TableDescriptor.Columns.Reset();

            GridRelationDescriptor childToChildRelationDescriptor = null;
            for (int i = 0; i < tareas.Count; i++)
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
                    parentToChildRelationDescriptor.ChildTableDescriptor.TopLevelGroupOptions.ShowCaption = false;

                    parentToChildRelationDescriptor.RelationKeys.Add("ID", "IDTareaPadre");

                    // Add relation to ParentTable 
                    if (childToChildRelationDescriptor == null)
                        gridGroupingControl1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);
                    else
                        childToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(parentToChildRelationDescriptor);

                    this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);

                    for (int j = 0; j < parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
                    {
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].AllowFilter = true;
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                    }

                    parentToChildRelationDescriptor.ChildTableDescriptor.ConditionalFormats.Add(gridConditionalFormatDescriptor3);
                    childToChildRelationDescriptor = parentToChildRelationDescriptor;
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
            }
            this.gridGroupingControl1.Table.ExpandAllRecords();
        }
    }
}
