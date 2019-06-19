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
    public class DAOExpediente
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public string CrearExpediente (TOExpediente nuevoExpediente)
        {
            // Abrir la conexion
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Iniciar nueva transaccion 
            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo expediente");
            string confirmacion = "El expediente se ingreso exitosamente en el sistema";

            try
            {

                // Crear nuevo comando con la sencuencia SQL y el objeto de conexion
                SqlCommand comando = new SqlCommand("INSERT INTO EXPEDIENTE (CEDULA_EXPEDIENTE, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, SEXO, FECHA_NACIMIENTO, FOTO, EXPEDIENTE_ANTIGUO)" +
                    "VALUES (@ced, @nom, @priAp, @segAp, @sexo, @naci, @foto, @expAnt);", conexion);

                comando.Transaction = transaccion;
                // Asignar un valor a los parametros del comando a ejecutar

                comando.Parameters.AddWithValue("@ced", nuevoExpediente.Cedula);
                comando.Parameters.AddWithValue("@nom", nuevoExpediente.Nombre);
                comando.Parameters.AddWithValue("@priAp", nuevoExpediente.PrimerApellido);
                comando.Parameters.AddWithValue("@segAp", nuevoExpediente.SegundoApellido);
                comando.Parameters.AddWithValue("@sexo", nuevoExpediente.Sexo);
                comando.Parameters.AddWithValue("@naci", nuevoExpediente.FechaNacimiento);
                comando.Parameters.AddWithValue("@foto", nuevoExpediente.Foto);
                comando.Parameters.AddWithValue("@exoAnt", nuevoExpediente.ExpedienteAntiguo);

                // Ejecutar comando y realizar commit de la transaccion 
                comando.ExecuteNonQuery();
                transaccion.Commit();
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
    }
}
