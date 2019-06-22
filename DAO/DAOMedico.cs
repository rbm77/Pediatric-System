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
        public void insertarMedico(TOMedico miTOMedico)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Medico");
            string confirmacion = "El Medico se ingresó exitosamente en el sistema";

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar el medico";
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
