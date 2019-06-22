using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAOAgendaEstandar
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Actualiza la agenda estandar del medico
        /// </summary>
        /// <param name="agenda">Agenda</param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string ActualizarAgenda(List<TOAgendaEstandar> agenda, string codigo)
        {
            string confirmacion = "La agenda se actualizó exitosamente";

            // Se abre la conexión

            if (conexion != null)
            {
                try
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                }
                catch (Exception)
                {
                    confirmacion = "Ocurrió un error y no se pudo actualizar la agenda";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo actualizar la agenda";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Actualizar la agenda");
            

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                string sentencia = "UPDATE DISPONIBILIDAD_MEDICO SET HORA_INICIO = @inicio, HORA_FIN = @fin WHERE CODIGO_MEDICO = @codigo AND DIA = @dia IF @@ROWCOUNT = 0 INSERT INTO DISPONIBILIDAD_MEDICO(CODIGO_MEDICO, DIA, HORA_INICIO, HORA_FIN) VALUES(@codigo, @dia, @inicio, @fin);";

                string codigoMedico = codigo;
                string dia = "";
                string horaInicio = "";
                string horaFin = "";

                SqlCommand comando = new SqlCommand(sentencia, conexion);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar y se ejecuta el comando


                foreach (TOAgendaEstandar elemento in agenda)
                {
                    dia = elemento.Dia;
                    horaInicio = elemento.HoraInicio;
                    horaFin = elemento.HoraFin;

                    comando.Parameters.AddWithValue("@codigo", codigoMedico);
                    comando.Parameters.AddWithValue("@dia", dia);
                    comando.Parameters.AddWithValue("@inicio", horaInicio);
                    comando.Parameters.AddWithValue("@fin", horaFin);

                    comando.ExecuteNonQuery();

                    comando.Parameters.Clear();

                }



                // Una vez actualizada, se recupera la nueva agenda

                comando.CommandText = "SELECT * FROM DISPONIBILIDAD_MEDICO WHERE CODIGO_MEDICO = @codigo;";

                comando.Parameters.AddWithValue("@codigo", codigoMedico);

                SqlDataReader lector = comando.ExecuteReader();

                // Se limpia la lista de agenda

                agenda.Clear();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de agenda

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOAgendaEstandar toAgenda = new TOAgendaEstandar(lector["CODIGO_MEDICO"].ToString(), lector["DIA"].ToString(),
                            lector["HORA_INICIO"].ToString(), lector["HORA_FIN"].ToString());

                        agenda.Add(toAgenda);

                    }
                }

                lector.Close();


                // Se realiza un commit de la transacción

                transaccion.Commit();

            }
            catch (Exception)
            {
                try
                {

                    // En caso de un error se realiza un rollback a la transacción

                    transaccion.Rollback();
                }
                catch (Exception)
                {
                }
                finally
                {
                    confirmacion = "Ocurrió un error y no se pudo actualizar la agenda";
                }
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return confirmacion;
        }

        /// <summary>
        /// Obtiene los dias laborales del medico y su respectivo horario
        /// </summary>
        /// <param name="diaSeleccionado">Dia seleccionado</param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarDisponibilidad(TOAgendaEstandar diaSeleccionado)
        {
            string confirmacion = "La agenda se cargó exitosamente";

            // Se abre la conexión

            if (conexion != null)
            {
                try
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                }
                catch (Exception)
                {
                    confirmacion = "Ocurrió un error y no se pudo cargar la agenda";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar la agenda";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar disponibilidad del día");



            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT HORA_INICIO, HORA_FIN FROM DISPONIBILIDAD_MEDICO WHERE CODIGO_MEDICO = @codigo AND DIA = @dia;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@codigo", diaSeleccionado.CodigoMedico);
                comando.Parameters.AddWithValue("@dia", diaSeleccionado.Dia);

                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en el objeto TOAgendaEstandar

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        diaSeleccionado.HoraInicio = lector["HORA_INICIO"].ToString();
                        diaSeleccionado.HoraFin = lector["HORA_FIN"].ToString();
                    }
                }

                lector.Close();

                transaccion.Commit();

            }
            catch (Exception)
            {
                try
                {

                    // En caso de un error se realiza un rollback a la transacción

                    transaccion.Rollback();
                }
                catch (Exception)
                {
                }
                finally
                {
                    confirmacion = "Ocurrió un error y no se pudo cargar la agenda";
                }
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return confirmacion;
        }

        /// <summary>
        /// Elimina el dia seleccionado de la agenda laboral
        /// </summary>
        /// <param name="codigoMedico">Codigo Medico</param>
        /// <param name="dia">Dia</param>
        /// <returns>Retorna un mensaje indicando si la transaccion se realizo</returns>
        public string EliminarHorario(string codigoMedico, string dia)
        {
            string confirmacion = "La agenda se actualizó exitosamente";

            // Se abre la conexión

            if (conexion != null)
            {
                try
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                }
                catch (Exception)
                {
                    confirmacion = "Ocurrió un error y no se pudo actualizar la agenda";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo actualizar la agenda";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Eliminar horario");


            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                string sentencia = "DELETE FROM DISPONIBILIDAD_MEDICO WHERE CODIGO_MEDICO = @codigo AND DIA = @dia;";

                SqlCommand comando = new SqlCommand(sentencia, conexion);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar y se ejecuta el comando

                comando.Parameters.AddWithValue("@codigo", codigoMedico);
                comando.Parameters.AddWithValue("@dia", dia);

                comando.ExecuteNonQuery();



                // Se realiza un commit de la transacción

                transaccion.Commit();

            }
            catch (Exception)
            {
                try
                {

                    // En caso de un error se realiza un rollback a la transacción

                    transaccion.Rollback();
                }
                catch (Exception)
                {
                }
                finally
                {
                    confirmacion = "Ocurrió un error y no se pudo actualizar la agenda";
                }
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return confirmacion;
        }


    }
}
