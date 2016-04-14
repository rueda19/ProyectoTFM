﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Tarea
    {
        public int ID { get; set; }
        public string Descripcion { get; set; } 
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaEjecutado { get; set; }
        public double TiempoDedicado { get; set; }
        public string Estado { get; set; }
        public string Origen { get; set; }
        public string IDResponsable { get; set; }
        public int? IDReunion { get; set; }

        public Tarea(int id, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime? fechaEjecutado, double tiempoDedicado, string origen, string estado, string idResponsable, int? idReunion)
        {
            ID = id;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            FechaEjecutado = fechaEjecutado;
            TiempoDedicado = tiempoDedicado;
            Origen = origen;
            Estado = estado;
            IDResponsable = idResponsable;
            IDReunion = idReunion;
        }
    }
}
