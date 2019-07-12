using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using BL;
using System.Globalization;

namespace Pediatric_System
{
    public partial class FichaConsultaPaciente : System.Web.UI.Page
    {
        BLExpediente expediente = new BLExpediente();
        protected void Page_Load(object sender, EventArgs e)
        {
            imcPac.Disabled = true;

            expediente = (BLExpediente)Session["Expediente"];

            //Mostrar los datos generales 
            if (expediente.Codigo == expediente.Cedula)
            {
                cedGeneral.InnerText = " " + expediente.Cedula;
            }
            else
            {
                cedGeneral.InnerText = "No tiene aún";
            }
            paciGeneral.InnerText = " " + expediente.Nombre + " " + expediente.PrimerApellido + " " + expediente.SegundoApellido;
            TimeSpan dt = DateTime.Now - expediente.FechaNacimiento;
            edaGeneral.InnerText = " " + Convert.ToString(dt.Days) + " días";
            string imagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(expediente.Foto);
            imgPreview.ImageUrl = imagenDataURL64;

            if (!Page.IsPostBack)
            {
                if (((string)Session["pagina"] != "consultas_guardada") || ((string)Session["pagina"] != "consultas_activas_seleccionada"))
                {

                    string fechaA = Convert.ToString(DateTime.Now);


                    const string FMT = "o";
                    DateTime fff = Convert.ToDateTime(fechaA);
                    string news = fff.ToString(FMT);
                    DateTime ggg = DateTime.ParseExact(news, FMT, CultureInfo.InvariantCulture);


                    BLConsulta consulta = new BLConsulta();
                    consulta.CodigoExpediente = expediente.Codigo;
                    consulta.Fecha_Hora = ggg;
                    consulta.Estado = true;
                    consulta.CodigoMedico = Session["codigoMedico"].ToString();
                    BLExamenFisico examenFisico = new BLExamenFisico();
                    examenFisico.CodigoExpediente = expediente.Codigo;
                    examenFisico.Fecha_Hora = ggg;
                    examenFisico.CodigoMedico = Session["codigoMedico"].ToString();

                    ManejadorConsulta manejador = new ManejadorConsulta();
                    manejador.crearConsulta(consulta, examenFisico);

                    Session["consulta"] = consulta;
                }
                else
                {
                    cargarConsulta();
                }
            }
        }

        protected void finalizarConsulta_Click(object sender, EventArgs e)
        {
            BLConsulta consulta = new BLConsulta();
            consulta = (BLConsulta)Session["consulta"];
            consulta.Estado = false;

            ManejadorConsulta manejador = new ManejadorConsulta();
            manejador.cambiarEstadoConsulta(consulta);

            Response.Redirect("ListaConsultas.aspx");
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaConsultas.aspx");
        }

        protected void guardarConsulta_Click(object sender, EventArgs e)
        {
            actualizarConsulta();
            Response.Redirect("ListaConsultas.aspx");

        }

        protected void btnReportarMM_Click(object sender, EventArgs e)
        {
            BLConsulta consulta = new BLConsulta();
            consulta = (BLConsulta)Session["consulta"];

            consulta.MedicinaMixta = true;

            if(subsecuente.Checked == true)
            {
                consulta.Frecuencia = "subsecuen";
            }
            else
            {
                string frecu = "primera" + " ";

                if(opcion_vida.Checked == true)
                {
                    frecu += "vida";
                }
                else
                {
                    frecu += "anno";
                }
                consulta.Frecuencia = frecu;
            }

            if(especialista.Checked == true)
            {
                consulta.ReferidoA = "refe_especialista";
            }

            if (hospitalizacion.Checked == true)
            {
                consulta.ReferidoA = "refe_hospitalizacion";
            }

            if (otro_centro.Checked == true)
            {
                consulta.ReferidoA = "refe_otro_centro";
            }

            ManejadorConsulta manejador = new ManejadorConsulta();
            manejador.actualizarReporteMedicinaMixta(consulta);
        }

