using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class CuentaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrasena = "123";
            string tipo = "Paciente";

            BLCuenta miBLCuenta = new BLCuenta();
            miBLCuenta.correo = correo;
            miBLCuenta.contrasena = contrasena;
            miBLCuenta.tipo = tipo;
            miBLCuenta.insertarCuenta();

            mensajeConfirmacion.Text = "<div class=\"alert alert-success alert-dismissible fade show\" " +
            "role=\"alert\"> <strong></strong>" + "Cuenta Creada Correctamente" + "<button" +
            " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
            " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;

            txtCorreo.Text = "";
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}