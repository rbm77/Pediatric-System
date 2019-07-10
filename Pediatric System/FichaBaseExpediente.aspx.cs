using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using BL;

namespace Pediatric_System
{
    public partial class FichaBaseExpediente : System.Web.UI.Page
    {
        private static List<Pendiente> listaPendientes = new List<Pendiente>();
        private static List<BLVacuna> vacunas = new List<BLVacuna>();
        protected void Page_Load(object sender, EventArgs e)
        {

            //proEX.Value = "Puntarenas";
            //canEX.Value = "OSA";
            //disEX.Value = "PALMAR";

            //proEN.Value = "Puntarenas";
            //canEN.Value = "OSA";
            //disEN.Value = "PALMAR";
            //barEN.Value = "Alemania";

            //proFA.Value = "Puntarenas";
            //canFA.Value = "OSA";
            //disFA.Value = "PALMAR";
            //barFA.Value = "Alemania";

            if ((string)Session["pagina"] == "listaExpedientes-Nuevo")
            {
                verConsultas.Visible = false;
                nuevaConsulta.Visible = false;
                informacionPaciente.Visible = false;
            }

            if ((string)Session["pagina"] == "dashboard")
            {
                verConsultas.Visible = false;
                nuevaConsulta.Visible = false;
                informacionPaciente.Visible = false;
            }

            if ((string)Session["pagina"] == "listaExpedientes-seleccionado")
            {
                string codigoExp = (string)Session["expedienteSeleccionado"];
                mostrarExpediente(codigoExp);
                if (!IsPostBack)
                {
                    MostrarEsquemaVacunacion(codigoExp);
                }
            }

        }

        private void mostrarExpediente(string codigo)
        {
            BLExpediente expediente = new BLExpediente();
            BLDireccion expDireccion = new BLDireccion();
            BLEncargado_Facturante encargado = new BLEncargado_Facturante();
            BLDireccion encDireccion = new BLDireccion();
            BLEncargado_Facturante facturante = new BLEncargado_Facturante();
            BLDireccion facDireccion = new BLDireccion();
            BLHistoriaClinica historiaClinica = new BLHistoriaClinica();

            ManejadorExpediente manejador = new ManejadorExpediente();
            manejador.mostrarExpediente(codigo, expediente, expDireccion, encargado, encDireccion, facturante, facDireccion, historiaClinica);

            // Aqui recupero los datos que se van a mostrar en el pdf de la referencia medica y el esquema de vacunacion

            ManejadorEdad manejadorEdad = new ManejadorEdad();

            Session["nombrePaciente"] = expediente.Nombre + " " + expediente.PrimerApellido + " " + expediente.SegundoApellido;
            Session["edadPaciente"] = manejadorEdad.ExtraerEdad(expediente.FechaNacimiento);
            Session["fechaNacimento"] = expediente.FechaNacimiento;

            Session["direccionPaciente"] = expDireccion.Barrio + ", " + expDireccion.Distrito + ", " 
                + expDireccion.Canton + ", " + expDireccion.Provincia;
            Session["nombreEncargado"] = encargado.Nombre + " " + encargado.PrimerApellido + " " + encargado.SegundoApellido;
            Session["telefonoEncargado"] = encargado.Telefono;
            Session["direccionEncargado"] = encDireccion.Barrio + ", " + encDireccion.Distrito + ", "
                + encDireccion.Canton + ", " + encDireccion.Provincia;


            /////////////////////////////////////////////////////////////////////////////////

            asignarTab_1(expediente, expDireccion);
            asignarTab_2(encargado, encDireccion);
            asignarTab_3(facturante, facDireccion);
            asignarTab_4(historiaClinica);
        }

