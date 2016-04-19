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
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;

namespace PresentacionEscritorio
{
    public partial class AnadirNuevaInvitacion : MetroForm
    {
        private GridDynamicFilter filter = new GridDynamicFilter();
        private List<Empleado> empleados = new List<Empleado>();
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private List<InvitadoNuevo> ias = new List<InvitadoNuevo>();
        public List<string> invitados { get; set; }

        public AnadirNuevaInvitacion(List<string> invitados)
        {
            InitializeComponent();

            empleados = negocio.getEmpleados();
            this.invitados = invitados;
            foreach (Empleado em in empleados)
            {
                ias.Add(new InvitadoNuevo(em.Usuario, em.NombreCompleto, invitadoEmpleado(em.Usuario)));
            }
            gridGroupingControl1.DataSource = ias;
            SampleCustomization(gridGroupingControl1);
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl1.TableDescriptor.Columns[1].Width = 120;
            this.gridGroupingControl1.TableDescriptor.Columns[2].Width = 50;
            this.gridGroupingControl1.TableDescriptor.Columns[0].Width = 80;
        }

        void SampleCustomization(GridGroupingControl ggc)
        {
            ggc.TopLevelGroupOptions.ShowFilterBar = true;
            ggc.NestedTableGroupOptions.ShowFilterBar = true;
            ggc.ChildGroupOptions.ShowFilterBar = true;
            //Enable the filter for each columns 
            for (int i = 0; i < ggc.TableDescriptor.Columns.Count; i++)
                ggc.TableDescriptor.Columns[i].AllowFilter = true;

            //Enable dynamic filter.
            ggc.TableModel.EnableLegacyStyle = false;
            filter.WireGrid(ggc);
            foreach (GridColumnDescriptor col in ggc.TableDescriptor.Columns)
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

        private bool invitadoEmpleado(string p)
        {
            bool b = false;
            int i = 0;
            while (invitados.Count > i && !b)
            {
                if (invitados[i].Equals(p))
                {
                    b = true;
                }
                i++;
            }
            return b;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridGroupingControl1_TableControlCheckBoxClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridGroupingControl ggc = (GridGroupingControl)sender;
            Element el = ggc.Table.GetInnerMostCurrentElement();
            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = ggc.GetTableControl(table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleUser = table.GetTableCellStyle(cc.RowIndex, 1);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    Boolean b = (bool)style.CellValue;
                    if (!b)
                    {
                        invitados.Add(rec.GetValue(styleUser.TableCellIdentity.Column.Name).ToString());
                    }
                    else
                    {
                        invitados.Remove(rec.GetValue(styleUser.TableCellIdentity.Column.Name).ToString());
                    }
                }
            }
        }
    }
    public class InvitadoNuevo
    {
        public string Usuario;
        public string Nombre;
        public bool Invitacion;

        public InvitadoNuevo(string usuario, string nombre, bool invitacion)
        {
            Usuario = usuario;
            Nombre = nombre;
            Invitacion = invitacion;
        }
    }
}
