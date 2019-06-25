using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pediatric_System
{
    public partial class InicioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuentaPersonal.aspx");
        }

        protected void btnGestionarCuentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("EstadoCuenta.aspx");
        }
    }
}