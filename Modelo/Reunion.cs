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
        public double DuracionEstimada { get; set; }
        public double DuracionReal { get; set; }
        public DateTime Fecha { get; set; }
        public string IDResponsable { get; set; }
        List<Empleado> Asistentes { get; set; }
        List<Empleado> Invitados { get; set; }

        public Reunion(int id, string titulo, string ubicacion, double duracionEstimada, double duracionReal, DateTime fecha, string idResponsable, List<Empleado> invitados, List<Empleado> asistentes)
        {
            ID = id;
            Titulo = titulo;
            Ubicacion = ubicacion;
            DuracionEstimada = duracionEstimada;
            DuracionReal = duracionReal;
            Fecha = fecha;
            IDResponsable = idResponsable;
            Asistentes = asistentes;
            Invitados = invitados;
        }
    }
}
