using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Tarea
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; } 
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaEjecutado { get; set; }
        public double TiempoDedicado { get; set; }
        public string Estado { get; set; }
        public string IDResponsable { get; set; }
        public int? IDReunion { get; set; }
        public string IDProceso { get; set; }
        public int? IDTareaPadre { get; set; }

        public Tarea(int id, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime? fechaEjecutado, double tiempoDedicado, string tipo, string estado, string idResponsable, int? idReunion, string idProceso, int? idTareaPadre)
        {
            ID = id;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            FechaEjecutado = fechaEjecutado;
            TiempoDedicado = tiempoDedicado;
            Tipo = tipo;
            Estado = estado;
            IDResponsable = idResponsable;
            IDReunion = idReunion;
            IDProceso = idProceso;
            IDTareaPadre = idTareaPadre;
        }
    }
}
