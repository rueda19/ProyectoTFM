using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Asistente
    {
        public int IDActa { get; set; }
        public int IDEmpleado { get; set; }

        public Asistente(int idActa, int idEmpleado)
        {
            IDActa = idActa;
            IDEmpleado = idEmpleado;
        }
    }
}
