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

        /// <summary>
        /// Insertar un objeto expediente en la BD
        /// </summary>
        /// <param name="nuevoExpediente"></param>
        /// <returns>Retorna un mensaje de confirmacion indicando si la transaccion se realizo</returns>
        public string CrearExpediente(TOExpediente nuevoExpediente)
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

                // --------------------------- Insertar en la tabla Expediente ---------------------------  //

                // Crear nuevo comando con la sencuencia SQL y el objeto de conexion
                SqlCommand comandoExp = new SqlCommand("INSERT INTO EXPEDIENTE (CEDULA_EXPEDIENTE, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, SEXO, FECHA_NACIMIENTO, FOTO, EXPEDIENTE_ANTIGUO)" +
                    "VALUES (@cedPa, @nomPa, @priApPa, @segApPa, @sexoPa, @naciPa, @fotoPa, @expAntPa);", conexion);

                comandoExp.Transaction = transaccion;
                // Asignar un valor a los parametros del comando a ejecutar

                comandoExp.Parameters.AddWithValue("@cedPa", nuevoExpediente.Cedula);
                comandoExp.Parameters.AddWithValue("@nomPa", nuevoExpediente.Nombre);
                comandoExp.Parameters.AddWithValue("@priApPa", nuevoExpediente.PrimerApellido);
                comandoExp.Parameters.AddWithValue("@segApPa", nuevoExpediente.SegundoApellido);
                comandoExp.Parameters.AddWithValue("@sexoPa", nuevoExpediente.Sexo);
                comandoExp.Parameters.AddWithValue("@naciPa", nuevoExpediente.FechaNacimiento);
                comandoExp.Parameters.AddWithValue("@fotoPa", nuevoExpediente.Foto);
                comandoExp.Parameters.AddWithValue("@expAntPa", nuevoExpediente.ExpedienteAntiguo);

                // Ejecutar comando y realizar commit de la transaccion 
                comandoExp.ExecuteNonQuery();
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

        /// <summary>
        /// Obtiene la lista de los registros que estan en la tabla Expediente 
        /// </summary>
        /// <param name="toListaExpediente"></param>
        /// <returns></returns>
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
                        //TOExpediente expediente = new TOExpediente();
                        //expediente.Nombre = lector["NOMBRE"].ToString();
                        //expediente.PrimerApellido = lector["PRIMER_APELLIDO"].ToString();
                        //expediente.SegundoApellido = lector["SEGUNDO_APELLIDO"].ToString();
                        //expediente.Cedula = lector["CEDULA_EXPEDIENTE"].ToString();
                        //expediente.Sexo = lector["SEXO"].ToString();

                        //toListaExpediente.Add(expediente);

                        TOExpediente expediente = new TOExpediente(lector["NOMBRE"].ToString(), lector["PRIMER_APELLIDO"].ToString(), lector["SEGUNDO_APELLIDO"].ToString(), lector["CEDULA_EXPEDIENTE"].ToString(),
                            DateTime.Parse(lector["FECHA_NACIMIENTO"].ToString()), lector["SEXO"].ToString(), (byte[])lector["FOTO"], lector["EXPEDIENTE_ANTIGUO"].ToString());
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

    }
}


//    public string CrearExpediente (TOExpediente nuevoExpediente, TODireccion nuevaDireccionPaciente, TODireccion nuevaDireccionEncargado, TODireccion nuevaDireccionFactura, TOHistoriaClinica nuevaHistoriaClinica1, TOHistoriaClinica nuevaHistoriaClinica2)
//    {
//        // Abrir la conexion
//        if (conexion.State != ConnectionState.Open)
//        {
//            conexion.Open();
//        }

//        // Iniciar nueva transaccion 
//        SqlTransaction transaccion = conexion.BeginTransaction("Insertar nuevo expediente");
//        string confirmacion = "El expediente se ingreso exitosamente en el sistema";

//        try
//        {

