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

        public string CargarEsquemaVacunacion(List<TOVacuna> vacunas, List<TOVacuna> aplicaciones, string idExpediente)
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

                comando.CommandText = "SELECT * FROM APLICACION_VACUNA WHERE ID_EXPEDIENTE = @idExpediente";

                comando.Parameters.AddWithValue("@idExpediente", idExpediente);

                SqlDataReader lector2 = comando.ExecuteReader();

                if (lector2.HasRows)
                {
                    while (lector2.Read())
                    {
                        TOVacuna aplicacion = new TOVacuna(lector2["NOMBRE_VACUNA"].ToString(), lector2["APLICACION1"].ToString(),
                            lector2["APLICACION2"].ToString(), lector2["APLICACION3"].ToString(),
                            lector2["REFUERZO1"].ToString(), lector2["REFUERZO2"].ToString(),
                            lector2["REFUERZO3"].ToString());

                        aplicaciones.Add(aplicacion);

                    }
                }
                lector2.Close();

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



        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Antineumocóccica');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Antipolio, inactivada, vía intramuscular (IPV)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Antisarampionosa, rubéola y paperas (SRP)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Antituberculosa (BCG)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'CALOSTRO (primera vacuna)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Haemophilus influenzae. Tipo B.(HIB)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Hepatitis B.(VHB)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Toxoide diftérico, pertusis acelular (DTaP)');
        //INSERT INTO APLICACION_VACUNA(ID_EXPEDIENTE, NOMBRE_VACUNA) VALUES('@ID', 'Varicela');

    }
}
