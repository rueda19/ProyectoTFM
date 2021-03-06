﻿using System;
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
using Syncfusion.Windows.Forms.Diagram;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;

namespace PresentacionEscritorio
{
    public partial class ProcesosPrincipales : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private Proceso proceso;

        public ProcesosPrincipales(string idProceso)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icono;
            this.MetroColor = Color.FromArgb(179, 207, 96);

            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;
            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            
            proceso = negocio.getProceso(idProceso);
            if (proceso.ID == "GBL")
            {
                textBoxNombre.Text = proceso.Nombre;
                textBoxTipo.Enabled = false;
                textBoxResponsable.Enabled = false;
                labelTitulo.Text = proceso.Nombre;
            }
            else
            {
                textBoxID.Text = proceso.ID;
                textBoxNombre.Text = proceso.Nombre;
                textBoxTipo.Text = proceso.Tipo;
                textBoxResponsable.Text = proceso.IDResponsable;
                labelTitulo.Text = proceso.ID + " " + proceso.Nombre;
            }

            if (idProceso=="GBL")
                diagram1.EventSink.NodeClick += new NodeMouseEventHandler(EventSink_NodeClick);

            Byte[] dBinary = negocio.GetDiagrama(idProceso);
            MemoryStream dStream = new MemoryStream(dBinary, 0, dBinary.Length);
            dStream.Position = 0;
            diagram1.LoadBinary(dStream);
            dStream.Close();
            diagram1.View.Grid.Visible = false;
            foreach (Node p in this.diagram1.Model.Nodes)
            {
                p.EditStyle.AllowSelect = false;
            }
        }

        void EventSink_NodeClick(NodeMouseEventArgs evtArgs)
        {
            //MessageBox.Show(evtArgs.Node.Name);
            if (existeProceso(evtArgs.Node.Name))
            {
                this.Hide();
                var form2 = new ProcesosPrincipales(evtArgs.Node.Name);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        private bool existeProceso(string id)
        {
            if (id == null)
                return false;
            foreach (Proceso p in negocio.getProcesos())
            {
                if (p.ID == id)
                    return true;
            }
            return false;

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
                this.Hide();
                //var form2 = new MisTareas();
                var form2 = new TodasTareas();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if ((sender as CaptionImage).Name == "CaptionImage4")
            {
                this.Hide();
                var form2 = new ListaEmpleados();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
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

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new ProcesosPrincipalesAvanzado(proceso.ID);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void buttonIndicadores_Click(object sender, EventArgs e)
        {
            Process.Start("http://kpis.garnica.one/");


            //string browser = string.Empty;
            //RegistryKey key = null;
            //try
            //{
            //    key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
 
            //    //trim off quotes
            //    //browser = key.GetValue(null).ToString().ToLower().Replace("\\", "");
            //    browser = key.GetValue(null).ToString();
            //    if (!browser.EndsWith("exe"))
            //    {
            //        //get rid of everything after the ".exe"
            //        browser = browser.Substring(0, browser.LastIndexOf(".exe")+4);
            //    }
            //}
            //finally
            //{
            //    if (key != null) key.Close();
            //}
            ////open default system browser
            //System.Diagnostics.Process.Start(browser.Substring(1), "http://kpis.garnica.one/arcplan/8/scripts/arcCGI8.exe");
 

//***************************************************
 
            // Convert string data into byte array 
            //string strData = "<?xml version='1.0' encoding='UTF-8' standalone='no' ?><soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'><soap:Header><ServerName>SVRDCPORTAL.GarnicaPlywood.com:28251</ServerName><NetworkDuration>44</NetworkDuration></soap:Header><soap:Body><OpenStartDoc xmlns='http://schemas.arcplan.com/arcplan/clientCommunication'><OpenStartDocParam><SessionID>755</SessionID><SessionToken>SVRDCPORTAL.GarnicaPlywood.com:28251&amp;755&amp;m0KFCYKNBJWj2jXS3wfO6hVLAM</SessionToken><UserInformation><LoginUser><AuthMode>243</AuthMode><UserName>garnica\\drueda</UserName><Password>JxwlKxo0</Password><StoreCredentials>false</StoreCredentials></LoginUser></UserInformation></OpenStartDocParam></OpenStartDoc></soap:Body></soap:Envelope>";
            //byte[] dataByte = Encoding.UTF8.GetBytes(strData);

            //HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create("http://kpis.garnica.one/arcplan/8/scripts/arcCGI8.exe");
            //POSTRequest.Method = "POST";
            //// Set the content type - Mine was xml.
            //POSTRequest.ContentType = "text/xml";
            //POSTRequest.KeepAlive = false;
            //POSTRequest.Timeout = 5000;
            //POSTRequest.ContentLength = dataByte.Length;
            //// Get the request stream
            //Stream POSTstream = POSTRequest.GetRequestStream();
            //// Write the data bytes in the request stream
            //POSTstream.Write(dataByte, 0, dataByte.Length);
 
            ////Get response from server
            //HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();
            //Stream receiveStream = POSTResponse.GetResponseStream();

            //WebBrowser webBrowser = new WebBrowser();
            //webBrowser.DocumentStream = receiveStream;  
        }

        private void buttonPr_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new TareasProceso(proceso.ID);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
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

        private void buttonExportar_Click(object sender, EventArgs e)
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

        private void textBoxNombre_Leave(object sender, EventArgs e)
        {
            if (proceso.Nombre != textBoxNombre.Text)
            {
                proceso.Nombre = textBoxNombre.Text;
                negocio.setProcesoFila(proceso.ID, "Nombre", proceso.Nombre);
            }
        }

        private void textBoxTipo_Leave(object sender, EventArgs e)
        {
            if (proceso.Tipo != textBoxTipo.Text)
            {
                proceso.Tipo = textBoxTipo.Text;
                negocio.setProcesoFila(proceso.ID, "Tipo", proceso.Tipo);
            }
        }

        private void textBoxResponsable_Leave(object sender, EventArgs e)
        {
            if (proceso.IDResponsable != textBoxResponsable.Text)
            {
                proceso.IDResponsable = textBoxResponsable.Text;
                negocio.setProcesoFila(proceso.ID, "IDResponsable", proceso.IDResponsable);
            }
        }
    }
}
