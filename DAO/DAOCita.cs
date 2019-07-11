using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAOCita
    {
        //Se establece la propiedad de conexion con la base de datos
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Ingresa una nueva cita al sistema
        /// </summary>
        /// <param name="nuevaCita">Nueva Cita</param>
        /// <returns>Retorna un mensaje de confirmación indicando si se realizó la transacción</returns>
        public string CrearCita(TOCita nuevaCita)
        {
            string confirmacion = "La cita se ingresó exitosamente en el sistema";

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar la cita en el sistema";
                    return confirmacion;

                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo ingresar la cita en el sistema";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Ingresar nueva cita");



            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("INSERT INTO CITA (CODIGO_MEDICO, NOMBRE, EDAD, CORREO," +
                "TELEFONO, FECHA, HORA) VALUES (@cod, @nom, @edad, @correo, @tel, @fecha, @hora);", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cod", nuevaCita.CodigoMedico);
                comando.Parameters.AddWithValue("@nom", nuevaCita.Nombre);
                comando.Parameters.AddWithValue("@edad", nuevaCita.Edad);
                comando.Parameters.AddWithValue("@correo", nuevaCita.Correo);
                comando.Parameters.AddWithValue("@tel", nuevaCita.Telefono);
                comando.Parameters.AddWithValue("@fecha", DateTime.Parse(nuevaCita.Fecha));
                comando.Parameters.AddWithValue("@hora", nuevaCita.Hora);

                // Se ejecuta el comando y se realiza un commit de la transacción

                comando.ExecuteNonQuery();

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar la cita en el sistema";
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
        /// Obtiene una lista de citas de la base de datos
        /// </summary>
        /// <param name="toLista">Lista de citas</param>
        /// <param name="codigoMedico">Codigo del medico</param>
        /// <param name="fecha">Fecha de la cita</param>
        /// <returns>Retorna un mensaje de confirmacion indicando si la transaccion se realizo</returns>
        public string CargarHorasCita(List<TOCita> toLista, string codigoMedico, string fecha)
        {
            string confirmacion = "Las citas se cargaron exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar las citas";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar horas de citas");



            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT HORA FROM CITA WHERE CODIGO_MEDICO = @cod AND FECHA = @fecha;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cod", codigoMedico);
                comando.Parameters.AddWithValue("@fecha", DateTime.Parse(fecha));

                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de citas

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOCita cita = new TOCita(lector["HORA"].ToString());

                        toLista.Add(cita);

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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
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
        /// Elimina una cita de la base de datos
        /// </summary>
        /// <param name="codigoMedico"></param>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CancelarCita(string codigoMedico, string fecha, string hora)
        {


            string confirmacion = "La cita se canceló exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cancelar la cita";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cancelar la cita";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cancelar cita");


            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                string sentencia = "DELETE FROM CITA WHERE CODIGO_MEDICO = @codigo AND FECHA = @fecha AND HORA = @hora;";

                SqlCommand comando = new SqlCommand(sentencia, conexion);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar y se ejecuta el comando

                comando.Parameters.AddWithValue("@codigo", codigoMedico);
                comando.Parameters.AddWithValue("@fecha", DateTime.Parse(fecha));
                comando.Parameters.AddWithValue("@hora", hora);

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
                    confirmacion = "Ocurrió un error y no se pudo cancelar la cita";
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
        /// Cargan las citas para mostrar en la agenda del medico
        /// </summary>
        /// <param name="toLista"></param>
        /// <param name="codigoMedico"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string CargarCitas(List<TOCita> toLista, string codigoMedico, string fecha)
        {
            string confirmacion = "Las citas se cargaron exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar las citas";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar cita");



            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM CITA WHERE CODIGO_MEDICO = @cod AND FECHA = @fecha;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cod", codigoMedico);
                comando.Parameters.AddWithValue("@fecha", DateTime.Parse(fecha));

                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de citas

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOCita cita = new TOCita(lector["CODIGO_MEDICO"].ToString(), lector["NOMBRE"].ToString(),
                            lector["EDAD"].ToString(), lector["CORREO"].ToString(),
                            int.Parse(lector["TELEFONO"].ToString()), ((DateTime)lector["FECHA"]).ToShortDateString(),
                            lector["HORA"].ToString());

                        toLista.Add(cita);

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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
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
        /// Carga las citas pendientes que se mostraran al usuario
        /// </summary>
        /// <param name="listaNombres"></param>
        /// <param name="listaCitas"></param>
        /// <param name="cuenta"></param>
        /// <returns>Retorna un mensaje de confirmacion de la transaccion</returns>
        public string CargarCitasUsuario(List<TOCita> listaCitas, string cuenta)
        {
            string confirmacion = "Las citas se cargaron exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar las citas";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar citas");



            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT T3.CODIGO_MEDICO, T3.NOMBRE AS 'NOMBRE_MEDICO', T3.APELLIDO  AS 'APELLIDO_MEDICO', T1.FECHA, T1.NOMBRE AS 'NOMBRE_PACIENTE', T1.HORA  FROM CITA T1, EXPEDIENTE T2, MEDICO T3 WHERE T1.NOMBRE = T2.NOMBRE + ' ' + T2.PRIMER_APELLIDO + ' ' + T2.SEGUNDO_APELLIDO AND T2.CORREO = @cuenta AND T3.CODIGO_MEDICO = T1.CODIGO_MEDICO AND T1.FECHA >= CONVERT(date, GETDATE());", conexion);


                comando.Transaction = transaccion;

                    comando.Parameters.AddWithValue("@cuenta", cuenta);

                    // Se ejecuta el comando 

                    SqlDataReader lector = comando.ExecuteReader();

                    // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de citas

                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            TOCita cita = new TOCita(lector["CODIGO_MEDICO"].ToString(), lector["NOMBRE_MEDICO"].ToString() + " " +
                                lector["APELLIDO_MEDICO"].ToString(), lector["NOMBRE_PACIENTE"].ToString(),
                                ((DateTime)lector["FECHA"]).ToShortDateString(),
                                lector["HORA"].ToString());

                                listaCitas.Add(cita);
                                                     
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
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
        /// Carga la lista de pacientes que pertenecen a una misma cuenta
        /// </summary>
        /// <param name="listaPacientes"></param>
        /// <param name="cuenta"></param>
        /// <returns>Retorna un mensaje de confirmacion</returns>
        public string CargarPacientes(List<TOPacienteCita> listaPacientes, string cuenta)
        {
                string confirmacion = "La lista de pacientes se cargó exitosamente";

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
                        confirmacion = "Ocurrió un error y no se pudo cargar la lista de pacientes";
                        return confirmacion;
                    }
                }
                else
                {
                    confirmacion = "Ocurrió un error y no se pudo cargar la lista de pacientes";
                    return confirmacion;
                }

                // Se inicia una nueva transacción

                SqlTransaction transaccion = conexion.BeginTransaction("Cargar la lista de pacientes");



                try
                {

                    // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                    SqlCommand comando = new SqlCommand("SELECT T1.NOMBRE, T1.PRIMER_APELLIDO, T1.SEGUNDO_APELLIDO," +
                        " T1.FECHA_NACIMIENTO, T2.CORREO, T2.TELEFONO FROM EXPEDIENTE T1, ENCARGADO T2 " +
                        " WHERE T1.CORREO = @cuenta AND " +
                        "T1.CODIGO_EXPEDIENTE = T2.CODIGO_EXPEDIENTE;", conexion);


                    comando.Transaction = transaccion;

                comando.Parameters.AddWithValue("@cuenta", cuenta);

                    // Se ejecuta el comando 

                    SqlDataReader lector = comando.ExecuteReader();

                    // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de pacientes

                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            TOPacienteCita paciente = new TOPacienteCita(lector["NOMBRE"].ToString() + " " + lector["PRIMER_APELLIDO"].ToString() + " " + 
                                lector["SEGUNDO_APELLIDO"].ToString(), ((DateTime)lector["FECHA_NACIMIENTO"]).ToShortDateString(), lector["CORREO"].ToString(), lector["TELEFONO"].ToString());

                            listaPacientes.Add(paciente);

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
                        confirmacion = "Ocurrió un error y no se pudo cargar la lista de pacientes";
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
