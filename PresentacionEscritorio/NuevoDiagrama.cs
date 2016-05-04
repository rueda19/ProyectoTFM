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
    public partial class NuevoDiagrama : MetroForm
    {
        private Negocio.Negocio negocio = new Negocio.Negocio();
        public string IDDiagrama { get; set; }

        public NuevoDiagrama()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3)
                textBox1.Text = textBox1.Text.Substring(0,3);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 3)
            {
                IDDiagrama = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("El Nuevo ID debe tener tres caracteres");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IDDiagrama = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