        private void cargarConsulta()
        {
            BLExamenFisico examenFisico = new BLExamenFisico();
            BLConsulta consultaEnviada = new BLConsulta();
            consultaEnviada = (BLConsulta)Session["consulta"];
            if(consultaEnviada.Estado == false)
            {
                finalizarConsulta.Visible = false;
            }

            ManejadorConsulta manejador = new ManejadorConsulta();
            if(Session["pagina"].ToString() == "consultas_guardada")
            {
                manejador.mostrarConsulta(consultaEnviada.CodigoExpediente, consultaEnviada.Fecha_Hora, consultaEnviada, examenFisico);
            }
            else
            {
                manejador.mostrarConsultaFecha(consultaEnviada.Fecha_Hora, consultaEnviada, examenFisico);
            }

            //Datos del objeto Consulta 
            analisisPac.Value = consultaEnviada.Analisis;
            impresionPac.Value = consultaEnviada.ImpresionDiagnostica;
            planPac.Value = consultaEnviada.Plan;
            padecimientoPac.Value = consultaEnviada.PadecimientoActual;

            
            if (consultaEnviada.MedicinaMixta == true)
            {
                reporte_medicina_mixta.Checked = true;
                reporte_medicina_mixta.Disabled = true;
                btnReportarMM.Visible = false;

                string frecuen = consultaEnviada.Frecuencia;

                if(frecuen == "subsecuen")
                {
                    subsecuente.Checked = true;
                }
                else
                {
                    primera_vez.Checked = true;

                    string[] frecuDiv = frecuen.Split();
                    string tiposPri = frecuDiv[1];
                    if (tiposPri == "vida")
                    {
                        opcion_vida.Checked = true;
                    }
                    else
                    {
                        opcion_anno.Checked = true;
                    }
                }

                string tiposReferi = consultaEnviada.ReferidoA;
                if(tiposReferi == "refe_especialista")
                {
                    especialista.Checked = true;
                }

                if (tiposReferi == "refe_hospitalizacion")
                {
                    hospitalizacion.Checked = true;
                }

                if (tiposReferi == "refe_otro_centro")
                {
                    otro_centro.Checked = true;
                }

                if(consultaEnviada.ReferenciaMedica == true)
                {
                    referencia_consulta_privada.Checked = true;
                    referencia_consulta_privada.Disabled = true;

                    especialidad.Text = consultaEnviada.Especialidad;
                    motivo.Value = consultaEnviada.MotivoReferecnia;
                }
            }


            //Datos del objeto Examen Fisico
            tallaPac.Value = Convert.ToString(examenFisico.Talla);
            pesoPac.Value = Convert.ToString(examenFisico.Peso);
            perimetroPac.Value = Convert.ToString(examenFisico.PerimetroCefalico);
            so2Pac.Value = Convert.ToString(examenFisico.SO2);
            imcPac.Value = Convert.ToString(examenFisico.IMC);
            temperaturaPac.Value = Convert.ToString(examenFisico.Temperatura);
            alertaPac.Value = examenFisico.EstadoAlerta;
            hidratacionPac.Value = examenFisico.EstadoHidratacion;
            ruidosPac.Value = examenFisico.RuidosCardiacos;
            camposPac.Value = examenFisico.CamposPulmonares;
            abdomenPpac.Value = examenFisico.Abdomen;
            faringePac.Value = examenFisico.Faringe;
            neuroPac.Value = examenFisico.Neurodesarrollo;
            narizPac.Value = examenFisico.Nariz;
            oidosPac.Value = examenFisico.Oidos;
            sncPac.Value = examenFisico.SNC;
            osteomuscPac.Value = examenFisico.Osteomuscular;
            pielPac.Value = examenFisico.Piel;
            otrosPac.Value = examenFisico.Otros;
        }

