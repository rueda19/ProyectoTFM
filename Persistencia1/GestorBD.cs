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
        public int getNumTareasUsuarioReunion(int idReunion, string user)
        {
            int numTareas = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Count(ID) FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDResponsable=@user AND IDReunion=@idReu", conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@idReu", idReunion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numTareas = dr.GetInt32(0);
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
            return numTareas;
        }

        public Byte[] getEmpleadoFoto(string user)
        {
            Byte[] foto = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Foto FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado] WHERE Usuario=@user", conn);
                cmd.Parameters.AddWithValue("@user", user);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    foto = (byte[])dr.GetValue(0);
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
            return foto;
        }

        public DataTable getEmpleadosFoto()
        {
            DataTable table = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Foto, Usuario, NombreCompleto, Departamento, Telefono FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado]", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
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
            return table;
        }

        public int updateEmpleado(string empleado, string fila, string valor, byte[] foto)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Empleado] SET " + fila + "=@valor WHERE Usuario=@user", conn);
                cmd.Parameters.AddWithValue("@user", empleado);
                if(fila!="Foto")
                    cmd.Parameters.AddWithValue("@valor", valor);
                else
                    cmd.Parameters.AddWithValue("@valor", (object)foto ?? DBNull.Value);
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

        public List<List<Tarea>> getTareaRama(int idTarea)
        {
            List<List<Tarea>> listaTareas = new List<List<Tarea>>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("GP_TareaRama", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTarea", idTarea);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = -1;
                List<Tarea> tareas = null;
                while (dr.Read())
                {
                    if (dr.GetInt32(12) != i)
                    {
                        i = dr.GetInt32(12);
                        if (tareas != null)
                            listaTareas.Add(tareas);
                        tareas = new List<Tarea>();
                    }
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
                }
                listaTareas.Add(tareas);
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

            return listaTareas;
        }

        public List<string> getUsuariosDepartamentos()
        {
            List<string> tiposTareas = new List<string>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT distinct [Usuario] FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado] WHERE [Usuario] is not null and [Usuario]!='' UNION ALL SELECT distinct [DEPARTAMENTO] FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado] WHERE [DEPARTAMENTO] is not null and [DEPARTAMENTO]!=''", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tiposTareas.Add(dr.GetString(0));
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

            return tiposTareas;
        }

        public List<string> getTiposTareas()
        {
            List<string> tiposTareas = new List<string>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT distinct[Tipo] FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE [Tipo] is not null", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tiposTareas.Add(dr.GetString(0));
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

            return tiposTareas;
        }

        public List<List<Tarea>> getTareasTipoUsuario(string tipo, string usuario, DateTime fechaInicio, DateTime fechaFin, string filtrarPor)
        {
            List<List<Tarea>> listaTareas = new List<List<Tarea>>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("GP_TareasTipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@FiltrarPor", filtrarPor);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = -1;
                List<Tarea> tareas = null;
                while (dr.Read())
                {
                    if (dr.GetInt32(12) != i)
                    {
                        i = dr.GetInt32(12);
                        if (tareas != null)
                            listaTareas.Add(tareas);
                        tareas = new List<Tarea>();
                    }
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
                }
                if (tareas == null)
                    tareas = new List<Tarea>();
                listaTareas.Add(tareas);
            }
            catch (Exception e)
            {
                listaTareas.Add(new List<Tarea>());
                System.Diagnostics.Debug.Write(e.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return listaTareas;
        }

        public List<List<Tarea>> getTareasReunion(int idReunion)
        {
            List<List<Tarea>> listaTareas = new List<List<Tarea>>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("GP_TareasReunion", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDReunion", idReunion);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = -1;
                List<Tarea> tareas = null;
                while (dr.Read())
                {
                    if (dr.GetInt32(12) != i)
                    {
                        i = dr.GetInt32(12);
                        if (tareas != null)
                            listaTareas.Add(tareas);
                        tareas = new List<Tarea>();
                    }
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
                }
                listaTareas.Add(tareas);
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

            return listaTareas;
        }

        public List<List<Tarea>> getTareasProcesos(string idProceso, DateTime fechaInicio, DateTime fechaFin, string filtrarPor)
        {
            List<List<Tarea>> listaTareas = new List<List<Tarea>>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("GP_TareasProceso", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDProceso", idProceso);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@FiltrarPor", filtrarPor);
                SqlDataReader dr = cmd.ExecuteReader();
                int i = -1;
                List<Tarea> tareas = null;
                while (dr.Read())
                {
                    if (dr.GetInt32(12) != i)
                    {
                        i = dr.GetInt32(12);
                        if (tareas != null)
                            listaTareas.Add(tareas);
                        tareas=new List<Tarea>();
                    }
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
                }
                listaTareas.Add(tareas);
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

            return listaTareas;
        }

        public DataTable getEstadisticasTareasResponsable(string idProceso, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable table = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("GP_TareasResponsable", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@IDProceso", idProceso);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
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
            return table;
        }

        public DataTable getEstadisticasTareasAcabadas(string idProceso,DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable table = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("GP_TareasAcabadas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                cmd.Parameters.AddWithValue("@IDProceso", idProceso);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(table);
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
            return table;
        }

        /*public PuntoRojo getPuntoRojo(int id)
        {
            PuntoRojo puntoRojo = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, Prioridad, Solucionado, IDResponsable, IDProceso FROM [GP_PuntoRojo] Where ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    puntoRojo =new PuntoRojo(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetBoolean(3), dr.GetString(4), dr.GetString(5));
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
            return puntoRojo;
        }

        public int updatePuntoRojo(PuntoRojo puntoRojo)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_PuntoRojo] SET Descripcion=@des, Prioridad=@prio, Solucionado=@sol, IDResponsable=@idRes, IDProceso=@idPro WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", puntoRojo.ID);
                cmd.Parameters.AddWithValue("@prio", puntoRojo.Prioridad);
                cmd.Parameters.AddWithValue("@sol", puntoRojo.Solucionado);
                cmd.Parameters.AddWithValue("@des", puntoRojo.Descripcion);
                cmd.Parameters.AddWithValue("@idPro", puntoRojo.IDProceso);
                cmd.Parameters.AddWithValue("@idRes", puntoRojo.IDResponsable);
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

        public int removePuntoRojo(int id)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_PuntoRojo] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
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

        public int setPuntoRojoFila(int ID, string fila, string valor)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_PuntoRojo] SET " + fila + "=@valor WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@fila", fila);
                cmd.Parameters.AddWithValue("@valor", valor);
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

        public int setPuntoRojo(PuntoRojo puntoRojo)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_PuntoRojo](Prioridad, Solucionado, Descripcion, IDProceso, IDResponsable) VALUES(@prio,@sol,@des,@idPro,@idRes)", conn);
                cmd.Parameters.AddWithValue("@prio", puntoRojo.Prioridad);
                cmd.Parameters.AddWithValue("@sol", puntoRojo.Solucionado);
                cmd.Parameters.AddWithValue("@des", puntoRojo.Descripcion);
                cmd.Parameters.AddWithValue("@idPro", puntoRojo.IDProceso);
                cmd.Parameters.AddWithValue("@idRes", puntoRojo.IDResponsable);
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

        public List<PuntoRojo> getPuntosRojos()
        {
            List<PuntoRojo> puntosRojos = new List<PuntoRojo>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, Prioridad, Solucionado, IDResponsable, IDProceso FROM [GP_PuntoRojo]", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    puntosRojos.Add(new PuntoRojo(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetBoolean(3),dr.GetString(4), dr.GetString(5)));
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

            return puntosRojos;
        }*/

        public List<Proceso> getProcesos()
        {
            List<Proceso> procesos = new List<Proceso>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Nombre, Tipo, IDResponsable FROM [GP_Proceso] WHERE ID<>'GBL'", conn);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    procesos.Add(new Proceso(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3)));
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

            return procesos;
        }

        public Proceso getProcesoTarea(int? tarea)
        {
            Proceso proceso = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT p.ID, p.Nombre, p.Tipo, p.IDResponsable FROM [GP_Proceso] p join [GP_Tarea] t on p.ID=t.IDProceso WHERE t.ID=@idTarea", conn);
                cmd.Parameters.AddWithValue("@idTarea", tarea);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    proceso = new Proceso(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
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

            return proceso;
        }

        public Proceso getProceso(string id)
        {
            Proceso proceso = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Nombre, Tipo, IDResponsable FROM [GP_Proceso] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    proceso = new Proceso(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3));
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

            return proceso;
        }

        public int setProceso(Proceso proceso)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Proceso](ID, Nombre, Tipo, IDResponsable) VALUES(@id,@nom,@tipo,@isRes)", conn);
                cmd.Parameters.AddWithValue("@id", proceso.ID);
                cmd.Parameters.AddWithValue("@nom", proceso.Nombre);
                cmd.Parameters.AddWithValue("@tipo", proceso.Tipo);
                cmd.Parameters.AddWithValue("@isRes", proceso.IDResponsable);
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

        public int setProcesoFila(string ID, string fila, string valor)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Proceso] SET " + fila + "=@valor WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@fila", fila);
                cmd.Parameters.AddWithValue("@valor", valor);
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

        public int removeProceso(string id)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Proceso] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
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

        public List<string> GetIDDiagramas()
        {
            List<string> idDiagramas = new List<string>();
            idDiagramas.Add("Global");
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDProceso FROM [Fw_GrupoGarnica].[dbo].[GP_Diagrama]", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idDiagramas.Add(dr.GetString(0));
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

            return idDiagramas;
        }

        public Byte[] GetDiagrama(string idProceso)
        {
            Byte[] diagrama = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Diagrama FROM [Fw_GrupoGarnica].[dbo].[GP_Diagrama] WHERE IDProceso=@idProceso", conn);
                cmd.Parameters.AddWithValue("@idProceso", idProceso);
                diagrama = (Byte[])cmd.ExecuteScalar();
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

            return diagrama;
        }

        public int UpdateDiagrama(string idProceso, Byte[] dBinary)
        {
            SqlConnection conn = null;
            int i = 0;
            try
            {
                //Create an instance of the connection and command object.
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE GP_Diagrama SET Diagrama=@Diagrama WHERE IDProceso=@idProceso", conn);
                //Set parameter values
                cmd.Parameters.AddWithValue("@idProceso", idProceso);
                cmd.Parameters.AddWithValue("@Diagrama", dBinary);

                //Execute the command.
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

        public int SetDiagrama(string idProceso, Byte[] dBinary)
        {
            SqlConnection conn = null;
            int i = 0;
            try
            {
                //Create an instance of the connection and command object.
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO GP_Diagrama (IDProceso, Diagrama) VALUES (@idProceso, @Diagrama)", conn);

                //Set parameter values
                cmd.Parameters.AddWithValue("@idProceso", idProceso);
                cmd.Parameters.AddWithValue("@Diagrama", dBinary);

                //Execute the command.
                i=cmd.ExecuteNonQuery();
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

        public List<Reunion> getReunionBase()
        {
            List<Reunion> reuniones = new List<Reunion>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Titulo, Ubicacion, DuracionEstimada, DuracionReal, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE EsBase=1", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reuniones.Add(new Reunion(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), (Double)dr.GetDecimal(3), (Double)dr.GetDecimal(4), dr.GetDateTime(5), dr.GetString(6)));
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

        public List<Reunion> getReunionUsuario(string user)
        {
            List<Reunion> reuniones = new List<Reunion>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Titulo, Ubicacion, DuracionEstimada, DuracionReal, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] JOIN GP_Invitado ON ID=IDReunion WHERE IDEmpl=@user And Fecha>@fecha", conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@fecha", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reuniones.Add(new Reunion(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), (Double)dr.GetDecimal(3), (Double)dr.GetDecimal(4), dr.GetDateTime(5), dr.GetString(6)));
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
                SqlCommand cmd = new SqlCommand("SELECT ID, Titulo, Ubicacion, DuracionEstimada, DuracionReal, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] JOIN GP_Invitado ON ID=IDReunion WHERE IDEmpl=@user", conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reuniones.Add(new Reunion(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), (Double)dr.GetDecimal(3), (Double)dr.GetDecimal(4), dr.GetDateTime(5), dr.GetString(6)));
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

        /*public List<Tarea> getTareasReunion(int idReunion)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", idReunion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
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
        }*/

        public List<Tarea> getTareasUsuarioTerminadas(string Usuario)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDResponsable=@resp", conn);
                cmd.Parameters.AddWithValue("@resp", Usuario);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
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
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDResponsable=@resp And (Estado<>'Terminada' And Estado<>'Abandonada')", conn);
                cmd.Parameters.AddWithValue("@resp", Usuario);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
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

        public List<Tarea> getTareas(DateTime desde, DateTime hasta)
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE FechaInicio>=@desde And FechaInicio<=@hasta", conn);
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
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

        public List<Tarea> getTareas()
        {
            List<Tarea> tareas = new List<Tarea>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea]", conn);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tareas.Add(new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11))));
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
                SqlCommand cmd = new SqlCommand("SELECT ID, Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //tarea = new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), (dr.GetValue(3) is DBNull) ? new DateTime(0) : dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? new DateTime(0) : dr.GetDateTime(4), (dr.GetValue(5) is DBNull) ? 0 : Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), dr.GetInt32(9));
                    tarea = new Tarea(dr.GetInt32(0), dr.GetString(1), dr.GetDateTime(2), dr.GetDateTime(3), (dr.GetValue(4) is DBNull) ? null : (DateTime?)dr.GetDateTime(4), Double.Parse(dr.GetValue(5).ToString()), dr.GetString(6), dr.GetString(7), dr.GetString(8), (dr.GetValue(9) is DBNull ? null : (int?)dr.GetInt32(9)), (dr.GetValue(10) is DBNull ? null : dr.GetString(10)), (dr.GetValue(11) is DBNull ? null : (int?)dr.GetInt32(11)));
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

        public int updateTarea(Tarea tarea)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE GP_Tarea SET Descripcion=@fdes, FechaInicio=@fini, FechaFin=@ffin, FechaEjecutado=@feje, TiempoDedicado=@tiemdedi, Tipo=@tipo, Estado=@estado, IDResponsable=@idres, IDReunion=@idreunion, IDProceso=@idProceso, IDTareaPadre=@idTareaPadre WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", tarea.ID);
                cmd.Parameters.AddWithValue("@fdes", tarea.Descripcion);
                cmd.Parameters.AddWithValue("@fini", tarea.FechaInicio);
                cmd.Parameters.AddWithValue("@ffin", tarea.FechaFin);
                cmd.Parameters.AddWithValue("@feje", (object)tarea.FechaEjecutado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tiemdedi", tarea.TiempoDedicado);
                //cmd.Parameters.AddWithValue("@tiemdedi", tarea.TiempoDedicado.ToString().Replace(",","."));
                cmd.Parameters.AddWithValue("@tipo", tarea.Tipo);
                cmd.Parameters.AddWithValue("@estado", tarea.Estado);
                cmd.Parameters.AddWithValue("@idres", tarea.IDResponsable);
                cmd.Parameters.AddWithValue("@idreunion", (object)tarea.IDReunion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idProceso", (object)tarea.IDProceso ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idTareaPadre", (object)tarea.IDTareaPadre ?? DBNull.Value);
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

        public int setTarea(Tarea tarea)
        {
            int i=0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO GP_Tarea(Descripcion, FechaInicio, FechaFin, FechaEjecutado, TiempoDedicado, Tipo, Estado, IDResponsable, IDReunion, IDProceso, IDTareaPadre) VALUES (@fdes,@fini,@ffin,@feje,@tiemdedi,@tipo,@estado,@idres,@idreunion,@idproceso,@idTareaPadre)", conn);
                cmd.Parameters.AddWithValue("@fdes", tarea.Descripcion);
                cmd.Parameters.AddWithValue("@fini", tarea.FechaInicio);
                cmd.Parameters.AddWithValue("@ffin", tarea.FechaFin);
                cmd.Parameters.AddWithValue("@feje", (object)tarea.FechaEjecutado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tiemdedi", tarea.TiempoDedicado);
                cmd.Parameters.AddWithValue("@tipo", tarea.Tipo);
                cmd.Parameters.AddWithValue("@estado", tarea.Estado);
                cmd.Parameters.AddWithValue("@idres", tarea.IDResponsable);
                cmd.Parameters.AddWithValue("@idreunion", (object)tarea.IDReunion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idproceso", (object)tarea.IDProceso ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idTareaPadre", (object)tarea.IDTareaPadre ?? DBNull.Value);
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
                //SqlCommand cmd = new SqlCommand("DELETE FROM GP_Tarea WHERE ID=@id", conn);
                SqlCommand cmd = new SqlCommand("[GP_EliminarTareaRecursiva]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTarea", ID);
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
                SqlCommand cmd = new SqlCommand("SELECT ID, Titulo, Ubicacion, DuracionEstimada, DuracionReal, Fecha, IDResponsable FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reunion = new Reunion(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), (Double)dr.GetDecimal(3), (Double)dr.GetDecimal(4), dr.GetDateTime(5), dr.GetString(6));
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

        public int setNuevaReunion(Reunion reunion, Agenda agenda, List<string> invitados)
        {
            int idReunion=0;
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Reunion](Titulo, Ubicacion, DuracionEstimada, DuracionReal, Fecha, IDResponsable) VALUES (@tit,@ubi,@durE,@durR,@fecha,@res)", conn);
                cmd.Parameters.AddWithValue("@tit", reunion.Titulo);
                cmd.Parameters.AddWithValue("@ubi", reunion.Ubicacion);
                cmd.Parameters.AddWithValue("@durE", reunion.DuracionEstimada);
                cmd.Parameters.AddWithValue("@durR", reunion.DuracionReal);
                cmd.Parameters.AddWithValue("@fecha", reunion.Fecha);
                cmd.Parameters.AddWithValue("@res", reunion.IDResponsable);
                i = cmd.ExecuteNonQuery();
                if (i == 0)
                    throw new System.Exception();
                cmd.Parameters.Clear();

                cmd.CommandText = "SELECT IDENT_CURRENT('[Fw_GrupoGarnica].[dbo].[GP_Reunion]')";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idReunion = Int32.Parse(dr.GetValue(0).ToString());
                }
                if (idReunion == 0)
                    throw new System.Exception();
                dr.Close();

                cmd.CommandText = "INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Agenda](Contenido, IDReunion) VALUES(@cont,@idreu)";
                cmd.Parameters.AddWithValue("@cont", agenda.Contenido);
                cmd.Parameters.AddWithValue("@idreu", idReunion);
                i = cmd.ExecuteNonQuery();
                if (i == 0)
                    throw new System.Exception();
                cmd.Parameters.Clear();

                foreach (string inv in invitados)
                {
                    cmd.CommandText = "INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Invitado](IDReunion, IDEmpl) VALUES(@idreu,@idemp)";
                    cmd.Parameters.AddWithValue("@idemp", inv);
                    cmd.Parameters.AddWithValue("@idreu", idReunion);
                    i = cmd.ExecuteNonQuery();
                    if (i == 0)
                        throw new System.Exception();
                    cmd.Parameters.Clear();
                }
                cmd.CommandText = "INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Acta](Contenido, IDReunion) VALUES(@cont,@idReun)";
                cmd.Parameters.AddWithValue("@cont", "");
                cmd.Parameters.AddWithValue("@idReun", idReunion);
                i = cmd.ExecuteNonQuery();
                if (i == 0)
                    throw new System.Exception();
                cmd.Parameters.Clear();

                i = 1;
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

        public int setReunionFila(int ID, string fila, string valor)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Reunion] SET " + fila + "=@valor WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@fila", fila);
                if (fila.Equals("DuracionEstimada") || fila.Equals("DuracionReal"))
                {
                    cmd.Parameters.AddWithValue("@valor", valor.Replace(",", "."));
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

        public int setReunion(Reunion reunion)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Reunion](Titulo, Ubicacion, DuracionEstimada, DuracionReal, Fecha, IDResponsable) VALUES (@tit,@ubi,@durE,@durR,@fecha,@res)", conn);
                cmd.Parameters.AddWithValue("@tit", reunion.Titulo);
                cmd.Parameters.AddWithValue("@ubi", reunion.Ubicacion);
                cmd.Parameters.AddWithValue("@durE", reunion.DuracionEstimada);
                cmd.Parameters.AddWithValue("@durR", reunion.DuracionReal);
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
                //eliminar uno a uno
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Tarea] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i = cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Acta] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i += cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Agenda] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i += cmd.ExecuteNonQuery();
                //eliminar uno a uno
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i += cmd.ExecuteNonQuery();
                //eliminar uno a uno
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i += cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_EmpleadoIndicadores] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i += cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Indicadores] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID);
                i += cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Reunion] WHERE ID=@id", conn);
                cmd.Parameters.AddWithValue("@id", ID); 
                i += cmd.ExecuteNonQuery();
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

        public Agenda getAgendaReunion(int IDReunion)
        {
            Agenda agenda = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Contenido, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Agenda] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", IDReunion);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    agenda = new Agenda(dr.GetString(0), dr.GetInt32(1));
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

        public int updateAgenda(Agenda agenda)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                //"UPDATE [Fw_GrupoGarnica].[dbo].[GP_Tarea] SET "+fila+"=@valor WHERE ID=@id"
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Agenda] SET Contenido=@cont WHERE ID=@idreu", conn);
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

        public int setAgenda(Agenda agenda)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Agenda](Contenido, IDReunion) VALUES(@cont,@idreu)", conn);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Agenda] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", ID);
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

        public Acta getActaReunion(int IDReunion)
        {
            Acta acta = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Contenido, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Acta] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", IDReunion);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    acta = new Acta(dr.GetString(0), dr.GetInt32(1));
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

        public int updateActa(Acta acta)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                //SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Agenda] SET HoraInicio=@horaini, Contenido=@cont, IDReunion=@idreu WHERE ID=@id", conn);
                SqlCommand cmd = new SqlCommand("UPDATE [Fw_GrupoGarnica].[dbo].[GP_Acta] SET Contenido=@cont WHERE IDReunion=@idReun", conn);
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

        public int setActa(Acta acta)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Acta](Contenido, IDReunion) VALUES(@cont,@idReun)", conn);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Acta] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", ID);
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

        public List<Empleado> getEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Usuario, NombreCompleto, Departamento FROM [Fw_GrupoGarnica].[dbo].[GP_Empleado]", conn);
                //cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empleados.Add(new Empleado(dr.GetString(0), dr.GetString(1), dr.GetString(2)));
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

            return empleados;
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

        public int setEmpIndicadores(EmpleadoIndicadores empleadoIndicadores)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_EmpleadoIndicadores](IDIndicadores, IDEmpl) VALUES(@idind,@idemp)", conn);
                cmd.Parameters.AddWithValue("@idemp", empleadoIndicadores.IDEmpleado);
                cmd.Parameters.AddWithValue("@idind", empleadoIndicadores.IDIndicadores);
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
                cmd.Parameters.AddWithValue("@idemp", invitado.IDEmpleado);
                cmd.Parameters.AddWithValue("@idreu", invitado.IDReunion);
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

        public int removeEmpIndicadores(EmpleadoIndicadores empleadoIndicadores)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_EmpleadoIndicadores] WHERE IDIndicadores=@idind And IDEmpl=@idEmpl", conn);
                cmd.Parameters.AddWithValue("@idEmpl", empleadoIndicadores.IDEmpleado);
                cmd.Parameters.AddWithValue("@idind", empleadoIndicadores.IDIndicadores);
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

        public int removeInvitado(Invitado invitado)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDReunion=@idReu And IDEmpl=@idEmpl", conn);
                cmd.Parameters.AddWithValue("@idEmpl", invitado.IDEmpleado);
                cmd.Parameters.AddWithValue("@idReu", invitado.IDReunion);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Invitado] WHERE IDEmpl=@id", conn);
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

        public List<Asistente> getAsistenteReunion(int IDReunion)
        {
            List<Asistente> asistentes = new List<Asistente>();
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDReunion, IDEmpl FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDReunion=@id", conn);
                cmd.Parameters.AddWithValue("@id", IDReunion);
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
                SqlCommand cmd = new SqlCommand("SELECT IDReunion, IDEmpl FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDEmpl=@id", conn);
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
                SqlCommand cmd = new SqlCommand("INSERT INTO [Fw_GrupoGarnica].[dbo].[GP_Asistente](IDReunion, IDEmpl) VALUES(@idReunion,@idEmp)", conn);
                cmd.Parameters.AddWithValue("@idEmp", asistente.IDEmpleado);
                cmd.Parameters.AddWithValue("@idReunion", asistente.IDReunion);
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

        public int removeAsistente(Asistente asistente)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDReunion=@idReunion And IDEmpl=@idEmp", conn);
                cmd.Parameters.AddWithValue("@idReunion", asistente.IDReunion);
                cmd.Parameters.AddWithValue("@idEmp", asistente.IDEmpleado);
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

        public int removeAsistenteReunion(int IDReunion)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDReunion=@id", conn);
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

        public int removeAsistenteEmpleado(string IDEmpleado)
        {
            int i = 0;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Fw_GrupoGarnica].[dbo].[GP_Asistente] WHERE IDEmpl=@id", conn);
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

        public Indicadores getIndicadores(int IDReunion)
        {
            Indicadores indicadores = null;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = Persistencia.Properties.Settings.Default.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Asistencia, NumTareas, Terminadas, Abandonadas, EnProceso, IDReunion FROM [Fw_GrupoGarnica].[dbo].[GP_Indicadores] WHERE IDReunion=@idReunion", conn);
                cmd.Parameters.AddWithValue("@idReunion", IDReunion);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    indicadores = new Indicadores(dr.GetInt32(0), (Double)dr.GetDecimal(1), dr.GetInt32(2), (Double)dr.GetDecimal(3), (Double)dr.GetDecimal(4), (Double)dr.GetDecimal(5), dr.GetInt32(6));
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

            return indicadores;
        }
    }
}
