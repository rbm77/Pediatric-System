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
  public  class DAOCuenta
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public void buscarCuentaConContraseña(TOCuenta myTOCuenta)
        {
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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }


        public void recuperarContraseña(TOCuenta myTOCuenta)
        {
            string sql = "update CUENTA set CONTRASENA = @Contraseña where CORREO = @Correo";
            SqlCommand command = new SqlCommand(sql, conexion);
            command.Parameters.AddWithValue("@Correo", myTOCuenta.correo);
            command.Parameters.AddWithValue("@Contraseña", myTOCuenta.contrasena);
            conexion.Open();
            command.ExecuteNonQuery();
            //SqlDataReader reader = command.ExecuteReader();
            conexion.Close();
        }



        public void editarContrasena(TOCuenta miTOCuenta)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Editar contraseña");
           // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

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
                  //  confirmacion = "Ocurrió un error y no se pudo ingresar la cuenta";
                }
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
           // return confirmacion;
        }


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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return confirmacion;
        }

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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return valor;
        }





    }
}
