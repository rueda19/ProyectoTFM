using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    public class Indicadores
    {
        public int ID { get; set; }
        public double Asistencia { get; set; }
        public int NumTareas { get; set; }
        public double Terminadas { get; set; }
        public double Abandonadas { get; set; }
        public double EnProceso { get; set; }
        public int IDReunion { get; set; }

        public Indicadores(int id, double asistencia, int numTareas, double terminadas, double abandonadas, double enProceso, int idReunion)
        {
            ID = id;
            Asistencia = asistencia;
            NumTareas = numTareas;
            Terminadas = terminadas;
            Abandonadas = abandonadas;
            EnProceso = enProceso;
            IDReunion = idReunion;
        }
    }
}
