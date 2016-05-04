using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentacionEscritorio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
            //    Microsoft.Office.Interop.Outlook.Application app = null;
            //    Microsoft.Office.Interop.Outlook.AppointmentItem appt = null;

            //    app = new Microsoft.Office.Interop.Outlook.Application();

            //    appt = (Microsoft.Office.Interop.Outlook.AppointmentItem)app
            //        .CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
            //    appt.MeetingStatus = Microsoft.Office.Interop.Outlook.OlMeetingStatus.olMeeting;
            //    appt.Subject = "Meeting ";
            //    appt.Body = "Test Appointment body";
            //    appt.Location = "TBD";
            //    appt.Start = new DateTime(2016, 5, 22, 17, 0, 0);
            //    appt.Recipients.Add("drueda@garnicaplywood.com");
            //    appt.End = new DateTime(2016, 5, 22, 18, 0, 0);
            //    appt.ReminderSet = true;
            //    appt.ReminderMinutesBeforeStart = 15;
            //    appt.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
            //    appt.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;

            //    Microsoft.Office.Interop.Outlook.Recipient recipient = appt.Recipients.Add("drueda@garnicaplywood.com");
            //    recipient.Type = (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olRequired;

            //    Microsoft.Office.Interop.Outlook.Recipient recipient1 = appt.Recipients.Add("raul.boveda@garnica.one");
            //    recipient1.Type = (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType.olOptional;
            //    ((Microsoft.Office.Interop.Outlook._AppointmentItem)appt).Send();

            //    appt.Save();
            //    appt.Send();
            //    Microsoft.Office.Interop.Outlook.MailItem mailItem = appt.ForwardAsVcal();
            //    mailItem.Recipients.Add("drueda@garnicaplywood.com");
            //    mailItem.Send();
            //}
            //catch (Exception e)
            //{
            //    System.Diagnostics.Debug.Write(e.Message);
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new NuevaReunion());
            //Application.Run(new ProcesosPrincipalesAvanzado("P01"));
            Application.Run(new Form1());
        }
    }
}
