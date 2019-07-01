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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((string)Session["pagina"] == "listaExpedientes-Nuevo")
            //{
            //    verConsultas.Visible = false;
            //    nuevaConsulta.Visible = false;
            //    informacionPaciente.Visible = false;
            //}

            if ((string)Session["pagina"] == "dashboard")
            {
                verConsultas.Visible = false;
                nuevaConsulta.Visible = false;
                informacionPaciente.Visible = false;
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

        //    string confirmacion = manejador.crearExpediente(expediente);


            //string colorMensaje = "success";

            //if (confirmacion.Contains("error"))
            //{
            //    colorMensaje = "danger";
            //}

            //mensajeConfirmacion1.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
            //    "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
            //    " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
            //    " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            //mensajeConfirmacion1.Visible = true;            
        }

        private void infoTab_1(BLExpediente expediente, BLDireccion direccionExp)
        {

            // Recuperar campos de texto para objeto Direccion (Expediente) 
            string provincia = Request.Form["listaProvinciasEX"];
            string canton = Request.Form["listaCantonEX"];
            string distrito = Request.Form["listaDistritoEX"];
            string codigo = codigoDireccion(provincia, canton, distrito, "");

            direccionExp.Codigo = codigo;
            direccionExp.Provincia = provincia;
            direccionExp.Canton = canton;
            direccionExp.Distrito = distrito;

            // Recuperar campos de texto para objeto Expediente
            expediente.Nombre = nombrePaciente.Text.Trim();
            expediente.PrimerApellido = primerApellidoPaciente.Text.Trim();
            expediente.SegundoApellido = segundoApellidoPaciente.Text.Trim();
            expediente.Cedula = cedulaPaciente.Text.Trim();
            expediente.FechaNacimiento = DateTime.ParseExact(fechaNacimientoPaciente.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
            expediente.Sexo = sexoPaciente.Text.Trim();
            expediente.Foto = guardarImag();
            expediente.ExpedienteAntiguo = VincExpedientePaciente.Text.Trim();
            expediente.Direccion = codigo;

            //byte[] fotoTxt = guardarImag();
        }

        private void infoTab_2 (BLEncargado_Facturante encargado, BLDireccion direccionEncar)
        {
            // Recuperar campos de texto para objeto Direccion(Encargado)
            string provincia = Request.Form["listaProvinciasEN"];
            string canton = Request.Form["listaCantonEN"];
            string distrito = Request.Form["listaDistritoEN"];
            string barrio = Request.Form["listaDistritoEN"];
            string codigo = codigoDireccion(provincia, canton, distrito, barrio);

            direccionEncar.Codigo = codigo;
            direccionEncar.Provincia = provincia;
            direccionEncar.Canton = canton;
            direccionEncar.Distrito = distrito;

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
            string provincia = Request.Form["listaProvinciasFA"];
            string canton = Request.Form["listaCantonFA"];
            string distrito = Request.Form["listaDistritoFA"];
            string barrio = Request.Form["listaDistritoFA"];
            string codigo = codigoDireccion(provincia, canton, distrito, barrio);

            direccionFactu.Codigo = codigo;
            direccionFactu.Provincia = provincia;
            direccionFactu.Canton = canton;
            direccionFactu.Distrito = distrito;

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