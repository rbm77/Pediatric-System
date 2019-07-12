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
    public class DAOExamenLaboratorio
    {
        //Se establece la propiedad de conexion con la base de datos
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Ingresa un nuevo examen de laboratorio
        /// </summary>
        /// <param name="examen"></param>
        /// <returns>Retorna un mensaje de confirmación indicando si se realizó la transacción</returns>
        public string IngresarExamenLaboratorio(TOExamenLaboratorio examen)
        {
            string confirmacion = "El examen de laboratorio se ingresó exitosamente en el sistema";

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar el examen en el sistema";
                    return confirmacion;

                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo ingresar el examen en el sistema";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = null;



            try
            {
                transaccion = conexion.BeginTransaction("Ingresar nuevo examen");
                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("INSERT INTO EXAMENES_LABORATORIO (ID_EXPEDIENTE, FECHA, UBICACION_ARCHIVO, DESCRIPCION) VALUES (@id, @fecha, @ubicacion, @descripcion);", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@id", examen.IDExpediente);
                comando.Parameters.AddWithValue("@fecha", DateTime.Parse(examen.Fecha));
                comando.Parameters.AddWithValue("@ubicacion", examen.UbicacionArchivo);
                comando.Parameters.AddWithValue("@descripcion", examen.Descripcion);

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar el examen en el sistema";
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

        /// Cargan los examenes para mostrar en la llista
        /// </summary>
        /// <param name="toLista"></param>
        /// <param name="codigoMedico"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public string CargarExamenesLaboratorio(List<TOExamenLaboratorio> toLista, string idExpediente)
        {
            string confirmacion = "Los exámenes se cargaron exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cargar los exámenes";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar los exámenes";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = null;



            try
            {

                transaccion = conexion.BeginTransaction("Cargar exámenes");

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM EXAMENES_LABORATORIO WHERE ID_EXPEDIENTE = @id;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@id", idExpediente);

                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de examenes

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOExamenLaboratorio examen = new TOExamenLaboratorio(lector["ID_EXPEDIENTE"].ToString(), lector["FECHA"].ToString(),
                            lector["UBICACION_ARCHIVO"].ToString(), lector["DESCRIPCION"].ToString());

                        toLista.Add(examen);

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
                    confirmacion = "Ocurrió un error y no se pudo cargar  los exámenes";
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
