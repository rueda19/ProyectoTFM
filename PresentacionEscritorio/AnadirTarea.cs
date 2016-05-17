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

namespace PresentacionEscritorio
{
    public partial class AnadirTarea : MetroForm
    {
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private List<Tarea> tareas = new List<Tarea>();
        private List<Proceso> procesos = new List<Proceso>();

        public AnadirTarea(Reunion reunion, Proceso proceso, Tarea tarea)
        {
            InitializeComponent();
            FechaInicio.Value = DateTime.Now;
            FechaFin.Value = DateTime.Now;
            
            //puntosRojos = negocio.getPuntosRojos();
            procesos = negocio.getProcesos();
            ComboBoxPuntoRojoID.DataSource = procesos;
            //ComboBoxPuntoRojoID.ListBox.Grid.Model.HideCols.SetRange(3, 5, true);
            ComboBoxPuntoRojoID.DisplayMember = "ID"; 
            ComboBoxPuntoRojoID.Text="";
            //ComboBoxPuntoRojoID.col.HideCols.SetRange(1, 3, true);

            tareas = negocio.getTareas();
            ComboBoxTareaPadre.DataSource = tareas;
            //ComboBoxPuntoRojoID.ListBox.Grid.Model.HideCols.SetRange(3, 5, true);
            ComboBoxTareaPadre.DisplayMember = "ID";
            ComboBoxTareaPadre.Text = "";

            List<Empleado> s = negocio.getEmpleados();
            cbResponsable.DataSource = s;
            cbResponsable.DisplayMember = "Usuario";

            if (reunion != null)
            {
                tbReunionID.Text = reunion.ID.ToString();
                tbReunionNombre.Text = reunion.Titulo;
                //tbOrigen.Text = "Reunion";
            }
            if (proceso != null)
            {
                ComboBoxPuntoRojoID.Text = proceso.ID;
                textBoxPuntoRojoProceso.Text = proceso.Nombre;
                ComboBoxPuntoRojoID.Enabled = false;
                //tbOrigen.Text = "PuntoRojo";
            }
            if (tarea != null)
            {
                ComboBoxTareaPadre.Text = tarea.ID.ToString();
                textBoxTareaPadre.Text = tarea.Tipo + " " + tarea.Descripcion;
                //tbOrigen.Text = "PuntoRojo";
            }
            this.ComboBoxPuntoRojoID.TextChanged += new System.EventHandler(this.ComboBoxPuntoRojoID_TextChanged);
            this.ComboBoxTareaPadre.TextChanged += new System.EventHandler(this.ComboBoxTareaPadre_TextChanged);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, tbReunionID.Text.Equals("") ? (int?)null : Int32.Parse(tbReunionID.Text), ComboBoxPuntoRojoID.Text.Equals("") ? null : ComboBoxPuntoRojoID.Text, ComboBoxTareaPadre.Text.Equals("") ? (int?)null : Int32.Parse(ComboBoxTareaPadre.Text)));
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboBoxPuntoRojoID_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxPuntoRojoID.Text == "")
            {
                textBoxPuntoRojoProceso.Text = "";
            }
            else
            {
                Proceso pr = procesos.Single(p => p.ID == ComboBoxPuntoRojoID.Text);
                textBoxPuntoRojoProceso.Text = pr.Nombre;
            }
        }

        private void ComboBoxTareaPadre_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ComboBoxTareaPadre.Text == "")
            {
                textBoxTareaPadre.Text = "";
                ComboBoxPuntoRojoID.Enabled = true;
                ComboBoxPuntoRojoID.Text = "";
                textBoxPuntoRojoProceso.Text = "";
                tbReunionID.Text = "";
                tbReunionNombre.Text = "";
            }
            else if (Int32.TryParse(ComboBoxTareaPadre.Text, out i))
            {
                Tarea t = tareas.Single(p => p.ID == i);
                textBoxTareaPadre.Text = t.Tipo + " " + t.Descripcion;
                if (t.IDReunion != null)
                {
                    tbReunionID.Text = t.IDReunion.ToString();
                    tbReunionNombre.Text = negocio.getReunion(t.IDReunion.Value).Titulo;
                }
                else
                {
                    tbReunionID.Text = "";
                    tbReunionNombre.Text = "";
                }

                if (t.IDProceso != null)
                {
                    ComboBoxPuntoRojoID.Text = t.IDProceso;
                    if (ComboBoxPuntoRojoID.Text == "")
                    {
                        textBoxPuntoRojoProceso.Text = "";
                    }
                    else
                    {
                        Proceso pr = procesos.Single(p => p.ID == ComboBoxPuntoRojoID.Text);
                        textBoxPuntoRojoProceso.Text = pr.Nombre;
                    }
                }
                else
                {
                    ComboBoxPuntoRojoID.Text = "";
                    textBoxPuntoRojoProceso.Text = "";
                }
                ComboBoxPuntoRojoID.Enabled = false;
            }
            else
            {
                ComboBoxTareaPadre.Text = "";
                ComboBoxPuntoRojoID.Enabled = true;
            }
        }
    }
}
