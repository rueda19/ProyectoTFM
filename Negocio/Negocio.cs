﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Persistencia;
using System.Data;

namespace Negocio
{
    public class Negocio
    {
        private GestorBD gbd;

        public int getNumTareasUsuarioReunion(int idReunion, string user)
        {
            return gbd.getNumTareasUsuarioReunion(idReunion, user);
        }

        public Byte[] getEmpleadoFoto(string user)
        {
            return gbd.getEmpleadoFoto(user);
        }

        public DataTable getEmpleadosFoto()
        {
            return gbd.getEmpleadosFoto();
        }

        public int updateEmpleado(string empleado, string fila, string valor, byte[] foto)
        {
            return gbd.updateEmpleado(empleado, fila, valor, foto);
        }

        public List<List<Tarea>> getTareaRama(int idTarea)
        {
            return gbd.getTareaRama(idTarea);
        }

        public List<string> getUsuariosDepartamentos()
        {
            return gbd.getUsuariosDepartamentos();
        }

        public List<string> getTiposTareas()
        {
            return gbd.getTiposTareas();
        }

        public List<List<TareaCompleta>> getTareasTipoUsuarioNuevo(string tipo, string usuario, DateTime fechaInicio, DateTime fechaFin, string filtrarPor, string proceso)
        {
            return gbd.getTareasTipoUsuarioNuevo(tipo, usuario, fechaInicio, fechaFin, filtrarPor, proceso);
        }

        public List<List<Tarea>> getTareasTipoUsuario(string tipo, string usuario, DateTime fechaInicio, DateTime fechaFin, string filtrarPor, string proceso)
        {
            return gbd.getTareasTipoUsuario(tipo, usuario, fechaInicio, fechaFin, filtrarPor, proceso);
        }

        public List<List<Tarea>> getTareasProcesos(string idProceso, DateTime fechaInicio, DateTime fechaFin, string filtrarPor)
        {
            return gbd.getTareasProcesos(idProceso, fechaInicio, fechaFin, filtrarPor);
        }

        public DataTable getEstadisticasTareasResponsable(string idProceso, DateTime fechaInicio, DateTime fechaFin)
        {
            return gbd.getEstadisticasTareasResponsable(idProceso, fechaInicio, fechaFin);
        }

        public DataTable getEstadisticasTareasAcabadas(string idProceso, DateTime fechaInicio, DateTime fechaFin)
        {
            return gbd.getEstadisticasTareasAcabadas(idProceso, fechaInicio, fechaFin);
        }

        /*public PuntoRojo getPuntoRojo(int id)
        {
            return gbd.getPuntoRojo(id);
        }

        public int updatePuntoRojo(PuntoRojo puntoRojo)
        {
            return gbd.updatePuntoRojo(puntoRojo);
        }

        public int removePuntoRojo(int id)
        {
            return gbd.removePuntoRojo(id);
        }

        public int setPuntoRojoFila(int ID, string fila, string valor)
        {
            return gbd.setPuntoRojoFila(ID, fila, valor);
        }

        public int setPuntoRojo(PuntoRojo puntoRojo)
        {
            return gbd.setPuntoRojo(puntoRojo);
        }

        public List<PuntoRojo> getPuntosRojos()
        {
            return gbd.getPuntosRojos();
        }*/

        public List<String> getProcesosListado()
        {
            return gbd.getProcesosListado();
        }

        public List<Proceso> getProcesos()
        {
            return gbd.getProcesos();
        }

        public Proceso getProcesoTarea(int? idTarea)
        {
            return gbd.getProcesoTarea(idTarea);
        }

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

        public List<Reunion> getReunionBase()
        {
            return gbd.getReunionBase();
        }

        public List<Reunion> getReunionUsuario(string user)
        {
            return gbd.getReunionUsuario(user);
        }

        public List<Reunion> getReunionUsuarioPasadas(string user)
        {
            return gbd.getReunionUsuarioPasadas(user);
        }
        
        public List<List<Tarea>> getTareasReunion(int idReunion)
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

        public List<Tarea> getTareas(DateTime desde, DateTime hasta)
        {
            return gbd.getTareas(desde, hasta);
        }

        public List<Tarea> getTareas()
        {
            return gbd.getTareas();
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
            return gbd.removeReunion(ID);
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

        public List<string> getInvitadoReunion(int IDReunion)
        {
            return gbd.getInvitadoReunion(IDReunion);
        }

        public List<int> getInvitadoEmpleado(string IDEmpleado)
        {
            return gbd.getInvitadoEmpleado(IDEmpleado);
        }

        public int setEmpIndicadores(string IDEmpleado, int IDIndicadores)
        {
            return gbd.setEmpIndicadores(IDEmpleado, IDIndicadores);
        }

        public int removeEmpIndicadores(string IDEmpleado, int IDIndicadores)
        {
            return gbd.removeEmpIndicadores(IDEmpleado, IDIndicadores);
        }

        public int setInvitado(string IDEmpleado, int IDReunion)
        {
            return gbd.setInvitado(IDEmpleado, IDReunion);
        }

        public int removeInvitado(string IDEmpleado, int IDReunion)
        {
            return gbd.removeInvitado(IDEmpleado, IDReunion);
        }

        public int removeInvitadoEmpleado(string IDEmpleado)
        {
            return gbd.removeInvitadoEmpleado(IDEmpleado);
        }

        public int removeInvitadoReunion(int IDReunion)
        {
            return gbd.removeInvitadoReunion(IDReunion);
        }

        public List<string> getAsistenteReunion(int IDReunion)
        {
            return gbd.getAsistenteReunion(IDReunion);
        }

        public List<int> getAsistenteEmpleado(string IDEmpleado)
        {
            return gbd.getAsistenteEmpleado(IDEmpleado);
        }

        public int setAsistente(string IDEmpleado, int IDReunion)
        {
            return gbd.setAsistente(IDEmpleado, IDReunion);
        }

        public int removeAsistenteReunion(int IDReunion)
        {
            return gbd.removeAsistenteReunion(IDReunion);
        }

        public int removeAsistente(string IDEmpleado, int IDReunion)
        {
            return gbd.removeAsistente(IDEmpleado, IDReunion);
        }

        public int removeAsistenteEmpleado(string IDEmpleado)
        {
            return gbd.removeAsistenteEmpleado(IDEmpleado);
        }

        public int setTareaFila(int ID, string fila, string valor)
        {
            return gbd.setTareaFila(ID, fila, valor);
        }

        public int setTareaFilaMeses(int ID, string fila, string valor)
        {
            return gbd.setTareaFilaMeses(ID, fila, valor);
        }

        public Indicadores getIndicadores(int IDReunion)
        {
            return gbd.getIndicadores(IDReunion);
        }
    }
}
