using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Reunion
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Ubicacion { get; set; }
        public double Duracion { get; set; }
        public DateTime Fecha { get; set; }
        public string IDResponsable { get; set; }

        public Reunion(int id, string titulo, string ubicacion, double duracion, DateTime fecha, string idResponsable)
        {
            ID = id;
            Titulo = titulo;
            Ubicacion = ubicacion;
            Duracion = duracion;
            Fecha = fecha;
            IDResponsable = idResponsable;
        }
    }
}
