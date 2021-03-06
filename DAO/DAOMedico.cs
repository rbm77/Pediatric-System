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
    public class DAOMedico
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /// <summary>
        /// Inserta un Medico en la ase de datos
        /// </summary>
        /// <param name="miTOMedico">Recibe los un objeto con los datos del medico que se desea ingresar</param>
        public void insertarMedico(TOMedico miTOMedico)
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
            SqlTransaction transaccion = null;
            //  string confirmacion = "El Medico se ingresó exitosamente en el sistema";
            try
            {
                transaccion = conexion.BeginTransaction("Insertar nuevo Medico");
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
                    // confirmacion = "Ocurrió un error y no se pudo ingresar el medico";
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

        public string buscarNombreMedico(string codigoMedico, TOMedico medico)
        {
            string confirmacion = "El nombre del doctor no fue encontrado";

            //Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo obtener el nombre del doctor";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo obtener el nombre del doctor";
                return confirmacion;
            }

            // Iniciar nueva transaccion 
            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Buscar nombre doctor");

                SqlCommand comando = new SqlCommand("SELECT * FROM MEDICO WHERE CODIGO_MEDICO = @codMed", conexion);

                comando.Transaction = transaccion;
                comando.Parameters.AddWithValue("@codMed", codigoMedico);

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        medico.nombre = lector["NOMBRE"].ToString();
                        medico.apellido = lector["APELLIDO"].ToString();
                    }
                }

                lector.Close();
                transaccion.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaccion.Rollback();
                }
                catch (Exception)
                {
                }
                finally
                {
                    confirmacion = "Ocurrió un error y no se pudo obtener el nombre del doctor";
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


        /// <summary>
        /// Busca un medico dentro de la base de datos segun un correo
        /// </summary>
        /// <param name="miTOMedico">Recibe un objeto que contiene los atributos de la cuenta que se desea buscar</param>

        public void buscarMedico(TOMedico miTOMedico)
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

            SqlTransaction transaccion = null;
            // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {
                transaccion = conexion.BeginTransaction("Buscar Medico");
                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT * FROM MEDICO WHERE CUE_CORREO = @cor;", conexion);

                comando.Parameters.AddWithValue("@cor", miTOMedico.correo);

                comando.Transaction = transaccion;

                // Se asigna un valor a los parámetros del comando a ejecutar



                // Se ejecuta el comando y se realiza un commit de la transacción

                SqlDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    // Se asignado los valores a un objeto segun los atributos seleccionados 
                    while (lector.Read())
                    {
                        miTOMedico.nombre = lector["NOMBRE"].ToString();
                        miTOMedico.apellido = lector["APELLIDO"].ToString();
                        miTOMedico.cedula = Int32.Parse(lector["CEDULA"].ToString());
                        miTOMedico.telefono = Int32.Parse(lector["TELEFONO"].ToString());
                        miTOMedico.codigo = lector["CODIGO_MEDICO"].ToString();
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
                // Se finaliza la conexion
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

        }

        /// <summary>
        /// Edita los datos de un medico dentro de la base de datos
        /// </summary>
        /// <param name="miTOMedico">Recibe un objeto que posee los atributos de la cuetna que se desea editar</param>
        public void editarMedico(TOMedico miTOMedico)
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

            SqlTransaction transaccion = null;
            // string confirmacion = "El Medico se ingresó exitosamente en el sistema";

            try
            {
                conexion.BeginTransaction("Insertar nuevo Medico");
                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("UPDATE MEDICO SET NOMBRE = @nom, APELLIDO = @ape, Cedula = @ced, Telefono = @tel WHERE CUE_CORREO = @cor;", conexion);


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
                    //  confirmacion = "Ocurrió un error y no se pudo ingresar el medico";
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

        /// <summary>
        /// Carga la lista de medicos disponibles para atender consultas
        /// </summary>
        /// <param name="toLista"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si se realizo la transaccion</returns>
        public string CargarMedicos(List<TOMedico> toLista)
        {
            string confirmacion = "La lista de médicos se cargó exitosamente";

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
                    confirmacion = "Ocurrió un error y no se pudo cargar la lista de médicos";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar la lista de médicos";
                return confirmacion;
            }

            // Se inicia una nueva transacción

            SqlTransaction transaccion = null;



            try
            {
                transaccion = conexion.BeginTransaction("Cargar la lista de médicos");
                // Se crea un nuevo comando con la secuencia SQL y el objeto de conexión

                SqlCommand comando = new SqlCommand("SELECT CODIGO_MEDICO, NOMBRE, APELLIDO FROM MEDICO;", conexion);


                comando.Transaction = transaccion;

                // Se ejecuta el comando 

                SqlDataReader lector = comando.ExecuteReader();

                // Se lee el dataReader con los registros obtenidos y se cargan los datos en la lista de citas

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOMedico medico = new TOMedico(lector["CODIGO_MEDICO"].ToString(), lector["NOMBRE"].ToString(),
                            lector["APELLIDO"].ToString());

                        toLista.Add(medico);

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
                    confirmacion = "Ocurrió un error y no se pudo cargar la lista de médicos";
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
