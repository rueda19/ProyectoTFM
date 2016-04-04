using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Reunion
    {
        public int ID { get; set; }
        public string Ubicacion { get; set; }
        public double Duracion { get; set; }
        public DateTime Fecha { get; set; }

        public Reunion(int id, string ubicacion, double duracion, DateTime fecha)
        {
            ID = id;
            Ubicacion = ubicacion;
            Duracion = duracion;
            Fecha = fecha;
        }
    }
}
