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

        public Proceso getProceso(string id)
        {
            return gbd.getProceso(id);
        }

        public int setProceso(Proceso proceso)
        {
            return gbd.setProceso(proceso);
        }

        public int setProcesoFila(string ID, string fila, string valor)
        {
            return gbd.setProcesoFila(ID, fila, valor);
        }

        public int removeProceso(string id)
        {
            return gbd.removeProceso(id);
        }

        public List<string> GetIDDiagramas()
        {
            return gbd.GetIDDiagramas();
        }

        public Byte[] GetDiagrama(string idProceso)
        {
            return gbd.GetDiagrama(idProceso);
        }

        public int UpdateDiagrama(string idProceso, Byte[] dBinary)
        {
            return gbd.UpdateDiagrama(idProceso, dBinary);
        }

        public int SetDiagrama(string idProceso, Byte[] dBinary)
        {
            return gbd.SetDiagrama(idProceso, dBinary);
        }

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

        public int updateTarea(Tarea tarea)
        {
            return gbd.updateTarea(tarea);
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

        public int setReunionFila(int ID, string fila, string valor)
        {
            return gbd.setReunionFila(ID, fila, valor);
        }

        public int setNuevaReunion(Reunion reunion, Agenda agenda, List<string> invitados)
        {
            return gbd.setNuevaReunion(reunion, agenda, invitados);
        }

        public int setReunion(Reunion reunion)
        {
            return gbd.setReunion(reunion);
        }

        public int removeReunion(int ID)
        {
            return gbd.removeTarea(ID);
        }

        public Agenda getAgendaReunion(int IDReunion)
        {
            return gbd.getAgendaReunion(IDReunion);
        }

        public int updateAgenda(Agenda agenda)
        {
            return gbd.updateAgenda(agenda);
        }

        public int setAgenda(Agenda agenda)
        {
            return gbd.setAgenda(agenda);
        }

        public int removeAgenda(int ID)
        {
            return gbd.removeAgenda(ID);
        }

        public Acta getActaReunion(int IDReunion)
        {
            return gbd.getActaReunion(IDReunion);
        }

        public int updateActa(Acta acta)
        {
            return gbd.updateActa(acta);
        }

        public int setActa(Acta acta)
        {
            return gbd.setActa(acta);
        }

        public int removeActa(int ID)
        {
            return gbd.removeActa(ID);
        }

        public List<Empleado> getEmpleados()
        {
            return gbd.getEmpleados();
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

        public int removeInvitado(Invitado invitado)
        {
            return gbd.removeInvitado(invitado);
        }

        public int removeInvitadoEmpleado(string IDEmpleado)
        {
            return gbd.removeInvitadoEmpleado(IDEmpleado);
        }

        public int removeInvitadoReunion(int IDReunion)
        {
            return gbd.removeInvitadoReunion(IDReunion);
        }

        public List<Asistente> getAsistenteReunion(int IDReunion)
        {
            return gbd.getAsistenteReunion(IDReunion);
        }

        public List<Asistente> getAsistenteEmpleado(string IDEmpleado)
        {
            return gbd.getAsistenteEmpleado(IDEmpleado);
        }

        public int setAsistente(Asistente asistente)
        {
            return gbd.setAsistente(asistente);
        }

        public int removeAsistenteReunion(int IDReunion)
        {
            return gbd.removeAsistenteReunion(IDReunion);
        }

        public int removeAsistente(Asistente asistente)
        {
            return gbd.removeAsistente(asistente);
        }

        public int removeAsistenteEmpleado(string IDEmpleado)
        {
            return gbd.removeAsistenteEmpleado(IDEmpleado);
        }

        public int setTareaFila(int ID, string fila, string valor)
        {
            return gbd.setTareaFila(ID, fila, valor);
        }

        public Indicadores getIndicadores(int IDReunion)
        {
            return gbd.getIndicadores(IDReunion);
        }
    }
}
