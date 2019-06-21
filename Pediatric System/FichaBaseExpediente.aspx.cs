using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class FichaBaseExpediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void guardarExpediente_Click(object sender, EventArgs e)
        {
            // Recuperar campos de texto
            string nombreTxt = nombre.Text.Trim();
            string primerApellidoTxt = primerApellido.Text.Trim();
            string segundoApellidoTxt = segundoApellido.Text.Trim();
            string cedulaTxt = cedula.Text.Trim();
            DateTime fechaNacimientoTxt = DateTime.ParseExact(fechaNacimiento.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

            string sexoTxt = sexo.Text.Trim();
            string fotoTxt = fotoPaciente.FileName; // Cambiar esto por la direccion donde se va a almacenar
            string vincularExpedienteTxt = VincExpediente.Text.Trim();

            // Enviar datos para guardar en BD

            ManejadorExpediente manejador = new ManejadorExpediente();
            //string confirmacion = manejador.crearExpediente(nombreTxt, primerApellidoTxt, segundoApellidoTxt, cedulaTxt, fechaNacimientoTxt, sexoTxt, fotoTxt, vincularExpedienteTxt);
            string confirmacion = "";
            string colorMensaje = "success";

            if (confirmacion.Contains("error"))
            {
                colorMensaje = "danger";
            }

            mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
                "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
                " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
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