//            // --------------------------- Insertar en la tabla Expediente ---------------------------  //

//            // Crear nuevo comando con la sencuencia SQL y el objeto de conexion
//            SqlCommand comandoExp = new SqlCommand("INSERT INTO EXPEDIENTE (CEDULA_EXPEDIENTE, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, SEXO, FECHA_NACIMIENTO, FOTO, EXPEDIENTE_ANTIGUO)" +
//                "VALUES (@cedPa, @nomPa, @priApPa, @segApPa, @sexoPa, @naciPa, @fotoPa, @expAntPa);", conexion);

//            comandoExp.Transaction = transaccion;
//            // Asignar un valor a los parametros del comando a ejecutar

//            comandoExp.Parameters.AddWithValue("@cedPa", nuevoExpediente.Cedula);
//            comandoExp.Parameters.AddWithValue("@nomPa", nuevoExpediente.Nombre);
//            comandoExp.Parameters.AddWithValue("@priApPa", nuevoExpediente.PrimerApellido);
//            comandoExp.Parameters.AddWithValue("@segApPa", nuevoExpediente.SegundoApellido);
//            comandoExp.Parameters.AddWithValue("@sexoPa", nuevoExpediente.Sexo);
//            comandoExp.Parameters.AddWithValue("@naciPa", nuevoExpediente.FechaNacimiento);
//            comandoExp.Parameters.AddWithValue("@fotoPa", nuevoExpediente.Foto);
//            comandoExp.Parameters.AddWithValue("@expAntPa", nuevoExpediente.ExpedienteAntiguo);

//            // --------------------------- Insertar en la tabla ... ---------------------------  //




//            // --------------------------- Insertar en la tabla Antecedentes Perinatales ---------------------------  //

//            SqlCommand comandoAntPeri = new SqlCommand("INSERT INTO ANTECEDENTES_PERINATALES (CEDULA_EXPEDIENTE, TALLA_NACIMIENTO, PESO_NACIMIENTO, PERIMETRO_CEFALICO_NACIMIENTO, APGAR, EDAD_GESTACIONAL, CLASI_UNI_RN, OTROS_ESTADO, OTROS_DESCRIPCION)" +
//                "VALUES (@cedAP, @tallaAP, @pesoAP, @periAP, @apgarAP, @edadGesAP, @clasiAP, @otroEstadoAP, @otroDescAP);", conexion);

//            comandoAntPeri.Transaction = transaccion;

//            comandoExp.Parameters.AddWithValue("@cedAP", nuevaHistoriaClinica1.Cedula);
//            comandoExp.Parameters.AddWithValue("@tallaAP", nuevaHistoriaClinica1.AP_Talla);
//            comandoExp.Parameters.AddWithValue("@pesoAP", nuevaHistoriaClinica1.AP_Peso);
//            comandoExp.Parameters.AddWithValue("@periAP", nuevaHistoriaClinica1.AP_PerimetroCefalico);
//            comandoExp.Parameters.AddWithValue("@apgarAP", nuevaHistoriaClinica1.AP_APGAR);
//            comandoExp.Parameters.AddWithValue("@edadGesAP", nuevaHistoriaClinica1.AP_EdadGestacional);
//            comandoExp.Parameters.AddWithValue("@clasiAP", nuevaHistoriaClinica1.AP_CalificacionUniversal);
//            comandoExp.Parameters.AddWithValue("@otroEstadoAP", nuevaHistoriaClinica1.AP_OtrasComplicaciones);
//            comandoExp.Parameters.AddWithValue("@otroDescAP", nuevaHistoriaClinica1.AP_OtrasComplicacionesDescripcion);

//            // --------------------------- Insertar en la tabla Antecedentes ---------------------------  //

