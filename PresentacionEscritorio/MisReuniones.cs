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

namespace PresentacionEscritorio
{
    public partial class MisReuniones : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private GridDynamicFilter filter = new GridDynamicFilter();
        private List<Reunion> reuniones;
        List<Tarea> tareas;
        List<Asistente> asistentes;
        List<Invitado> invitados;
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
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
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

            //this.gridGroupingControl1.TableDescriptor.Columns[2].Appearance.AnyCell.AutoSize=true;
            //this.gridGroupingControl1.TableDescriptor.Columns[5].Width = 25;

            comboBox2.DataSource = installedFonts.Families;
            comboBox2.DisplayMember = "Name";
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DataSource = installedFonts.Families;
            comboBox4.DisplayMember = "Name";
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;

            invitados = negocio.getInvitadoReunion(1);
            gridGroupingControl3.DataSource = invitados;
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
            //this.gridGroupingControl3.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.PushButton;
            //this.gridGroupingControl3.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.Description = "Quitar";
            
            asistentes = negocio.getAsistenteActa(1);
            gridGroupingControl4.DataSource = asistentes;
            SampleCustomization(gridGroupingControl4);
            this.gridGroupingControl4.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl4.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl4.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl4.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl4.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl4.TableDescriptor.Columns.Add(" ");
            this.gridGroupingControl4.TableDescriptor.Columns[2].Width = 20;
            this.gridGroupingControl4.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageList = il;
            this.gridGroupingControl4.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageIndex = 0;          
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
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage2")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage3")
            {
                this.WindowState = FormWindowState.Minimized;
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
                        MessageBox.Show(idReu.ToString());
                    }
                }
            }
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
            richTextBox2.Rtf = richTextBox1.Rtf;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Rtf = richTextBox2.Rtf;
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
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        if(ggc.Text.Equals("Invitado"))
                            MessageBox.Show(style.TableCellIdentity.Column.Name+"I");
                        else
                            MessageBox.Show(style.TableCellIdentity.Column.Name + "A");
                        //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                    }
                }
            }
        }
    }
}
