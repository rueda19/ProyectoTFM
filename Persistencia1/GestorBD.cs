using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Modelo;
using System.Data;

namespace Persistencia
{
    public class GestorBD
    {
        public List<Reunion> getReunionUsuario(string user)
        {
            List<Reunion> reuniones = new List<Reunion>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Ubicacion, Duracion, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE IDResponsable=@user And Fecha>@fecha", conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reuniones.Add(new Reunion(dr.GetInt32(0), dr.GetString(1), (Double)dr.GetDecimal(2), dr.GetDateTime(3), dr.GetString(4)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return reuniones;
        }

        public List<Reunion> getReunionUsuarioPasadas(string user)
        {
            List<Reunion> reuniones = new List<Reunion>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Ubicacion, Duracion, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE IDResponsable=@user", conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reuniones.Add(new Reunion(dr.GetInt32(0), dr.GetString(1), (Double)dr.GetDecimal(2), dr.GetDateTime(3), dr.GetString(4)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return reuniones;
        }

        public List<Tarea> getTareasReunion(int idReunion)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Origen, Estado, IDResponsable, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", idReunion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetDateTime(1), (dr.GetValue(2) is DBNull) ? new DateTime(0) : dr.GetDateTime(2), (dr.GetValue(3) is DBNull) ? new DateTime(0) : dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? 0 : Double.Parse(dr.GetValue(4).ToString()), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetInt32(8)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return tareas;
        }