//            SqlCommand comandoAntec = new SqlCommand("INSERT INTO ANTECEDENTES (CEDULA_EXPEDIENTE, APAT_PRESENTE, APAT_DESCRIPCION, AQUIR_PRESENTE, AQUIR_DESCRIPCION, ATRAU_PRESENTE, ATRAU_DESCRIPCION, AHF_ASMA, AHF_DIABETES, AHF_HIPERTENSION " + 
//                "AHF_DISPLIDEMIA, AHF_CARDIOVASCULAR, AHF_EPILEPSIA, AHF_OTROS, AHF_OTROS_DESCRIPCION, ALERGIAS_PRESENTE, ALERGIAS_DESCRIPCION)" + 
//                "VALUES (@cedANT, @apatPre, @apatDes, @aquirPre, @aquirDes, @atrauPre, @atrauDes, @ahfAsma, @ahfDiab, @ahfHiper, @ahfDispl, @ahfCardi, @ahfEpilep, @ahfOtros, @ahfOtrosDesc, @alergiasPreANT, alergiasDescAnt);", conexion);

//            comandoAntec.Transaction = transaccion;

//            comandoExp.Parameters.AddWithValue("@cedANT", nuevaHistoriaClinica2.Cedula);
//            comandoExp.Parameters.AddWithValue("@apatPre", nuevaHistoriaClinica2.APAT_Estado);
//            comandoExp.Parameters.AddWithValue("@apatDes", nuevaHistoriaClinica2.APAT_Descripcion);
//            comandoExp.Parameters.AddWithValue("@aquirPre", nuevaHistoriaClinica2.AQ_Estado);
//            comandoExp.Parameters.AddWithValue("@aquirDes", nuevaHistoriaClinica2.AQ_Descripcion);
//            comandoExp.Parameters.AddWithValue("@atrauPre", nuevaHistoriaClinica2.AT_Estado);
//            comandoExp.Parameters.AddWithValue("@atrauDes", nuevaHistoriaClinica2.AT_Descripcion);
//            comandoExp.Parameters.AddWithValue("@ahfAsma", nuevaHistoriaClinica2.HF_Asma);
//            comandoExp.Parameters.AddWithValue("@ahfDiab", nuevaHistoriaClinica2.HF_Diabetes);
//            comandoExp.Parameters.AddWithValue("@ahfHiper", nuevaHistoriaClinica2.HF_Hipertension);
//            comandoExp.Parameters.AddWithValue("@ahfDispl", nuevaHistoriaClinica2.HF_Displidemia);
//            comandoExp.Parameters.AddWithValue("@ahfCardi", nuevaHistoriaClinica2.HF_Cardivasculares);
//            comandoExp.Parameters.AddWithValue("@ahfEpilep", nuevaHistoriaClinica2.HF_Epilepsia);
//            comandoExp.Parameters.AddWithValue("@ahfOtros", nuevaHistoriaClinica2.HF_Otros);
//            comandoExp.Parameters.AddWithValue("@ahfOtrosDesc", nuevaHistoriaClinica2.HF_DescripcionOtros);
//            comandoExp.Parameters.AddWithValue("@alergiasPreANT", nuevaHistoriaClinica2.Alergias);
//            comandoExp.Parameters.AddWithValue("@alergiasDescAnt", nuevaHistoriaClinica2.AlegergiasDescripcion);


//            // Ejecutar comando y realizar commit de la transaccion 
//            comandoExp.ExecuteNonQuery();
//            comandoAntPeri.ExecuteNonQuery();
//            comandoAntec.ExecuteNonQuery();
//            transaccion.Commit();


//        }
//        catch (Exception)
//        {
//            try
//            {
//                // Realizar rollback a la transaccion
//                transaccion.Rollback();
//            }
//            catch (Exception)
//            {

//            }
//            finally
//            {
//                confirmacion = "Ocurrió un error y no se pudo ingresar la cita en el sistema";
//            }
//        }
//        finally
//        {
//            if (conexion.State != ConnectionState.Closed)
//            {
//                conexion.Close();
//            }
//        }

//        return confirmacion;
//    }
//}


