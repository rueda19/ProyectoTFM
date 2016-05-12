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
        private List<PuntoRojo> puntosRojos = new List<PuntoRojo>();

        public AnadirTarea(Reunion reunion, PuntoRojo puntoRojo)
        {
            InitializeComponent();
            FechaInicio.Value = DateTime.Now;
            FechaFin.Value = DateTime.Now;
            
            puntosRojos = negocio.getPuntosRojos();
            ComboBoxPuntoRojoID.DataSource = puntosRojos;
            ComboBoxPuntoRojoID.ListBox.Grid.Model.HideCols.SetRange(3, 5, true);
            ComboBoxPuntoRojoID.DisplayMember = "ID"; 
            ComboBoxPuntoRojoID.Text="";
            //ComboBoxPuntoRojoID.col.HideCols.SetRange(1, 3, true);


            List<Empleado> s = negocio.getEmpleados();
            cbResponsable.DataSource = s;
            cbResponsable.DisplayMember = "Usuario";

            if (reunion != null)
            {
                tbReunionID.Text = reunion.ID.ToString();
                tbReunionNombre.Text = reunion.Titulo;
                tbOrigen.Text = "Reunion";
            }
            if (puntoRojo != null)
            {
                ComboBoxPuntoRojoID.Text = puntoRojo.ID.ToString();
                textBoxPuntoRojoProceso.Text = puntoRojo.IDProceso + " " + negocio.getProceso(puntoRojo.IDProceso).Nombre;
                tbOrigen.Text = "PuntoRojo";
            }
            if (reunion == null && puntoRojo == null)
            {
                tbOrigen.Text = "Manual";
            }
            this.ComboBoxPuntoRojoID.TextChanged += new System.EventHandler(this.ComboBoxPuntoRojoID_TextChanged);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(tbReunionID.Text.Equals(""))
                if (ComboBoxPuntoRojoID.Text.Equals(""))
                    negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, null, null));
                else
                    negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, null, Int32.Parse(ComboBoxPuntoRojoID.Text)));
            else
                if (ComboBoxPuntoRojoID.Text.Equals(""))
                    negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, int.Parse(tbReunionID.Text), null));
                else
                    negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, int.Parse(tbReunionID.Text), Int32.Parse(ComboBoxPuntoRojoID.Text)));
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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
            }
            else if (Int32.TryParse(ComboBoxPuntoRojoID.Text, out i))
            {
                textBoxPuntoRojoProceso.Text = puntosRojos.Single(p => p.ID == i).IDProceso + " " + negocio.getProceso(puntosRojos.Single(p => p.ID == i).IDProceso).Nombre;
                tbOrigen.Text = "PuntoRojo";
            }
            else
            {
                ComboBoxPuntoRojoID.Text = "";
            }
        }
    }
}
