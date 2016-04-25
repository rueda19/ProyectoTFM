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

        public AnadirTarea(Reunion reunion)
        {
            InitializeComponent();
            FechaInicio.Value = DateTime.Now;
            FechaFin.Value = DateTime.Now;

            List<Empleado> s = negocio.getEmpleados();
            cbResponsable.DataSource = s;
            cbResponsable.DisplayMember = "Usuario";

            if (reunion != null)
            {
                tbReunionID.Text = reunion.ID.ToString();
                tbReunionNombre.Text = reunion.Titulo;
                tbOrigen.Text = "Reunion";
            }
            else
            {
                tbOrigen.Text = "Manual";
            }

            

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(tbReunionID.Text.Equals(""))
                negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, null));
            else
                negocio.setTarea(new Tarea(0, tbDescripcion.Text, FechaInicio.Value, FechaFin.Value, null, 0.0, tbOrigen.Text, cbEstado.Text, cbResponsable.Text, int.Parse(tbReunionID.Text)));
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