        private void actualizarConsulta()
        {
            BLConsulta consultaActu = new BLConsulta();
            BLExamenFisico examenFisicoActu = new BLExamenFisico();

            //Datos del objeto Consulta 
            consultaActu.Analisis = analisisPac.Value.Trim();
            consultaActu.ImpresionDiagnostica = impresionPac.Value.Trim();
            consultaActu.Plan = planPac.Value.Trim();
            consultaActu.PadecimientoActual = padecimientoPac.Value.Trim();
            
            //Datos del objeto Examen Fisico
            examenFisicoActu.Talla = float.Parse(tallaPac.Value);
            examenFisicoActu.Peso = float.Parse(pesoPac.Value);
            examenFisicoActu.PerimetroCefalico = float.Parse(perimetroPac.Value);
            examenFisicoActu.SO2 = float.Parse(so2Pac.Value);
            examenFisicoActu.IMC = float.Parse(tallaPac.Value) * float.Parse(pesoPac.Value);
            examenFisicoActu.Temperatura = float.Parse(temperaturaPac.Value);
            examenFisicoActu.EstadoAlerta = alertaPac.Value.Trim();
            examenFisicoActu.EstadoHidratacion = hidratacionPac.Value.Trim();
            examenFisicoActu.RuidosCardiacos = ruidosPac.Value.Trim();
            examenFisicoActu.CamposPulmonares = camposPac.Value.Trim();
            examenFisicoActu.Abdomen = abdomenPpac.Value.Trim();
            examenFisicoActu.Faringe = faringePac.Value.Trim();
            examenFisicoActu.Neurodesarrollo = neuroPac.Value.Trim();
            examenFisicoActu.Nariz = narizPac.Value.Trim();
            examenFisicoActu.Oidos = oidosPac.Value.Trim();
            examenFisicoActu.SNC = sncPac.Value.Trim();
            examenFisicoActu.Osteomuscular = osteomuscPac.Value.Trim();
            examenFisicoActu.Piel = pielPac.Value.Trim();
            examenFisicoActu.Otros = otrosPac.Value.Trim();

            BLConsulta consultaGuardada = new BLConsulta();
            consultaGuardada = (BLConsulta)Session["consulta"];
            consultaActu.Fecha_Hora = consultaGuardada.Fecha_Hora;
            consultaActu.CodigoExpediente = consultaGuardada.CodigoExpediente;
            consultaActu.Estado = consultaGuardada.Estado;

            examenFisicoActu.Fecha_Hora = consultaGuardada.Fecha_Hora;
            examenFisicoActu.CodigoExpediente = consultaGuardada.CodigoExpediente;

            ManejadorConsulta manejador = new ManejadorConsulta();
            manejador.actualizarConsulta(consultaActu, examenFisicoActu);

        }


        /// <summary>
        /// Genera un pdf con la referencia a consulta externa privada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerarReferencia_Click(object sender, EventArgs e)
        {

            //Actualizar consulta con los datos de la referencia 
            BLConsulta consulta = new BLConsulta();
            consulta = (BLConsulta)Session["consulta"];

            consulta.ReferenciaMedica = true;
            consulta.Especialidad = especialidad.Text.Trim();
            consulta.MotivoReferecnia = motivo.Value.Trim();

            ManejadorConsulta manejador = new ManejadorConsulta();
            manejador.actualizarReferenciaMedica(consulta);


            ///////////////////////////////////////////////////////////////////////////

            StringWriter sw = new StringWriter();
            string html = sw.ToString();

            Document Doc = new Document(iTextSharp.text.PageSize.LETTER, 30f, 30f, 50f, 40f);

            String path = this.Server.MapPath(".") + "\\referencia\\referencia.pdf";

            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);



            PdfWriter.GetInstance(Doc, file);

            Doc.Open();

            Font fuente = new Font();
            fuente.SetStyle(Font.UNDERLINE);

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font times = new Font(bfTimes, 15, Font.NORMAL, Color.BLACK);
            Font times2 = new Font(bfTimes, 12, Font.NORMAL, Color.BLACK);
            times.SetStyle(Font.UNDERLINE);

            Chunk c = new Chunk
            ("Hoja de referencia médica Clínica Pediátrica Divino Niño", times);

            Paragraph p = new Paragraph();
            p.Alignment = Element.ALIGN_CENTER;
            p.Add(c);


            Chunk chunk2 = new Chunk
            ("\n\nFecha de la referencia: " + DateTime.Now.ToLongDateString() + "\n");
            Paragraph p2 = new Paragraph();
            p2.Alignment = Element.ALIGN_JUSTIFIED;
            p2.Add(chunk2);

            string nombreMedico = "Robert Moya Vásquez";

            Chunk chunk3 = new Chunk("Nombre del médico remitente: " + nombreMedico + "\n");
            Paragraph p3 = new Paragraph();
            p3.Alignment = Element.ALIGN_JUSTIFIED;
            p3.Add(chunk3);

            string telefonoMedico = "83112858";

            Chunk chunk4 = new Chunk("Teléfono del médico remitente: " + telefonoMedico + "\n");
            Paragraph p4 = new Paragraph();
            p4.Alignment = Element.ALIGN_JUSTIFIED;
            p4.Add(chunk4);