        private void asignarTab_1(BLExpediente exp, BLDireccion dir)
        {

            if (exp.Codigo == exp.Cedula)
            {
                cedulaPaciente.Text = exp.Cedula;
                cedGeneral.InnerText = " " + exp.Cedula;
            }
            else
            {
                cedGeneral.InnerText = "No tiene aún";
                cedulaPaciente.Text = "";
                pacienteNoCedula.Checked = true;
            }

            paciGeneral.InnerText = " " + exp.Nombre + " " + exp.PrimerApellido + " " + exp.SegundoApellido;
            TimeSpan dt = DateTime.Now - exp.FechaNacimiento;
            edaGeneral.InnerText = " " + Convert.ToString(dt.Days) + " días";
            string imagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(exp.Foto);
            imgPreview.ImageUrl = imagenDataURL64;

            nombrePaciente.Text = exp.Nombre;
            primerApellidoPaciente.Text = exp.PrimerApellido;
            segundoApellidoPaciente.Text = exp.SegundoApellido;
            fechaNacimientoPaciente.Text = exp.FechaNacimiento.ToShortDateString();
            sexoPaciente.SelectedValue = exp.Sexo;

            proEX.Value = dir.Provincia;
            canEX.Value = dir.Canton;
            disEX.Value = dir.Distrito;

            VincExpedientePaciente.Text = exp.ExpedienteAntiguo;
        }

        private void asignarTab_2(BLEncargado_Facturante encar, BLDireccion dir)
        {
            nombreEncargado.Text = encar.Nombre;
            primerApellidoEncargado.Text = encar.PrimerApellido;
            segundoApellidoEncargado.Text = encar.SegundoApellido;
            cedulaEncargado.Text = encar.Cedula;
            telefonoEncargado.Text = Convert.ToString(encar.Telefono);
            correoEncargado.Text = encar.CorreoElectronico;
            parentezcoEncargado.Text = encar.Parentesco;

            proEN.Value = dir.Provincia;
            canEN.Value = dir.Canton;
            disEN.Value = dir.Distrito;
            barEN.Value = dir.Barrio;
        }

        private void asignarTab_3(BLEncargado_Facturante fac, BLDireccion dir)
        {
            nombreFacturante.Text = fac.Nombre;
            primerApellidoFacturante.Text = fac.PrimerApellido;
            segundoApellidoFacturante.Text = fac.SegundoApellido;
            cedulaFacturante.Text = fac.Cedula;
            telefonoFacturante.Text = Convert.ToString(fac.Telefono);
            correoFacturante.Text = fac.CorreoElectronico;

            proFA.Value = dir.Provincia;
            canFA.Value = dir.Canton;
            disFA.Value = dir.Distrito;
            barFA.Value = dir.Barrio;
        }

