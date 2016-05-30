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
using Syncfusion.Windows.Forms.Schedule;
using Syncfusion.Schedule;

namespace PresentacionEscritorio
{
    public partial class TareasEnFecha : MetroForm
    {
        private string user;
        private Negocio.Negocio negocio = new Negocio.Negocio();
        private List<Tarea> tareas;
        
        public TareasEnFecha()
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

            this.scheduleControl1.Calendar.DateValue = DateTime.Now;
            this.scheduleControl1.ScheduleType = ScheduleViewType.Month;
            this.scheduleControl1.Appearance.VisualStyle = GridVisualStyles.Office2007Blue;

            tareas = negocio.getTareasUsuario(user.ToUpper());
            ArrayListDataProvider dataprovider = new Syncfusion.Schedule.ArrayListDataProvider();
            foreach (Tarea t in tareas)
            {
                IScheduleAppointment appointment = dataprovider.NewScheduleAppointment();
                appointment = dataprovider.NewScheduleAppointment();
                // appointment Date & Start time ( 12.00 Pm)
                appointment.StartTime = new System.DateTime(t.FechaFin.Year, t.FechaFin.Month, t.FechaFin.Day, 12, 0, 0);
                // End time ( 12.30 Pm)
                appointment.EndTime = DateTime.Now.AddMinutes(30);
                appointment.AllDay = true;
                string desc = t.Descripcion.Replace(System.Environment.NewLine, " ");
                if(desc.Length>79)
                    desc = t.Descripcion.Substring(0, 80);
                appointment.Subject = t.Tipo + ", " + desc;
                appointment.ReminderText = t.ID.ToString();
                    if(t.FechaFin > DateTime.Now)
                        appointment.LabelValue = 0;
                    else
                        appointment.LabelValue = 1;
                dataprovider.AddItem(appointment);
            }

            // Save to datasource
            this.scheduleControl1.DataSource = dataprovider;
            this.scheduleControl1.NavigationPanelFillWithCalendar = true;
            scheduleControl1.ShowingAppointmentForm += new ShowingAppointmentFormHandler(scheduleControl1_ShowingAppointmentForm);
            this.scheduleControl1.DataSource.SaveOnCloseBehaviorAction = SaveOnCloseBehavior.SaveWithoutPrompt; 
        }

        void scheduleControl1_ShowingAppointmentForm(object sender, ShowingAppointFormEventArgs e)
        {
            e.Cancel=true;
            //MessageBox.Show(e.Item.Subject + " " + e.Item.ReminderText);
            int id;
            if (Int32.TryParse(e.Item.ReminderText, out id))
            {
                DetallesTarea formIT = new DetallesTarea(negocio.getTarea(id));
                formIT.ShowDialog();
            }
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
    }
}