            string codigoMedico = "6136";

            Chunk chunk5 = new Chunk("Código del médico remitente: " + codigoMedico + "\n");
            Paragraph p5 = new Paragraph();
            p5.Alignment = Element.ALIGN_JUSTIFIED;
            p5.Add(chunk5);

            Chunk chunk1 = new Chunk("Especialidad a la que refiere: " + especialidad.Text + "\n");
            Paragraph p1 = new Paragraph();
            p1.Alignment = Element.ALIGN_JUSTIFIED;
            p1.Add(chunk1);

            Chunk chunk6 = new Chunk("Motivo de la referencia: " + motivo.Value + "\n\n");
            Paragraph p6 = new Paragraph();
            p6.Alignment = Element.ALIGN_JUSTIFIED;
            p6.Add(chunk6);

            Chunk chunk7 = new Chunk("Datos Personales del Paciente", fuente);
            Paragraph p7 = new Paragraph();
            p7.Alignment = Element.ALIGN_JUSTIFIED;
            p7.Add(chunk7);


            string nombrePaciente = Session["nombrePaciente"].ToString();

            Chunk chunk8 = new Chunk("\nNombre completo: " + nombrePaciente + "\n");
            Paragraph p8 = new Paragraph();
            p8.Alignment = Element.ALIGN_JUSTIFIED;
            p8.Add(chunk8);

            string edadPaciente = Session["edadPaciente"].ToString();

            Chunk chunk9 = new Chunk("Edad: " + edadPaciente + "\n");
            Paragraph p9 = new Paragraph();
            p9.Alignment = Element.ALIGN_JUSTIFIED;
            p9.Add(chunk9);

            string direccionPaciente = Session["direccionPaciente"].ToString();

            Chunk chunk10 = new Chunk("Dirección: " + direccionPaciente + "\n\n");
            Paragraph p10 = new Paragraph();
            p10.Alignment = Element.ALIGN_JUSTIFIED;
            p10.Add(chunk10);

            Chunk chunk11 = new Chunk("Datos Personales del Encargado", fuente);
            Paragraph p11 = new Paragraph();
            p11.Alignment = Element.ALIGN_JUSTIFIED;
            p11.Add(chunk11);


            string nombreEncargado = Session["nombreEncargado"].ToString();

            Chunk chunk12 = new Chunk("\nNombre completo: " + nombreEncargado + "\n");
            Paragraph p12 = new Paragraph();
            p12.Alignment = Element.ALIGN_JUSTIFIED;
            p12.Add(chunk12);

            string telefonoEncargado = Session["telefonoEncargado"].ToString();

            Chunk chunk13 = new Chunk("Teléfono: " + telefonoEncargado + "\n");
            Paragraph p13 = new Paragraph();
            p13.Alignment = Element.ALIGN_JUSTIFIED;
            p13.Add(chunk13);

            string direccionEncargado = Session["direccionEncargado"].ToString();

            Chunk chunk14 = new Chunk("Dirección: " + direccionEncargado + "\n\n");
            Paragraph p14 = new Paragraph();
            p14.Alignment = Element.ALIGN_JUSTIFIED;
            p14.Add(chunk14);


            Chunk chunk15 = new Chunk("Resultados del Examen Físico", fuente);
            Paragraph p15 = new Paragraph();
            p15.Alignment = Element.ALIGN_JUSTIFIED;
            p15.Add(chunk15);

            string talla = tallaPac.Value.Trim();

            Chunk chunk16 = new Chunk("\nTalla: " + talla + "\n");
            Paragraph p16 = new Paragraph();
            p16.Alignment = Element.ALIGN_JUSTIFIED;
            p16.Add(chunk16);

            string peso = pesoPac.Value.Trim();

            Chunk chunk17 = new Chunk("Peso: " + peso + "\n");
            Paragraph p17 = new Paragraph();
            p17.Alignment = Element.ALIGN_JUSTIFIED;
            p17.Add(chunk17);

            string perimetroCefalico = perimetroPac.Value.Trim();

            Chunk chunk18 = new Chunk("Perímetro Cefálico: " + perimetroCefalico + "\n");
            Paragraph p18 = new Paragraph();
            p18.Alignment = Element.ALIGN_JUSTIFIED;
            p18.Add(chunk18);

