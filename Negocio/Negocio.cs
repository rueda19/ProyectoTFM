using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class Negocio
    {
        private GestorBD gbd;

        public Negocio()
        {
            gbd = new GestorBD();
        }

        public List<Reunion> getReunionUsuario(string user)
        {
            return gbd.getReunionUsuario(user);
        }

        public List<Reunion> getReunionUsuarioPasadas(string user)
        {
            return gbd.getReunionUsuarioPasadas(user);
        }
        
        public List<Tarea> getTareasReunion(int idReunion)
        {
            return gbd.getTareasReunion(idReunion);
        }

        public List<Tarea> getTareasUsuarioTerminadas(string Usuario)
        {
            return gbd.getTareasUsuarioTerminadas(Usuario);
        }

        public List<Tarea> getTareasUsuario(string Usuario)
        {
            return gbd.getTareasUsuario(Usuario);
        }

        public Tarea getTarea(int ID)
        {
            return gbd.getTarea(ID);
        }

        public int setTarea(Tarea tarea)
        {
            return gbd.setTarea(tarea);
        }

        public int removeTarea(int ID)
        {
            return gbd.removeTarea(ID);
        }

        public Reunion getReunion(int ID)
        {
            return gbd.getReunion(ID);
        }

        public int setReunion(Reunion reunion)
        {
            return gbd.setReunion(reunion);
        }

        public int removeReunion(int ID)
        {
            return gbd.removeTarea(ID);
        }

        public Agenda getAgenda(int ID)
        {
            return gbd.getAgenda(ID);
        }

        public int setAgenda(Agenda agenda)
        {
            return gbd.setAgenda(agenda);
        }

        public int removeAgenda(int ID)
        {
            return gbd.removeAgenda(ID);
        }

        public Acta getActa(int ID)
        {
            return gbd.getActa(ID);
        }

        public int setActa(Acta acta)
        {
            return gbd.setActa(acta);
        }

        public int removeActa(int ID)
        {
            return gbd.removeActa(ID);
        }

        public Empleado getEmpleado(string user)
        {
            return gbd.getEmpleado(user);
        }

        public int setEmpleado(Empleado empleado)
        {
            return gbd.setEmpleado(empleado);
        }

        public int removeEmpleado(string user)
        {
            return gbd.removeEmpleado(user);
        }

        public List<Invitado> getInvitadoReunion(int IDReunion)
        {
            return gbd.getInvitadoReunion(IDReunion);
        }

        public List<Invitado> getInvitadoEmpleado(string IDEmpleado)
        {
            return gbd.getInvitadoEmpleado(IDEmpleado);
        }

        public int setInvitado(Invitado invitado)
        {
            return gbd.setInvitado(invitado);
        }

        public int removeInvitadoEmpleado(string IDEmpleado)
        {
            return gbd.removeInvitadoEmpleado(IDEmpleado);
        }

        public int removeInvitadoReunion(int IDReunion)
        {
            return gbd.removeInvitadoReunion(IDReunion);
        }

        public List<Asistente> getAsistenteActa(int IDActa)
        {
            return gbd.getAsistenteActa(IDActa);
        }

        public List<Asistente> getAsistenteEmpleado(string IDEmpleado)
        {
            return gbd.getAsistenteEmpleado(IDEmpleado);
        }

        public int setAsistente(Asistente asistente)
        {
            return gbd.setAsistente(asistente);
        }

        public int removeAsistenteActa(int IDActa)
        {
            return gbd.removeAsistenteActa(IDActa);
        }

        public int removeAsistenteEmpleado(string IDEmpleado)
        {
            return gbd.removeAsistenteEmpleado(IDEmpleado);
        }

        public int setTareaFila(int ID, string fila, string valor)
        {
            return gbd.setTareaFila(ID, fila, valor);
        }
    }
}
