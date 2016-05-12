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
using System.Text.RegularExpressions;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Drawing;

namespace PresentacionEscritorio
{
    public partial class PuntosRojos : MetroForm
    {
        //GridDynamicFilter filter = new GridDynamicFilter();
        GridExcelFilter filter = new GridExcelFilter();
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        List<Proceso> procesos = new List<Proceso>();
        List<PuntoRojo> puntosRojos = new List<PuntoRojo>();
        List<TareaAux> tareas = new List<TareaAux>();
        private string IDProc;

        public PuntosRojos(string idProc)
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
            dateTimeHasta.Value = new DateTime(DateTime.Now.Year+1, 1, 1, 0, 0, 0);

            ObtenerDatos();
            MostrarGridGroupingControl();
            
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;

            this.listBox1.AllowDrop = true;
            this.listBox2.AllowDrop = true;

            this.listBox1.MouseDown += new MouseEventHandler(this.listBox1_MouseDown);
            this.listBox2.DragDrop +=new DragEventHandler(listBox2_DragDrop);
            this.listBox2.DragOver += new DragEventHandler(listBox2_DragOver);
            this.listBox2.MouseDown += new MouseEventHandler(this.listBox1_MouseDown);
            this.listBox1.DragDrop += new DragEventHandler(listBox2_DragDrop);
            this.listBox1.DragOver += new DragEventHandler(listBox2_DragOver);

        }