            string temperatuta = temperaturaPac.Value.Trim();

            Chunk chunk19 = new Chunk("Temperatura: " + temperatuta + "\n");
            Paragraph p19 = new Paragraph();
            p19.Alignment = Element.ALIGN_JUSTIFIED;
            p19.Add(chunk19);

            string so2 = so2Pac.Value.Trim();

            Chunk chunk20 = new Chunk("SO2: " + so2 + "\n");
            Paragraph p20 = new Paragraph();
            p20.Alignment = Element.ALIGN_JUSTIFIED;
            p20.Add(chunk20);

            string imc = imcPac.Value.Trim();

            Chunk chunk21 = new Chunk("IMC: " + imc + "\n");
            Paragraph p21 = new Paragraph();
            p21.Alignment = Element.ALIGN_JUSTIFIED;
            p21.Add(chunk21);

            string estadoAlerta = alertaPac.Value.Trim();

            Chunk chunk22 = new Chunk("Estado de alerta: " + estadoAlerta + "\n");
            Paragraph p22 = new Paragraph();
            p22.Alignment = Element.ALIGN_JUSTIFIED;
            p22.Add(chunk22);

            string estadoHidratacion = hidratacionPac.Value.Trim();

            Chunk chunk23 = new Chunk("Estado de hidratación: " + estadoHidratacion + "\n");
            Paragraph p23 = new Paragraph();
            p23.Alignment = Element.ALIGN_JUSTIFIED;
            p23.Add(chunk23);

            string ruidosCardiacos = ruidosPac.Value.Trim();

            Chunk chunk24 = new Chunk("Ruidos cardiácos: " + ruidosCardiacos + "\n");
            Paragraph p24 = new Paragraph();
            p24.Alignment = Element.ALIGN_JUSTIFIED;
            p24.Add(chunk24);

            string camposPulmonares = camposPac.Value.Trim();

            Chunk chunk25 = new Chunk("Campos pulmonares: " + camposPulmonares + "\n");
            Paragraph p25 = new Paragraph();
            p25.Alignment = Element.ALIGN_JUSTIFIED;
            p25.Add(chunk25);

            string abdomen = abdomenPpac.Value.Trim();

            Chunk chunk26 = new Chunk("Abdomen: " + abdomen + "\n");
            Paragraph p26 = new Paragraph();
            p26.Alignment = Element.ALIGN_JUSTIFIED;
            p26.Add(chunk26);

            string faringe = faringePac.Value.Trim();

            Chunk chunk27 = new Chunk("Faringe: " + faringe + "\n");
            Paragraph p27 = new Paragraph();
            p27.Alignment = Element.ALIGN_JUSTIFIED;
            p27.Add(chunk27);

            string neurodesarrollo = neuroPac.Value.Trim();

            Chunk chunk28 = new Chunk("Neurodesarrollo: " + neurodesarrollo + "\n");
            Paragraph p28 = new Paragraph();
            p28.Alignment = Element.ALIGN_JUSTIFIED;
            p28.Add(chunk28);

            string nariz = narizPac.Value.Trim();

            Chunk chunk29 = new Chunk("Nariz: " + nariz + "\n");
            Paragraph p29 = new Paragraph();
            p29.Alignment = Element.ALIGN_JUSTIFIED;
            p29.Add(chunk29);

            string oidos = oidosPac.Value.Trim();

            Chunk chunk30 = new Chunk("Oídos: " + oidos + "\n");
            Paragraph p30 = new Paragraph();
            p30.Alignment = Element.ALIGN_JUSTIFIED;
            p30.Add(chunk30);

            string snc = sncPac.Value.Trim();

            Chunk chunk31 = new Chunk("SNC: " + snc + "\n");
            Paragraph p31 = new Paragraph();
            p31.Alignment = Element.ALIGN_JUSTIFIED;
            p31.Add(chunk31);

            string sistemaOsteomuscular = osteomuscPac.Value.Trim();

            Chunk chunk32 = new Chunk("Sistema Osteomuscular: " + sistemaOsteomuscular + "\n");
            Paragraph p32 = new Paragraph();
            p32.Alignment = Element.ALIGN_JUSTIFIED;
            p32.Add(chunk32);

            string piel = pielPac.Value.Trim();

