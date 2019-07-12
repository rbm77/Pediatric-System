using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pediatric_System
{
    public partial class dashboard : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["pagina"] = "dashboard";
            if(Session["codigoMedico"] == null)
            {
                mensajeAviso("warning", "Debe tener un medico asociado a su cuenta para acceder a la sección de Citas");
            }

            conteos();
        }

        public void conteos()
        {
            BLDatos_Dashboard misDatos = new BLDatos_Dashboard();
            BLAdministrativo miBLAdministrativo = new BLAdministrativo();
            if (Session["codigoMedico"] != null)
            {
                misDatos.buscarDatosDashBoard(Session["codigoMedico"].ToString());
                lblCantidadExpedientes.Attributes.Add("data-to", misDatos.cantidadExpedientes);
                lblCantidadCitasPendientes.Attributes.Add("data-to", misDatos.cantidadCitasPendientes);
                lblCantidadConsultaActiva.Attributes.Add("data-to", misDatos.cantidadConsultasActivas);
            }
            else {

                miBLAdministrativo.correo = Session["Cuenta"].ToString();
                miBLAdministrativo.buscarAdministrativo();
                if (miBLAdministrativo.cod_Asist == "")
                {
                    misDatos.buscarDatosDashBoard("");
                    lblCantidadExpedientes.Attributes.Add("data-to", misDatos.cantidadExpedientes);
                    lblCantidadCitasPendientes.Attributes.Add("data-to", misDatos.cantidadCitasPendientes);
                    lblCantidadConsultaActiva.Attributes.Add("data-to", misDatos.cantidadConsultasActivas);
                } else {
                    Session["codigoMedico"] = miBLAdministrativo.cod_Asist;
                    misDatos.buscarDatosDashBoard(miBLAdministrativo.cod_Asist);
                    lblCantidadExpedientes.Attributes.Add("data-to", misDatos.cantidadExpedientes);
                    lblCantidadCitasPendientes.Attributes.Add("data-to", misDatos.cantidadCitasPendientes);
                    lblCantidadConsultaActiva.Attributes.Add("data-to", misDatos.cantidadConsultasActivas);
                }
            }
        }
        public void mensajeAviso(String color, String texto)
        {
            //Colores:  primary = Azul
            //          secondary = Gris
            //          success = Verde
            //          danger = Rojo
            //          warning = Amarillo
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + color + " alert-dismissible fade show\" " +
           "role=\"alert\"  style =\"margin-left:50%\"> <strong></strong>" + texto + "<button" +
         " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
         " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }
    }
}