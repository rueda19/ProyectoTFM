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
    public partial class EditarTarea : MetroForm
    {
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private Tarea tarea;
        private List<PuntoRojo> puntosRojos = new List<PuntoRojo>();

        public EditarTarea(Tarea tarea)
        {
            InitializeComponent();
            this.tarea = tarea;
            FechaInicio.Value = this.tarea.FechaInicio;
            FechaFin.Value = this.tarea.FechaFin;
            if (this.tarea.FechaEjecutado != null)
                FechaEjecucion.Value = this.tarea.FechaEjecutado.Value;

            puntosRojos = negocio.getPuntosRojos();
            ComboBoxPuntoRojoID.DataSource = puntosRojos;
            ComboBoxPuntoRojoID.ListBox.Grid.Model.HideCols.SetRange(3, 5, true);
            ComboBoxPuntoRojoID.DisplayMember = "ID"; 
            ComboBoxPuntoRojoID.Text="";

            List<Empleado> s = negocio.getEmpleados();
            cbResponsable.DataSource = s;
            cbResponsable.DisplayMember = "Usuario";
            cbResponsable.Text = this.tarea.IDResponsable;

            if (this.tarea.IDReunion != null)
            {
                Reunion reunion = negocio.getReunion(this.tarea.IDReunion.Value);
                tbReunionID.Text = reunion.ID.ToString();
                tbReunionNombre.Text = reunion.Titulo;
            }
            if (tarea.IDPuntoRojo != null)
            {
                ComboBoxPuntoRojoID.Text = tarea.IDPuntoRojo.ToString();
                Proceso p=negocio.getProcesoPuntoRojo(tarea.IDPuntoRojo);
                textBoxPuntoRojoProceso.Text = p.ID + " " + p.Nombre;
            }
            tbOrigen.Text = this.tarea.Origen;

            tbTiempoDedicado.Text = this.tarea.TiempoDedicado.ToString();
            tbDescripcion.Text = this.tarea.Descripcion;

            cbEstado.Text = this.tarea.Estado;

            this.ComboBoxPuntoRojoID.TextChanged += new System.EventHandler(this.ComboBoxPuntoRojoID_TextChanged);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            negocio.updateTarea(this.tarea);
            //if (tbReunionID.Text.Equals(""))
            //    negocio.updateTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, null));
            //else
            //    negocio.updateTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, int.Parse(tbReunionID.Text)));
            this.Close();
        }

        private void FechaFin_ValueChanged(object sender, EventArgs e)
        {
            this.tarea.FechaFin = FechaFin.Value;
        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            this.tarea.FechaInicio = FechaInicio.Value;
        }

        private void tbTiempoDedicado_TextChanged(object sender, EventArgs e)
        {
            this.tarea.TiempoDedicado = Double.Parse(tbTiempoDedicado.Text);
        }

        private void cbEstado_TextChanged(object sender, EventArgs e)
        {
            this.tarea.Estado = cbEstado.Text;
        }

        private void FechaEjecucion_ValueChanged(object sender, EventArgs e)
        {
            this.tarea.FechaEjecutado = FechaEjecucion.Value;
        }

        private void cbResponsable_TextChanged(object sender, EventArgs e)
        {
            this.tarea.IDResponsable = cbResponsable.Text;
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            this.tarea.Descripcion = tbDescripcion.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            negocio.removeTarea(this.tarea.ID);
            this.Close();
        }

        private void ComboBoxPuntoRojoID_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ComboBoxPuntoRojoID.Text == "")
            {
                textBoxPuntoRojoProceso.Text = "";
                if (tbReunionID.Text == "")
                {
                    tbOrigen.Text = "Manual";
                }
                else
                {
                    tbOrigen.Text = "Reunion";
                }
                tarea.IDPuntoRojo = null;
            }
            else if (Int32.TryParse(ComboBoxPuntoRojoID.Text, out i))
            {
                textBoxPuntoRojoProceso.Text = puntosRojos.Single(p => p.ID == i).IDProceso + " " + negocio.getProceso(puntosRojos.Single(p => p.ID == i).IDProceso).Nombre;
                tbOrigen.Text = "PuntoRojo";
                tarea.IDPuntoRojo = i;
            }
            else
            {
                ComboBoxPuntoRojoID.Text = "";
            }

            tarea.Origen = tbOrigen.Text;
        }
    }
}
