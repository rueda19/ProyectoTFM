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
using Syncfusion.Windows.Forms.Diagram.Samples;
using Syncfusion.Windows.Forms.Diagram;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Reflection;

namespace PresentacionEscritorio
{
    public partial class ProcesosPrincipalesAvanzado : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private string idProceso = "";

        public ProcesosPrincipalesAvanzado(string idProc)
        {
            InitializeComponent();
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;
            idProceso = idProc;

            Byte[] dBinary = negocio.GetDiagrama(idProceso);
            MemoryStream dStream = new MemoryStream(dBinary, 0, dBinary.Length);
            dStream.Position = 0;
            diagram1.LoadBinary(dStream);
            dStream.Close();

            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            //diagram1.EventSink.NodeClick += new NodeMouseEventHandler(EventSink_NodeClick);

            Application.Idle += new EventHandler(Application_Idle);

            //diagram1.Model.BoundaryConstraintsEnabled = false;
            //diagram1.Controller.Guides.Enable = false;
            //this.diagram1.Model.BoundaryConstraintsEnabled = false;
            //diagram1.Controller.InPlaceEditing = false;
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
                this.Hide();
                var form2 = new MisReuniones();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage3")
            {
                //this.Hide();
                //var form2 = new MisTareas();
                //form2.Closed += (s, args) => this.Close();
                //form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage4")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if ((sender as CaptionImage).Name == "CaptionImage5")
            {
                this.Hide();
                var form2 = new ProcesosPrincipales("GBL");
                form2.Closed += (s, args) => this.Close();
                form2.Show();
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

        void Application_Idle(object sender, EventArgs e)
        {
            if (this.diagram1 != null && this.diagram1.Model != null)
            {
                this.guardarToolStripButton.Enabled = true;
                this.imprimirToolStripButton.Enabled = true;
                this.cortarToolStripButton.Enabled = diagram1.CanCut;
                this.copiarToolStripButton.Enabled = diagram1.CanCopy;
                if (this.WindowState != FormWindowState.Minimized)
                    this.pegarToolStripButton.Enabled = diagram1.CanPaste;
                this.deshacerToolStripButton.Enabled = diagram1.Model.HistoryManager.CanUndo;
                this.rehacerToolStripButton.Enabled = diagram1.Model.HistoryManager.CanRedo;
                //this.deleteToolStripButton.Enabled = (this.diagram1.View.SelectionList.Count > 0);

            }
            else
            {
                this.copiarToolStripButton.Enabled = false;
                this.imprimirToolStripButton.Enabled = false;
                this.cortarToolStripButton.Enabled = false;
                this.pegarToolStripButton.Enabled = false;
                if (this.WindowState != FormWindowState.Minimized)
                    this.pegarToolStripButton.Enabled = false;
                this.deshacerToolStripButton.Enabled = false;
                this.rehacerToolStripButton.Enabled = false;
                //this.deleteToolStripButton.Enabled = false;
            }
        }

        //void EventSink_NodeClick(NodeMouseEventArgs evtArgs)
        //{
        //    //MessageBox.Show(evtArgs.Node.Name);
        //}

        private void toolStripProcesoA1_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 0),
                    new Point(80, 0),
                    new Point(100, 50),
                    new Point(80, 100),
                    new Point(0, 100),
                    new Point(20, 50)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoA2_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 0),
                    new Point(0, 80),
                    new Point(50, 100),
                    new Point(100, 80),
                    new Point(100, 0),
                    new Point(50, 20)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoA3_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(20, 0),
                    new Point(0, 50),
                    new Point(20, 100),
                    new Point(100, 100),
                    new Point(80, 50),
                    new Point(100, 0)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoA4_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 20),
                    new Point(0, 100),
                    new Point(50, 80),
                    new Point(100, 100),
                    new Point(100, 20),
                    new Point(50, 0)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoB1_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 0),
                    new Point(80, 0),
                    new Point(100, 50),
                    new Point(80, 100),
                    new Point(0, 100)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoB2_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 0),
                    new Point(0, 80),
                    new Point(50, 100),
                    new Point(100, 80),
                    new Point(100, 0)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoB3_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(20, 0),
                    new Point(0, 50),
                    new Point(20, 100),
                    new Point(100, 100),
                    new Point(100, 0)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripProcesoB4_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 20),
                    new Point(0, 100),
                    new Point(100, 100),
                    new Point(100, 20),
                    new Point(50, 0)

                };
            this.diagram1.Model.AppendChild(new MiProceso(pts));
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.diagram1.Controller.ActivateTool("LineTool");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.diagram1.Controller.ActivateTool("TextTool");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.diagram1.Controller.ActivateTool("RectangleTool");
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            if (idProceso != "")
            {
                DialogResult dialogResult = MessageBox.Show("¿Estas seguro que quieres actualizar el diagrama?", "Actualizar Diagrama", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MemoryStream dStream = new MemoryStream();
                    diagram1.SaveBinary(dStream);
                    Byte[] dBinary = dStream.ToArray();
                    negocio.UpdateDiagrama(idProceso, dBinary);
                }
            }
            else
            {
                using (var form = new NuevoDiagrama())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string nuevoIdProceso = form.IDDiagrama;
                        if (negocio.GetIDDiagramas().Contains(nuevoIdProceso))
                        {
                            MessageBox.Show("Ya existe un diagrama con el ID=" + nuevoIdProceso);
                        }
                        else
                        {
                            negocio.setProceso(new Proceso(nuevoIdProceso, form.Nombre, form.Tipo, form.Responsable));
                            MemoryStream dStream = new MemoryStream();
                            diagram1.SaveBinary(dStream);
                            Byte[] dBinary = dStream.ToArray();
                            negocio.SetDiagrama(nuevoIdProceso, dBinary);
                            idProceso = nuevoIdProceso;
                        }
                    }
                }
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            using (var form = new AbrirDiagrama())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    idProceso = form.IDDiagrama;
                    Byte[] dBinary = negocio.GetDiagrama(idProceso);
                    MemoryStream dStream = new MemoryStream(dBinary, 0, dBinary.Length);
                    dStream.Position = 0;
                    diagram1.LoadBinary(dStream);
                    dStream.Close();
                }
            }


            //Negocio.Negocio n = new Negocio.Negocio();
            //Byte[] dBinary = n.GetDiagrama("P01");
            //MemoryStream dStream = new MemoryStream(dBinary, 0, dBinary.Length);
            ////dStream.Position = 0d
            //diagram1.LoadBinary(dStream);
            //dStream.Close();
            //foreach (Node p in this.diagram1.Model.Nodes)
            //{
            //    p.EditStyle.AllowSelect = false;
            //}
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro que quieres crear un nuevo diagrama?", "Nuevo Diagrama", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                idProceso = "";
                diagram1.Model.Clear();
            }
        }

        private void imprimirToolStripButton_Click(object sender, EventArgs e)
        {
            //ImageFormat imgformat = ImageFormat.Bmp;
            //Image img = this.diagram1.View.ExportDiagramAsImage(true);
            //img.Save("MyDiagram.bmp", imgformat);
            if (this.diagram1 != null)
            {
                PrintDocument printDoc = this.diagram1.CreatePrintDocument();
                MyPrintPreviewDialog printPreviewDlg = new MyPrintPreviewDialog();

                printDoc.DefaultPageSettings.Landscape = true;
                printDoc.PrinterSettings.FromPage = 0;
                printDoc.PrinterSettings.ToPage = 0;
                printDoc.PrinterSettings.PrintRange = PrintRange.AllPages;

                printPreviewDlg.Document = printDoc;
                printPreviewDlg.ShowDialog(this);
            }
        }

        private void cortarToolStripButton_Click(object sender, EventArgs e)
        {
            diagram1.Controller.Cut();
            cortarToolStripButton.Enabled = true;
        }

        private void copiarToolStripButton_Click(object sender, EventArgs e)
        {
            diagram1.Controller.Copy();
            copiarToolStripButton.Enabled = true;
        }

        private void pegarToolStripButton_Click(object sender, EventArgs e)
        {
            diagram1.Controller.Paste();
            pegarToolStripButton.Enabled = false;
        }

        private void deshacerToolStripButton_Click(object sender, EventArgs e)
        {
            this.diagram1.Model.HistoryManager.Undo();
        }

        private void rehacerToolStripButton_Click(object sender, EventArgs e)
        {
            this.diagram1.Model.HistoryManager.Redo();
        }

        private void exportToolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = @"Windows Bitmap(*.bmp)|*.bmp|Exchangeable Image Format(*.exif)|*.exif|Graphics Interchange Format(*.gif)|*.gif|Windows Icon Image(*.ico)|*.ico|Joint Photographic Experts Group(*.jpeg)|*.jpeg|W3C Portable Network Graphics(*.png)|*.png|Tag Image File Format(*.tiff)|*.tiff";//|Enhanced Metafile Format(*.emf)|*.emf";
            saveFileDialog1.Title = "Export Diagram As:";
            saveFileDialog1.FileName = "Diagram";

            ImageFormat imgformat = ImageFormat.Bmp;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        imgformat = ImageFormat.Bmp;
                        break;
                    case 2:
                        imgformat = ImageFormat.Exif;
                        break;
                    case 3:
                        imgformat = ImageFormat.Gif;
                        break;
                    case 4:
                        imgformat = ImageFormat.Icon;
                        break;
                    case 5:
                        imgformat = ImageFormat.Jpeg;
                        break;
                    case 6:
                        imgformat = ImageFormat.Png;
                        break;
                    case 7:
                        imgformat = ImageFormat.Tiff;
                        break;
                }

                Image img = this.diagram1.View.ExportDiagramAsImage(true);
                img.Save(saveFileDialog1.FileName, imgformat);
            }
        }
    }


    public class MyPrintPreviewDialog :