        private void ObtenerDatos()
        {
            if (IDProc == "GBL")
                procesos = negocio.getProcesos();
            else
            {
                procesos = new List<Proceso>();
                procesos.Add(negocio.getProceso(IDProc));
            }
            puntosRojos = negocio.getPuntosRojos();
            tareas = ConvertirTareas(negocio.getTareas(dateTimeDesde.Value, dateTimeHasta.Value), puntosRojos);
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
                if (listBox1.Items.Count == 1)
                    this.gridGroupingControl1.TableModel.QueryRowHeight += new GridRowColSizeEventHandler(TableModel_QueryRowHeight);
                else
                    this.gridGroupingControl1.TableModel.QueryRowHeight += null;
            }

        }

        private void MostrarGridGroupingControl()
        {
            filter.UnWireGrid(gridGroupingControl1);
            filter.ClearFilters(gridGroupingControl1);
            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = false;

            this.gridGroupingControl1.Table.CollapseAllRecords();
            this.gridGroupingControl1.Engine.SourceListSet.Clear();
            gridGroupingControl1.TableDescriptor.Relations.Clear();
            gridGroupingControl1.Update();
            this.gridGroupingControl1.Refresh();

            gridGroupingControl1.TableDescriptor.Columns.Reset();

            int i = listBox1.Items.Count;
            if (i > 0)
            {
                setDataSource();
                setLista(0);

                if (i > 1)
                {
                    GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
                    parentToChildRelationDescriptor.ChildTableName = listBox1.Items[1].ToString();    // same as SourceListSetEntry.Name for childTable (see below)
                    parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;

                    parentToChildRelationDescriptor.RelationKeys.Add(getID1(listBox1.Items[0].ToString(), listBox1.Items[1].ToString()), getID2(listBox1.Items[0].ToString(), listBox1.Items[1].ToString()));
                    
                    // Add relation to ParentTable 
                    gridGroupingControl1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);
                    setLista(1);

                    for (int j = 0; j < parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;

                    if (i > 2)
                    {
                        GridRelationDescriptor childToGrandChildRelationDescriptor = new GridRelationDescriptor();
                        childToGrandChildRelationDescriptor.ChildTableName = listBox1.Items[2].ToString();  // same as SourceListSetEntry.Name for grandChhildTable (see below)
                        childToGrandChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
                        
                        childToGrandChildRelationDescriptor.RelationKeys.Add(getID1(listBox1.Items[1].ToString(), listBox1.Items[2].ToString()), getID2(listBox1.Items[1].ToString(), listBox1.Items[2].ToString()));
                        
                        // Add relation to ChildTable 
                        parentToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor);
                        setLista(2);

                        for (int j = 0; j < childToGrandChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
                            childToGrandChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                    }
                }

                for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
                {
                    gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = true;
                    gridGroupingControl1.TableDescriptor.Columns[j].ReadOnly = true;
                }

                filter.WireGrid(gridGroupingControl1);
            }
        }

        private void setDataSource()
        {
            switch (listBox1.Items[0].ToString())
            {
                case "Tareas":
                    this.gridGroupingControl1.DataSource = tareas;
                    break;
                case "PuntosRojos":
                    this.gridGroupingControl1.DataSource = puntosRojos;
                    break;
                default:
                    this.gridGroupingControl1.DataSource = procesos;
                    break;
            }
        }

        private string getID1(string nombre1, string nombre2)
        {
            if (nombre1.Equals("Procesos"))
            {
                return "ID";
            }
            else if (nombre1.Equals("PuntosRojos"))
            {
                if (nombre2.Equals("Tareas"))
                {
                    return "ID";
                }
                else
                {
                    return "IDProceso";
                }
            }
            else
            {
                if (nombre2.Equals("Procesos"))
                {
                    return "IDProceso";
                }
                else
                {
                    return "IDPuntoRojo";
                }
            }
        }

        private string getID2(string nombre1, string nombre2)
        {
            if (nombre1.Equals("Procesos"))
            {
                return "IDProceso";
            }
            else if (nombre1.Equals("PuntosRojos"))
            {
                if (nombre2.Equals("Tareas"))
                {
                    return "IDPuntoRojo";
                }
                else
                {
                    return "ID";
                }
            }
            else
            {
                if (nombre2.Equals("Procesos"))
                {
                    return "ID";
                }
                else
                {
                    return "ID";
                }
            }
        }

        private string getID(string nombre)
        {
            string opcion = "";
            switch (nombre)
            {
                case "Tareas":
                    opcion = "IDPuntoRojo";
                    break;
                case "PuntosRojos":
                    opcion = "IDProceso";
                    break;
                default:
                    opcion = "ID";
                    break;
            }
            return opcion;
        }

        private void setLista(int i)
        {
            switch (listBox1.Items[i].ToString())
            {
                case "Tareas":
                    this.gridGroupingControl1.Engine.SourceListSet.Add(listBox1.Items[i].ToString(), tareas);
                    break;
                case "PuntosRojos":
                    this.gridGroupingControl1.Engine.SourceListSet.Add(listBox1.Items[i].ToString(), puntosRojos);
                    break;
                default:
                    this.gridGroupingControl1.Engine.SourceListSet.Add(listBox1.Items[i].ToString(), procesos);
                    break;
            }
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

        private List<TareaAux> ConvertirTareas(List<Tarea> tareas, List<PuntoRojo> puntosRojos)
        {
            List<TareaAux> ta = new List<TareaAux>();
            foreach (Tarea t in tareas)
            {
                if (t.IDPuntoRojo != null)
                {
                    string idProceso = puntosRojos.Single(s => s.ID == t.IDPuntoRojo).IDProceso;
                    ta.Add(new TareaAux(t.ID, t.Descripcion, t.FechaInicio, t.FechaFin, t.FechaEjecutado, t.TiempoDedicado, t.Origen, t.Estado, t.IDResponsable, t.IDReunion, t.IDPuntoRojo, idProceso));
                }
            }
            return ta;
        }

        private void buttonEstadisticas_Click(object sender, EventArgs e)
        {
            string idProc = procesos[0].ID;
            if (procesos.Count > 1)
                idProc = "GBL";
            this.Hide();
            var form2 = new EstadisticasTareas(idProc);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void dateTimeDesde_ValueChanged(object sender, EventArgs e)
        {
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void dateTimeHasta_ValueChanged(object sender, EventArgs e)
        {
            ObtenerDatos();
            MostrarGridGroupingControl();
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

        void TableModel_QueryRowHeight(object sender, GridRowColSizeEventArgs e)
        {
            if (e.Index > 0)
            {
                IGraphicsProvider graphicsProvider = this.gridGroupingControl1.TableModel.GetGraphicsProvider();
                Graphics g = graphicsProvider.Graphics;
                GridStyleInfo style = this.gridGroupingControl1.TableModel[e.Index, 2];
                GridCellModelBase model = style.CellModel;
                if(model != null)
                    e.Size = model.CalculatePreferredCellSize(g, e.Index, 2, style, GridQueryBounds.Height).Height;
                e.Handled = true;
            }
        }

        private void gridGroupingControl1_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            //MessageBox.Show("");

            Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();

            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                //GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 2);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    if (styleID.TableCellIdentity.Column.Name == "ID")
                        switch (styleID.TableCellIdentity.Column.TableDescriptor.Name)
                        {
                            case "Procesos":
                                //MessageBox.Show("Abrir Proceso con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                this.Hide();
                                var form2 = new ProcesosPrincipales(rec.GetValue(styleID.TableCellIdentity.Column.Name).ToString());
                                form2.Closed += (s, args) => this.Close();
                                form2.Show();
                                break;
                            case "PuntosRojos":
                                //MessageBox.Show("Abrir PuntoRojo con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                EditarPuntoRojo formITP = new EditarPuntoRojo(negocio.getPuntoRojo((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                                formITP.ShowDialog();
                                break;
                            case "Tareas":
                                //MessageBox.Show("Abrir Tarea con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                                formIT.ShowDialog();
                                //ObtenerDatos();
                                //MostrarGridGroupingControl();
                                break;
                            default:
                                //MessageBox.Show("Abrir "+ listBox1.Items[0] + " con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                switch (listBox1.Items[0].ToString())
                                {
                                    case "Procesos":
                                        //MessageBox.Show("Abrir Proceso con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                        this.Hide();
                                        var form21 = new ProcesosPrincipales(rec.GetValue(styleID.TableCellIdentity.Column.Name).ToString());
                                        form21.Closed += (s, args) => this.Close();
                                        form21.Show();
                                        break;
                                    case "PuntosRojos":
                                        //MessageBox.Show("Abrir PuntoRojo con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                        EditarPuntoRojo formITP1 = new EditarPuntoRojo(negocio.getPuntoRojo((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                                        formITP1.ShowDialog();
                                        break;
                                    case "Tareas":
                                        //MessageBox.Show("Abrir Tarea con ID= " + rec.GetValue(styleID.TableCellIdentity.Column.Name));
                                        EditarTarea formIT1 = new EditarTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                                        formIT1.ShowDialog();
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        }
                }
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void buttonAnadirPunto_Click(object sender, EventArgs e)
        {
            AnadirPuntoRojo formAP = new AnadirPuntoRojo(procesos[0]);
            formAP.ShowDialog();
            ObtenerDatos();
            MostrarGridGroupingControl();
        }

        private void buttonAnadirTarea_Click(object sender, EventArgs e)
        {
            AnadirTarea formAT = new AnadirTarea(null,null);
            formAT.ShowDialog();
            ObtenerDatos();
            MostrarGridGroupingControl();
        }
    }

    public class TareaAux
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaEjecutado { get; set; }
        public double TiempoDedicado { get; set; }
        public string Estado { get; set; }
        public string Origen { get; set; }
        public string IDResponsable { get; set; }
        public int? IDReunion { get; set; }
        public int? IDPuntoRojo { get; set; }
        public string IDProceso { get; set; }

        public TareaAux(int id, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime? fechaEjecutado, double tiempoDedicado, string origen, string estado, string idResponsable, int? idReunion, int? idPuntoRojo, string idProceso)
        {
            ID = id;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            FechaEjecutado = fechaEjecutado;
            TiempoDedicado = tiempoDedicado;
            Origen = origen;
            Estado = estado;
            IDResponsable = idResponsable;
            IDReunion = idReunion;
            IDPuntoRojo = idPuntoRojo;
            IDProceso = idProceso;
        }
    }
}
