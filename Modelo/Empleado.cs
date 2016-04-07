using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Empleado
    {
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Departamento { get; set; }

        public Empleado(string usuario, string nombreCompleto, string departamento)
        {
            Usuario = usuario;
            NombreCompleto = nombreCompleto;
            Departamento = departamento;
        }
    }
}
