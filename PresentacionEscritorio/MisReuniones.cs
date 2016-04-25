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
using Syncfusion.GridHelperClasses;
using System.Text.RegularExpressions;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using System.Drawing.Text;
using System.Diagnostics;
using Syncfusion.Drawing;

namespace PresentacionEscritorio
{
    public partial class MisReuniones : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private GridDynamicFilter filter = new GridDynamicFilter();
        private List<Reunion> reuniones;
        Reunion reunion;
        List<Tarea> tareas;
        List<Asistente> asistentes;
        List<Invitado> invitados;
        List<InvitadoAsitente> ia;
        Agenda agenda;
        Acta acta;
        Indicadores indicador;
        private int idReu=0;
        private InstalledFontCollection installedFonts = new InstalledFontCollection();
        private int tamano1 = 8;
        private bool vineta1 = false;
        private bool negrita1 = false;
        private bool subrayado1 = false;
        private string tipoLetra1;
        private int tamano2 = 8;
        private bool vineta2 = false;
        private bool negrita2 = false;
        private bool subrayado2 = false;
        private string tipoLetra2;

        public MisReuniones()
        {
            InitializeComponent();
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1).ToUpper();
            this.Text = user;

            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            reuniones = negocio.getReunionUsuario(user);
            gridGroupingControl1.DataSource = reuniones;
            SampleCustomization(gridGroupingControl1);
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            gridGroupingControl1.TableDescriptor.Columns[0].ReadOnly = true;
            gridGroupingControl1.TableDescriptor.Columns[1].ReadOnly = true;
            gridGroupingControl1.TableDescriptor.Columns[6].ReadOnly = true;
            gridGroupingControl1.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "yyyy-MM-dd HH:mm";

            //Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            //GridTable table = el.ParentTable as GridTable;
            //GridTableCellStyleInfo style = table.GetTableCellStyle(1, 2);
            //GridRecord rec = el as GridRecord;
            //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
            tareas = negocio.getTareasReunion(0);
            gridGroupingControl2.DataSource = tareas;
            SampleCustomization(gridGroupingControl2);
            this.gridGroupingControl2.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl2.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            gridGroupingControl2.TableDescriptor.Columns[2].Appearance.AnyCell.Format = "yyyy-MM-dd";
            gridGroupingControl2.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "yyyy-MM-dd";
            gridGroupingControl2.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "yyyy-MM-dd";

            //this.gridGroupingControl1.TableDescriptor.Columns[2].Appearance.AnyCell.AutoSize=true;
            //this.gridGroupingControl1.TableDescriptor.Columns[5].Width = 25;

            comboBox2.DataSource = installedFonts.Families;
            comboBox2.DisplayMember = "Name";
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DataSource = installedFonts.Families;
            comboBox4.DisplayMember = "Name";
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;

            invitados = negocio.getInvitadoReunion(0);
            asistentes = negocio.getAsistenteReunion(0);
            ia = new List<InvitadoAsitente>();
            ia.Add(new InvitadoAsitente("",false));
            gridGroupingControl3.DataSource = ia;
            SampleCustomization(gridGroupingControl3);
            this.gridGroupingControl3.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl3.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl3.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl3.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl3.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl3.TableDescriptor.Columns.Add(" ");
            this.gridGroupingControl3.TableDescriptor.Columns[2].Width = 20;
            ImageList il = new ImageList();
            il.Images.Add(Properties.Resources.ELIMINAR);
            this.gridGroupingControl3.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageList = il;
            this.gridGroupingControl3.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageIndex = 0;

            richTextBox1.Text = "";
            //asistentes = negocio.getAsistenteActa(0);
            //gridGroupingControl4.DataSource = asistentes;
            //SampleCustomization(gridGroupingControl4);
            //this.gridGroupingControl4.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            //this.gridGroupingControl4.TopLevelGroupOptions.ShowCaption = false;
            //this.gridGroupingControl4.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            //this.gridGroupingControl4.GridVisualStyles = GridVisualStyles.Metro;
            //this.gridGroupingControl4.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            //this.gridGroupingControl4.TableDescriptor.Columns.Add(" ");
            //this.gridGroupingControl4.TableDescriptor.Columns[2].Width = 20;
            //this.gridGroupingControl4.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageList = il;
            //this.gridGroupingControl4.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageIndex = 0;          

