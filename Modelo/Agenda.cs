using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Agenda
    {
        public int ID { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public string Contenido { get; set; }
        public int IDReunion { get; set; }

        public Agenda(int id, TimeSpan horaInicio, string contenido, int idReunion)
        {
            ID = id;
            HoraInicio = horaInicio;
            Contenido = contenido;
            IDReunion = idReunion;
        }
    }
}
