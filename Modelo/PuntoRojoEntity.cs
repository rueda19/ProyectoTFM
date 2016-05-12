using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class PuntoRojoEntity
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public bool Solucionado { get; set; }
        public string IDResponsable { get; set; }
        public ProcesoEntity Proceso { get; set; }

        public PuntoRojoEntity(int id, string descripcion, string prioridad, bool solucionado, string idResponsable, ProcesoEntity proceso)
        {
            this.ID = id;
            this.Descripcion = descripcion;
            this.Prioridad = prioridad;
            this.Solucionado = solucionado;
            this.IDResponsable = idResponsable;
            this.Proceso = proceso;
        }
    }
}
