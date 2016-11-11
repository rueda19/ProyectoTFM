using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class TareaCompleta
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
        public string Mes1 { get; set; }
        public string Mes2 { get; set; }
        public string Mes3 { get; set; }
        public string Mes4 { get; set; }
        public string Mes5 { get; set; }
        public string Mes6 { get; set; }
        public string Mes7 { get; set; }
        public string Mes8 { get; set; }
        public string Mes9 { get; set; }
        public string Mes10 { get; set; }
        public string Mes11 { get; set; }
        public string Mes12 { get; set; }

        public TareaCompleta(int id, string descripcion, DateTime fechaInicio, DateTime fechaFin, DateTime? fechaEjecutado, double tiempoDedicado, string tipo, string estado, string idResponsable, int? idReunion, string idProceso, int? idTareaPadre, string mes1, string mes2, string mes3, string mes4, string mes5, string mes6, string mes7, string mes8, string mes9, string mes10, string mes11, string mes12)
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
            Mes1 = mes1;
            Mes2 = mes2;
            Mes3 = mes3;
            Mes4 = mes4;
            Mes5 = mes5;
            Mes6 = mes6;
            Mes7 = mes7;
            Mes8 = mes8;
            Mes9 = mes9;
            Mes10 = mes10;
            Mes11 = mes11;
            Mes12 = mes12;
        }
    }
}
