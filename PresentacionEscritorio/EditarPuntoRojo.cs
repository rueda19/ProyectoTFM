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
    public partial class EditarPuntoRojo : MetroForm
    {
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private PuntoRojo puntoRojo;

        public EditarPuntoRojo(PuntoRojo puntRojo)
        {
            puntoRojo = puntRojo;
            InitializeComponent();

            List<Empleado> s = negocio.getEmpleados();
            cbResponsable.DataSource = s;
            cbResponsable.DisplayMember = "Usuario";

            List<Proceso> p = negocio.getProcesos();
            cbProceso.DataSource = p;
            cbProceso.DisplayMember = "ID";

            cbPrioridad.Text = puntoRojo.Prioridad;
            cbResponsable.Text = puntoRojo.IDResponsable;
            cbProceso.Text = puntoRojo.IDProceso;
            checkBoxSolucionado.Checked = puntoRojo.Solucionado;
            textBox1.Text = puntoRojo.Descripcion;


            this.cbResponsable.TextChanged += new System.EventHandler(this.cbResponsable_TextChanged);
            this.cbProceso.TextChanged += new System.EventHandler(this.cbProceso_TextChanged);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (negocio.updatePuntoRojo(puntoRojo) > 0)
                this.Close();
            else
                MessageBox.Show("Error al crear el Punto Rojo");
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (negocio.removePuntoRojo(puntoRojo.ID) > 0)
                this.Close();
            else
                MessageBox.Show("Error al eliminar el Punto Rojo");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.puntoRojo.Prioridad = cbPrioridad.Text;
        }

        private void checkBoxSolucionado_CheckedChanged(object sender, EventArgs e)
        {
            this.puntoRojo.Solucionado = checkBoxSolucionado.Checked;
        }

        private void cbProceso_TextChanged(object sender, EventArgs e)
        {
            this.puntoRojo.IDProceso = cbProceso.Text;
        }

        private void cbResponsable_TextChanged(object sender, EventArgs e)
        {
            this.puntoRojo.IDResponsable = cbResponsable.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.puntoRojo.Descripcion = textBox1.Text;
        }
    }
}
