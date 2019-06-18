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

        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Ingresa una nueva cita al sistema
        /// </summary>
        /// <param name="nuevaCita">Nueva Cita</param>
        /// <returns>Retorna un mensaje de confirmación indicando si se realizó la transacción</returns>
        public string CrearCita(TOCita nuevaCita)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nueva cita");
            string confirmacion = "La cita se ingresó exitosamente en el sistema";

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
                comando.Parameters.AddWithValue("@fecha", nuevaCita.Fecha);
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

        public string CargarCitas(List<TOCita> toLista, string codigoMedico, string fecha)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar citas");
            string confirmacion = "Las citas se cargaron exitosamente";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM CITA WHERE CODIGO_MEDICO = @cod AND FECHA = @fecha;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cod", codigoMedico);
                comando.Parameters.AddWithValue("@fecha", fecha);

                // Se ejecuta el comando y se realiza un commit de la transacción

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOCita cita = new TOCita(lector["CODIGO_MEDICO"].ToString(), lector["NOMBRE"].ToString(), 
                            lector["EDAD"].ToString(), lector["CORREO"].ToString(), 
                            int.Parse(lector["TELEFONO"].ToString()), lector["FECHA"].ToString(),
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

    }
}
