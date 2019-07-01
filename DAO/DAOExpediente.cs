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

        public string CrearExpediente(TOExpediente nuevoExpediente, TODireccion nuevaDireccionPaciente, TODireccion nuevaDireccionEncargado, TODireccion nuevaDireccionFactura, TOEncargado_Facturante encargado, TOEncargado_Facturante facturante, TOHistoriaClinica nuevaHistoriaClinica1)
        {
            string confirmacion = "El expediente se ingresó correctamente en el sistema";

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar el expediente en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo ingresar el expediente en el sistema";
                return confirmacion;
            }

            // Iniciar nueva transaccion 
            SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo expediente");

            try
            {
                // --------------------------- Insertar en la tabla Direccion (Paciente) ---------------------------  //

                //Crear un nuevo comando para verificar si la direccion ya fue ingresada 
                SqlCommand cmdVerificarDirPaci = new SqlCommand("SELECT CODIGO_DIRECCION FROM DIRECCION WHERE CODIGO_DIRECCION = @cod;", conexion);
                cmdVerificarDirPaci.Transaction = transaccion;
                cmdVerificarDirPaci.Parameters.AddWithValue("@cod", nuevaDireccionPaciente.Codigo);

                object resulVerificarDirPaciente = cmdVerificarDirPaci.ExecuteScalar();

                if(resulVerificarDirPaciente == null)
                {
                    SqlCommand cmdInsertarDirPaciente = new SqlCommand("INSERT INTO DIRECCION (CODIGO_DIRECCION, NOMBRE_PROVINCIA, NOMBRE_CANTON, NOMBRE_DISTRITO)" +
                        "VALUES (@cod, @nomPro, @nomCan, @nomDis);", conexion);

                    cmdInsertarDirPaciente.Transaction = transaccion;

                    cmdInsertarDirPaciente.Parameters.AddWithValue("@cod", nuevaDireccionPaciente.Codigo);
                    cmdInsertarDirPaciente.Parameters.AddWithValue("@nomPro", nuevaDireccionPaciente.Provincia);
                    cmdInsertarDirPaciente.Parameters.AddWithValue("@nomCan", nuevaDireccionPaciente.Canton);
                    cmdInsertarDirPaciente.Parameters.AddWithValue("@nomDis", nuevaDireccionPaciente.Distrito);

                    cmdInsertarDirPaciente.ExecuteNonQuery();
                }

                // --------------------------- Insertar en la tabla Direccion (Encargado)---------------------------  //

                //Crear un nuevo comando para verificar si la direccion ya fue ingresada 
                SqlCommand cmdVerificarDirEncargado = new SqlCommand("SELECT CODIGO_DIRECCION FROM DIRECCION WHERE CODIGO_DIRECCION = @cod;", conexion);
                cmdVerificarDirEncargado.Transaction = transaccion;
                cmdVerificarDirEncargado.Parameters.AddWithValue("@cod", nuevaDireccionEncargado.Codigo);

                object resulVerificarDirEncargado = cmdVerificarDirEncargado.ExecuteScalar();

                if (resulVerificarDirEncargado == null)
                {
                    SqlCommand cmdInsertarDirEncargado = new SqlCommand("INSERT INTO DIRECCION (CODIGO_DIRECCION, NOMBRE_PROVINCIA, NOMBRE_CANTON, NOMBRE_DISTRITO, NOMBRE_BARRIO)" +
                        "VALUES (@cod, @nomPro, @nomCan, @nomDis, @nomBarr);", conexion);

                    cmdInsertarDirEncargado.Transaction = transaccion;

                    cmdInsertarDirEncargado.Parameters.AddWithValue("@cod", nuevaDireccionEncargado.Codigo);
                    cmdInsertarDirEncargado.Parameters.AddWithValue("@nomPro", nuevaDireccionEncargado.Provincia);
                    cmdInsertarDirEncargado.Parameters.AddWithValue("@nomCan", nuevaDireccionEncargado.Canton);
                    cmdInsertarDirEncargado.Parameters.AddWithValue("@nomDis", nuevaDireccionEncargado.Distrito);
                    cmdInsertarDirEncargado.Parameters.AddWithValue("@nomBarr", nuevaDireccionEncargado.Barrio);

                    cmdInsertarDirEncargado.ExecuteNonQuery();
                }

                // --------------------------- Insertar en la tabla Direccion (Facturante) ---------------------------  //

                //Crear un nuevo comando para verificar si la direccion ya fue ingresada 
                SqlCommand cmdVerificarDirFactura = new SqlCommand("SELECT CODIGO_DIRECCION FROM DIRECCION WHERE CODIGO_DIRECCION = @cod;", conexion);
                cmdVerificarDirFactura.Transaction = transaccion;
                cmdVerificarDirFactura.Parameters.AddWithValue("@cod", nuevaDireccionFactura.Codigo);

                object resulVerificarDirFactura = cmdVerificarDirFactura.ExecuteScalar();

                if (resulVerificarDirFactura == null)
                {
                    SqlCommand cmdInsertarDirFactura = new SqlCommand("INSERT INTO DIRECCION (CODIGO_DIRECCION, NOMBRE_PROVINCIA, NOMBRE_CANTON, NOMBRE_DISTRITO, NOMBRE_BARRIO)" +
                        "VALUES (@cod, @nomPro, @nomCan, @nomDis, @nomBarr);", conexion);

                    cmdInsertarDirFactura.Transaction = transaccion;

                    cmdInsertarDirFactura.Parameters.AddWithValue("@cod", nuevaDireccionFactura.Codigo);
                    cmdInsertarDirFactura.Parameters.AddWithValue("@nomPro", nuevaDireccionFactura.Provincia);
                    cmdInsertarDirFactura.Parameters.AddWithValue("@nomCan", nuevaDireccionFactura.Canton);
                    cmdInsertarDirFactura.Parameters.AddWithValue("@nomDis", nuevaDireccionFactura.Distrito);
                    cmdInsertarDirFactura.Parameters.AddWithValue("@nomBarr", nuevaDireccionFactura.Barrio);

                    cmdInsertarDirFactura.ExecuteNonQuery();
                }

                // --------------------------- Insertar en la tabla Expediente ---------------------------  //

                // Crear nuevo comando con la sencuencia SQL y el objeto de conexion
                SqlCommand comandoExp = new SqlCommand("INSERT INTO EXPEDIENTE (CEDULA_EXPEDIENTE, CODIGO_DIRECCION, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, SEXO, FECHA_NACIMIENTO, FOTO, EXPEDIENTE_ANTIGUO)" +
                    "VALUES (@cedPa, @codDir, @nomPa, @priApPa, @segApPa, @sexoPa, @naciPa, @fotoPa, @expAntPa);", conexion);

                comandoExp.Transaction = transaccion;
                // Asignar un valor a los parametros del comando a ejecutar

                comandoExp.Parameters.AddWithValue("@cedPa", nuevoExpediente.Cedula);
                comandoExp.Parameters.AddWithValue("@codDir", nuevoExpediente.Direccion);
                comandoExp.Parameters.AddWithValue("@nomPa", nuevoExpediente.Nombre);
                comandoExp.Parameters.AddWithValue("@priApPa", nuevoExpediente.PrimerApellido);
                comandoExp.Parameters.AddWithValue("@segApPa", nuevoExpediente.SegundoApellido);
                comandoExp.Parameters.AddWithValue("@sexoPa", nuevoExpediente.Sexo);
                comandoExp.Parameters.AddWithValue("@naciPa", nuevoExpediente.FechaNacimiento);
                comandoExp.Parameters.AddWithValue("@fotoPa", nuevoExpediente.Foto);
                comandoExp.Parameters.AddWithValue("@expAntPa", nuevoExpediente.ExpedienteAntiguo);

                comandoExp.ExecuteNonQuery();

                // --------------------------- Insertar en la tabla Encargado ---------------------------  //

                SqlCommand comandoEncar = new SqlCommand("INSERT INTO ENCARGADO (CEDULA_ENCARGADO, CEDULA_EXPEDIENTE, CODIGO_DIRECCION, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, TELEFONO, CORREO, PARENTEZCO)" +
                    "VALUES (@cedEncar, @cedExpe, @codDir, @nom, @priApe, @segApe, @tel, @correo, @paren);", conexion);

                comandoEncar.Transaction = transaccion;

                comandoEncar.Parameters.AddWithValue("@cedEncar", encargado.Cedula);
                comandoEncar.Parameters.AddWithValue("@cedExpe", nuevoExpediente.Cedula);
                comandoEncar.Parameters.AddWithValue("@codDir", encargado.Direccion);
                comandoEncar.Parameters.AddWithValue("@nom", encargado.Nombre);
                comandoEncar.Parameters.AddWithValue("@priApe", encargado.PrimerApellido);
                comandoEncar.Parameters.AddWithValue("@segApe", encargado.SegundoApellido);
                comandoEncar.Parameters.AddWithValue("@tel", encargado.Telefono);
                comandoEncar.Parameters.AddWithValue("@correo", encargado.CorreoElectronico);
                comandoEncar.Parameters.AddWithValue("@paren", encargado.Parentesco);

                comandoEncar.ExecuteNonQuery();

                // --------------------------- Insertar en la tabla Facturante ---------------------------  //

                SqlCommand comandoFactu = new SqlCommand("INSERT INTO FACTURANTE (CEDULA_FACTURANTE, CEDULA_EXPEDIENTE, CODIGO_DIRECCION, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, TELEFONO, CORREO)" +
                    "VALUES (@cedFactu, @cedExpe, @codDir, @nom, @priApe, @segApe, @tel, @correo);", conexion);

                comandoFactu.Transaction = transaccion;

                comandoFactu.Parameters.AddWithValue("@cedFactu", facturante.Cedula);
                comandoFactu.Parameters.AddWithValue("@cedExpe", facturante.Cedula);
                comandoFactu.Parameters.AddWithValue("@codDir", facturante.Direccion);
                comandoFactu.Parameters.AddWithValue("@nom", facturante.Nombre);
                comandoFactu.Parameters.AddWithValue("@priApe", facturante.PrimerApellido);
                comandoFactu.Parameters.AddWithValue("@segApe", facturante.SegundoApellido);
                comandoFactu.Parameters.AddWithValue("@tel", facturante.Telefono);
                comandoFactu.Parameters.AddWithValue("@correo", facturante.CorreoElectronico);

                comandoFactu.ExecuteNonQuery();

                // --------------------------- Insertar en la tabla Antecedentes Perinatales ---------------------------  //

                SqlCommand comandoAntPeri = new SqlCommand("INSERT INTO ANTECEDENTES_PERINATALES (CEDULA_EXPEDIENTE, TALLA_NACIMIENTO, PESO_NACIMIENTO, PERIMETRO_CEFALICO_NACIMIENTO, APGAR, EDAD_GESTACIONAL, CLASI_UNI_RN, OTROS_ESTADO, OTROS_DESCRIPCION)" +
                    "VALUES (@cedAP, @tallaAP, @pesoAP, @periAP, @apgarAP, @edadGesAP, @clasiAP, @otroEstadoAP, @otroDescAP);", conexion);

                comandoAntPeri.Transaction = transaccion;

                comandoAntPeri.Parameters.AddWithValue("@cedAP", nuevaHistoriaClinica1.Cedula);
                comandoAntPeri.Parameters.AddWithValue("@tallaAP", nuevaHistoriaClinica1.AP_Talla);
                comandoAntPeri.Parameters.AddWithValue("@pesoAP", nuevaHistoriaClinica1.AP_Peso);
                comandoAntPeri.Parameters.AddWithValue("@periAP", nuevaHistoriaClinica1.AP_PerimetroCefalico);
                comandoAntPeri.Parameters.AddWithValue("@apgarAP", nuevaHistoriaClinica1.AP_APGAR);
                comandoAntPeri.Parameters.AddWithValue("@edadGesAP", nuevaHistoriaClinica1.AP_EdadGestacional);
                comandoAntPeri.Parameters.AddWithValue("@clasiAP", nuevaHistoriaClinica1.AP_CalificacionUniversal);
                comandoAntPeri.Parameters.AddWithValue("@otroEstadoAP", nuevaHistoriaClinica1.AP_OtrasComplicaciones);
                comandoAntPeri.Parameters.AddWithValue("@otroDescAP", nuevaHistoriaClinica1.AP_OtrasComplicacionesDescripcion);

                comandoAntPeri.ExecuteNonQuery();

                // --------------------------- Insertar en la tabla Antecedentes ---------------------------  //

                SqlCommand comandoAntec = new SqlCommand("INSERT INTO ANTECEDENTES (CEDULA_EXPEDIENTE, APAT_PRESENTE, APAT_DESCRIPCION, AQUIR_PRESENTE, AQUIR_DESCRIPCION, ATRAU_PRESENTE, ATRAU_DESCRIPCION, AHF_ASMA, AHF_DIABETES, AHF_HIPERTENSION " +
                    "AHF_DISPLIDEMIA, AHF_CARDIOVASCULAR, AHF_EPILEPSIA, AHF_OTROS, AHF_OTROS_DESCRIPCION, ALERGIAS_PRESENTE, ALERGIAS_DESCRIPCION)" +
                    "VALUES (@cedANT, @apatPre, @apatDes, @aquirPre, @aquirDes, @atrauPre, @atrauDes, @ahfAsma, @ahfDiab, @ahfHiper, @ahfDispl, @ahfCardi, @ahfEpilep, @ahfOtros, @ahfOtrosDesc, @alergiasPreANT, alergiasDescAnt);", conexion);

                comandoAntec.Transaction = transaccion;

                comandoAntec.Parameters.AddWithValue("@cedANT", nuevaHistoriaClinica1.Cedula);
                comandoAntec.Parameters.AddWithValue("@apatPre", nuevaHistoriaClinica1.APAT_Estado);
                comandoAntec.Parameters.AddWithValue("@apatDes", nuevaHistoriaClinica1.APAT_Descripcion);
                comandoAntec.Parameters.AddWithValue("@aquirPre", nuevaHistoriaClinica1.AQ_Estado);
                comandoAntec.Parameters.AddWithValue("@aquirDes", nuevaHistoriaClinica1.AQ_Descripcion);
                comandoAntec.Parameters.AddWithValue("@atrauPre", nuevaHistoriaClinica1.AT_Estado);
                comandoAntec.Parameters.AddWithValue("@atrauDes", nuevaHistoriaClinica1.AT_Descripcion);
                comandoAntec.Parameters.AddWithValue("@ahfAsma", nuevaHistoriaClinica1.HF_Asma);
                comandoAntec.Parameters.AddWithValue("@ahfDiab", nuevaHistoriaClinica1.HF_Diabetes);
                comandoAntec.Parameters.AddWithValue("@ahfHiper", nuevaHistoriaClinica1.HF_Hipertension);
                comandoAntec.Parameters.AddWithValue("@ahfDispl", nuevaHistoriaClinica1.HF_Displidemia);
                comandoAntec.Parameters.AddWithValue("@ahfCardi", nuevaHistoriaClinica1.HF_Cardivasculares);
                comandoAntec.Parameters.AddWithValue("@ahfEpilep", nuevaHistoriaClinica1.HF_Epilepsia);
                comandoAntec.Parameters.AddWithValue("@ahfOtros", nuevaHistoriaClinica1.HF_Otros);
                comandoAntec.Parameters.AddWithValue("@ahfOtrosDesc", nuevaHistoriaClinica1.HF_DescripcionOtros);
                comandoAntec.Parameters.AddWithValue("@alergiasPreANT", nuevaHistoriaClinica1.Alergias);
                comandoAntec.Parameters.AddWithValue("@alergiasDescAnt", nuevaHistoriaClinica1.AlegergiasDescripcion);

                comandoAntec.ExecuteNonQuery();

                // Realizar commit de la transaccion 

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar el expediente en el sistema";
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
        /// Obtiene la lista de los registros que estan en la tabla Expediente 
        /// </summary>
        /// <param name="toListaExpediente"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si la transaccion se realizo</returns>
        public string CargarListaExpedientes(List<TOExpediente> toListaExpediente)
        {
            string confirmacion = "Los expedientes se cargaron exitosamente";

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
                    confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrio un error y no se pudo cargar los expedientes";
                return confirmacion;
            }

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar Expedientes");

            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM EXPEDIENTE", conexion);

                comando.Transaction = transaccion;

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        TOExpediente expediente = new TOExpediente(lector["NOMBRE"].ToString(), lector["PRIMER_APELLIDO"].ToString(), lector["SEGUNDO_APELLIDO"].ToString(), lector["CEDULA_EXPEDIENTE"].ToString(),
                            DateTime.Parse(lector["FECHA_NACIMIENTO"].ToString()), lector["SEXO"].ToString(), (byte[])lector["FOTO"], lector["EXPEDIENTE_ANTIGUO"].ToString(), lector["CODIGO_DIRECCION"].ToString());
                        toListaExpediente.Add(expediente);
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las citas";
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
        /// Obtiene la informacion de las tablas EXPEDIENTE, ENCARGADO, FACTURANTE, DIRECCION, ANTECEDENTES Y ANTECEDENTES PERINATALES que se encuentran en la BD y se asignan a los respectivos objetos que se reciben por parametro
        /// </summary>
        /// <param name="cedulaBuscar"></param>
        /// <param name="expediente"></param>
        /// <param name="direccionPaciente"></param>
        /// <param name="encargado"></param>
        /// <param name="direccionEncargado"></param>
        /// <param name="facturante"></param>
        /// <param name="direccionFacturante"></param>
        /// <param name="historiaClinica"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si la transaccion se realizo</returns>
        public string CargarExpediente(string cedulaBuscar, TOExpediente expediente, TODireccion direccionPaciente, TOEncargado_Facturante encargado, TODireccion direccionEncargado,  TOEncargado_Facturante facturante, TODireccion direccionFacturante, TOHistoriaClinica historiaClinica)
        {
            string confirmacion = "El expediente se cargó correctamente";

            //Abrir la conexion 
            if (conexion != null)
            {
                try
                {
                    if(conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                }
                catch (Exception)
                {
                    confirmacion = "Ocurrió un error y se pudo cargar el expediente";
                    return confirmacion;    
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y se pudo cargar el expediente";
                return confirmacion;
            }
                        
            //Se inicia una nueva transaccion  
            SqlTransaction transaccion = conexion.BeginTransaction("Mostrar expediente completo");

            try
            {

                // --------------------------- Buscar en la tabla Expediente ---------------------------  //

                //Se crea un nuveo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoExp = new SqlCommand("SELECT * FROM EXPEDIENTE WHERE CEDULA_EXPEDIENTE = @ced", conexion);
                comandoExp.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoExp.Parameters.AddWithValue("@ced", cedulaBuscar);

                // Ejecutar el comando

                SqlDataReader lectorExp = comandoExp.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOExpediente

                if (lectorExp.HasRows)
                {
                    while (lectorExp.Read())
                    {
                        expediente.Cedula = lectorExp["CEDULA_EXPEDIENTE"].ToString();
                        expediente.Nombre = lectorExp["NOMBRE"].ToString();
                        expediente.PrimerApellido = lectorExp["PRIMER_APELLIDO"].ToString();
                        expediente.SegundoApellido = lectorExp["SEGUNDO_APELLIDO"].ToString();
                        expediente.FechaNacimiento = DateTime.Parse(lectorExp["FECHA_NACIMIENTO"].ToString());
                        expediente.Sexo = lectorExp["SEXO"].ToString();
                        expediente.Foto = (byte[])lectorExp["FOTO"];
                        expediente.ExpedienteAntiguo = lectorExp["EXPEDIENTE_ANTIGUO"].ToString();
                        expediente.Direccion = lectorExp["CODIGO_DIRECCION"].ToString();
                    }
                }
                lectorExp.Close();

                // --------------------------- Buscar en la tabla Direccion (Paciente)  ---------------------------  //

                //Obtener el codigo de la direccion de la tabla Expediente
                string expDir = expediente.Direccion;

                //Se crea un nuevo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoDirExp = new SqlCommand("SELECT * FROM DIRECCION WHERE CODIGO_DIRECCION = @cod", conexion);
                comandoDirExp.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoDirExp.Parameters.AddWithValue("@cod", expDir);

                // Ejecutar el comando

                SqlDataReader lectorDirExp = comandoDirExp.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOExpediente

                if (lectorDirExp.HasRows)
                {
                    while (lectorDirExp.Read())
                    {
                        direccionPaciente.Codigo = lectorDirExp["CODIGO_DIRECCION"].ToString();
                        direccionPaciente.Provincia = lectorDirExp["NOMBRE_PROVINCIA"].ToString();
                        direccionPaciente.Canton = lectorDirExp["NOMBRE_CANTON"].ToString();
                        direccionPaciente.Distrito = lectorDirExp["NOMBRE_DISTRITO"].ToString();
                    }
                }
                lectorDirExp.Close();


                // --------------------------- Buscar en la tabla Encargado ---------------------------  //

                //Se crea un nuveo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoEncar = new SqlCommand("SELECT * FROM ENCARGADO WHERE CEDULA_EXPEDIENTE = @ced", conexion);
                comandoEncar.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoEncar.Parameters.AddWithValue("@ced", cedulaBuscar);

                // Ejecutar el comando

                SqlDataReader lectorEncar = comandoEncar.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOExpediente

                if (lectorEncar.HasRows)
                {
                    while (lectorEncar.Read())
                    {
                        encargado.Cedula = lectorEncar["CEDULA_ENCARGADO"].ToString();
                        encargado.Nombre = lectorEncar["NOMBRE"].ToString();
                        encargado.PrimerApellido = lectorEncar["PRIMER_APELLIDO"].ToString();
                        encargado.SegundoApellido = lectorEncar["SEGUNDO_APELLIDO"].ToString();
                        encargado.Telefono = (Decimal)lectorEncar["TELEFONO"];
                        encargado.CorreoElectronico = lectorEncar["CORREO"].ToString();
                        encargado.Parentesco = lectorEncar["PARENTESCO"].ToString();
                        encargado.Direccion = lectorEncar["CODIGO_DIRECCION"].ToString();
                    }
                }
                lectorEncar.Close();

                // --------------------------- Buscar en la tabla Direccion (Encargado) ---------------------------  //

                //Obtener el codigo de la direccion de la tabla Encargado
                string encarDir = encargado.Direccion;

                //Se crea un nuevo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoDirEncar = new SqlCommand("SELECT * FROM DIRECCION WHERE CODIGO_DIRECCION = @cod", conexion);
                comandoDirEncar.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoDirEncar.Parameters.AddWithValue("@cod", encarDir);

                // Ejecutar el comando

                SqlDataReader lectorDirEncar = comandoDirEncar.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOExpediente

                if (lectorDirEncar.HasRows)
                {
                    while (lectorDirEncar.Read())
                    {
                        direccionEncargado.Codigo = lectorDirEncar["CODIGO_DIRECCION"].ToString();
                        direccionEncargado.Provincia = lectorDirEncar["NOMBRE_PROVINCIA"].ToString();
                        direccionEncargado.Canton = lectorDirEncar["NOMBRE_CANTON"].ToString();
                        direccionEncargado.Distrito = lectorDirEncar["NOMBRE_DISTRITO"].ToString();
                        direccionEncargado.Barrio = lectorDirEncar["NOMBRE_BARRIO"].ToString();
                    }
                }
                lectorDirEncar.Close();

                // --------------------------- Buscar en la tabla Facturante ---------------------------  //

                //Se crea un nuveo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoFactu = new SqlCommand("SELECT * FROM FACTURANTE WHERE CEDULA_EXPEDIENTE = @ced", conexion);
                comandoFactu.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoFactu.Parameters.AddWithValue("@ced", cedulaBuscar);

                // Ejecutar el comando

                SqlDataReader lectorFactu = comandoFactu.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOExpediente

                if (lectorFactu.HasRows)
                {
                    while (lectorFactu.Read())
                    {
                        facturante.Cedula = lectorFactu["CEDULA_FACTURANTE"].ToString();
                        facturante.Nombre = lectorFactu["NOMBRE"].ToString();
                        facturante.PrimerApellido = lectorFactu["PRIMER_APELLIDO"].ToString();
                        facturante.SegundoApellido = lectorFactu["SEGUNDO_APELLIDO"].ToString();
                        facturante.Telefono = (Decimal)lectorFactu["TELEFONO"];
                        facturante.CorreoElectronico = lectorFactu["CORREO"].ToString();
                        facturante.Direccion = lectorFactu["CODIGO_DIRECCION"].ToString();
                    }
                }
                lectorFactu.Close();

                // --------------------------- Buscar en la tabla Direccion (Facturante) ---------------------------  //

                //Obtener el codigo de la direccion de la tabla Facturante
                string factuDir = facturante.Direccion;

                //Se crea un nuevo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoDirFactu = new SqlCommand("SELECT * FROM DIRECCION WHERE CODIGO_DIRECCION = @cod", conexion);
                comandoDirFactu.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoDirFactu.Parameters.AddWithValue("@cod", expDir);

                // Ejecutar el comando

                SqlDataReader lectorDirFactu = comandoDirFactu.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOExpediente

                if (lectorDirFactu.HasRows)
                {
                    while (lectorDirFactu.Read())
                    {
                        direccionEncargado.Codigo = lectorDirFactu["CODIGO_DIRECCION"].ToString();
                        direccionEncargado.Provincia = lectorDirFactu["NOMBRE_PROVINCIA"].ToString();
                        direccionEncargado.Canton = lectorDirFactu["NOMBRE_CANTON"].ToString();
                        direccionEncargado.Distrito = lectorDirFactu["NOMBRE_DISTRITO"].ToString();
                        direccionEncargado.Barrio = lectorDirFactu["NOMBRE_BARRIO"].ToString();
                    }
                }
                lectorDirFactu.Close();

                // --------------------------- Buscar en la tabla Antecedentes ---------------------------  //

                //Se crea un nuveo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoAntece = new SqlCommand("SELECT * FROM ANTECEDENTES WHERE CEDULA_EXPEDIENTE = @ced", conexion);
                comandoAntece.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoAntece.Parameters.AddWithValue("@ced", cedulaBuscar);

                // Ejecutar el comando

                SqlDataReader lectorAntece = comandoAntece.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOHistoriaClinica

                if (lectorAntece.HasRows)
                {
                    while (lectorAntece.Read())
                    {
                        historiaClinica.Cedula = lectorAntece["CEDULA_EXPEDIENTE"].ToString();
                        historiaClinica.APAT_Estado = (Boolean)lectorAntece["APAT_PRESENTE"];
                        historiaClinica.APAT_Descripcion = lectorAntece["APAT_DESCRIPCION"].ToString();
                        historiaClinica.AQ_Estado = (Boolean)lectorAntece["AQUIR_PRESENTE"];
                        historiaClinica.AQ_Descripcion = lectorAntece["AQUIR_DESCRIPCION"].ToString();
                        historiaClinica.AT_Estado = (Boolean)lectorAntece["ATRAU_ESTADO"];
                        historiaClinica.AT_Descripcion = lectorAntece["ATRAU_DESCRIPCION"].ToString();
                        historiaClinica.HF_Asma = (Boolean)lectorAntece["AHF_ASMA"];
                        historiaClinica.HF_Diabetes = (Boolean)lectorAntece["AHF_DIABETES"];
                        historiaClinica.HF_Hipertension = (Boolean)lectorAntece["AHF_HIPERTENSION"];
                        historiaClinica.HF_Displidemia = (Boolean)lectorAntece["AHF_DISPLIDEMIA"];
                        historiaClinica.HF_Cardivasculares = (Boolean)lectorAntece["AHF_CARDIOVASCULAR"];
                        historiaClinica.HF_Epilepsia = (Boolean)lectorAntece["AHF_EPILEPSIA"];
                        historiaClinica.HF_Otros = (Boolean)lectorAntece["AHF_OTROS"];
                        historiaClinica.HF_DescripcionOtros = lectorAntece["AHF_OTROS_DESCRIPCION"].ToString();
                        historiaClinica.Alergias = (Boolean)lectorAntece["ALERGIAS_PRESENTE"];
                        historiaClinica.AlegergiasDescripcion = lectorAntece["ALERGIAS_DESCRIPCION"].ToString();

                    }
                }
                lectorAntece.Close();

                // --------------------------- Buscar en la tabla Antecedentes PERINATALES---------------------------  //

                //Se crea un nuveo comando con la secuencia SQL y el objeto conexion
                SqlCommand comandoAntecePeri = new SqlCommand("SELECT * FROM ANTECEDENTES_PERINATALES WHERE CEDULA_EXPEDIENTE = @ced", conexion);
                comandoAntecePeri.Transaction = transaccion;

                //Asignar un valor a los parametros del comando a ejecutar 
                comandoAntecePeri.Parameters.AddWithValue("@ced", cedulaBuscar);

                // Ejecutar el comando

                SqlDataReader lectorAntecePeri = comandoAntecePeri.ExecuteReader();

                //Leer el dataReader con los registros obtenidos y se cargan los datos en objeto TOHistoriaClinica 

                if (lectorAntecePeri.HasRows)
                {
                    while (lectorAntecePeri.Read())
                    {
                        historiaClinica.AP_Talla = (Decimal)lectorAntecePeri["TALLA_NACIMIENTO"];
                        historiaClinica.AP_Peso = (Decimal)lectorAntecePeri["PESO_NACIMIENTO"];
                        historiaClinica.AP_PerimetroCefalico = (Decimal)lectorAntecePeri["PERIMETRO_CEFALICO"];
                        historiaClinica.AP_APGAR = (Decimal)lectorAntecePeri["APGAR"];
                        historiaClinica.AP_EdadGestacional = (Decimal)lectorAntecePeri["EDAD_GESTACIONAL"];
                        historiaClinica.AP_CalificacionUniversal = lectorAntecePeri["CLASI_UNI_RN"].ToString();
                        historiaClinica.AP_OtrasComplicaciones = (Boolean)lectorAntecePeri["OTROS_ESTADO"];
                        historiaClinica.AP_OtrasComplicacionesDescripcion = lectorAntecePeri["OTROS_DESCRIPCION"].ToString();

                    }
                }

                lectorAntecePeri.Close();

                //Realizar el commit de la transaccion
                transaccion.Commit();

            }
            catch (Exception)
            {
                try
                {
                    //En caso de error se realiza un rollback a la transaccion
                    transaccion.Rollback();
                }
                catch (Exception)
                {

                }
                finally
                {
                    confirmacion = "Ocurrió un error y no se pudo cargar el expdiente";
                }
            }
            finally
            {
                if(conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return confirmacion;
        }

    }
}

/// <summary>
/// Insertar un objeto expediente en la BD
/// </summary>
/// <param name="nuevoExpediente"></param>
/// <returns>Retorna un mensaje de confirmacion indicando si la transaccion se realizo</returns>
//public string CrearExpediente(TOExpediente nuevoExpediente)
//{
//    string confirmacion = "El expediente se ingresó correctamente en el sistema";

//    // Abrir la conexion
//    if (conexion != null)
//    {
//        try
//        {
//            if (conexion.State != ConnectionState.Open)
//            {
//                conexion.Open();
//            }
//        }
//        catch (Exception)
//        {
//            confirmacion = "Ocurrió un error y no se pudo ingresar el expediente en el sistema";
//            return confirmacion;
//        }
//    }
//    else
//    {
//        confirmacion = "Ocurrió un error y no se pudo ingresar el expediente en el sistema";
//        return confirmacion;
//    }

//    // Iniciar nueva transaccion 
//    SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo expediente");

//    try
//    {

//        // --------------------------- Insertar en la tabla Expediente ---------------------------  //

//        // Crear nuevo comando con la sencuencia SQL y el objeto de conexion
//        SqlCommand comandoExp = new SqlCommand("INSERT INTO EXPEDIENTE (CEDULA_EXPEDIENTE, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, SEXO, FECHA_NACIMIENTO, FOTO, EXPEDIENTE_ANTIGUO)" +
//            "VALUES (@cedPa, @nomPa, @priApPa, @segApPa, @sexoPa, @naciPa, @fotoPa, @expAntPa);", conexion);

//        comandoExp.Transaction = transaccion;
//        // Asignar un valor a los parametros del comando a ejecutar

//        comandoExp.Parameters.AddWithValue("@cedPa", nuevoExpediente.Cedula);
//        comandoExp.Parameters.AddWithValue("@nomPa", nuevoExpediente.Nombre);
//        comandoExp.Parameters.AddWithValue("@priApPa", nuevoExpediente.PrimerApellido);
//        comandoExp.Parameters.AddWithValue("@segApPa", nuevoExpediente.SegundoApellido);
//        comandoExp.Parameters.AddWithValue("@sexoPa", nuevoExpediente.Sexo);
//        comandoExp.Parameters.AddWithValue("@naciPa", nuevoExpediente.FechaNacimiento);
//        comandoExp.Parameters.AddWithValue("@fotoPa", nuevoExpediente.Foto);
//        comandoExp.Parameters.AddWithValue("@expAntPa", nuevoExpediente.ExpedienteAntiguo);

//        // Ejecutar comando y realizar commit de la transaccion 
//        comandoExp.ExecuteNonQuery();
//        transaccion.Commit();


//    }
//    catch (Exception)
//    {
//        try
//        {
//            // Realizar rollback a la transaccion
//            transaccion.Rollback();
//        }
//        catch (Exception)
//        {

//        }
//        finally
//        {
//            confirmacion = "Ocurrió un error y no se pudo ingresar la cita en el sistema";
//        }
//    }
//    finally
//    {
//        if (conexion.State != ConnectionState.Closed)
//        {
//            conexion.Close();
//        }
//    }

//    return confirmacion;
//}
//}


