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
    public class DAOAdministrativo
    {
        //Se establece la propiedad de conexion con la base de datos
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Inserta una cuenta de tipo administrativo
        /// </summary>
        /// <param name="miAdministrativo">Parametro con un objeto que posee los datos de la cuenta que 
        /// sera ingresada</param>
        public void insertarAdministrativo(TOAdministrativo miAdministrativo)
        {
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
                    //confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                    //return confirmacion;
                }
            }
            else
            {
                //confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                //return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Insertar nuevo Administrativo");

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión
                SqlCommand comando = new SqlCommand("INSERT INTO ADMINISTRATIVO (CUE_Correo, Nombre, Apellido, Cedula,Telefono) VALUES (@cor, @nom, @ape, @ced, @tel);", conexion);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar
                comando.Parameters.AddWithValue("@cor", miAdministrativo.correo);
                comando.Parameters.AddWithValue("@nom", miAdministrativo.nombre);
                comando.Parameters.AddWithValue("@ape", miAdministrativo.apellido);
                comando.Parameters.AddWithValue("@ced", miAdministrativo.cedula);
                comando.Parameters.AddWithValue("@tel", miAdministrativo.telefono);

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
            }
            finally
            {
                // Finalmente se cietta la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }

        /// <summary>
        /// Edita una cuenta de tipo administrativo segun el parametro de correo
        /// </summary>
        /// <param name="miAdministrativo">Parametro con un objeto que posee los datos de la cuenta que sera ingresada</param>
        public void editarAdministrativo(TOAdministrativo miAdministrativo)
        {
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
                    //confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                    //return confirmacion;
                }
            }
            else
            {
                //confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                //return confirmacion;
            }

            // Se inicia una nueva transacción
            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Insertar nuevo Administrativo");

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión
                SqlCommand comando = new SqlCommand("UPDATE ADMINISTRATIVO SET NOMBRE = @nom, APELLIDO = @ape, Cedula = @ced, Telefono = @tel, Cod_Asist = @cod_asist WHERE CUE_CORREO = @cor;", conexion);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miAdministrativo.correo);
                comando.Parameters.AddWithValue("@nom", miAdministrativo.nombre);
                comando.Parameters.AddWithValue("@ape", miAdministrativo.apellido);
                comando.Parameters.AddWithValue("@ced", miAdministrativo.cedula);
                comando.Parameters.AddWithValue("@tel", miAdministrativo.telefono);
                comando.Parameters.AddWithValue("@cod_asist", miAdministrativo.cod_Asist);
                


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
            }
            finally
            {
                // finalmente se cierra la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }


        /// <summary>
        /// Busca una cuenta de tipo administrativo
        /// </summary>
        /// <param name="miTOAdministrativo">Parametro con un objeto que posee los datos de la cuenta que sera buscada</param>
        public void buscarAdministrativo(TOAdministrativo miTOAdministrativo)
        {
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
                    //confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                    //return confirmacion;
                }
            }
            else
            {
                //confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                //return confirmacion;
            }

            // Se inicia una nueva transacción
            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Buscar Administrativo");

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión
                SqlCommand comando = new SqlCommand("SELECT * FROM ADMINISTRATIVO WHERE CUE_CORREO = @cor;", conexion);

                comando.Parameters.AddWithValue("@cor", miTOAdministrativo.correo);

                comando.Transaction = transaccion;

                // Se ejecuta el comando y se realiza un commit de la transacción

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    //Se asigna los atributos a un objeto
                    while (lector.Read())
                    {
                        miTOAdministrativo.nombre = lector["NOMBRE"].ToString();
                        miTOAdministrativo.apellido = lector["APELLIDO"].ToString();
                        miTOAdministrativo.cedula = Int32.Parse(lector["CEDULA"].ToString());
                        miTOAdministrativo.telefono = Int32.Parse(lector["TELEFONO"].ToString());
                        miTOAdministrativo.cod_Asist = lector["COD_ASIST"].ToString(); 
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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }
    }
}
