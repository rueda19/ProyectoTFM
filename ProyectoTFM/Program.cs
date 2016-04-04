using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Modelo;
namespace ProyectoTFM
{
    class Program
    {
        public static void Main(string[] args)
        {
            GestorBD gb = new GestorBD();
            //System.Diagnostics.Debug.Write(gb.getGrupos());
            //Tarea t = gb.getTareasUsuario(1)[0];
            Console.WriteLine(gb.getAsistenteEmpleado(1).IDEmpleado);
            Console.ReadKey();
        }
    }
}