        private void asignarTab_4(BLHistoriaClinica his)
        {
            tallaNacer.Text = Convert.ToString(his.AP_Talla);
            pesoNacer.Text = Convert.ToString(his.AP_Peso);
            edadGestacional.Text = Convert.ToString(his.AP_EdadGestacional);
            apgar.Text = Convert.ToString(his.AP_APGAR);
            perimetroCefalico.Text = Convert.ToString(his.AP_PerimetroCefalico);

            string cali = his.AP_CalificacionUniversal;
            string[] caliDiv = cali.Split();
            clasificacionUniversal.Value = caliDiv[0].ToString().Trim();
            if (caliDiv[1] == "pequeño")
            {
                opcion_pequeno.Checked = true;
            }

            if (caliDiv[1] == "grande")
            {
                opcion_grande.Checked = true;
            }

            if (caliDiv[1] == "adecuado")
            {
                opcion_adecuado.Checked = true;
            }

            if (his.AP_OtrasComplicaciones == true)
            {
                otrasComplicacionesAP.Value = "presentes";
                complicacionPerinatal.Value = his.AP_OtrasComplicacionesDescripcion;
            }

            if (his.HF_Asma == true)
            {
                asmaCheck.Checked = true;
            }

            if (his.HF_Diabetes == true)
            {
                diabetesCheck.Checked = true;
            }

            if (his.HF_Hipertension == true)
            {
                hipertensionCheck.Checked = true;
            }

            if (his.HF_Cardivasculares == true)
            {
                cardiovascularCheck.Checked = true;
            }

            if (his.HF_Displidemia == true)
            {
                displidemiaCheck.Checked = true;
            }

            if (his.HF_Epilepsia == true)
            {
                epilepsiaCheck.Checked = true;
            }

            if (his.HF_Otros == true)
            {
                otrosCheck.Checked = true;
                descripcionOtrosHF.Value = his.HF_DescripcionOtros;
            }
            else
            {
                descripcionOtrosHF.Value = "";
            }

            if (his.APAT_Estado == true)
            {
                apatEstado.Value = "presentesPat";
                descripcionPatologicos.Value = his.APAT_Descripcion;
            }
            else
            {
                descripcionPatologicos.Value = "";
            }

            if (his.AQ_Estado == true)
            {
                aqEstado.Value = "presentesQui";
                descripcionQuirurgico.Value = his.AQ_Descripcion;
            }
            else
            {
                descripcionQuirurgico.Value = "";
            }

            if (his.AT_Estado == true)
            {
                atEstado.Value = "presentesTrau";
                descripcionTraumatico.Value = his.AT_Descripcion;
            }
            else
            {
                descripcionQuirurgico.Value = "";
            }

            if (his.Alergias == true)
            {
                alergiasEstado.Value = "presentesAlergia";
                descripcionAlergia.Value = his.AlegergiasDescripcion;
            }
            else
            {
                descripcionAlergia.Value = "";
            }
        }

   

        protected void guardarExpediente_Click(object sender, EventArgs e)
        {
            

            BLExpediente expediente = new BLExpediente();
            BLDireccion direccionExp = new BLDireccion();
            BLEncargado_Facturante encargado = new BLEncargado_Facturante();
            BLDireccion direccionEncar = new BLDireccion();
            BLEncargado_Facturante facturante = new BLEncargado_Facturante();
            BLDireccion direccionFactu = new BLDireccion();
            BLHistoriaClinica historiaClinica = new BLHistoriaClinica();

            // Enviar datos para guardar en BD
            ManejadorExpediente manejador = new ManejadorExpediente();
            string confirmacion = manejador.crearExpediente(expediente, direccionExp, direccionEncar, direccionFactu, encargado, facturante, historiaClinica);

            infoTab_1(expediente, direccionExp);
            infoTab_2(encargado, direccionEncar);
            infoTab_3(facturante, direccionFactu);
            infoTab_4(historiaClinica);


            MostrarMensaje(confirmacion);

            Response.Redirect("ListaExpedientes.aspx");
           

        }

        private void infoTab_1(BLExpediente expediente, BLDireccion direccionExp)
        {


            // Recuperar campos de texto para objeto Direccion (Expediente) 

            string provincia = proEX.Value;
            string canton = canEX.Value;
            string distrito = disEX.Value;
            string codigo = codigoDireccion(provincia, canton, distrito, "");
            
            direccionExp.Codigo = codigo;
            direccionExp.Provincia = provincia;
            direccionExp.Canton = canton;
            direccionExp.Distrito = distrito;

            //// Recuperar campos de texto para objeto Expediente

            if (pacienteNoCedula.Checked)
            {
                expediente.Codigo = crearCodigoExpe();
            }
            else
            {
                expediente.Codigo = cedulaPaciente.Text.Trim();
            }

            expediente.Nombre = nombrePaciente.Text.Trim();
            expediente.PrimerApellido = primerApellidoPaciente.Text.Trim();
            expediente.SegundoApellido = segundoApellidoPaciente.Text.Trim();
            expediente.Cedula = cedulaPaciente.Text.Trim();
            expediente.FechaNacimiento = Convert.ToDateTime(fechaNacimientoPaciente.Text);
                //DateTime.ParseExact(fechaNacimientoPaciente., "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            expediente.Sexo = sexoPaciente.Text.Trim();
            expediente.Foto = guardarImag();
            expediente.ExpedienteAntiguo = VincExpedientePaciente.Text.Trim();
            expediente.Direccion = codigo;
        }

