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
    public class DAOVacuna
    {
        //Se establece la propiedad de conexion con la base de datos
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Carga el esquema de vacunacion y las aplicaciones
        /// </summary>
        /// <param name="vacunas"></param>
        /// <param name="aplicaciones"></param>
        /// <param name="idExpediente"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarVacunas(List<TOVacuna> vacunas)
        {
            string confirmacion = "El esquema de vacunación se cargó exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cargar el esquema de vacunación";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar el esquema de vacunación";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar esquema de vacunación");



            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM VACUNA;", conexion);


                comando.Transaction = transaccion;

                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de vacunas

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOVacuna vacuna = new TOVacuna(lector["NOMBRE_VACUNA"].ToString(), lector["APLICACION1"].ToString(),
                            lector["APLICACION2"].ToString(), lector["APLICACION3"].ToString(),
                            lector["REFUERZO1"].ToString(), lector["REFUERZO2"].ToString(),
                            lector["REFUERZO3"].ToString());

                        vacunas.Add(vacuna);

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
                    confirmacion = "Ocurrió un error y no se pudo cargar el esquema de vacunación";
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

        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Antineumocóccica',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Antipolio, inactivada, vía intramuscular (IPV)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Antisarampionosa, rubéola y paperas (SRP)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Antituberculosa (BCG)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'CALOSTRO (primera vacuna)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Haemophilus influenzae. Tipo B.(HIB)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Hepatitis B.(VHB)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Toxoide diftérico, pertusis acelular (DTaP)',0,0,0,0,0,0);
        //INSERT INTO APLICACION_VACUNA VALUES('@ID', 'Varicela',0,0,0,0,0,0);


    }
}
