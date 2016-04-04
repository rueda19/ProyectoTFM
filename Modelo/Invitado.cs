using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Invitado
    {
        public int IDReunion { get; set; }
        public int IDEmpleado { get; set; }

        public Invitado(int idReunion, int idEmpleado)
        {
            IDReunion = idReunion;
            IDEmpleado = idEmpleado;
        }
    }
}
