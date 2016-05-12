using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class PuntoRojo
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public bool Solucionado { get; set; }
        public string IDResponsable { get; set; }
        public string IDProceso { get; set; }

        public PuntoRojo(int id, string descripcion, string prioridad, bool solucionado, string idResponsable, string idProceso)
        {
            this.ID = id;
            this.Descripcion = descripcion;
            this.Prioridad = prioridad;
            this.Solucionado = solucionado;
            this.IDResponsable = idResponsable;
            this.IDProceso = idProceso;
        }
    }
}
