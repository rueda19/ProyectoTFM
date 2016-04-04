using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Empleado
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Departamento { get; set; }

        public Empleado(int id, string usuario, string nombreCompleto, string departamento)
        {
            ID = id;
            Usuario = usuario;
            NombreCompleto = nombreCompleto;
            Departamento = departamento;
        }
    }
}
