using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TO;

namespace DAO
{
    public class DAOPersonal
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
        List<TOPersonal> lista = new List<TOPersonal>();


        /// <summary>
        /// Inserta una cuenta de tipo personal
        /// </summary>
        /// <param name="miTOPersonal">Recibe un objeto que posee los atributos de la cuenta que se desea ingresar</param>
        public void insertarPersonal(TOPersonal miTOPersonal)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Personal");
            //string confirmacion = "La cita se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("INSERT INTO PERSONAL (CUE_Correo, Nombre, Apellido, Cedula,Telefono) VALUES (@cor, @nom, @ape, @ced, @tel);", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miTOPersonal.correo);
                comando.Parameters.AddWithValue("@nom", miTOPersonal.nombre);
                comando.Parameters.AddWithValue("@ape", miTOPersonal.apellido);
                comando.Parameters.AddWithValue("@ced", miTOPersonal.cedula);
                comando.Parameters.AddWithValue("@tel", miTOPersonal.telefono);


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
                    //confirmacion = "Ocurrió un error y no se pudo ingresar el personal";
                }
            }
            finally
            {
                // Finaliza la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }

        /// <summary>
        /// Edita una cuenta de tipo personal
        /// </summary>
        /// <param name="miTOPersonal">Recibe un objeto que posee los atributos de la cuenta que se desea editar</param>
        public void editarPersonal(TOPersonal miTOPersonal)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Personal");
            //string confirmacion = "La cita se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("UPDATE PERSONAL SET NOMBRE = @nom, APELLIDO = @ape, Cedula = @ced, Telefono = @tel WHERE CUE_CORREO = @cor;", conexion);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miTOPersonal.correo);
                comando.Parameters.AddWithValue("@nom", miTOPersonal.nombre);
                comando.Parameters.AddWithValue("@ape", miTOPersonal.apellido);
                comando.Parameters.AddWithValue("@ced", miTOPersonal.cedula);
                comando.Parameters.AddWithValue("@tel", miTOPersonal.telefono);


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
                    //confirmacion = "Ocurrió un error y no se pudo ingresar el personal";
                }
            }
            finally
            {
                // Finaliza la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }


        /// <summary>
        /// Llena una lista con cada una de las cuetnas de tipo personal dentro de la base de datos
        /// </summary>
        /// <returns>Retorna la lista de cuetas de tipo personal</returns>
        public List<TOPersonal> buscarListaPersonal()
        {

            // Se abre la conexión
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Personal");
            //string confirmacion = "La cita se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM PERSONAL", conexion);

                comando.Transaction = transaccion;
                // Se ejecuta el comando y se realiza un commit de la transacción

                comando.ExecuteNonQuery();

                transaccion.Commit();


                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    // Añade una cuenta a la lista por cada una de las encontrada en la base de datos
                    while (reader != null && reader.Read())
                    {
                        TOPersonal miTOPersonal = new TOPersonal();
                        miTOPersonal.correo = reader["CUE_CORREO"].ToString();
                        miTOPersonal.nombre = reader["NOMBRE"].ToString();
                        miTOPersonal.apellido = reader["APELLIDO"].ToString();
                        miTOPersonal.cedula = Int32.Parse(reader["CEDULA"].ToString());
                        miTOPersonal.telefono = Int32.Parse(reader["TELEFONO"].ToString());

                        lista.Add(miTOPersonal);
                    }
                }
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
                    //confirmacion = "Ocurrió un error y no se pudo ingresar el personal";
                }
            }

            finally
            {
                // Finaliza la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return lista;
        }
    }
}
