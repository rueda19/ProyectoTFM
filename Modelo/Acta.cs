using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Acta
    {
        public string Contenido { get; set; }
        public int IDReunion { get; set; }

        public Acta(string contenido, int idReunion)
        {
            Contenido = contenido;
            IDReunion = idReunion;
        }
    }
}
