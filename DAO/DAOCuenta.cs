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
    public class DAOCuenta
    {
        List<TOCuenta> lista = new List<TOCuenta>();
        //Se establece la propiedad de conexion con la base de datos
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Busca que el correo y la contraseña de una cuenta coincida
        /// </summary>
        /// <param name="myTOCuenta">Se recibe un objeto que contiene los datos a buscar</param>
        public void buscarCuentaConContraseña(TOCuenta myTOCuenta)
        {
            // Se abre la conexión
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            SqlTransaction transaccion = conexion.BeginTransaction("Buscar Cuenta con Contraseña");
            try
            {

                SqlCommand comando = new SqlCommand("select * from Cuenta where CORREO = @Correo and CONTRASENA = @Contraseña", conexion);
                comando.Transaction = transaccion;

                // Asignar un valor a los parametros del comando a ejecutar

                comando.Parameters.AddWithValue("@Correo", myTOCuenta.correo);
                comando.Parameters.AddWithValue("@Contraseña", myTOCuenta.contrasena);

                // Ejecutar comando y realizar commit de la transaccion 
                comando.ExecuteNonQuery();
                transaccion.Commit();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    myTOCuenta.estado = reader["ESTADO"].ToString();
                    myTOCuenta.tipo = reader["TIPO"].ToString();
                }
            }
            catch (Exception)
            {
                try
                {
                    // Realizar rollback a la transaccion
                    transaccion.Rollback();
                }
                catch (Exception)
                {

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
        /// Sustituye la contraseña por un valor aleatorio que es enviado por mensaje de correo
        /// </summary>
        /// <param name="myTOCuenta">Recibe un objeto con los atributos de la cuenta que se desea modificar</param>
        public void recuperarContraseña(TOCuenta myTOCuenta)
        {
            //Comando de actualizacion
            string sql = "update CUENTA set CONTRASENA = @Contraseña where CORREO = @Correo";
            SqlCommand command = new SqlCommand(sql, conexion);

            // Asignar un valor a los parametros del comando a ejecutar
            command.Parameters.AddWithValue("@Correo", myTOCuenta.correo);
            command.Parameters.AddWithValue("@Contraseña", myTOCuenta.contrasena);

            // Se abre la conexion
            conexion.Open();

            // Se ejecuta el comando
            command.ExecuteNonQuery();

            //Se cierra la conexion
            conexion.Close();
        }


        /// <summary>
        /// Edita la contraseña de una cuenta segun la nueva contraseña ingresada
        /// </summary>
        /// <param name="miTOCuenta">Recibe un objeto con los atributos de la cuenta que se desea modificar</param>
        public void editarContrasena(TOCuenta miTOCuenta)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Editar contraseña");

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("UPDATE CUENTA SET CONTRASENA = @con WHERE CORREO = @cor;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miTOCuenta.correo);
                comando.Parameters.AddWithValue("@con", miTOCuenta.contrasena);

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
                }
            }
            finally
            {
                //Se finaliza la conezion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// Inserta una cuenta a la base de datos
        /// </summary>
        /// <param name="miTOCuenta">Recibe un objeto que posee los atributos de la cuenta</param>
        /// <returns>Retorna un mensaje para confirmar la insercion de la cuenta</returns>
        public string InsertarCuenta(TOCuenta miTOCuenta)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nueva cuenta");
            string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("INSERT INTO CUENTA (Correo, Contrasena, Tipo, Estado) VALUES (@cor, @con, @tip, @est);", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miTOCuenta.correo);
                comando.Parameters.AddWithValue("@con", miTOCuenta.contrasena);
                comando.Parameters.AddWithValue("@tip", miTOCuenta.tipo);
                comando.Parameters.AddWithValue("@est", miTOCuenta.estado);

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar la cuenta";
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
            return confirmacion;
        }

        /// <summary>
        /// Revisa que la contraseña recibida concida con los datos de la cuenta
        /// </summary>
        /// <param name="miTOCuenta">Se recibe un objeto con los atributos de la cuenta que interesa validad</param>
        /// <returns>Retorna un valor booleano segun sea que la contraseña coincida o no</returns>
        public Boolean revisarContrasena(TOCuenta miTOCuenta)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Revisar Contraseña");
            Boolean valor = false;
            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT CONTRASENA FROM CUENTA WHERE CORREO = @cor;", conexion);


                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miTOCuenta.correo);




                // Se ejecuta el comando y se realiza un commit de la transacción

                comando.ExecuteNonQuery();

                transaccion.Commit();


                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["CONTRASENA"].ToString() == miTOCuenta.contrasena)
                    {
                        valor = true;
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
                // Se finaliza la conezion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return valor;
        }

        /// <summary>
        /// Busca los datos de una cuenta segun el correo ingresado
        /// </summary>
        /// <param name="miTOCuenta">Se recibe un ojbeto con el atributo de correo</param>
        public void buscarCuentaPorCorreo(TOCuenta miTOCuenta)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Revisar Contraseña");
            Boolean valor = false;
            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM CUENTA WHERE CORREO = @cor;", conexion);

                comando.Parameters.AddWithValue("@cor", miTOCuenta.correo);

                comando.Transaction = transaccion;


                // Se ejecuta el comando y se realiza un commit de la transacción


                SqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    // Se asignado los valores a un objeto segun los atributos seleccionados 
                    while (lector.Read())
                    {
                        miTOCuenta.tipo = lector["TIPO"].ToString();
                        miTOCuenta.estado = lector["ESTADO"].ToString();
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
                // Se finaliza la conezion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// Edita la contraseña de una cuenta segun la nueva contraseña ingresada
        /// </summary>
        /// <param name="miTOCuenta">Recibe un objeto con los atributos de la cuenta que se desea modificar</param>
        public void editarEstado(TOCuenta miTOCuenta, String Accion)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Editar estado");

            try
            {
                SqlCommand comando;
                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                if (Accion == "Habilitar") {
                comando = new SqlCommand("UPDATE CUENTA SET ESTADO = 'Habilitada' WHERE CORREO = @cor;", conexion);
                } else
                {
                comando = new SqlCommand("UPDATE CUENTA SET ESTADO = 'Deshabilitada' WHERE CORREO = @cor;", conexion);
                }

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar

                comando.Parameters.AddWithValue("@cor", miTOCuenta.correo);

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
                }
            }
            finally
            {
                //Se finaliza la conezion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }



        public List<TOCuenta> buscarListaPacientes()
        {

            // Se abre la conexión
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Buscar Lista");
            //string confirmacion = "La cita se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM CUENTA WHERE TIPO = 'Paciente'", conexion);

                comando.Transaction = transaccion;
                // Se ejecuta el comando y se realiza un commit de la transacción

                comando.ExecuteNonQuery();

                transaccion.Commit();


                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    // Añade una cuenta a la lista por cada una de las encontrada en la base de datos
                    while (reader != null && reader.Read())
                    {
                        TOCuenta miTOCuenta = new TOCuenta();
                        miTOCuenta.correo = reader["CORREO"].ToString();
                        lista.Add(miTOCuenta);
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