        private string crearCodigoExpe ()
        {
            string codEx = "RN-";
            codEx += cedulaEncargado.Text.Trim();
            return codEx;
        }

        private void infoTab_2 (BLEncargado_Facturante encargado, BLDireccion direccionEncar)
        {
            // Recuperar campos de texto para objeto Direccion(Encargado)
            string provincia = proEN.Value;
            string canton = canEN.Value;
            string distrito = disEN.Value;
            string barrio = barEN.Value;
            string codigo = codigoDireccion(provincia, canton, distrito, barrio);

            direccionEncar.Codigo = codigo;
            direccionEncar.Provincia = provincia;
            direccionEncar.Canton = canton;
            direccionEncar.Distrito = distrito;
            direccionEncar.Barrio = barrio;

            // Recuperar campos de texto para el objeto Encargado
            encargado.Nombre = nombreEncargado.Text.Trim();
            encargado.PrimerApellido = primerApellidoEncargado.Text.Trim();
            encargado.SegundoApellido = segundoApellidoEncargado.Text.Trim();
            encargado.Cedula = cedulaEncargado.Text.Trim();
            encargado.Telefono = decimal.Parse(telefonoEncargado.Text);
            encargado.Parentesco = parentezcoEncargado.Text.Trim();
            encargado.CorreoElectronico = correoEncargado.Text.Trim();
            encargado.Direccion = codigo;
        }

        private void infoTab_3(BLEncargado_Facturante facturante, BLDireccion direccionFactu)
        {
            // Recuperar campos de texto para objeto Direccion(Encargado)
            string provincia = proFA.Value;
            string canton = canFA.Value;
            string distrito = disFA.Value;
            string barrio = barFA.Value;
            string codigo = codigoDireccion(provincia, canton, distrito, barrio);

            direccionFactu.Codigo = codigo;
            direccionFactu.Provincia = provincia;
            direccionFactu.Canton = canton;
            direccionFactu.Distrito = distrito;
            direccionFactu.Barrio = barrio;

            // Recuperar campos de texto para el objeto Encargado
            facturante.Nombre = nombreFacturante.Text.Trim();
            facturante.PrimerApellido = primerApellidoFacturante.Text.Trim();
            facturante.SegundoApellido = segundoApellidoFacturante.Text.Trim();
            facturante.Cedula = cedulaFacturante.Text.Trim();
            facturante.Telefono = decimal.Parse(telefonoFacturante.Text);
            facturante.CorreoElectronico = correoFacturante.Text.Trim();
            facturante.Direccion = codigo;
        }


