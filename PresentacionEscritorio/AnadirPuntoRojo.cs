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
    public partial class AnadirPuntoRojo : MetroForm
    {
        private Negocio.Negocio negocio = new Negocio.Negocio();

        public AnadirPuntoRojo(Proceso proceso)
        {
            InitializeComponent();

            cbPrioridad.SelectedIndex = 1;

            List<Empleado> s = negocio.getEmpleados();
            cbResponsable.DataSource = s;
            cbResponsable.DisplayMember = "Usuario";

            List<Proceso> p = negocio.getProcesos();
            cbProceso.DataSource = p;
            cbProceso.DisplayMember = "ID";

            if (proceso != null)
            {
                cbProceso.Text = proceso.ID;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            //if (negocio.setPuntoRojo(new PuntoRojo(0, textBox1.Text, cbPrioridad.Text, checkBoxSolucionado.Checked, cbResponsable.Text, cbProceso.Text)) > 0)
            //    this.Close();
            //else
            //    MessageBox.Show("Error al crear el Punto Rojo");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
