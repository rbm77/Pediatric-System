using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class InicioUsuarioExterno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cuenta"] == null)
            {
                Response.Redirect("IniciarSesion.aspx");
            }
            conteos();
        }

        public void conteos()
        {
            BLDatos_Dashboard misDatos = new BLDatos_Dashboard();
            misDatos.buscarDatosDashBoardPaciente(Session["Cuenta"].ToString());
            lblCantidadExpedientes.Attributes.Add("data-to", misDatos.cantidadExpedientes);
            lblCantidadCitasPendientes.Attributes.Add("data-to", misDatos.cantidadCitasPendientes);
           
        }
    }
}