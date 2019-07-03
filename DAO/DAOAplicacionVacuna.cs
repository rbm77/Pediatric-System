﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAOAplicacionVacuna
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
        public string CargarAplicaciones(List<TOAplicacionVacuna> aplicaciones, string idExpediente)
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

                SqlCommand comando = new SqlCommand("SELECT * FROM APLICACION_VACUNA WHERE ID_EXPEDIENTE = @idExpediente", conexion);


                comando.Transaction = transaccion;

                comando.Parameters.AddWithValue("@idExpediente", idExpediente);


                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de vacunas

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOAplicacionVacuna aplicacion = new TOAplicacionVacuna(lector["ID_EXPEDIENTE"].ToString(), lector["NOMBRE_VACUNA"].ToString(), Convertir(lector["APLICACION1"].ToString()),
                            Convertir(lector["APLICACION2"].ToString()), Convertir(lector["APLICACION3"].ToString()),
                            Convertir(lector["REFUERZO1"].ToString()), Convertir(lector["REFUERZO2"].ToString()),
                            Convertir(lector["REFUERZO3"].ToString()));

                        aplicaciones.Add(aplicacion);

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

        private bool Convertir(string binario)
        {
            if (int.Parse(binario) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
