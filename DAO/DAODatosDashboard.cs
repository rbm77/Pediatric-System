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
   public class DAODatosDashboard
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);





        public void buscarDatos(TODatosDashboard miTODatos, String codigoMedico)
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

            SqlTransaction transaccion = conexion.BeginTransaction("Buscar Datos DashBoard");
            // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {
                SqlCommand comando = new SqlCommand("Select COUNT(codigo_expediente) from EXPEDIENTE", conexion);
                comando.Transaction = transaccion;
                miTODatos.cantidadExpedientes = (int)comando.ExecuteScalar() + "";


                SqlCommand comando2 = new SqlCommand("Select count('Codigo_medico') from cita where fecha = CAST(GETDATE() AS DATE) and Hora > FORMAT(DATEADD(HOUR, +1, GETDATE()),'h:mm tt') and Codigo_Medico = @cod;", conexion);
                comando2.Parameters.AddWithValue("@cod", codigoMedico);
                comando2.Transaction = transaccion;

                miTODatos.cantidadCitasPendientes = (int)comando2.ExecuteScalar() + "";

                SqlCommand comando3 = new SqlCommand("Select COUNT(CODIGO_EXPEDIENTE) from CONSULTA Where Estado = 1", conexion);
                comando3.Transaction = transaccion;
                miTODatos.cantidadConsultasActivas = (int)comando3.ExecuteScalar() + "";


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
    }
}
