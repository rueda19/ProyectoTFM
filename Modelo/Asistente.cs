using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Asistente
    {
        public int IDReunion { get; set; }
        public string IDEmpleado { get; set; }

        public Asistente(int idReunion, string idEmpleado)
        {
            IDReunion = idReunion;
            IDEmpleado = idEmpleado;
        }
    }
}
