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
        private List<Tarea> tareas = new List<Tarea>();
        private Tarea tarea;
        private List<Proceso> procesos = new List<Proceso>();

        public EditarTarea(Tarea tarea)
        {
            InitializeComponent();
            this.tarea = tarea;
            FechaInicio.Value = this.tarea.FechaInicio;
            FechaFin.Value = this.tarea.FechaFin;

            if (tarea.Estado == "Terminada")
            {
                if (this.tarea.FechaEjecutado != null)
                    FechaEjecucion.Value = this.tarea.FechaEjecutado.Value;
            }
            else
                FechaEjecucion.Enabled = false;

            procesos = negocio.getProcesos();
            ComboBoxPuntoRojoID.DataSource = procesos;
            //ComboBoxPuntoRojoID.ListBox.Grid.Model.HideCols.SetRange(3, 5, true);
            ComboBoxPuntoRojoID.DisplayMember = "ID";
            ComboBoxPuntoRojoID.Text = "";
            //ComboBoxPuntoRojoID.col.HideCols.SetRange(1, 3, true);

            tareas = negocio.getTareas();
            ComboBoxTareaPadre.DataSource = tareas;
            //ComboBoxPuntoRojoID.ListBox.Grid.Model.HideCols.SetRange(3, 5, true);
            ComboBoxTareaPadre.DisplayMember = "ID";
            ComboBoxTareaPadre.Text = "";

            //cbResponsable.Text = this.tarea.IDResponsable;
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
            if (tarea.IDProceso != null)
            {
                ComboBoxPuntoRojoID.Text = tarea.IDProceso;
                Proceso p=negocio.getProceso(tarea.IDProceso);
                textBoxPuntoRojoProceso.Text = p.ID + " " + p.Nombre;
            }
            if (tarea.IDTareaPadre != null)
            {
                ComboBoxTareaPadre.Text = tarea.IDTareaPadre.ToString();
                Tarea tPadre = negocio.getTarea(tarea.IDTareaPadre.Value);
                textBoxTareaPadre.Text = tPadre.Tipo + " " + tPadre.Descripcion;
            }
            this.comboBoxTipo.AutoCompleteControl.ChangeDataManagerPosition = true;
            this.comboBoxTipo.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxTipo.AutoCompleteControl.OverrideCombo = true;
            this.comboBoxTipo.AutoCompleteControl.DataSource = negocio.getTiposTareas();
            comboBoxTipo.Text = this.tarea.Tipo;

            tbTiempoDedicado.Text = this.tarea.TiempoDedicado.ToString();
            tbDescripcion.Text = this.tarea.Descripcion;

            cbEstado.Text = this.tarea.Estado;

            this.ComboBoxPuntoRojoID.Leave += new System.EventHandler(this.ComboBoxPuntoRojoID_TextChanged);
            //this.ComboBoxTareaPadre.TextChanged += new System.EventHandler(this.ComboBoxTareaPadre_TextChanged);
            this.ComboBoxTareaPadre.Leave += new System.EventHandler(this.ComboBoxTareaPadre_TextChanged);
            this.cbResponsable.Leave += new System.EventHandler(this.cbResponsable_TextChanged);
            this.comboBoxTipo.Leave += new EventHandler(tbOrigen_TextChanged);
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
            Double tiemDedi;
            if (tbTiempoDedicado.Text != "" && Double.TryParse(tbTiempoDedicado.Text, out tiemDedi))
                this.tarea.TiempoDedicado = tiemDedi;
            else
            {
                //tbTiempoDedicado.Text = "0";
                this.tarea.TiempoDedicado = 0;
            }   
        }

        private void cbEstado_TextChanged(object sender, EventArgs e)
        {
            this.tarea.Estado = cbEstado.Text;
            if (tarea.Estado == "Terminada")
            {
                FechaEjecucion.Enabled = true;
                tarea.FechaEjecutado = FechaEjecucion.Value;
            }
            else
            {
                FechaEjecucion.Enabled = false;
                tarea.FechaEjecutado = null;
            }
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
                tarea.IDTareaPadre = null;
            }
            else if (Int32.TryParse(ComboBoxTareaPadre.Text, out i))
            {
                if (tareas.Any(t => t.ID == i))
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

                    tarea.IDTareaPadre = t.ID;
                }
                else
                {
                    MessageBox.Show("No existe la tarea con ID=" + ComboBoxTareaPadre.Text);
                    ComboBoxTareaPadre.Text = "";
                    textBoxTareaPadre.Text = "";
                    ComboBoxPuntoRojoID.Enabled = true;
                    ComboBoxPuntoRojoID.Text = "";
                    textBoxPuntoRojoProceso.Text = "";
                    tbReunionID.Text = "";
                    tbReunionNombre.Text = "";
                    tarea.IDTareaPadre = null;
                }
            }
            else
            {
                textBoxTareaPadre.Text = "";
                ComboBoxPuntoRojoID.Enabled = true;
                ComboBoxPuntoRojoID.Text = "";
                textBoxPuntoRojoProceso.Text = "";
                tbReunionID.Text = "";
                tbReunionNombre.Text = "";
                tarea.IDTareaPadre = null;
            }
        }

        private void tbOrigen_TextChanged(object sender, EventArgs e)
        {
            this.tarea.Tipo = comboBoxTipo.Text;
        }
    }
}