            Chunk chunk33 = new Chunk("Piel: " + piel + "\n");
            Paragraph p33 = new Paragraph();
            p33.Alignment = Element.ALIGN_JUSTIFIED;
            p33.Add(chunk33);

            string hallazgos = otrosPac.Value.Trim();

            Chunk chunk34 = new Chunk("Otros hallazgos: " + hallazgos + "\n\n");
            Paragraph p34 = new Paragraph();
            p34.Alignment = Element.ALIGN_JUSTIFIED;
            p34.Add(chunk34);

            Chunk chunk35 = new Chunk("Padecimiento Actual", fuente);
            Paragraph p35 = new Paragraph();
            p35.Alignment = Element.ALIGN_JUSTIFIED;
            p35.Add(chunk35);

            string padecimiento = padecimientoPac.Value.Trim();

            Chunk chunk36 = new Chunk("\n" + padecimiento + "\n\n");
            Paragraph p36 = new Paragraph();
            p36.Alignment = Element.ALIGN_JUSTIFIED;
            p36.Add(chunk36);

            Chunk chunk37 = new Chunk("Análisis", fuente);
            Paragraph p37 = new Paragraph();
            p37.Alignment = Element.ALIGN_JUSTIFIED;
            p37.Add(chunk37);

            string analisis = analisisPac.Value.Trim();

            Chunk chunk38 = new Chunk("\n" + analisis + "\n\n");
            Paragraph p38 = new Paragraph();
            p38.Alignment = Element.ALIGN_JUSTIFIED;
            p38.Add(chunk38);

            Chunk chunk39 = new Chunk("Impresión Diagnóstica", fuente);
            Paragraph p39 = new Paragraph();
            p39.Alignment = Element.ALIGN_JUSTIFIED;
            p39.Add(chunk39);

            string impresionDiagnostica = impresionPac.Value.Trim();

            Chunk chunk40 = new Chunk("\n" + impresionDiagnostica + "\n\n\n\n");
            Paragraph p40 = new Paragraph();
            p40.Alignment = Element.ALIGN_JUSTIFIED;
            p40.Add(chunk40);

            Chunk chunk41 = new Chunk("\n\n______________________________\n");
            Paragraph p41 = new Paragraph();
            p41.Alignment = Element.ALIGN_CENTER;
            p41.Add(chunk41);

            Chunk chunk42 = new Chunk("Firma del médico remitente\n");
            Paragraph p42 = new Paragraph();
            p42.Alignment = Element.ALIGN_CENTER;
            p42.Add(chunk42);


            Doc.Add(p);
            Doc.Add(p2);
            Doc.Add(p3);
            Doc.Add(p4);
            Doc.Add(p5);
            Doc.Add(p1);
            Doc.Add(p6);
            Doc.Add(p7);
            Doc.Add(p8);
            Doc.Add(p9);
            Doc.Add(p10);
            Doc.Add(p11);
            Doc.Add(p12);
            Doc.Add(p13);
            Doc.Add(p14);
            Doc.Add(p35);
            Doc.Add(p36);
            Doc.Add(p15);
            Doc.Add(p16);
            Doc.Add(p17);
            Doc.Add(p18);
            Doc.Add(p19);
            Doc.Add(p20);
            Doc.Add(p21);
            Doc.Add(p22);
            Doc.Add(p23);
            Doc.Add(p24);
            Doc.Add(p25);
            Doc.Add(p26);
            Doc.Add(p27);
            Doc.Add(p28);
            Doc.Add(p29);
            Doc.Add(p30);
            Doc.Add(p31);
            Doc.Add(p32);
            Doc.Add(p33);
            Doc.Add(p34);
            Doc.Add(p35);
            Doc.Add(p36);
            Doc.Add(p37);
            Doc.Add(p38);
            Doc.Add(p39);
            Doc.Add(p40);
            Doc.Add(p41);
            Doc.Add(p42);


            System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new StringReader(html));
            HtmlParser.Parse(Doc, xmlReader);

            Doc.Close();

            ShowPdf(path);
        }

        /// <summary>
        /// Muestra el pdf generado
        /// </summary>
        /// <param name="strS"></param>
        private void ShowPdf(string strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader
            ("Content-Disposition", "attachment; filename=" + "Referencia.pdf");
            Response.TransmitFile(strS);
            Response.End();
            Response.Flush();
            Response.Clear();

        }

        
    }
}