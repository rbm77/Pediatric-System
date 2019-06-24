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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
       
    }

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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }



    }
}
