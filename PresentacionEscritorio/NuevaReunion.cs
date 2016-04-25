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
using System.Drawing.Text;
using System.Diagnostics;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System.Text.RegularExpressions;
using Syncfusion.GridHelperClasses;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;

namespace PresentacionEscritorio
{
    public partial class NuevaReunion : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private InstalledFontCollection installedFonts = new InstalledFontCollection(); 
        private int tamano1 = 8;
        private bool vineta1 = false;
        private bool negrita1 = false;
        private bool subrayado1 = false;
        private string tipoLetra1;
        private List<string> invitados = new List<string>();
        private GridDynamicFilter filter = new GridDynamicFilter();

        public NuevaReunion()
        {
            InitializeComponent();
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1).ToUpper();

            List<Reunion> reuniones = negocio.getReunionUsuario(user);
            multiColumnComboBoxBase.DataSource = reuniones;
            multiColumnComboBoxBase.DisplayMember = "Titulo";
            multiColumnComboBoxBase.DropDownStyle = ComboBoxStyle.DropDownList;
            multiColumnComboBoxBase.ListBox.Text = "";

            dateTimePickerFecha.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            comboBox2.DataSource = installedFonts.Families;
            comboBox2.DisplayMember = "Name";
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;

            gridGroupingControl1.DataSource = invitados.Select(x => new { Usuario = x }).ToList();
            SampleCustomization(gridGroupingControl1);
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl1.TableDescriptor.Columns.Add(" ");
            this.gridGroupingControl1.TableDescriptor.Columns[0].Width = 65;
            this.gridGroupingControl1.TableDescriptor.Columns[1].Width = 25;
            this.gridGroupingControl1.TableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.BackgroundImage = Properties.Resources.ELIMINAR;
            this.gridGroupingControl1.TableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.BackgroundImageMode = Syncfusion.Windows.Forms.Grid.GridBackgroundImageMode.StretchImage;
            this.gridGroupingControl1.TableDescriptor.Columns[1].ReadOnly = true;
            //this.gridGroupingControl1.TableDescriptor.Columns[1].Appearance.AnyRecordFieldCell.ImageIndex = 0;
        }

        private void gridGroupingControl3_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridGroupingControl ggc = (GridGroupingControl)sender;
            Element el = ggc.Table.GetInnerMostCurrentElement();
            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = ggc.GetTableControl(table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                if (cc.ColIndex.Equals(2) && cc.RowIndex > 2)
                {
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 1);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        invitados.Remove(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                        gridGroupingControl1.DataSource = invitados.Select(x => new { Usuario = x }).ToList();
                        //negocio.removeInvitado(new Invitado(reunion.ID, rec.GetValue(style.TableCellIdentity.Column.Name).ToString()));
                        //negocio.removeAsistente(new Asistente(acta.ID, rec.GetValue(style.TableCellIdentity.Column.Name).ToString()));
                        //invitados = negocio.getInvitadoReunion(idReu);
                        //asistentes = negocio.getAsistenteActa(acta.ID);
                        //ia = new List<InvitadoAsitente>();
                        //foreach (Invitado inv in invitados)
                        //{
                        //    ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
                        //}
                        //gridGroupingControl3.DataSource = ia;
                        ////MessageBox.Show(style.TableCellIdentity.Column.Name);
                        ////MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                        //ActualizarIndicadores(true);
                    }
                }
            }
        }

        void SampleCustomization(GridGroupingControl ggc)
        {
            ggc.TopLevelGroupOptions.ShowFilterBar = true;
            ggc.NestedTableGroupOptions.ShowFilterBar = true;
            ggc.ChildGroupOptions.ShowFilterBar = true;
            //Enable the filter for each columns 
            for (int i = 0; i < ggc.TableDescriptor.Columns.Count; i++)
                ggc.TableDescriptor.Columns[i].AllowFilter = true;

            //Enable dynamic filter.
            ggc.TableModel.EnableLegacyStyle = false;
            filter.WireGrid(ggc);
            foreach (GridColumnDescriptor col in ggc.TableDescriptor.Columns)
            {
                Regex rex = new Regex(@"\p{Lu}");
                int index = rex.Match(col.MappingName.Substring(1)).Index;
                string name = "";
                while (index > 0)
                {
                    name += col.MappingName.Substring(0, index + 1) + " ";
                    string secondName = col.MappingName.Substring(index + 1);
                    index = rex.Match(secondName.Substring(1)).Index;
                    while (index > 0)
                    {
                        name += secondName.Substring(0, index + 1) + " ";
                        index = rex.Match(col.MappingName.Substring(name.Replace(" ", "").Length).Substring(1)).Index;
                    }
                }
                name += col.MappingName.Substring(name.Replace(" ", "").Length);
                col.HeaderText = name;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVineta_Click(object sender, EventArgs e)
        {
            vineta1 = !vineta1;
            cambiarRichTextBox1();
        }

        private void buttonNegrita_Click(object sender, EventArgs e)
        {
            subrayado1 = false;
            negrita1 = !negrita1;
            cambiarRichTextBox1();
        }

        private void buttonSubrayado_Click(object sender, EventArgs e)
        {
            negrita1 = false;
            subrayado1 = !subrayado1;
            cambiarRichTextBox1();
        }

        private void buttonHipervinculo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectedText = ofd.FileName.Replace(" ", "!");
            }
        }

        private void cambiarRichTextBox1()
        {
            richTextBox1.SelectionBullet = vineta1;
            if (negrita1)
                richTextBox1.SelectionFont = new Font(tipoLetra1, tamano1, FontStyle.Bold);
            else if (subrayado1)
                richTextBox1.SelectionFont = new Font(tipoLetra1, tamano1, FontStyle.Underline);
            else
                richTextBox1.SelectionFont = new Font(tipoLetra1, tamano1, FontStyle.Regular);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process p = new Process();
            p = Process.Start(e.LinkText.Replace("!", " "));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoLetra1 = comboBox2.Text;
            cambiarRichTextBox1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            if (Int32.TryParse(comboBox1.Text, out num))
                tamano1 = num;
            else
                MessageBox.Show("Tipo no numérico");
            comboBox1.Text = tamano1.ToString();

            cambiarRichTextBox1();
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            FontFamily family = installedFonts.Families[e.Index];
            tipoLetra1 = family.Name;
            FontStyle style = FontStyle.Regular;
            if (!family.IsStyleAvailable(style))
                style = FontStyle.Bold;
            if (!family.IsStyleAvailable(style))
                style = FontStyle.Italic;
            Font fnt = new Font(family, 10, style);
            Brush brush;
            if (e.State == DrawItemState.Selected)
            {
                brush = new SolidBrush(Color.White);
            }
            else
            {
                brush = new SolidBrush(comboBox1.ForeColor);
            }

            e.DrawBackground();
            e.Graphics.DrawString(family.GetName(0),
                                  fnt, brush, e.Bounds.Location);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnadirNuevaInvitacion ani = new AnadirNuevaInvitacion(invitados);
            ani.ShowDialog();
            invitados = ani.invitados;
            gridGroupingControl1.DataSource = invitados.Select(x => new { Usuario = x }).ToList();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Double horas;
            if (Double.TryParse(textBoxDuracion.Text.Replace(".", ","), out horas))
            {
                negocio.setNuevaReunion(new Reunion(0, textBoxTitulo.Text, textBoxUbicacion.Text, Double.Parse(textBoxDuracion.Text.Replace(".", ",")),0.0, dateTimePickerFecha.Value, user), new Agenda(richTextBox1.Rtf, 0), invitados);
                this.Close();
            }
            else
                MessageBox.Show("El campo horas no es de tipo numerico");
        }

        private void multiColumnComboBoxBase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Reunion reunionBase = ((Reunion)multiColumnComboBoxBase.SelectedItem);
            Agenda agendaBase = negocio.getAgendaReunion(reunionBase.ID);
            List<Invitado> invitadosBase = negocio.getInvitadoReunion(reunionBase.ID);

            textBoxDuracion.Text = reunionBase.DuracionEstimada + "";
            textBoxTitulo.Text = reunionBase.Titulo;
            textBoxUbicacion.Text = reunionBase.Ubicacion;
            dateTimePickerFecha.Value = reunionBase.Fecha;
            richTextBox1.Rtf = agendaBase.Contenido;

            invitados.Clear();
            foreach (Invitado inBase in invitadosBase)
            {
                invitados.Add(inBase.IDEmpleado); 
            }
            gridGroupingControl1.DataSource = invitados.Select(x => new { Usuario = x }).ToList();
        }
    }

    public class InvitadoNuevo1
    {
        public string Usuario;

        public InvitadoNuevo1(string usuario)
        {
            Usuario = usuario;
        }
    }
}
