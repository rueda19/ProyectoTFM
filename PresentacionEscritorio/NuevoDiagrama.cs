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
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Responsable { get; set; }

        public NuevoDiagrama()
        {
            InitializeComponent();
            multiColumnComboBox1.DataSource = negocio.getEmpleados();
            multiColumnComboBox1.DisplayMember = "Usuario";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3)
                textBox1.Text = textBox1.Text.Substring(0,3);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 3 && textBox2.Text != "" && textBox3.Text != "" && multiColumnComboBox1.Text != "")
            {
                IDDiagrama = textBox1.Text;
                Nombre = textBox2.Text;
                Tipo = textBox3.Text;
                Responsable = multiColumnComboBox1.Text;
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
