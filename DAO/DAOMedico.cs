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
    public class DAOMedico
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Inserta un Medico en la ase de datos
        /// </summary>
        /// <param name="miTOMedico">Recibe los un objeto con los datos del medico que se desea ingresar</param>
        public void insertarMedico(TOMedico miTOMedico)
        {
            // Se abre la conexión
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            // Se inicia una nueva transacción
            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Medico");
            //  string confirmacion = "El Medico se ingresó exitosamente en el sistema";
            try
            {
                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("INSERT INTO MEDICO (Codigo_Medico, CUE_Correo, Nombre, Apellido, Cedula,Telefono, Especialidad) VALUES (@cod, @cor, @nom, @ape, @ced, @tel, @esp);", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cod", miTOMedico.codigo);
                comando.Parameters.AddWithValue("@cor", miTOMedico.correo);
                comando.Parameters.AddWithValue("@nom", miTOMedico.nombre);
                comando.Parameters.AddWithValue("@ape", miTOMedico.apellido);
                comando.Parameters.AddWithValue("@ced", miTOMedico.cedula);
                comando.Parameters.AddWithValue("@tel", miTOMedico.telefono);
                comando.Parameters.AddWithValue("@esp", "Pediatria");

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
                    // confirmacion = "Ocurrió un error y no se pudo ingresar el medico";
                }
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }


        /// <summary>
        /// Busca un medico dentro de la base de datos segun un correo
        /// </summary>
        /// <param name="miTOMedico">Recibe un objeto que contiene los atributos de la cuenta que se desea buscar</param>

        public void buscarMedico(TOMedico miTOMedico)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Buscar Medico");
            // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM MEDICO WHERE CUE_CORREO = @cor;", conexion);

                comando.Parameters.AddWithValue("@cor", miTOMedico.correo);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar



                // Se ejecuta el comando y se realiza un commit de la transacción

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    // Se asignado los valores a un objeto segun los atributos seleccionados 
                    while (lector.Read())
                    {
                        miTOMedico.nombre = lector["NOMBRE"].ToString();
                        miTOMedico.apellido = lector["APELLIDO"].ToString();
                        miTOMedico.cedula = Int32.Parse(lector["CEDULA"].ToString());
                        miTOMedico.telefono = Int32.Parse(lector["TELEFONO"].ToString());
                        miTOMedico.codigo = lector["CODIGO_MEDICO"].ToString();
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
            }
            finally
            {
                // Se finaliza la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }

        /// <summary>
        /// Edita los datos de un medico dentro de la base de datos
        /// </summary>
        /// <param name="miTOMedico">Recibe un objeto que posee los atributos de la cuetna que se desea editar</param>
        public void editarMedico(TOMedico miTOMedico)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Medico");
            // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("UPDATE MEDICO SET NOMBRE = @nom, APELLIDO = @ape, Cedula = @ced, Telefono = @tel WHERE CUE_CORREO = @cor;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cod", miTOMedico.codigo);
                comando.Parameters.AddWithValue("@cor", miTOMedico.correo);
                comando.Parameters.AddWithValue("@nom", miTOMedico.nombre);
                comando.Parameters.AddWithValue("@ape", miTOMedico.apellido);
                comando.Parameters.AddWithValue("@ced", miTOMedico.cedula);
                comando.Parameters.AddWithValue("@tel", miTOMedico.telefono);
                comando.Parameters.AddWithValue("@esp", "Pediatria");

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
                    //  confirmacion = "Ocurrió un error y no se pudo ingresar el medico";
                }
            }
            finally
            {
                // Se finaliza la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }
    }
}
