using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class EmpleadoIndicadores
    {
        public int IDIndicadores { get; set; }
        public string IDEmpleado { get; set; }

        public EmpleadoIndicadores(int idIndicadores, string idEmpleado)
        {
            IDIndicadores = idIndicadores;
            IDEmpleado = idEmpleado;
        }
    }
}
