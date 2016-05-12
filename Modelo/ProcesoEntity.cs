using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class ProcesoEntity
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string IDResponsable { get; set; }
        public List<PuntoRojo> PuntosRojos { get; set; }

        public ProcesoEntity(string id, string nombre, string tipo, string idResponsable, List<PuntoRojo> puntosRojos)
        {
            ID = id;
            Nombre = nombre;
            Tipo = tipo;
            IDResponsable = idResponsable;
            PuntosRojos = puntosRojos;
        }
    }
}
