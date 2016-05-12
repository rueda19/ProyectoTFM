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
using Syncfusion.Windows.Forms.Chart;

namespace PresentacionEscritorio
{
    public partial class EstadisticasTareas : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private string idProceso;
        private DataTable dt, dt1;

        public EstadisticasTareas(string idProc)
        {
            InitializeComponent();
            idProceso = idProc;
            label1.Text = label1.Text + " " + idProceso;
            user = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1);
            this.Text = user;
            foreach (CaptionImage image in this.CaptionImages)
            {
                image.ImageMouseEnter += new CaptionImage.MouseEnter(image_ImageMouseEnter);
                image.ImageMouseLeave += new CaptionImage.MouseLeave(image_ImageMouseLeave);
                image.ImageMouseUp += new CaptionImage.MouseUp(image_ImageMouseUp);
            }

            dateTimeDesde.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);//DateTime.Parse(DateTime.Now.Year+"/1/1");
            dateTimeHasta.Value = new DateTime(DateTime.Now.Year + 1, 1, 1, 0, 0, 0);
            
            dt = negocio.getEstadisticasTareasAcabadas(idProceso, dateTimeDesde.Value, dateTimeHasta.Value);
            dt1 = negocio.getEstadisticasTareasResponsable(idProceso, dateTimeDesde.Value, dateTimeHasta.Value);

            this.gridGroupingControl1.DataSource = dt;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl1.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl1.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            gridGroupingControl1.TableDescriptor.Columns[0].Appearance.AnyCell.Format = "dd-MM-yyyy";


            this.gridGroupingControl2.DataSource = dt1;
            this.gridGroupingControl2.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.TopLevelGroupOptions.ShowCaption = false;
            this.gridGroupingControl2.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridGroupingControl2.GridVisualStyles = GridVisualStyles.Metro;
            this.gridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;


            this.chartControl2.Series.Clear();
            ChartSeries series1 = new ChartSeries("%tareasAcabas");
            series1.Text = series1.Name;
            series1.Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), "Line", true);
            series1.Style.Border.Width = float.Parse("0.7");
            series1.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series1.Style.Symbol.Color = Color.Black;
            series1.Style.Symbol.Border.Color = Color.Black;
            series1.Style.Symbol.Border.Width = 3;

            int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[2].ToString());
                series1.Points.Add(j, d);
            }
            this.chartControl2.Series.Add(series1);

            ChartSeries series2 = new ChartSeries("%progresion");
            series2.Text = series2.Name;
            series2.Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), "Line", true);
            series2.Style.Border.Width = float.Parse("0.7");
            series2.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series2.Style.Symbol.Color = Color.Black;
            series2.Style.Symbol.Border.Color = Color.Black;
            series2.Style.Symbol.Border.Width = 3;

            j = 0;
            foreach (DataRow row in dt.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[3].ToString());
                series2.Points.Add(j, d);
            }
            this.chartControl2.Series.Add(series2);
            this.chartControl2.PrimaryYAxis.Range = new MinMaxInfo(0, 100, 10);
            this.chartControl2.Text = "Estadisticas Fechas";

            this.chartControl1.Series.Clear();
            ChartSeries series1a = new ChartSeries("%tareasAcabasResponsable");
            series1a.Text = series1a.Name;
            series1a.Style.Border.Width = float.Parse("0.3");
            series1a.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series1a.Style.Symbol.Color = Color.Black;
            series1a.Style.Symbol.Border.Color = Color.Black;
            series1a.Style.Symbol.Border.Width = 3;

            j = 0;
            foreach (DataRow row in dt1.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[2].ToString());
                series1a.Points.Add(j, d);
            }
            this.chartControl1.Series.Add(series1a);

            ChartSeries series2a = new ChartSeries("%cargaResponsable");
            series2a.Text = series2a.Name;
            series2a.Style.Border.Width = float.Parse("0.3");
            series2a.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series2a.Style.Symbol.Color = Color.Black;
            series2a.Style.Symbol.Border.Color = Color.Black;
            series2a.Style.Symbol.Border.Width = 3;

            j = 0;
            foreach (DataRow row in dt1.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[3].ToString());
                series2a.Points.Add(j, d);
            }
            this.chartControl1.Series.Add(series2a);
            this.chartControl1.PrimaryYAxis.Range = new MinMaxInfo(0, 100, 10);
            this.chartControl1.Text = "Estadisticas Resposable";

            this.chartControl1.ChartFormatAxisLabel += new Syncfusion.Windows.Forms.Chart.ChartFormatAxisLabelEventHandler(this.chartControl1_ChartFormatAxisLabel1);
            this.chartControl2.ChartFormatAxisLabel += new Syncfusion.Windows.Forms.Chart.ChartFormatAxisLabelEventHandler(this.chartControl1_ChartFormatAxisLabel);

        }

        private void chartControl1_ChartFormatAxisLabel(object sender, ChartFormatAxisLabelEventArgs e)
        {
            if (e.AxisOrientation == ChartOrientation.Horizontal)
            {
                if (!e.Value.ToString().Contains(","))
                {
                    if (0 < Convert.ToInt32(e.Value) && dt.Rows.Count >= Convert.ToInt32(e.Value))
                        e.Label = ((DateTime)dt.Rows[Convert.ToInt32(e.Value) - 1].ItemArray[0]).ToString("dd/MM/yyyy");
                    else
                        e.Label = "";
                    e.Handled = true;
                }
                else
                {
                    e.Label = "";
                    e.Handled = true;
                }
            }
        }

        private void chartControl1_ChartFormatAxisLabel1(object sender, ChartFormatAxisLabelEventArgs e)
        {
            if (e.AxisOrientation == ChartOrientation.Horizontal)
            {
                if (!e.Value.ToString().Contains(","))
                {
                    if (0 < Convert.ToInt32(e.Value) && dt1.Rows.Count >= Convert.ToInt32(e.Value))
                        e.Label = dt1.Rows[Convert.ToInt32(e.Value) - 1].ItemArray[0].ToString();
                    else
                        e.Label = "";
                    e.Handled = true;
                }
                else
                {
                    e.Label = "";
                    e.Handled = true;
                }
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
                this.Hide();
                var form2 = new ProcesosPrincipales("GBL");
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            dt = negocio.getEstadisticasTareasAcabadas(idProceso, dateTimeDesde.Value, dateTimeHasta.Value);
            dt1 = negocio.getEstadisticasTareasResponsable(idProceso, dateTimeDesde.Value, dateTimeHasta.Value);

            this.gridGroupingControl1.DataSource = dt;
            this.gridGroupingControl1.Update();

            this.gridGroupingControl2.DataSource = dt1;
            this.gridGroupingControl2.Update();

            this.chartControl2.Series.Clear();
            ChartSeries series1 = new ChartSeries("%tareasAcabas");
            series1.Text = series1.Name;
            series1.Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), "Line", true);
            series1.Style.Border.Width = float.Parse("0.7");
            series1.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series1.Style.Symbol.Color = Color.Black;
            series1.Style.Symbol.Border.Color = Color.Black;
            series1.Style.Symbol.Border.Width = 3;

            int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[2].ToString());
                series1.Points.Add(j, d);
            }
            this.chartControl2.Series.Add(series1);

            ChartSeries series2 = new ChartSeries("%progresion");
            series2.Text = series2.Name;
            series2.Type = (ChartSeriesType)Enum.Parse(typeof(ChartSeriesType), "Line", true);
            series2.Style.Border.Width = float.Parse("0.7");
            series2.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series2.Style.Symbol.Color = Color.Black;
            series2.Style.Symbol.Border.Color = Color.Black;
            series2.Style.Symbol.Border.Width = 3;

            j = 0;
            foreach (DataRow row in dt.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[3].ToString());
                series2.Points.Add(j, d);
            }
            this.chartControl2.Series.Add(series2);
            this.chartControl2.PrimaryYAxis.Range = new MinMaxInfo(0, 100, 10);
            this.chartControl2.Text = "Estadisticas Fechas";

            this.chartControl1.Series.Clear();
            ChartSeries series1a = new ChartSeries("%tareasAcabasResponsable");
            series1a.Text = series1a.Name;
            series1a.Style.Border.Width = float.Parse("0.3");
            series1a.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series1a.Style.Symbol.Color = Color.Black;
            series1a.Style.Symbol.Border.Color = Color.Black;
            series1a.Style.Symbol.Border.Width = 3;

            j = 0;
            foreach (DataRow row in dt1.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[2].ToString());
                series1a.Points.Add(j, d);
            }
            this.chartControl1.Series.Add(series1a);

            ChartSeries series2a = new ChartSeries("%cargaResponsable");
            series2a.Text = series2a.Name;
            series2a.Style.Border.Width = float.Parse("0.3");
            series2a.Style.Symbol.Shape = ChartSymbolShape.Circle;
            series2a.Style.Symbol.Color = Color.Black;
            series2a.Style.Symbol.Border.Color = Color.Black;
            series2a.Style.Symbol.Border.Width = 3;

            j = 0;
            foreach (DataRow row in dt1.Rows)
            {
                j++;
                double d = Double.Parse(row.ItemArray[3].ToString());
                series2a.Points.Add(j, d);
            }
            this.chartControl1.Series.Add(series2a);
        }
    }
}
