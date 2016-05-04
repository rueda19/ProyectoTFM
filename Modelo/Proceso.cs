using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Proceso
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string IDResponsable { get; set; }

        public Proceso(string id, string nombre, string tipo, string idResponsable)
        {
            ID = id;
            Nombre = nombre;
            Tipo = tipo;
            IDResponsable = idResponsable;
        }
    }
}
