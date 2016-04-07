using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Asistente
    {
        public int IDActa { get; set; }
        public string IDEmpleado { get; set; }

        public Asistente(int idActa, string idEmpleado)
        {
            IDActa = idActa;
            IDEmpleado = idEmpleado;
        }
    }
}
