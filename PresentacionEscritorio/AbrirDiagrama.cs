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
    public partial class AbrirDiagrama : MetroForm
    {
        private Negocio.Negocio negocio=new Negocio.Negocio();
        public string IDDiagrama { get; set; }

        public AbrirDiagrama()
        {
            InitializeComponent();
            comboBoxDiagramas.DataSource = negocio.GetIDDiagramas();
            comboBoxDiagramas.SelectionStart = 0;
            IDDiagrama = comboBoxDiagramas.SelectedValue.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            IDDiagrama = comboBoxDiagramas.SelectedValue.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IDDiagrama = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
