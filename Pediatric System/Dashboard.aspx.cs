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
            conteos();
        }

        public void conteos()
        {
            BLDatos_Dashboard misDatos = new BLDatos_Dashboard();

            if (Session["codigoMedico"] != null)
            {
                misDatos.buscarDatosDashBoard(Session["codigoMedico"].ToString());
                lblCantidadExpedientes.Attributes.Add("data-to", misDatos.cantidadExpedientes);
                lblCantidadCitasPendientes.Attributes.Add("data-to", misDatos.cantidadCitasPendientes);
                lblCantidadConsultaActiva.Attributes.Add("data-to", misDatos.cantidadConsultasActivas);
            }

        }
       
    }
}