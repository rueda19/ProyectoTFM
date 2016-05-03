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

namespace PresentacionEscritorio
{
    public partial class ProcesosPrincipalesAvanzado : MetroForm
    {
        public ProcesosPrincipalesAvanzado()
        {
            InitializeComponent();

            diagram1.EventSink.NodeClick += new NodeMouseEventHandler(EventSink_NodeClick);
            diagram1.Model.BoundaryConstraintsEnabled = false;
            diagram1.Controller.Guides.Enable = false;
            this.diagram1.Model.BoundaryConstraintsEnabled = false;
            diagram1.Controller.InPlaceEditing = false;
            //this.diagram1.Model.Nodes[0].EnableCentralPort = false;

            //this.diagram1.Model.Nodes[1].EnableCentralPort = true;
        }

        void EventSink_NodeClick(NodeMouseEventArgs evtArgs)
        {
            MessageBox.Show(evtArgs.Node.Name);
        }

        //void EventSink_NodeDoubleClick(NodeMouseEventArgs evtArgs)
        //{
        //    evtArgs.Node;
        //    if (evtArgs.Connection.TargetPort.GetType() == typeof(AnchoredPort))
        //    {
        //        this.textBox2.Text = (evtArgs.Connection.TargetPort.Parent.Name);
        //        symbol2 = evtArgs.Connection.TargetPort.Parent as Symbol;
        //    }
        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.diagram1.Controller.ActivateTool("RectangleTool");
            //Load the stream.
            Negocio.Negocio n = new Negocio.Negocio();
            Byte[] dBinary = n.GetDiagrama("P01");
            MemoryStream dStream = new MemoryStream(dBinary, 0, dBinary.Length);
            dStream.Position = 0;
            diagram1.LoadBinary(dStream);
            dStream.Close();
            foreach (Node p in this.diagram1.Model.Nodes)
            {
                p.EditStyle.AllowSelect = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //ImageFormat imgformat = ImageFormat.Bmp;
            //Image img = this.diagram1.View.ExportDiagramAsImage(true);
            //img.Save("MyDiagram.bmp", imgformat);

            MemoryStream dStream = new MemoryStream();
            diagram1.SaveBinary(dStream);
            Byte[] dBinary = dStream.ToArray();
            Negocio.Negocio n = new Negocio.Negocio();
            n.SetDiagrama("P01", dBinary);
        }

        private void toolStripProcesoA1_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 0),
                    new Point(0, 90),
                    new Point(50, 100),
                    new Point(100, 90),
                    new Point(100, 0),
                    new Point(50, 10)

                };
            this.diagram1.Model.AppendChild(new Proceso(pts));
        }

        private void toolStripProcesoA2_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 0),
                    new Point(90, 0),
                    new Point(100, 50),
                    new Point(90, 100),
                    new Point(0, 100),
                    new Point(10, 50)

                };
            this.diagram1.Model.AppendChild(new Proceso(pts));
        }

        private void toolStripProcesoA3_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(0, 10),
                    new Point(50, 0),
                    new Point(100, 10),
                    new Point(100, 100),
                    new Point(90, 50),
                    new Point(0, 100)

                };
            this.diagram1.Model.AppendChild(new Proceso(pts));
        }

        private void toolStripProcesoA4_Click(object sender, EventArgs e)
        {
            PointF[] pts =
                {
                    new Point(10, 0),
                    new Point(100, 100),
                    new Point(50, 90),
                    new Point(100, 100),
                    new Point(10, 100),
                    new Point(0, 50)

                };
            this.diagram1.Model.AppendChild(new Proceso(pts));
        }
    }
}
