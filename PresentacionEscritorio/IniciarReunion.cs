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
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid;
using System.Text.RegularExpressions;
using Syncfusion.GridHelperClasses;
using System.Drawing.Text;

namespace PresentacionEscritorio
{
    public partial class IniciarReunion : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        Indicadores indicador;
        private Reunion reunion;
        private GridDynamicFilter filter = new GridDynamicFilter();
        GridExcelFilter filter2 = new GridExcelFilter();
        List<string> asistentes;
        List<string> invitados;
        List<List<Tarea>> tareas;
        List<InvitadoAsitente> ia;
        Agenda agenda;
        Acta acta;
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
        private Double seg = 0, min = 30, horas = 1;

        public IniciarReunion(Reunion reu)
        {
            InitializeComponent();
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            user = user.ToUpper();
            this.reunion = reu;

            comboBox2.DataSource = installedFonts.Families;
            comboBox2.DisplayMember = "Name";
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DataSource = installedFonts.Families;
            comboBox4.DisplayMember = "Name";
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;

            invitados = negocio.getInvitadoReunion(reunion.ID);
            asistentes = negocio.getAsistenteReunion(reunion.ID);
            ia = new List<InvitadoAsitente>();
            foreach (string inv in invitados)
            {
                ia.Add(new InvitadoAsitente(inv, asistioEmpleado(inv)));
            }
            gridGroupingControl2.DataSource = ia;
            SampleCustomization(gridGroupingControl2);
            this.gridGroupingControl2.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl2.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl2.TableDescriptor.Columns.Add(" ");
            this.gridGroupingControl2.TableDescriptor.Columns[2].Width = 20;
            ImageList il = new ImageList();
            il.Images.Add(Properties.Resources.ELIMINAR);
            this.gridGroupingControl2.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageList = il;
            this.gridGroupingControl2.TableDescriptor.Columns[2].Appearance.AnyRecordFieldCell.ImageIndex = 0;

            agenda = negocio.getAgendaReunion(reunion.ID);
            richTextBox1.Rtf = agenda.Contenido;
            acta = negocio.getActaReunion(reunion.ID);
            richTextBox2.Rtf = acta.Contenido;

            tareas = negocio.getTareasReunion(reunion.ID);
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridGroupingControl1.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(gridGroupingControl1_QueryCellStyleInfo);
            this.gridGroupingControl1.TableControlCellClick += new GridTableControlCellClickEventHandler(gridGroupingControl1_TableControlCellClick);
            this.gridGroupingControl1.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridGroupingControl1_TableControlCellDoubleClick);
            MostrarGridGroupingControl();
            ActualizarIndicadores(true);
        }

        void gridGroupingControl1_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            if (e.Inner.MouseEventArgs.Button == MouseButtons.Right)
            {
                Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();

                if (el != null)
                {
                    GridTable table = el.ParentTable as GridTable;
                    GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                      (table.TableDescriptor.Name);
                    GridCurrentCell cc = tableControl.CurrentCell;
                    //GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                    GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        if (styleID.TableCellIdentity.Column != null)
                        {
                            DetallesTarea formIT = new DetallesTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                            formIT.ShowDialog();
                        }
                        else
                        {
                            DetallesTarea formIT = new DetallesTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                            formIT.ShowDialog();
                        }
                        tareas = negocio.getTareasReunion(reunion.ID);
                        //this.gridGroupingControl1.DataSource = tareas[0];
                        MostrarGridGroupingControl();
                        ActualizarIndicadores(true);
                    }
                }
            }
        }

        private void gridGroupingControl1_TableControlCellDoubleClick(object sender, GridTableControlCellClickEventArgs e)
        {
            Element el = this.gridGroupingControl1.Table.GetInnerMostCurrentElement();

            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = this.gridGroupingControl1.GetTableControl
                                  (table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                //GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex);
                GridTableCellStyleInfo styleID = table.GetTableCellStyle(cc.RowIndex, 1);
                GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 2);
                GridRecord rec = el as GridRecord;
                if (rec == null && el is GridRecordRow)
                {
                    rec = el.ParentRecord as GridRecord;
                }
                if (rec != null)
                {
                    if (styleID.TableCellIdentity.Column != null)
                    {
                        EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(styleID.TableCellIdentity.Column.Name)));
                        formIT.ShowDialog();
                    }
                    else
                    {
                        EditarTarea formIT = new EditarTarea(negocio.getTarea((int)rec.GetValue(style.TableCellIdentity.Column.Name)));
                        formIT.ShowDialog();
                    }
                    //ObtenerDatos();
                    //this.gridGroupingControl1.DataSource = tareas[0];
                    tareas = negocio.getTareasReunion(reunion.ID);
                    MostrarGridGroupingControl();
                    ActualizarIndicadores(true);
                }
            }
        }

        private void MostrarGridGroupingControl()
        {
            filter2.UnWireGrid(gridGroupingControl1);
            filter2.ClearFilters(gridGroupingControl1);
            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = false;

            gridGroupingControl1.TableDescriptor.Relations.Clear();
            this.gridGroupingControl1.Table.CollapseAllRecords();
            this.gridGroupingControl1.Engine.SourceListSet.Clear();
            gridGroupingControl1.Update();
            this.gridGroupingControl1.Refresh();

            gridGroupingControl1.TableDescriptor.Columns.Reset();
            this.gridGroupingControl1.DataSource = tareas[0];

            GridRelationDescriptor childToChildRelationDescriptor = null;
            for (int i = 0; i < tareas.Count; i++)
            {
                if (tareas[0] != null)
                    if (i == 0)
                    {
                        //this.gridGroupingControl1.DataSource = tareas[0];
                        this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);

                        gridGroupingControl1.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "dd-MM-yyyy";
                        gridGroupingControl1.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "dd-MM-yyyy";
                        gridGroupingControl1.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "dd-MM-yyyy";
                    }
                    else
                    {
                        GridRelationDescriptor parentToChildRelationDescriptor = new GridRelationDescriptor();
                        parentToChildRelationDescriptor.ChildTableName = "lista" + i;    // same as SourceListSetEntry.Name for childTable (see below)
                        parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
                        parentToChildRelationDescriptor.ChildTableDescriptor.TopLevelGroupOptions.ShowCaption = false;

                        parentToChildRelationDescriptor.RelationKeys.Add("ID", "IDTareaPadre");

                        // Add relation to ParentTable 
                        if (childToChildRelationDescriptor == null)
                            gridGroupingControl1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);
                        else
                            childToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(parentToChildRelationDescriptor);

                        this.gridGroupingControl1.Engine.SourceListSet.Add("lista" + i, tareas[i]);

                        for (int j = 0; j < parentToChildRelationDescriptor.ChildTableDescriptor.Columns.Count; j++)
                        //parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                        {
                            parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].AllowFilter = true;
                            parentToChildRelationDescriptor.ChildTableDescriptor.Columns[j].ReadOnly = true;
                        }

                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[5].Appearance.AnyCell.Format = "dd-MM-yyyy";
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[3].Appearance.AnyCell.Format = "dd-MM-yyyy";
                        parentToChildRelationDescriptor.ChildTableDescriptor.Columns[4].Appearance.AnyCell.Format = "dd-MM-yyyy";
                        //filter.WireGrid(parentToChildRelationDescriptor);

                        //gridGroupingControl1.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells);

                        //this.gridGroupingControl1.GetTableDescriptor("lista" + i).AllowCalculateMaxColumnWidth = false; 
                        //GridTableModel tm = this.gridGroupingControl1.GetTableModel("lista"+i); 
                        ////tm.Table.FilteredChildTable = null; 
                        //tm.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);
                        childToChildRelationDescriptor = parentToChildRelationDescriptor;
                    }
            }

            for (int j = 0; j < gridGroupingControl1.TableDescriptor.Columns.Count; j++)
            {
                gridGroupingControl1.TableDescriptor.Columns[j].AllowFilter = true;
                gridGroupingControl1.TableDescriptor.Columns[j].ReadOnly = true;
            }
            //this.gridGroupingControl1.TopLevelGroupOptions.ShowFilterBar = true;
            //this.gridGroupingControl1.NestedTableGroupOptions.ShowFilterBar = true;
            //this.gridGroupingControl1.ChildGroupOptions.ShowFilterBar = true;

            // Enable Optimized Filter in GridGRoupingControl.
            this.gridGroupingControl1.OptimizeFilterPerformance = true;

            filter2.WireGrid(gridGroupingControl1);
        }

        void gridGroupingControl1_QueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.TableCellType == GridTableCellType.RecordPlusMinusCell)
            {
                Element cell = e.TableCellIdentity.DisplayElement;
                Record r = cell.ParentRecord as Record;
                bool makeStatic = true;
                if (r != null && r.NestedTables.Count > 0)
                {
                    foreach (NestedTable nt in r.NestedTables)
                    {
                        if (nt.ChildTable.GetFilteredRecordCount() != 0)
                            makeStatic = false;
                    }
                }
                if (makeStatic)
                {
                    e.Style.CellType = "Static";
                    e.Style.Borders.Bottom = new GridBorder(GridBorderStyle.Solid, Color.FromArgb(208, 215, 229));
                }
            }
        }

        private void ActualizarIndicadores(bool terminada)
        {
            if (terminada)
            {
                indicador = negocio.getIndicadores(reunion.ID);
                lblAsistencia.Text = indicador.Asistencia * 100 + "%";
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

        private void gridGroupingControl2_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridGroupingControl ggc = (GridGroupingControl)sender;
            Element el = ggc.Table.GetInnerMostCurrentElement();
            if (el != null)
            {
                GridTable table = el.ParentTable as GridTable;
                GridTableControl tableControl = ggc.GetTableControl(table.TableDescriptor.Name);
                GridCurrentCell cc = tableControl.CurrentCell;
                if (cc.ColIndex.Equals(3) && cc.RowIndex > 2)
                {
                    GridTableCellStyleInfo style = table.GetTableCellStyle(cc.RowIndex, 1);
                    GridRecord rec = el as GridRecord;
                    if (rec == null && el is GridRecordRow)
                    {
                        rec = el.ParentRecord as GridRecord;
                    }
                    if (rec != null)
                    {
                        negocio.removeInvitado(rec.GetValue(style.TableCellIdentity.Column.Name).ToString(), reunion.ID);
                        negocio.removeAsistente(rec.GetValue(style.TableCellIdentity.Column.Name).ToString(), reunion.ID);
                        invitados = negocio.getInvitadoReunion(reunion.ID);
                        asistentes = negocio.getAsistenteReunion(reunion.ID);
                        ia = new List<InvitadoAsitente>();
                        foreach (string inv in invitados)
                        {
                            ia.Add(new InvitadoAsitente(inv, asistioEmpleado(inv)));
                        }
                        gridGroupingControl2.DataSource = ia;
                        //MessageBox.Show(style.TableCellIdentity.Column.Name);
                        //MessageBox.Show(rec.GetValue(style.TableCellIdentity.Column.Name).ToString());
                        ActualizarIndicadores(true);
                    }
                }
            }
        }

        private void gridGroupingControl2_TableControlCheckBoxClick(object sender, GridTableControlCellClickEventArgs e)
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
                        if (negocio.setAsistente(rec.GetValue(styleUser.TableCellIdentity.Column.Name).ToString(), reunion.ID) > 0)
                        {
                            invitados = negocio.getInvitadoReunion(reunion.ID);
                            asistentes = negocio.getAsistenteReunion(reunion.ID);
                            ia = new List<InvitadoAsitente>();
                            foreach (string inv in invitados)
                            {
                                ia.Add(new InvitadoAsitente(inv, asistioEmpleado(inv)));
                            }
                        }
                    }
                    else
                    {
                        if (negocio.removeAsistente(rec.GetValue(styleUser.TableCellIdentity.Column.Name).ToString(), reunion.ID) > 0)
                        {
                            asistentes = negocio.getAsistenteReunion(reunion.ID);
                            ia = new List<InvitadoAsitente>();
                            foreach (string inv in invitados)
                            {
                                ia.Add(new InvitadoAsitente(inv, asistioEmpleado(inv)));
                            }
                        }
                    }
                    ActualizarIndicadores(true);
                }
            }
        }

        private bool asistioEmpleado(string p)
        {
            bool b = false;
            int i = 0;
            while (asistentes.Count > i && !b)
            {
                if (asistentes[i].Equals(p))
                {
                    b = true;
                }
                i++;
            }
            return b;
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

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectedText = ofd.FileName.Replace(" ", "!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            agenda.Contenido = richTextBox1.Rtf;
            negocio.updateAgenda(agenda);
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

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.SelectedText = ofd.FileName.Replace(" ", "!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            acta.Contenido = richTextBox2.Rtf;
            negocio.updateActa(acta);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoLetra1 = comboBox2.Text;
            cambiarRichTextBox1();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            if (Int32.TryParse(comboBox3.Text, out num))
                tamano2 = num;
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

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }

        private void buttonPausa_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void buttonFinalizar_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            Double ti =  Math.Round(horas + (min / 60),2);
            negocio.setReunionFila(reunion.ID, "DuracionReal", ti.ToString());
            AnadirPerosnasInforme api = new AnadirPerosnasInforme(invitados, indicador);
            api.ShowDialog();
            //avisar por email
            EnviarEmail();
            this.Close();
        }

        private void EnviarEmail()
        {
            try
            {
                var oApp = new Microsoft.Office.Interop.Outlook.Application();

                Microsoft.Office.Interop.Outlook.NameSpace ns = oApp.GetNamespace("MAPI");
                var f = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

                System.Threading.Thread.Sleep(1000);

                var mailItem = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.Subject = reunion.Titulo + " " + reunion.Fecha.ToShortDateString(); ;

                //mailItem.HTMLBody = mailContent;
                string body = "<h2>Tiempo reunion: " + reunion.DuracionReal + "horas</h2>";
                body += "<h2>En esta reunion se te han asignado: " + negocio.getNumTareasUsuarioReunion(reunion.ID, user) + " Tareas</h2>";
                body += "<h2>Acta:</h2><p>" + richTextBox2.Text.Replace("\n","<br/>") + "</p>";
                body += "<h2>Indicadores:</h2>";
                Indicadores ind = negocio.getIndicadores(reunion.ID);
                body += "<ul>";
                body += "<li>Asistencia: " + ind.Asistencia + "%</li>";
                body += "<li>Número de tareas: " + ind.NumTareas + "</li>";
                body += "<li>Tareas terminadas: " + ind.Terminadas + "%</li>";
                body += "<li>Tareas abandonas: " + ind.Abandonadas + "%</li>";
                body += "<li>Tareas en proceso: " + ind.EnProceso + "%</li>";
                body += "</ul>";
                
                mailItem.HTMLBody = body;

                //List<EmpleadoIndicadores> eis=new List<EmpleadoIndicadores>();
                //foreach(EmpleadoIndicadores ei in eis)
                //{
                //    mailItem.To = ei.IDEmpleado;
                //}
                mailItem.To = "david.rueda@garnica.one";
                mailItem.Send();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnadirTarea formIT = new AnadirTarea(reunion, null, null);
            formIT.ShowDialog();

            tareas = negocio.getTareasReunion(reunion.ID);
            //gridGroupingControl2.DataSource = tareas;
            MostrarGridGroupingControl();

            ActualizarIndicadores(true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Añadir Invitados");
            AnadirInvitados formIA = new AnadirInvitados(invitados, reunion);
            formIA.ShowDialog();

            invitados = negocio.getInvitadoReunion(reunion.ID);
            asistentes = negocio.getAsistenteReunion(reunion.ID);
            ia = new List<InvitadoAsitente>();
            foreach (string inv in invitados)
            {
                ia.Add(new InvitadoAsitente(inv, asistioEmpleado(inv)));
            }
            gridGroupingControl2.DataSource = ia;

            ActualizarIndicadores(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seg++;
            if (seg == 60)
            {
                min++;
                seg = 0;
                if (min == 60)
                {
                    horas++;
                    min = 0;
                }
            }
            labelCronometro.Text = horas.ToString().PadLeft(2, '0') + ":" + min.ToString().PadLeft(2, '0') + ":" + seg.ToString().PadLeft(2, '0');
        }
    }
}
