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

            //Probar inserccion
            //Console.WriteLine(gb.setTarea(new Tarea(0, DateTime.Now,DateTime.Now,DateTime.Now,3,"Manual","Ejecucion",1,1)));
            //Console.WriteLine(gb.setReunion(new Reunion(0,"aaa",3.3,DateTime.Now)));
            //Console.WriteLine(gb.setAgenda(new Agenda(0, TimeSpan.Parse("01:00:00"), "aa", 1)));
            //Console.WriteLine(gb.setActa(new Acta(0,DateTime.Now,5,"pp",1)));
            //Console.WriteLine(gb.setEmpleado(new Empleado(0,"","","")));
            //Console.WriteLine(gb.setInvitado(new Invitado(2,2)));
            //Console.WriteLine(gb.setAsistente(new Asistente(2,2)));

            //Probar eliminacion
            //Console.WriteLine(gb.removeTarea(10));
            //Console.WriteLine(gb.removeReunion(2));
            //Console.WriteLine(gb.removeAgenda(2));
            //Console.WriteLine(gb.removeActa(2));
            //Console.WriteLine(gb.removeEmpleado(2));
            //Console.WriteLine(gb.removeInvitadoReunion(2));
            //Console.WriteLine(gb.removeAsistenteActa(2));

            Console.ReadKey();
        }
    }
}