        private void infoTab_4 (BLHistoriaClinica historiaClinica)
        {
            historiaClinica.AP_Talla = float.Parse(tallaNacer.Text);
            historiaClinica.AP_Peso = float.Parse(pesoNacer.Text); ;
            historiaClinica.AP_PerimetroCefalico = float.Parse(perimetroCefalico.Text); ;
            string calificacion = clasificacionUniversal.Value;
            calificacion += " ";
            if (opcion_pequeno.Checked)
            {
                calificacion += "pequeño";
            }

            if (opcion_grande.Checked)
            {
                calificacion += "grande";
            }

            if (opcion_adecuado.Checked)
            {
                calificacion += "adecuado";
            }

            historiaClinica.AP_CalificacionUniversal = calificacion;
            historiaClinica.AP_APGAR = decimal.Parse(apgar.Text);
            historiaClinica.AP_EdadGestacional = decimal.Parse(edadGestacional.Text);


            if (otrasComplicacionesAP.Value == "ausentes")
            {
                historiaClinica.AP_OtrasComplicaciones = false;
                historiaClinica.AP_OtrasComplicacionesDescripcion = "";
            }
            else
            {
                historiaClinica.AP_OtrasComplicaciones = true;
                historiaClinica.AP_OtrasComplicacionesDescripcion = complicacionPerinatal.Value.Trim();
            }
            if (otrasComplicacionesAP.Value == "ausentes")
            {
                historiaClinica.AP_OtrasComplicaciones = false;
                historiaClinica.AP_OtrasComplicacionesDescripcion = null;
            }
            else
            {
                historiaClinica.AP_OtrasComplicaciones = true;
                historiaClinica.AP_OtrasComplicacionesDescripcion = complicacionPerinatal.Value.Trim();
            }


            if (asmaCheck.Checked)
            {
                historiaClinica.HF_Asma = true;
            }

            if (diabetesCheck.Checked)
            {
                historiaClinica.HF_Diabetes = true;
            }

            if (hipertensionCheck.Checked)
            {
                historiaClinica.HF_Hipertension = true;
            }

            if (cardiovascularCheck.Checked)
            {
                historiaClinica.HF_Cardivasculares = true;
            }

            if (displidemiaCheck.Checked)
            {
                historiaClinica.HF_Displidemia = true;
            }

            if (epilepsiaCheck.Checked)
            {
                historiaClinica.HF_Epilepsia = true;
            }


            historiaClinica.HF_DescripcionOtros = "";
            if (otrosCheck.Checked)
            {
                historiaClinica.HF_Otros = true;
                historiaClinica.HF_DescripcionOtros = descripcionOtrosHF.Value.Trim();
            }

            historiaClinica.APAT_Descripcion = "";
            if (apatEstado.Value == "presentesPat")
            {
                historiaClinica.APAT_Estado = true;
                historiaClinica.APAT_Descripcion = descripcionPatologicos.Value.Trim();
            }

            historiaClinica.AT_Descripcion = "";
            if (atEstado.Value == "presentesTrau") {
                historiaClinica.AT_Estado = true;
                historiaClinica.AT_Descripcion = descripcionTraumatico.Value.Trim();
            }

            historiaClinica.AQ_Descripcion = "";
            if (aqEstado.Value == "presentesQui") {
                historiaClinica.AQ_Estado = true;
                historiaClinica.AQ_Descripcion = descripcionQuirurgico.Value.Trim();
            }

            historiaClinica.AlegergiasDescripcion = "";
            if (alergiasEstado.Value == "presentesAlergia")
            {
                historiaClinica.Alergias = true;
                historiaClinica.AlegergiasDescripcion = descripcionAlergia.Value.Trim();
            }

            if (otrosCheck.Checked)
            {
                historiaClinica.HF_Otros = true;
                historiaClinica.HF_DescripcionOtros = descripcionOtrosHF.Value.Trim();
            }

            if (apatEstado.Value == "presentesPat")
            {
                historiaClinica.APAT_Estado = true;
                historiaClinica.APAT_Descripcion = descripcionPatologicos.Value.Trim();
            }

            if (atEstado.Value == "presentesTrau")
            {
                historiaClinica.AT_Estado = true;
                historiaClinica.AT_Descripcion = descripcionTraumatico.Value.Trim();
            }

            if (aqEstado.Value == "presentesQui")
            {
                historiaClinica.AQ_Estado = true;
                historiaClinica.AQ_Descripcion = descripcionQuirurgico.Value.Trim();
            }

            if (alergiasEstado.Value == "presentesAlergia")
            {
                historiaClinica.Alergias = true;
                historiaClinica.AlegergiasDescripcion = descripcionAlergia.Value.Trim();
            }

        }


