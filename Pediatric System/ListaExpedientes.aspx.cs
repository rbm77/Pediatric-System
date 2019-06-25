using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class InicioPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Cuenta"] == null) { Response.Redirect("IniciarSesion.aspx"); }

            ManejadorExpediente manejador = new ManejadorExpediente();
            List<BLExpediente> expedientes = new List<BLExpediente>();
            manejador.cargarListaExpedientes(expedientes);

            if (!Page.IsPostBack)
            {
                gridExpedientes.DataSource = expedientes;
                gridExpedientes.DataBind();
            }
        }
    }
}