        public List<Tarea> getTareasUsuarioTerminadas(string Usuario)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Origen, Estado, IDResponsable, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDResponsable=@resp", conn);
                cmd.Parameters.AddWithValue("@resp", Usuario);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetDateTime(1), (dr.GetValue(2) is DBNull) ? new DateTime(0) : dr.GetDateTime(2), (dr.GetValue(3) is DBNull) ? new DateTime(0) : dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? 0 : Double.Parse(dr.GetValue(4).ToString()), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetInt32(8)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return tareas;
        }

        public List<Tarea> getTareasUsuario(string Usuario)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Origen, Estado, IDResponsable, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDResponsable=@resp And (Estado<>'Terminada' And Estado<>'Abandonada')", conn);
                cmd.Parameters.AddWithValue("@resp", Usuario);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetDateTime(1), (dr.GetValue(2) is DBNull) ? new DateTime(0) : dr.GetDateTime(2), (dr.GetValue(3) is DBNull) ? new DateTime(0) : dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? 0 : Double.Parse(dr.GetValue(4).ToString()), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetInt32(8)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return tareas;
        }

        public Tarea getTarea(int ID)
        {
            Tarea tarea = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Origen, Estado, IDResponsable, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tarea = new Tarea(dr.GetInt32(0), dr.GetDateTime(1), (dr.GetValue(2) is DBNull) ? new DateTime(0) : dr.GetDateTime(2), (dr.GetValue(3) is DBNull) ? new DateTime(0) : dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? 0 : (Double)dr.GetValue(4), dr.GetString(5), dr.GetString(6), dr.GetString(7), dr.GetInt32(8));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return tarea;
        }

        public int setTarea(Tarea tarea)
        {
            int i=0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO GP_Tarea(FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Origen, Estado, IDResponsable, IDReunion) VALUES (@fini,@ffin,@feje,@tiemdedi,@origen,@estado,@idres,@idreunion)", conn);
                cmd.Parameters.AddWithValue("@fini", tarea.FechaInicio);
                cmd.Parameters.AddWithValue("@ffin", tarea.FechaFin);
                cmd.Parameters.AddWithValue("@feje", tarea.FechaEjecutado);
                cmd.Parameters.AddWithValue("@tiemdedi", tarea.TiempoDedicado);
                cmd.Parameters.AddWithValue("@origen", tarea.Origen);
                cmd.Parameters.AddWithValue("@estado", tarea.Estado);
                cmd.Parameters.AddWithValue("@idres", tarea.IDResponsable);
                cmd.Parameters.AddWithValue("@idreunion", tarea.IDReunion);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeTarea(int ID)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM GP_Tarea WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public Reunion getReunion(int ID)
        {
            Reunion reunion = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Ubicacion, Duracion, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reunion = new Reunion(dr.GetInt32(0), dr.GetString(1), (Double)dr.GetDecimal(2), dr.GetDateTime(3), dr.GetString(4));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return reunion;
        }

        public int setReunion(Reunion reunion)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Reunion](Ubicacion, Duracion, Fecha, IDResponsable) VALUES (@ubi,@dur,@fecha,@res)", conn);
                cmd.Parameters.AddWithValue("@ubi", reunion.Ubicacion);
                cmd.Parameters.AddWithValue("@dur", reunion.Duracion);
                cmd.Parameters.AddWithValue("@fecha", reunion.Fecha);
                cmd.Parameters.AddWithValue("@res", reunion.IDResponsable);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeReunion(int ID)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID); 
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public Agenda getAgenda(int ID)
        {
            Agenda agenda = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, HoraInicio, Contenido, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Agenda] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    agenda = new Agenda(dr.GetInt32(0), (TimeSpan)dr.GetValue(1), dr.GetString(2), dr.GetInt32(3));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return agenda;
        }

        public int setAgenda(Agenda agenda)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Agenda](HoraInicio, Contenido, IDReunion) VALUES(@horaini,@cont,@idreu)", conn);
                cmd.Parameters.AddWithValue("@horaini", agenda.HoraInicio);
                cmd.Parameters.AddWithValue("@cont", agenda.Contenido);
                cmd.Parameters.AddWithValue("@idreu", agenda.IDReunion);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeAgenda(int ID)
        {
            int i = 0;
            SqlConnection conn = null;  
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Agenda] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public Acta getActa(int ID)
        {
            Acta acta = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Fecha, Duracion, Contenido, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Acta] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    acta = new Acta(dr.GetInt32(0), dr.GetDateTime(1), (Double)dr.GetDecimal(2), dr.GetString(3), dr.GetInt32(4));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return acta;
        }

        public int setActa(Acta acta)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Acta](Fecha, Duracion, Contenido, IDReunion) VALUES(@fecha,@dur,@cont,@idReun)", conn);
                cmd.Parameters.AddWithValue("@fecha", acta.Fecha);
                cmd.Parameters.AddWithValue("@dur", acta.Duracion);
                cmd.Parameters.AddWithValue("@cont", acta.Contenido);
                cmd.Parameters.AddWithValue("@idReun", acta.IDReunion);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeActa(int ID)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Acta] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public Empleado getEmpleado(string user)
        {
            Empleado empleado = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Usuario, NombreCompleto, Departamento FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado] WHERE Usuario=@user", conn);
                cmd.Parameters.AddWithValue("@user", user);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empleado = new Empleado(dr.GetString(0), dr.GetString(1), dr.GetString(2));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return empleado;
        }

        public int setEmpleado(Empleado empleado)
        {
            int i=0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Empleado](Usuario, NombreCompleto, Departamento) VALUES(@user,@nom,@depar)", conn);
                cmd.Parameters.AddWithValue("@user", empleado.Usuario);
                cmd.Parameters.AddWithValue("@nom", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@depar", empleado.Departamento);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeEmpleado(string user)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado] WHERE Usuario=@user", conn);
                cmd.Parameters.AddWithValue("@user", user);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public List<Invitado> getInvitadoReunion(int IDReunion)
        {
            List<Invitado> invitados = new List<Invitado>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDReunion, IDEmpl FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDReunion);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    invitados.Add(new Invitado(dr.GetInt32(0), dr.GetString(1)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return invitados;
        }

        public List<Invitado> getInvitadoEmpleado(string user)
        {
            List<Invitado> invitados = new List<Invitado>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDReunion, IDEmpl FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDEmpl=@id", conn);
                cmd.Parameters.AddWithValue("@id", user);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    invitados.Add(new Invitado(dr.GetInt32(0), dr.GetString(1)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return invitados;
        }

        public int setInvitado(Invitado invitado)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Invitado](IDReunion, IDEmpl) VALUES(@idreu,@idemp)", conn);
                cmd.Parameters.AddWithValue("@idreu", invitado.IDEmpleado);
                cmd.Parameters.AddWithValue("@idemp", invitado.IDReunion);
                //cmd.Parameters.AddWithValue("@id", IDReunion); WHERE IDReunion=@id
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeInvitadoEmpleado(string IDEmpleado)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDEmpleado=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDEmpleado);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeInvitadoReunion(int IDReunion)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDReunion);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public List<Asistente> getAsistenteActa(int IDActa)
        {
            List<Asistente> asistentes = new List<Asistente>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDActa, IDEmpl FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDActa=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDActa);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asistentes.Add(new Asistente(dr.GetInt32(0), dr.GetString(1)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return asistentes;
        }

        public List<Asistente> getAsistenteEmpleado(string IDEmpleado)
        {
            List<Asistente> asistentes = new List<Asistente>(); ;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDActa, IDEmpl FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDEmpl=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDEmpleado);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asistentes.Add(new Asistente(dr.GetInt32(0), dr.GetString(1)));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return asistentes;
        }

        public int setAsistente(Asistente asistente)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Asistente](IDActa, IDEmpl) VALUES(@idEmp,@idActa)", conn);
                cmd.Parameters.AddWithValue("@idEmp", asistente.IDEmpleado);
                cmd.Parameters.AddWithValue("@idActa", asistente.IDActa);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeAsistenteActa(int IDActa)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDActa=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDActa);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int removeAsistenteEmpleado(string IDEmpleado)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDEmpleado=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDEmpleado);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }

        public int setTareaFila(int ID, string fila, string valor)
        {
            int i=0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Tarea] SET "+fila+"=@valor WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@fila", fila);
                if (fila.Equals("TiempoDedicado"))
                {
                    cmd.Parameters.AddWithValue("@valor", valor.Replace(",","."));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@valor", valor);
                }
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return i;
        }
    }
}