System.Windows.Forms.PrintPreviewDialog
    {
        private ToolStripButton myPrintButton;
        public MyPrintPreviewDialog()
            : base()
        {
            Type t = typeof(PrintPreviewDialog);
            FieldInfo fi = t.GetField("toolStrip1",
            BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo fi2 = t.GetField("printToolStripButton",
            BindingFlags.Instance | BindingFlags.NonPublic);
            ToolStrip toolStrip1 =
            (ToolStrip)fi.GetValue(this);
            ToolStripButton printButton =
            (ToolStripButton)fi2.GetValue(this);
            printButton.Visible = false;
            myPrintButton = new ToolStripButton();
            myPrintButton.ToolTipText = printButton.ToolTipText;
            myPrintButton.ImageIndex = 0;

            ToolStripItem[] oldButtons =
            new ToolStripItem[toolStrip1.Items.Count];
            for (int i = 0; i < oldButtons.Length; i++)
                oldButtons[i] = toolStrip1.Items[i];

            toolStrip1.Items.Clear();
            toolStrip1.Items.Add(myPrintButton);
            for (int i = 0; i < oldButtons.Length; i++)
                toolStrip1.Items.Add(oldButtons[i]);
            toolStrip1.ItemClicked +=
            new ToolStripItemClickedEventHandler(toolBar1_Click);
        }

        private void toolBar1_Click(object sender,
        ToolStripItemClickedEventArgs eventargs)
        {
            if (eventargs.ClickedItem == myPrintButton)
            {
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = this.Document;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                    this.Document.Print();
            }
        }
    }

}
