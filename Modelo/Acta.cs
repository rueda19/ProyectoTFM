using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Acta
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public double Duracion { get; set; }
        public string Contenido { get; set; }
        public int IDReunion { get; set; }

        public Acta(int id, DateTime fecha, double duracion, string contenido, int idReunion)
        {
            ID = id;
            Fecha = fecha;
            Duracion = duracion;
            Contenido = contenido;
            IDReunion = idReunion;
        }
    }
}
