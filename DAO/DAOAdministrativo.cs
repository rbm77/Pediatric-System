﻿using System;
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
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
        public void insertarAdministrativo(TOAdministrativo miAdministrativo)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Administrativo");
            //string confirmacion = "La cita se ingresó exitosamente en el sistema";

            try
            {

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


        public void editarAdministrativo(TOAdministrativo miAdministrativo)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo Administrativo");
            //string confirmacion = "La cita se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("UPDATE ADMINISTRATIVO SET NOMBRE = @nom, APELLIDO = @ape, Cedula = @ced, Telefono = @tel WHERE CUE_CORREO = @cor;", conexion);


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



        public void buscarAdministrativo(TOAdministrativo miTOAdministrativo)
        {
            // Se abre la conexión

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = conexion.BeginTransaction("Buscar Administrativo");
            // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {

                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM ADMINISTRATIVO WHERE CUE_CORREO = @cor;", conexion);

                comando.Parameters.AddWithValue("@cor", miTOAdministrativo.correo);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar



                // Se ejecuta el comando y se realiza un commit de la transacción

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        miTOAdministrativo.nombre = lector["NOMBRE"].ToString();
                        miTOAdministrativo.apellido = lector["APELLIDO"].ToString();
                        miTOAdministrativo.cedula = Int32.Parse(lector["CEDULA"].ToString());
                        miTOAdministrativo.telefono = Int32.Parse(lector["TELEFONO"].ToString());
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