        /// <summary>
        /// Carga el esquema de vacunacion y las aplicaciones de cada una de ellas
        /// </summary>
        private void CargarEsquemaVacunacion(string idExpediente)
        {
            listaPendientes.Clear();
            vacunas.Clear();

            ManejadorVacunas manejadorVacunas = new ManejadorVacunas();
            ManejadorEdad manejadorEdad = new ManejadorEdad();
            
            int edadMeses = manejadorEdad.ExtraerMeses((DateTime) Session["fechaNacimento"]);

            
            List<BLAplicacionVacuna> aplicaciones = new List<BLAplicacionVacuna>();
            

            string confimacion = manejadorVacunas.CargarVacunas(vacunas);

            if (!confimacion.Contains("error"))
            {
                confimacion = manejadorVacunas.CargarAplicaciones(aplicaciones, idExpediente);

                if (!confimacion.Contains("error"))
                {
                    int mesesAplicacion = 0;

                    foreach (BLVacuna vacuna in vacunas)
                    {
                        
                        foreach (BLAplicacionVacuna aplicacion in aplicaciones)
                        {
                            if (vacuna.NombreVacuna.Equals(aplicacion.NombreVacuna))
                            {
                                if (!vacuna.Aplicacion1.Equals(""))
                                {
                                    mesesAplicacion = int.Parse(vacuna.Aplicacion1);

                                    if (mesesAplicacion <= edadMeses)
                                    {
                                        if (!aplicacion.Aplicacion1)
                                        {
                                            listaPendientes.Add(new Pendiente(aplicacion.NombreVacuna, mesesAplicacion));
                                        }
                                    }

                                }

                                //////////////////////////////
                                
                                if (!vacuna.Aplicacion2.Equals(""))
                                {

                                    mesesAplicacion = int.Parse(vacuna.Aplicacion2);

                                    if (mesesAplicacion <= edadMeses)
                                    {
                                        if (!aplicacion.Aplicacion2)
                                        {
                                            listaPendientes.Add(new Pendiente(aplicacion.NombreVacuna, mesesAplicacion));
                                        }
                                    }
                                }
                                //////////////////////////////

                                if (!vacuna.Aplicacion3.Equals(""))
                                {

                                    mesesAplicacion = int.Parse(vacuna.Aplicacion3);

                                    if (mesesAplicacion <= edadMeses)
                                    {
                                        if (!aplicacion.Aplicacion3)
                                        {
                                            listaPendientes.Add(new Pendiente(aplicacion.NombreVacuna, mesesAplicacion));
                                        }
                                    }
                                }
                                //////////////////////////////

                                if (!vacuna.Refuerzo1.Equals(""))
                                {

                                    mesesAplicacion = int.Parse(vacuna.Refuerzo1);

                                    if (mesesAplicacion <= edadMeses)
                                    {
                                        if (!aplicacion.Refuerzo1)
                                        {
                                            listaPendientes.Add(new Pendiente(aplicacion.NombreVacuna, mesesAplicacion));
                                        }
                                    }
                                }
                                //////////////////////////////

                                if (!vacuna.Refuerzo2.Equals(""))
                                {
                                    mesesAplicacion = int.Parse(vacuna.Refuerzo2);

                                    if (mesesAplicacion <= edadMeses)
                                    {
                                        if (!aplicacion.Refuerzo2)
                                        {
                                            listaPendientes.Add(new Pendiente(aplicacion.NombreVacuna, mesesAplicacion));
                                        }
                                    }
                                }
                                //////////////////////////////

                                if (!vacuna.Refuerzo3.Equals(""))
                                {
                                    mesesAplicacion = int.Parse(vacuna.Refuerzo3);

                                    if (mesesAplicacion <= edadMeses)
                                    {
                                        if (!aplicacion.Refuerzo3)
                                        {
                                            listaPendientes.Add(new Pendiente(aplicacion.NombreVacuna, mesesAplicacion));
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MostrarMensaje(confimacion);
                }
            }
            else
            {
                MostrarMensaje(confimacion);
            }
        }

        /// <summary>
        /// Se actualiza el esquema de vacunacion
        /// </summary>
        private void ActualizarEsquemaVacunacion()
        {
            CheckBox temp;
            List<BLAplicada> vacunasAplicadas = new List<BLAplicada>();
            string idExpediente = (string) Session["expedienteSeleccionado"];


            foreach (GridViewRow fila in esquemaVacunacion.Rows)
            {
                temp = (CheckBox) fila.Cells[0].FindControl("aplicado");

                if (temp.Checked)
                {
                    vacunasAplicadas.Add(AplicarVacuna(FormatoTildes(fila.Cells[1].Text), FormatoTildes(fila.Cells[2].Text), idExpediente));
                }
            }

            // ACTUALIZO LA BASE DE DATOS

            ManejadorVacunas manejador = new ManejadorVacunas();

            string confirmacion = manejador.ActualizarEsquemaVacunacion(vacunasAplicadas);

            MostrarMensaje(confirmacion);
        }

        /// <summary>
        /// Se obtiene el formato correcto de tildes
        /// </summary>
        /// <param name="tildar"></param>
        /// <returns></returns>
        private string FormatoTildes(string tildar)
        {
            tildar = tildar.Replace("&#243;", "ó").Replace("&#233;", "é").Replace("&#225;", "á").Replace("&#237;", "í").Replace("&#250;", "ú");
            return tildar;
        }

        private BLAplicada AplicarVacuna(string nombreVacuna, string edadAplicacion, string idExpediente)
        {
            BLAplicada aplicada = new BLAplicada();

            for (int i = 0; i < listaPendientes.Count; i++)
            {
                Pendiente pen = listaPendientes[i];
                if ((pen.EdadAplicacion.Equals(edadAplicacion)) && (pen.NombreVacuna.Equals(nombreVacuna)))
                {
                    aplicada.IDExpediente = idExpediente;
                    aplicada.NombreVacuna = pen.NombreVacuna;

                    foreach (BLVacuna vacuna in vacunas)
                    {
                        if (vacuna.NombreVacuna.Equals(aplicada.NombreVacuna))
                        {


                            if (!vacuna.Aplicacion1.Equals(""))
                            {
                                if (vacuna.Aplicacion1.Equals(pen.CantidadMeses + ""))
                                {
                                    aplicada.Aplicacion = "APLICACION1";
                                    break;
                                }

                            }

                            //////////////////////////////

                            if (!vacuna.Aplicacion2.Equals(""))
                            {
                                if (vacuna.Aplicacion2.Equals(pen.CantidadMeses + ""))
                                {
                                    aplicada.Aplicacion = "APLICACION2";
                                    break;
                                }
                            }
                            //////////////////////////////

                            if (!vacuna.Aplicacion3.Equals(""))
                            {
                                if (vacuna.Aplicacion3.Equals(pen.CantidadMeses + ""))
                                {
                                    aplicada.Aplicacion = "APLICACION3";
                                    break;
                                }
                            }
                            //////////////////////////////

                            if (!vacuna.Refuerzo1.Equals(""))
                            {
                                if (vacuna.Refuerzo1.Equals(pen.CantidadMeses + ""))
                                {
                                    aplicada.Aplicacion = "REFUERZO1";
                                    break;
                                }
                            }
                            //////////////////////////////

                            if (!vacuna.Refuerzo2.Equals(""))
                            {
                                if (vacuna.Refuerzo2.Equals(pen.CantidadMeses + ""))
                                {
                                    aplicada.Aplicacion = "REFUERZO2";
                                    break;
                                }
                            }
                            //////////////////////////////

                            if (!vacuna.Refuerzo3.Equals(""))
                            {
                                if (vacuna.Refuerzo3.Equals(pen.CantidadMeses + ""))
                                {
                                    aplicada.Aplicacion = "REFUERZO3";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    listaPendientes.RemoveAt(i);
                    break;
                }
            }
            return aplicada;
        }

        private void MostrarMensaje(string confirmacion)
        {
            string colorMensaje = "success";

            if (confirmacion.Contains("error"))
            {
                colorMensaje = "danger";
            }
            mensajeConfirmacion1.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
            "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
            " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
            " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion1.Visible = true;
        }


        private void MostrarEsquemaVacunacion(string idExpediente)
        {
            CargarEsquemaVacunacion(idExpediente);

            esquemaVacunacion.DataSource = listaPendientes;
            esquemaVacunacion.DataBind();

        }

        private class Pendiente
        {
            public string NombreVacuna { get; set; }
            public int CantidadMeses { get; set; }
            public string EdadAplicacion { get; set; }

            public Pendiente()
            {

            }
            public Pendiente(string nombreVacuna, int cantidadMeses)
            {
                this.NombreVacuna = nombreVacuna;
                this.CantidadMeses = cantidadMeses;
                this.EdadAplicacion = Formato(cantidadMeses);
            }

            /// <summary>
            /// Convierte el formato a la edad de aplicacion 
            /// </summary>
            /// <param name="cantidadMeses"></param>
            /// <returns>Retorna el formato correcto para mostrar</returns>
            private string Formato(int cantidadMeses)
            {
                int annos = 0;

                if (cantidadMeses >= 12)
                {
                    annos = cantidadMeses / 12;

                    int sobranteMeses = cantidadMeses - (annos * 12);

                    if (sobranteMeses == 0)
                    {
                        if (annos == 1)
                        {
                            return annos + "año";
                        }
                        return annos + " años";
                    }

                    if (annos == 1 && sobranteMeses == 1)
                    {
                        return annos + " año y " + sobranteMeses + " mes";
                    }
                    if (annos == 1 && sobranteMeses > 1)
                    {
                        return annos + " año y " + sobranteMeses + " meses";
                    }
                    if (annos > 1 && sobranteMeses == 1)
                    {
                        return annos + " años y " + sobranteMeses + " mes";
                    }
                    return annos + " años y " + sobranteMeses + " meses";
                }
                else
                {
                    if (cantidadMeses == 1)
                    {
                        return cantidadMeses + " mes";
                    }

                    return cantidadMeses + " meses";
                }
            }
        }

        

        private byte[] guardarImag()
        {
            int tamaño = fotoPaciente.PostedFile.ContentLength;
            byte[] imagenOoriginal = new byte[tamaño];
            fotoPaciente.PostedFile.InputStream.Read(imagenOoriginal, 0, tamaño);
            Bitmap imagenOrinalBinaria = new Bitmap(fotoPaciente.PostedFile.InputStream);

            string imagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(imagenOoriginal);

            imgPreview.ImageUrl = imagenDataURL64;
            return imagenOoriginal;

        }

        private string codigoDireccion(string provincia, string canton, string distrito, string barrio)
        {
            string codDireccion;

            codDireccion = provincia.Substring(0, 2);
            codDireccion += canton.Substring(0, 2);
            codDireccion += distrito.Substring(0, 2);

            if (barrio == "")
            {
                return codDireccion;
            }
            else
            {
                codDireccion += barrio.Substring(0, 2);
                return codDireccion;
            }
        }

        protected void verConsultas_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "expediente-verConsulta";
            Response.Redirect("ListaConsultas.aspx");
        }

        protected void nuevaConsulta_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "expediente-nuevaConsulta";
            Response.Redirect("FichaConsultaPaciente.aspx");
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaExpedientes.aspx");
        }


        //private void MostrarMensaje(string confirmacion)
        //{
        //    string colorMensaje = "success";

        //    if (confirmacion.Contains("error"))
        //    {
        //        colorMensaje = "danger";
        //    }


        //    mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
        //        "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
        //        " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
        //        " <span aria-hidden=\"true\">&times;</span> </button> </div>";
        //    mensajeConfirmacion.Visible = true;
        //}
    }
}