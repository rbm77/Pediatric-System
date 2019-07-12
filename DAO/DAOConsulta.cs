using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;


namespace DAO
{
    public class DAOConsulta
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public string CrearConsulta(TOConsulta consultaTO, TOExamenFisico examenFisicoTO)
        {
            string confirmacion = "La consulta se ingresó correctamente";

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo ingresar el expediente en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Insertar nueva consulta");

                const string FMT = "o";
                string fechaConv = consultaTO.Fecha_Hora.ToString(FMT);

                SqlCommand cmdInsertarConsulta = new SqlCommand("INSERT INTO CONSULTA (CODIGO_MEDICO, CODIGO_EXPEDIENTE, FECHA_HORA, ESTADO, PACIENTE) VALUES (@codMed, @codExp, @fecha, @estado, @paci);", conexion);
                cmdInsertarConsulta.Transaction = transaccion;
                cmdInsertarConsulta.Parameters.AddWithValue("@codMed", consultaTO.CodigoMedico);
                cmdInsertarConsulta.Parameters.AddWithValue("@codExp", consultaTO.CodigoExpediente);
                cmdInsertarConsulta.Parameters.AddWithValue("@fecha", fechaConv);
                cmdInsertarConsulta.Parameters.AddWithValue("@estado", consultaTO.Estado);
                cmdInsertarConsulta.Parameters.AddWithValue("@paci", consultaTO.Paciente);
                cmdInsertarConsulta.ExecuteNonQuery();

                SqlCommand cmdInsertarExamenFisico = new SqlCommand("INSERT INTO EXAMEN_FISICO (CODIGO_MEDICO, CODIGO_EXPEDIENTE, FECHA_HORA) VALUES (@codMed, @codExp, @fecha);", conexion);
                cmdInsertarExamenFisico.Transaction = transaccion;
                cmdInsertarExamenFisico.Parameters.AddWithValue("@codMed", examenFisicoTO.CodigoMedico);
                cmdInsertarExamenFisico.Parameters.AddWithValue("@codExp", examenFisicoTO.CodigoExpediente);
                cmdInsertarExamenFisico.Parameters.AddWithValue("@fecha", fechaConv);
                cmdInsertarExamenFisico.ExecuteNonQuery();

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
                    confirmacion = "Ocurrió un error y no se pudo ingresar la consulta en el sistema";
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

        public string cambiarEstadoConsulta(TOConsulta consultaTO)
        {
            string confirmacion = "La consulta se actualizó correctamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;


            try
            {
                transaccion = conexion.BeginTransaction("Actualizar estado de consulta");

                // --------------------------- Actualizar en la tabla Consulta ---------------------------  //

                SqlCommand cmdActuExpediente = new SqlCommand("UPDATE CONSULTA SET ESTADO = @estado WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdActuExpediente.Transaction = transaccion;

                //cmdActuExpediente.Parameters.AddWithValue("@codMed", consultaTO.CodigoMedico);

                const string FMT = "o";
                string fechaConv = consultaTO.Fecha_Hora.ToString(FMT);
                cmdActuExpediente.Parameters.AddWithValue("@estado", consultaTO.Estado);
                cmdActuExpediente.Parameters.AddWithValue("@fecha", fechaConv);
                cmdActuExpediente.Parameters.AddWithValue("@codExpe", consultaTO.CodigoExpediente);

                cmdActuExpediente.ExecuteNonQuery();

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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
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

        public string obtenerConsultasActivas(List<TOConsulta> toConsultas, string codDoctor)
        {
            string confirmacion = "Las consultas se cargaron exitosamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
                return confirmacion;
            }

            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Cargar consultas");

                SqlCommand cmdConsultas = new SqlCommand("SELECT * FROM CONSULTA WHERE (CODIGO_MEDICO = @cod) AND (ESTADO = @estado)", conexion);
                cmdConsultas.Parameters.AddWithValue("@cod", codDoctor);
                cmdConsultas.Parameters.AddWithValue("@estado", true);

                cmdConsultas.Transaction = transaccion;

                SqlDataReader lector = cmdConsultas.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {

                        //const string FMT = "o";
                        //DateTime now1 = DateTime.Now;
                        //string strDate = now1.ToString(FMT);
                        //DateTime now2 = DateTime.ParseExact(strDate, FMT, CultureInfo.InvariantCulture);
                        const string FMT = "o";
                        DateTime fechaConv = DateTime.ParseExact(lector["FECHA_HORA"].ToString(), FMT, CultureInfo.InvariantCulture);

                        TOConsulta consulta = new TOConsulta();
                        consulta.CodigoMedico = lector["CODIGO_MEDICO"].ToString();
                        consulta.CodigoExpediente = lector["CODIGO_EXPEDIENTE"].ToString();
                        consulta.Fecha_Hora = fechaConv;
                        consulta.Analisis = lector["ANALISIS"].ToString();
                        consulta.ImpresionDiagnostica = lector["IMPRESION_DIAGNOSTICA"].ToString();
                        consulta.Estado = (Boolean)lector["ESTADO"];
                        consulta.Paciente = lector["PACIENTE"].ToString();

                        toConsultas.Add(consulta);
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
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

        public DataTable generarMedMixta(string f1, string ff2, string code)
        {
            // Abrir la conexion
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
                    // confirmaciones
                }
            }
            else
            {
               // confirmaciones
            }

            SqlTransaction transaccion = null;


            try
            {
                transaccion = conexion.BeginTransaction("GenerarReporteMixta");
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable datatable = new DataTable();

                cmd = new SqlCommand("reporteMedMixta", conexion);
                cmd.Parameters.Add(new SqlParameter("@fini", f1));
                cmd.Parameters.Add(new SqlParameter("@ffin", ff2));
                cmd.Parameters.Add(new SqlParameter("@code", code));

                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                cmd.Transaction = transaccion;
                da.Fill(datatable); // getting value 

                return datatable;
               

            }
            catch (Exception ex)
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
                   // confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                }
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }

            return null;
        }

        public string actualizarReferenciaMedica(TOConsulta consultaTO)
        {
            string confirmacion = "La consulta se actualizó correctamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;


            try
            {
                transaccion = conexion.BeginTransaction("Actualizar referencia medica");

                // --------------------------- Actualizar en la tabla Consulta ---------------------------  //

                SqlCommand cmdActuExpediente = new SqlCommand("UPDATE CONSULTA SET REFERENCIA_MEDICA = @refMed, ESPECIALIDAD_REFERENCIA = @espRef, MOTIVO_REFERENCIA = @motRef WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdActuExpediente.Transaction = transaccion;

                //cmdActuExpediente.Parameters.AddWithValue("@codMed", consultaTO.CodigoMedico);

                const string FMT = "o";
                string fechaConv = consultaTO.Fecha_Hora.ToString(FMT);
                cmdActuExpediente.Parameters.AddWithValue("@refMed", consultaTO.ReferenciaMedica);
                cmdActuExpediente.Parameters.AddWithValue("@espRef", consultaTO.Especialidad);
                cmdActuExpediente.Parameters.AddWithValue("@motRef", consultaTO.MotivoReferecnia);
                cmdActuExpediente.Parameters.AddWithValue("@fecha", fechaConv);
                cmdActuExpediente.Parameters.AddWithValue("@codExpe", consultaTO.CodigoExpediente);

                cmdActuExpediente.ExecuteNonQuery();

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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
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

        public string actualizarReporteMedicinaMixta(TOConsulta consultaTO)
        {
            string confirmacion = "La consulta se actualizó correctamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;


            try
            {
                transaccion = conexion.BeginTransaction("Actualizar medicina mixta");

                // --------------------------- Actualizar en la tabla Consulta ---------------------------  //

                SqlCommand cmdActuExpediente = new SqlCommand("UPDATE CONSULTA SET MEDICINA_MIXTA = @medMix, FRECUENCIA = @frecu, REFERIDO_A = @refe WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdActuExpediente.Transaction = transaccion;

                //cmdActuExpediente.Parameters.AddWithValue("@codMed", consultaTO.CodigoMedico);

                const string FMT = "o";
                string fechaConv = consultaTO.Fecha_Hora.ToString(FMT);
                cmdActuExpediente.Parameters.AddWithValue("@medMix", consultaTO.MedicinaMixta);
                cmdActuExpediente.Parameters.AddWithValue("@frecu", consultaTO.Frecuencia);
                cmdActuExpediente.Parameters.AddWithValue("@refe", consultaTO.Referido_A);
                cmdActuExpediente.Parameters.AddWithValue("@fecha", fechaConv);
                cmdActuExpediente.Parameters.AddWithValue("@codExpe", consultaTO.CodigoExpediente);

                cmdActuExpediente.ExecuteNonQuery();

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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
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

        public string ActualizarConsulta(TOConsulta consultaTO, TOExamenFisico examenFisicoTO)
        {
            string confirmacion = "La consulta se actualizó correctamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;


            try
            {
                transaccion = conexion.BeginTransaction("Actualizar consulta");

                // --------------------------- Actualizar en la tabla Consulta ---------------------------  //

                SqlCommand cmdActuExpediente = new SqlCommand("UPDATE CONSULTA SET ANALISIS = @analisis, IMPRESION_DIAGNOSTICA = @impresion, PLAN_D = @plan, PADECIMIENTO_ACTUAL =@padece WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdActuExpediente.Transaction = transaccion;

                //cmdActuExpediente.Parameters.AddWithValue("@codMed", consultaTO.CodigoMedico);

                const string FMT = "o";
                string fechaConv = consultaTO.Fecha_Hora.ToString(FMT);

                cmdActuExpediente.Parameters.AddWithValue("@analisis", consultaTO.Analisis);
                cmdActuExpediente.Parameters.AddWithValue("@impresion", consultaTO.ImpresionDiagnostica);
                cmdActuExpediente.Parameters.AddWithValue("@plan", consultaTO.Plan);
                cmdActuExpediente.Parameters.AddWithValue("@codExpe", consultaTO.CodigoExpediente);
                cmdActuExpediente.Parameters.AddWithValue("@fecha", fechaConv);
                cmdActuExpediente.Parameters.AddWithValue("@padece", consultaTO.PadecimientoActual);

                cmdActuExpediente.ExecuteNonQuery();

                // --------------------------- Actualizar en la tabla Examen Fisico ---------------------------  //

                SqlCommand cmdActuExamenFisico = new SqlCommand("UPDATE EXAMEN_FISICO SET TALLA = @talla, PESO = @peso, PERIMETRO_CEFALICO = @perimetro, SO2 = @so2, IMC = @imc, TEMPERATURA = @temp, ESTADO_ALERTA = @alerta, ESTADO_HIDRATACION = @hidratacion, RUIDOS_CARDIACOS = @ruidos, CAMPOS_PULMONARES = @campos, ABDOMEN = @abdomen, FARINGE = @faringe, NARIZ = @nariz, OIDOS = @oidos, SNC = @snc, SISTEMA_OSTEOMUSCULAR = @osteomuscular, PIEL = @piel, NEURODESARROLLO = @neurod, OTROS = @otros WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdActuExamenFisico.Transaction = transaccion;
                cmdActuExamenFisico.Parameters.AddWithValue("@talla", examenFisicoTO.Talla);
                cmdActuExamenFisico.Parameters.AddWithValue("@peso", examenFisicoTO.Peso);
                cmdActuExamenFisico.Parameters.AddWithValue("@perimetro", examenFisicoTO.PerimetroCefalico);
                cmdActuExamenFisico.Parameters.AddWithValue("@so2", examenFisicoTO.SO2);
                cmdActuExamenFisico.Parameters.AddWithValue("@imc", examenFisicoTO.IMC);
                cmdActuExamenFisico.Parameters.AddWithValue("@temp", examenFisicoTO.Temperatura);
                cmdActuExamenFisico.Parameters.AddWithValue("@alerta", examenFisicoTO.EstadoAlerta);
                cmdActuExamenFisico.Parameters.AddWithValue("@hidratacion", examenFisicoTO.EstadoHidratacion);
                cmdActuExamenFisico.Parameters.AddWithValue("@ruidos", examenFisicoTO.RuidosCardiacos);
                cmdActuExamenFisico.Parameters.AddWithValue("@campos", examenFisicoTO.CamposPulmonares);
                cmdActuExamenFisico.Parameters.AddWithValue("@abdomen", examenFisicoTO.Abdomen);
                cmdActuExamenFisico.Parameters.AddWithValue("@faringe", examenFisicoTO.Faringe);
                cmdActuExamenFisico.Parameters.AddWithValue("@nariz", examenFisicoTO.Nariz);
                cmdActuExamenFisico.Parameters.AddWithValue("@oidos", examenFisicoTO.Oidos);
                cmdActuExamenFisico.Parameters.AddWithValue("@snc", examenFisicoTO.SNC);
                cmdActuExamenFisico.Parameters.AddWithValue("@osteomuscular", examenFisicoTO.Osteomuscular);
                cmdActuExamenFisico.Parameters.AddWithValue("@piel", examenFisicoTO.Piel);
                cmdActuExamenFisico.Parameters.AddWithValue("@neurod", examenFisicoTO.Neurodesarrollo);
                cmdActuExamenFisico.Parameters.AddWithValue("@otros", examenFisicoTO.Otros);
                cmdActuExamenFisico.Parameters.AddWithValue("@codExpe", examenFisicoTO.CodigoExpediente);
                cmdActuExamenFisico.Parameters.AddWithValue("@fecha", fechaConv);

                cmdActuExamenFisico.ExecuteNonQuery();

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
                    confirmacion = "Ocurrió un error y no se pudo actualizar la consulta en el sistema";
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

        public string CargarListaConsultas(List<TOConsulta> toConsultas, string codExpediente)
        {
            string confirmacion = "Las consultas se cargaron exitosamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
                return confirmacion;
            }

            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Cargar consultas");

                SqlCommand cmdConsultas = new SqlCommand("SELECT * FROM CONSULTA WHERE CODIGO_EXPEDIENTE = @cod", conexion);
                cmdConsultas.Parameters.AddWithValue("@cod", codExpediente);
                cmdConsultas.Transaction = transaccion;

                SqlDataReader lector = cmdConsultas.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {

                        //const string FMT = "o";
                        //DateTime now1 = DateTime.Now;
                        //string strDate = now1.ToString(FMT);
                        //DateTime now2 = DateTime.ParseExact(strDate, FMT, CultureInfo.InvariantCulture);
                        const string FMT = "o";
                        DateTime fechaConv = DateTime.ParseExact(lector["FECHA_HORA"].ToString(), FMT, CultureInfo.InvariantCulture);

                        TOConsulta consulta = new TOConsulta();
                        consulta.CodigoMedico = lector["CODIGO_MEDICO"].ToString();
                        consulta.CodigoExpediente = lector["CODIGO_EXPEDIENTE"].ToString();
                        consulta.Fecha_Hora = fechaConv;
                        consulta.Analisis = lector["ANALISIS"].ToString();
                        consulta.ImpresionDiagnostica = lector["IMPRESION_DIAGNOSTICA"].ToString();
                        consulta.Estado = (Boolean)lector["ESTADO"];

                        toConsultas.Add(consulta);
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
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

        public string CargarConsulta(string codExpediente, DateTime fecha, TOConsulta consultaTO, TOExamenFisico examenFisicoTO)
        {
            string confirmacion = "La consulta se cargó correctamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo cargar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar la consulta en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Cargar consulta");

                // --------------------------- Buscar en la tabla Consulta ---------------------------  //

                const string FMT = "o";
                string fechaConv = fecha.ToString(FMT);

                SqlCommand cmdCargarConsul = new SqlCommand("SELECT * FROM CONSULTA WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdCargarConsul.Transaction = transaccion;
                cmdCargarConsul.Parameters.AddWithValue("@codExpe", codExpediente);
                cmdCargarConsul.Parameters.AddWithValue("@fecha", fechaConv);

                SqlDataReader lectorExp = cmdCargarConsul.ExecuteReader();

                if (lectorExp.HasRows)
                {
                    while (lectorExp.Read())
                    {
                        DateTime fechaConver = DateTime.ParseExact(lectorExp["FECHA_HORA"].ToString(), FMT, CultureInfo.InvariantCulture);

                        consultaTO.CodigoMedico = lectorExp["CODIGO_MEDICO"].ToString();
                        consultaTO.CodigoExpediente = lectorExp["CODIGO_EXPEDIENTE"].ToString();
                        consultaTO.Fecha_Hora = fechaConver;
                        consultaTO.Analisis = lectorExp["ANALISIS"].ToString();
                        consultaTO.ImpresionDiagnostica = lectorExp["IMPRESION_DIAGNOSTICA"].ToString();
                        consultaTO.Plan = lectorExp["PLAN_D"].ToString();
                        if (lectorExp["MEDICINA_MIXTA"].ToString() == "")
                        {
                            consultaTO.MedicinaMixta = false;
                        }
                        else
                        {
                            consultaTO.MedicinaMixta = (Boolean)lectorExp["MEDICINA_MIXTA"];
                        }

                        consultaTO.Frecuencia = lectorExp["FRECUENCIA"].ToString(); ;
                        consultaTO.Referido_A = lectorExp["REFERIDO_A"].ToString();
                        consultaTO.Estado = (Boolean)lectorExp["ESTADO"];
                        consultaTO.PadecimientoActual = lectorExp["PADECIMIENTO_ACTUAL"].ToString();
                        if (lectorExp["REFERENCIA_MEDICA"].ToString() == "")
                        {
                            consultaTO.ReferenciaMedica = false;
                        }
                        else
                        {
                            consultaTO.ReferenciaMedica = (Boolean)lectorExp["REFERENCIA_MEDICA"];
                        }
                        consultaTO.Especialidad = lectorExp["ESPECIALIDAD_REFERENCIA"].ToString();
                        consultaTO.MotivoReferecnia = lectorExp["MOTIVO_REFERENCIA"].ToString();
                    }
                }
                lectorExp.Close();

                // --------------------------- Buscar en la tabla Examen Fisico ---------------------------  //

                SqlCommand cmdCargarExamenF = new SqlCommand("SELECT * FROM EXAMEN_FISICO WHERE (CODIGO_EXPEDIENTE = @codExpe) AND (FECHA_HORA = @fecha);", conexion);
                cmdCargarExamenF.Transaction = transaccion;
                cmdCargarExamenF.Parameters.AddWithValue("@codExpe", codExpediente);
                cmdCargarExamenF.Parameters.AddWithValue("@fecha", fechaConv);

                SqlDataReader lectorExa = cmdCargarExamenF.ExecuteReader();

                if (lectorExa.HasRows)
                {
                    while (lectorExa.Read())
                    {
                        examenFisicoTO.CodigoMedico = lectorExa["CODIGO_MEDICO"].ToString();
                        examenFisicoTO.CodigoExpediente = lectorExa["CODIGO_EXPEDIENTE"].ToString();
                        examenFisicoTO.Fecha_Hora = DateTime.Parse(lectorExa["FECHA_HORA"].ToString());
                        examenFisicoTO.Talla = float.Parse(lectorExa["TALLA"].ToString());
                        examenFisicoTO.Peso = float.Parse(lectorExa["PESO"].ToString());
                        examenFisicoTO.PerimetroCefalico = float.Parse(lectorExa["PERIMETRO_CEFALICO"].ToString());
                        examenFisicoTO.SO2 = float.Parse(lectorExa["SO2"].ToString());
                        examenFisicoTO.IMC = float.Parse(lectorExa["IMC"].ToString());
                        examenFisicoTO.Temperatura = float.Parse(lectorExa["TEMPERATURA"].ToString());
                        examenFisicoTO.EstadoAlerta = lectorExa["ESTADO_ALERTA"].ToString();
                        examenFisicoTO.EstadoHidratacion = lectorExa["ESTADO_HIDRATACION"].ToString();
                        examenFisicoTO.RuidosCardiacos = lectorExa["RUIDOS_CARDIACOS"].ToString();
                        examenFisicoTO.CamposPulmonares = lectorExa["CAMPOS_PULMONARES"].ToString();
                        examenFisicoTO.Abdomen = lectorExa["ABDOMEN"].ToString();
                        examenFisicoTO.Faringe = lectorExa["FARINGE"].ToString();
                        examenFisicoTO.Nariz = lectorExa["NARIZ"].ToString();
                        examenFisicoTO.Oidos = lectorExa["OIDOS"].ToString();
                        examenFisicoTO.SNC = lectorExa["SNC"].ToString();
                        examenFisicoTO.Osteomuscular = lectorExa["SISTEMA_OSTEOMUSCULAR"].ToString();
                        examenFisicoTO.Piel = lectorExa["PIEL"].ToString();
                        examenFisicoTO.Neurodesarrollo = lectorExa["NEURODESARROLLO"].ToString();
                        examenFisicoTO.Otros = lectorExa["OTROS"].ToString();
                    }
                }
                lectorExa.Close();

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
                    confirmacion = "Ocurrió un error y no se pudo cargar la consulta";
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

        public string CargarConsultaFecha(DateTime fecha, TOConsulta consultaTO, TOExamenFisico examenFisicoTO)
        {
            string confirmacion = "La consulta se cargó correctamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo cargar la consulta en el sistema";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar la consulta en el sistema";
                return confirmacion;
            }

            SqlTransaction transaccion = null;

            try
            {
                transaccion = conexion.BeginTransaction("Cargar consulta por fecha");

                // --------------------------- Buscar en la tabla Consulta ---------------------------  //

                const string FMT = "o";
                string fechaConv = fecha.ToString(FMT);

                SqlCommand cmdCargarConsul = new SqlCommand("SELECT * FROM CONSULTA WHERE FECHA_HORA = @fecha;", conexion);
                cmdCargarConsul.Transaction = transaccion;
                cmdCargarConsul.Parameters.AddWithValue("@fecha", fechaConv);

                SqlDataReader lectorExp = cmdCargarConsul.ExecuteReader();

                if (lectorExp.HasRows)
                {
                    while (lectorExp.Read())
                    {
                        DateTime fechaConver = DateTime.ParseExact(lectorExp["FECHA_HORA"].ToString(), FMT, CultureInfo.InvariantCulture);

                        consultaTO.CodigoMedico = lectorExp["CODIGO_MEDICO"].ToString();
                        consultaTO.CodigoExpediente = lectorExp["CODIGO_EXPEDIENTE"].ToString();
                        consultaTO.Fecha_Hora = fechaConver;
                        consultaTO.Analisis = lectorExp["ANALISIS"].ToString();
                        consultaTO.ImpresionDiagnostica = lectorExp["IMPRESION_DIAGNOSTICA"].ToString();
                        consultaTO.Plan = lectorExp["PLAN_D"].ToString();
                        if (lectorExp["MEDICINA_MIXTA"].ToString() == "")
                        {
                            consultaTO.MedicinaMixta = false;
                        }
                        else
                        {
                            consultaTO.MedicinaMixta = (Boolean)lectorExp["MEDICINA_MIXTA"];
                        }

                        consultaTO.Frecuencia = lectorExp["FRECUENCIA"].ToString(); ;
                        consultaTO.Referido_A = lectorExp["REFERIDO_A"].ToString();
                        consultaTO.Estado = (Boolean)lectorExp["ESTADO"];
                        consultaTO.PadecimientoActual = lectorExp["PADECIMIENTO_ACTUAL"].ToString();
                        if (lectorExp["REFERENCIA_MEDICA"].ToString() == "")
                        {
                            consultaTO.ReferenciaMedica = false;
                        }
                        else
                        {
                            consultaTO.ReferenciaMedica = (Boolean)lectorExp["REFERENCIA_MEDICA"];
                        }
                        consultaTO.Especialidad = lectorExp["ESPECIALIDAD_REFERENCIA"].ToString();
                        consultaTO.MotivoReferecnia = lectorExp["MOTIVO_REFERENCIA"].ToString();
                    }
                }
                lectorExp.Close();

                // --------------------------- Buscar en la tabla Examen Fisico ---------------------------  //

                SqlCommand cmdCargarExamenF = new SqlCommand("SELECT * FROM EXAMEN_FISICO WHERE FECHA_HORA = @fecha;", conexion);
                cmdCargarExamenF.Transaction = transaccion;
                cmdCargarExamenF.Parameters.AddWithValue("@fecha", fechaConv);

                SqlDataReader lectorExa = cmdCargarExamenF.ExecuteReader();

                if (lectorExa.HasRows)
                {
                    while (lectorExa.Read())
                    {
                        examenFisicoTO.CodigoMedico = lectorExa["CODIGO_MEDICO"].ToString();
                        examenFisicoTO.CodigoExpediente = lectorExa["CODIGO_EXPEDIENTE"].ToString();
                        examenFisicoTO.Fecha_Hora = DateTime.Parse(lectorExa["FECHA_HORA"].ToString());
                        examenFisicoTO.Talla = float.Parse(lectorExa["TALLA"].ToString());
                        examenFisicoTO.Peso = float.Parse(lectorExa["PESO"].ToString());
                        examenFisicoTO.PerimetroCefalico = float.Parse(lectorExa["PERIMETRO_CEFALICO"].ToString());
                        examenFisicoTO.SO2 = float.Parse(lectorExa["SO2"].ToString());
                        examenFisicoTO.IMC = float.Parse(lectorExa["IMC"].ToString());
                        examenFisicoTO.Temperatura = float.Parse(lectorExa["TEMPERATURA"].ToString());
                        examenFisicoTO.EstadoAlerta = lectorExa["ESTADO_ALERTA"].ToString();
                        examenFisicoTO.EstadoHidratacion = lectorExa["ESTADO_HIDRATACION"].ToString();
                        examenFisicoTO.RuidosCardiacos = lectorExa["RUIDOS_CARDIACOS"].ToString();
                        examenFisicoTO.CamposPulmonares = lectorExa["CAMPOS_PULMONARES"].ToString();
                        examenFisicoTO.Abdomen = lectorExa["ABDOMEN"].ToString();
                        examenFisicoTO.Faringe = lectorExa["FARINGE"].ToString();
                        examenFisicoTO.Nariz = lectorExa["NARIZ"].ToString();
                        examenFisicoTO.Oidos = lectorExa["OIDOS"].ToString();
                        examenFisicoTO.SNC = lectorExa["SNC"].ToString();
                        examenFisicoTO.Osteomuscular = lectorExa["SISTEMA_OSTEOMUSCULAR"].ToString();
                        examenFisicoTO.Piel = lectorExa["PIEL"].ToString();
                        examenFisicoTO.Neurodesarrollo = lectorExa["NEURODESARROLLO"].ToString();
                        examenFisicoTO.Otros = lectorExa["OTROS"].ToString();
                    }
                }
                lectorExa.Close();

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
                    confirmacion = "Ocurrió un error y no se pudo cargar la consulta";
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

        public string CargarListaConsultasFiltrada(List<TOConsulta> toConsultas, string codMedico, string tipoReporte, string ini, string fin)
        {
            string confirmacion = "Las consultas se cargaron exitosamente";

            // Abrir la conexion
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
                    confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
                return confirmacion;
            }

            SqlTransaction transaccion = conexion.BeginTransaction("Cargar consultas");

            try
            {
                SqlCommand cmdConsultas;
                if (codMedico == "Todos")
                {
                    cmdConsultas = new SqlCommand("SELECT CODIGO_EXPEDIENTE, FRECUENCIA, REFERIDO_A  FROM CONSULTA WHERE Medicina_Mixta = '1' and CAST(@ini as date) <= CAST(FECHA_HORA as date) and CAST(@fin as date) >= CAST(FECHA_HORA as date)", conexion);
                }
                else
                {

                    cmdConsultas = new SqlCommand("SELECT CODIGO_EXPEDIENTE, FRECUENCIA, REFERIDO_A  FROM CONSULTA WHERE CODIGO_MEDICO = @cod and Medicina_Mixta = '1' and CAST(@ini as date) <= CAST(FECHA_HORA as date) and CAST(@fin as date) >= CAST(FECHA_HORA as date)", conexion);
                    cmdConsultas.Parameters.AddWithValue("@cod", codMedico);
                }

                cmdConsultas.Parameters.AddWithValue("@ini", ini);
                cmdConsultas.Parameters.AddWithValue("@fin", fin);
                cmdConsultas.Transaction = transaccion;

                SqlDataReader lector = cmdConsultas.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {

                        //const string FMT = "o";
                        //DateTime now1 = DateTime.Now;
                        //string strDate = now1.ToString(FMT);
                        //DateTime now2 = DateTime.ParseExact(strDate, FMT, CultureInfo.InvariantCulture);


                        TOConsulta consulta = new TOConsulta();

                        consulta.CodigoExpediente = lector["CODIGO_EXPEDIENTE"].ToString();
                        if (lector["CODIGO_EXPEDIENTE"].ToString().Contains("RN-"))
                        {
                            consulta.CodigoExpediente = "Recien Nacido";
                        }


                        //FRECUENCIA
                        if (lector["FRECUENCIA"].ToString() == "primera vida")
                        {
                            consulta.Frecuencia = "Primera Vida";
                        }
                        else if (lector["FRECUENCIA"].ToString() == "primera año")
                        {
                            consulta.Frecuencia = "Primer año";
                        }
                        else
                        {
                            consulta.Frecuencia = lector["FRECUENCIA"].ToString();
                        }
                        //Referido A
                        if (lector["REFERIDO_A"].ToString() == "refe_especialista")
                        {
                            consulta.Referido_A = "Especialista";
                        }
                        else if (lector["REFERIDO_A"].ToString() == "refe_hospitalizacion")
                        {
                            consulta.Referido_A = "Hospitalización";
                        }
                        else if (lector["REFERIDO_A"].ToString() == "refe_otro_centro")
                        {
                            consulta.Referido_A = "Otro Centro";
                        }
                        else
                        {
                            consulta.Referido_A = lector["FRECUENCIA"].ToString();
                        }


                        toConsultas.Add(consulta);
                    }
                }
                lector.Close();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaccion.Rollback();
                }
                catch (Exception exe)
                {

                }
                finally
                {
                    confirmacion = "Ocurrió un error y no se pudo cargar las consultas";
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