            System.Collections.Specialized.StringCollection list1 = new System.Collections.Specialized.StringCollection();
            list1.Add("Retrasada");
            list1.Add("En curso");
            list1.Add("Terminada");
            list1.Add("Abandonada");
            list1.Add("Planificada");
            this.gridGroupingControl2.TableDescriptor.Columns[6].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.ComboBox;
            this.gridGroupingControl2.TableDescriptor.Columns[6].Appearance.AnyRecordFieldCell.ChoiceList = list1;
            this.gridGroupingControl2.TableDescriptor.Columns[6].Appearance.AnyRecordFieldCell.CellValue = "Trial1";
            gridGroupingControl2.TableDescriptor.Columns[0].ReadOnly = true;
            this.gridGroupingControl2.TableDescriptor.Columns[4].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.MonthCalendar;
            gridGroupingControl2.TableDescriptor.Columns[2].ReadOnly = true;
            gridGroupingControl2.TableDescriptor.Columns[7].ReadOnly = true;
            gridGroupingControl2.TableDescriptor.Columns[8].ReadOnly = true;
            gridGroupingControl2.TableDescriptor.Columns[9].ReadOnly = true;
            this.gridGroupingControl2.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl2.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl2.TableModel.QueryRowHeight += new GridRowColSizeEventHandler(TableModel_QueryRowHeight);
        }

        //This event is triggered when the row height is changed.
        void TableModel_QueryRowHeight(object sender, GridRowColSizeEventArgs e)
        {
            if (e.Index > 0)
            {
                IGraphicsProvider graphicsProvider = this.gridGroupingControl2.TableModel.GetGraphicsProvider();
                Graphics g = graphicsProvider.Graphics;
                GridStyleInfo style = this.gridGroupingControl2.TableModel[e.Index, 2];
                GridCellModelBase model = style.CellModel;
                e.Size = model.CalculatePreferredCellSize(g, e.Index, 2, style, GridQueryBounds.Height).Height;
                e.Handled = true;
            }
        }

        private void gridGroupingControl2_RecordValueChanged(object sender, RecordValueChangedEventArgs e)
        {
            Element el = this.gridGroupingControl2.Table.GetInnerMostCurrentElement();

            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl2.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    //MessageBox.Show(style.TableCellIdentity.Column.Name);
                    //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                    //MessageBox.Show(rec.GetValue(styleID.TableCellIdentity.Column.Name).ToString());
                    int j = (int)rec.GetValue(styleID.TableCellIdentity.Column.Name);
                    string fila = style.TableCellIdentity.Column.Name, valor = rec.GetValue(style.TableCellIdentity.Column.Name).ToString();
                    if (fila.Equals("TiempoDedicado") && valor.Contains("."))
                    {
                        rec.SetValue(style.TableCellIdentity.Column.Name, valor);
                    }
                    if (negocio.setTareaFila(j, fila, valor) == 0)
                        MessageBox.Show("Error al actualizar la Tarea");
                    else
                        ActualizarIndicadores(true);
                }
            }
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            FontFamily family = installedFonts.Families[e.Index];
            if(sender.Equals(comboBox2))
                tipoLetra1 = family.Name;
            else
                tipoLetra2 = family.Name;
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

        void image_ImageMouseUp(object sender, ImageMouseUpEventArgs e)
        {
            if ((sender as CaptionImage).Name == "CaptionImage1")
            {
                this.Hide();
                var form2 = new Form1();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage2")
            {
                //this.Hide();
                //var form2 = new MisReuniones();
                //form2.Closed += (s, args) => this.Close();
                //form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage3")
            {
                this.Hide();
                var form2 = new MisTareas();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage4")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage5")
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        void image_ImageMouseEnter(object sender, ImageMouseEnterEventArgs e)
        {
            e.BackColor = Color.Red;
        }

        void image_ImageMouseLeave(object sender, ImageMouseLeaveEventArgs e)
        {
            e.BackColor = Color.Transparent;
        }

        private void gridGroupingControl1_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            ////DataGridViewImageCell cell = (DataGridViewImageCell) gridGroupingControl1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            ////MessageBox.Show(e.Inner.ColIndex+"-"+e.Inner.RowIndex);
            //Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            //if (el != null)
            //{
            //    GridTable table = el.ParentTable as GridTable;
            //    GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
            //                      (table.TableDescriptor.Name);
            //    GridCurrentCell cc = tableControl.CurrentCell;
            //    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
            //    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
            //    GridRecord rec = el as GridRecord;
            //    if (rec == null && el is GridRecordRow)
            //    {
            //        rec = el.ParentRecord as GridRecord;
            //    }
            //    if (rec != null)
            //    {
            //        MessageBox.Show(style.TableCellIdentity.Column.Name);
            //        MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
            //    }
            //}
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

        private void gridGroupingControl1_SelectedRecordsChanged(object sender, SelectedRecordsChangedEventArgs e)
        {
            Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();
            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                //GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 1);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    if (idReu != (int)rec.GetValue(style.TableCellIdentity.Column.Name))
                    {
                        idReu = (int)rec.GetValue(style.TableCellIdentity.Column.Name);
                        //MessageBox.Show(idReu.ToString());
                        reunion = negocio.getReunion(idReu);
                        agenda = negocio.getAgendaReunion(idReu);
                        richTextBox1.Rtf = agenda.Contenido;
                        acta = negocio.getActaReunion(idReu);
                        richTextBox2.Rtf = acta.Contenido;
                        tareas = negocio.getTareasReunion(idReu);
                        gridGroupingControl2.DataSource = tareas;

                        invitados = negocio.getInvitadoReunion(idReu);
                        asistentes = negocio.getAsistenteReunion(idReu);
                        ia = new List<InvitadoAsitente>();
                        foreach (Invitado inv in invitados)
                        {
                            ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
                        }
                        gridGroupingControl3.DataSource = ia;

                        ActualizarIndicadores(true);
                    }
                }
            }
        }

        private bool asistioEmpleado(string p)
        {
            bool b=false;
            int i = 0;
            while (asistentes.Count > i && !b)
            {
                if (asistentes[i].IDEmpleado.Equals(p))
                {
                    b = true;
                }
                i++;
            }
            return b;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Clear all text from the RichTextBox;
            richTextBox1.Clear();
            // Indent bulleted text 30 pixels away from the bullet.
            richTextBox1.BulletIndent = 30;
            // Set the font for the opening text to a larger Arial font;
            richTextBox1.SelectionFont = new Font("Arial", 16);
            // Assign the introduction text to the RichTextBox control.
            richTextBox1.SelectedText = "The following is a list of bulleted items:\n";
            // Set the Font for the first item to a smaller size Arial font.
            richTextBox1.SelectionFont = new Font("Arial", 12);
            // Specify that the following items are to be added to a bulleted list.
            richTextBox1.SelectionBullet = true;
            // Set the color of the item text.
            richTextBox1.SelectionColor = Color.Red;
            // Assign the text to the bulleted item.
            richTextBox1.SelectedText = "Apples" + "\n";
            // Apply same font since font settings do not carry to next line.
            richTextBox1.SelectionFont = new Font("Arial", 12);
            richTextBox1.SelectionColor = Color.Orange;
            richTextBox1.SelectedText = "Oranges" + "\n";
            richTextBox1.SelectionFont = new Font("Arial", 12);
            richTextBox1.SelectionColor = Color.Purple;
            richTextBox1.SelectedText = "Grapes" + "\n";
            // End the bulleted list.
            richTextBox1.SelectionBullet = false;
            // Specify the font size and string for text displayed below bulleted list.
            richTextBox1.SelectionFont = new Font("Verdana", 10);
            richTextBox1.SelectedText = "The bulleted text is indented 30 pixels from the bullet symbol using the BulletIndent property.\n";
            MessageBox.Show(richTextBox1.Text);
            richTextBox1.LinkClicked +=new LinkClickedEventHandler(richTextBox1_LinkClicked);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process p = new Process();
            p = Process.Start(e.LinkText.Replace("!"," "));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoLetra1 = comboBox2.Text;
            cambiarRichTextBox1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            if(Int32.TryParse(comboBox1.Text,out num))
                tamano1=num;
            else
                MessageBox.Show("Tipo no numérico");
            comboBox1.Text = tamano1.ToString();

            cambiarRichTextBox1();
        }

        private void btnVineta_Click(object sender, EventArgs e)
        {
            vineta1 = !vineta1;
            cambiarRichTextBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subrayado1 = false;
            negrita1 = !negrita1;
            cambiarRichTextBox1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            negrita1 = false;
            subrayado1 = !subrayado1;
            cambiarRichTextBox1();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            if(Int32.TryParse(comboBox3.Text,out num))
                tamano2=num;
            else
                MessageBox.Show("Tipo no numérico");
            comboBox3.Text = tamano2.ToString();
            cambiarRichTextBox2();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoLetra2 = comboBox4.Text;
            cambiarRichTextBox2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vineta2 = !vineta2;
            cambiarRichTextBox2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            subrayado2 = false;
            negrita2 = !negrita2;
            cambiarRichTextBox2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            negrita2 = false;
            subrayado2 = !subrayado2;
            cambiarRichTextBox2();
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

        private void cambiarRichTextBox2()
        {
            richTextBox2.SelectionBullet = vineta2;
            if (negrita2)
                richTextBox2.SelectionFont = new Font(tipoLetra2, tamano2, FontStyle.Bold);
            else if (subrayado2)
                richTextBox2.SelectionFont = new Font(tipoLetra2, tamano2, FontStyle.Underline);
            else
                richTextBox2.SelectionFont = new Font(tipoLetra2, tamano2, FontStyle.Regular);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            agenda.Contenido = richTextBox1.Rtf;
            negocio.updateAgenda(agenda);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            acta.Contenido = richTextBox2.Rtf;
            negocio.updateActa(acta);
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
                if (cc.ColIndex.Equals(3) && cc.RowIndex>2)
                {
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 1);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        negocio.removeInvitado(new Invitado(reunion.ID, rec.GetValue(style.TableCellIdentity.Column.Name).ToString()));
                        negocio.removeAsistente(new Asistente(reunion.ID, rec.GetValue(style.TableCellIdentity.Column.Name).ToString()));
                        invitados = negocio.getInvitadoReunion(idReu);
                        asistentes = negocio.getAsistenteReunion(idReu);
                        ia = new List<InvitadoAsitente>();
                        foreach (Invitado inv in invitados)
                        {
                            ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
                        }
                        gridGroupingControl3.DataSource = ia;
                        //MessageBox.Show(style.TableCellIdentity.Column.Name);
                        //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                        ActualizarIndicadores(true);
                    }
                }
            }
        }

        private void gridGroupingControl3_TableControlCheckBoxClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridGroupingControl ggc = (GridGroupingControl)sender;
            Element el = ggc.Table.GetInnerMostCurrentElement();
            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = ggc.GetTableControl(table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleUser = table.GetTableCellStyle(cc.RowIndex, 1);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    Boolean b = (bool)style.CellValue;
                    if (!b)
                    {
                        if (negocio.setAsistente(new Asistente(reunion.ID, rec.GetValue(styleUser.TableCellIdentity.Column.Name).ToString())) > 0)
                        {
                            invitados = negocio.getInvitadoReunion(idReu);
                            asistentes = negocio.getAsistenteReunion(idReu);
                            ia = new List<InvitadoAsitente>();
                            foreach (Invitado inv in invitados)
                            {
                                ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
                            }
                        }
                    }
                    else
                    {
                        if (negocio.removeAsistente(new Asistente(reunion.ID, rec.GetValue(styleUser.TableCellIdentity.Column.Name).ToString())) > 0)
                        {
                            asistentes = negocio.getAsistenteReunion(idReu);
                            ia = new List<InvitadoAsitente>();
                            foreach (Invitado inv in invitados)
                            {
                                ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
                            }
                        }
                    }
                    ActualizarIndicadores(true);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Añadir Invitados");
            AnadirInvitados formIA = new AnadirInvitados(invitados, reunion);
            formIA.ShowDialog();

            invitados = negocio.getInvitadoReunion(idReu);
            asistentes = negocio.getAsistenteReunion(idReu);
            ia = new List<InvitadoAsitente>();
            foreach (Invitado inv in invitados)
            {
                ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
            }
            gridGroupingControl3.DataSource = ia;

            ActualizarIndicadores(true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AnadirTarea formIT = new AnadirTarea(reunion);
            formIT.ShowDialog();

            tareas = negocio.getTareasReunion(idReu);
            gridGroupingControl2.DataSource = tareas;

            ActualizarIndicadores(true);
        }

        private void ActualizarIndicadores(bool terminada)
        {
            if (terminada)
            {
                indicador = negocio.getIndicadores(idReu);
                lblAsistencia.Text = indicador.Asistencia*100 + "%";
                lblNTCreadas.Text = indicador.NumTareas + " Tareas";
                //var qTerminadas = tareas.Where(t => t.Estado == "Terminada");
                //lblTTerminadas.Text = qTerminadas.Count() * 100 / tareas.Count + "%";
                lblTTerminadas.Text = indicador.Terminadas * 100 + "%";
                lblTAbandonadas.Text = indicador.Abandonadas * 100 + "%";
                lblTProceso.Text = indicador.EnProceso * 100 + "%";
            }
            else
            {
                indicador = null;
                lblAsistencia.Text = "";
                lblNTCreadas.Text = "";
                lblTTerminadas.Text = "";
                lblTAbandonadas.Text = "";
                lblTProceso.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectedText = ofd.FileName.Replace(" ","!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.SelectedText = ofd.FileName.Replace(" ", "!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            NuevaReunion nr = new NuevaReunion();
            nr.ShowDialog();
            reuniones = negocio.getReunionUsuario(user);
            gridGroupingControl1.DataSource = reuniones;
            gridGroupingControl1.Table.Records[0].SetCurrent();
            gridGroupingControl1.TableControl.CurrentCell.Activate(0, 0);

            //idReu = (int)rec.GetValue(style.TableCellIdentity.Column.Name);
            idReu = reuniones[0].ID;
            reunion = negocio.getReunion(idReu);
            agenda = negocio.getAgendaReunion(idReu);
            richTextBox1.Rtf = agenda.Contenido;
            acta = negocio.getActaReunion(idReu);
            richTextBox2.Rtf = acta.Contenido;
            tareas = negocio.getTareasReunion(idReu);
            gridGroupingControl2.DataSource = tareas;

            invitados = negocio.getInvitadoReunion(idReu);
            asistentes = negocio.getAsistenteReunion(idReu);
            ia = new List<InvitadoAsitente>();
            foreach (Invitado inv in invitados)
            {
                ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
            }
            gridGroupingControl3.DataSource = ia;

            ActualizarIndicadores(true);
        }

        private void gridGroupingControl1_RecordValueChanged(object sender, RecordValueChangedEventArgs e)
        {
            Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();

            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    //MessageBox.Show(style.TableCellIdentity.Column.Name);
                    //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                    //MessageBox.Show(rec.GetValue(styleID.TableCellIdentity.Column.Name).ToString());
                    int j = (int)rec.GetValue(styleID.TableCellIdentity.Column.Name);
                    string fila = style.TableCellIdentity.Column.Name, valor = rec.GetValue(style.TableCellIdentity.Column.Name).ToString();
                    if (fila.Equals("Duracion") && valor.Contains("."))
                    {
                        rec.SetValue(style.TableCellIdentity.Column.Name, valor);
                    }
                    if (negocio.setReunionFila(j, fila, valor) == 0)
                        MessageBox.Show("Error al actualizar la Tarea");
                    else
                        ActualizarIndicadores(true);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                reuniones = negocio.getReunionUsuarioPasadas(user);
                gridGroupingControl1.DataSource = reuniones;
            }
            else
            {
                reuniones = negocio.getReunionUsuario(user);
                gridGroupingControl1.DataSource = reuniones;
            }

            gridGroupingControl1.Table.Records[0].SetCurrent();
            gridGroupingControl1.TableControl.CurrentCell.Activate(0, 0);

            //idReu = (int)rec.GetValue(style.TableCellIdentity.Column.Name);
            idReu = reuniones[0].ID;
            reunion = negocio.getReunion(idReu);
            agenda = negocio.getAgendaReunion(idReu);
            richTextBox1.Rtf = agenda.Contenido;
            acta = negocio.getActaReunion(idReu);
            richTextBox2.Rtf = acta.Contenido;
            tareas = negocio.getTareasReunion(idReu);
            gridGroupingControl2.DataSource = tareas;

            invitados = negocio.getInvitadoReunion(idReu);
            asistentes = negocio.getAsistenteReunion(idReu);
            ia = new List<InvitadoAsitente>();
            foreach (Invitado inv in invitados)
            {
                ia.Add(new InvitadoAsitente(inv.IDEmpleado, asistioEmpleado(inv.IDEmpleado)));
            }
            gridGroupingControl3.DataSource = ia;

            ActualizarIndicadores(true);
        }

        private void gridGroupingControl2_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            Element el = this.gridGroupingControl2.Table.GetInnerMostCurrentElement();

            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl2.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                    formIT.ShowDialog();

                    tareas = negocio.getTareasReunion(reunion.ID);
                    gridGroupingControl2.DataSource = tareas;
                }
            }
        }
    }

    public class InvitadoAsitente
    {
        public string Usuario;
        public bool Asistio;

        public InvitadoAsitente(string usuario, bool asistio)
        {
            Usuario = usuario;
            Asistio = asistio;
        }
    }
}
