using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class EditarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["Cuenta"] == null)
                {

                    Response.Redirect("IniciarSesion.aspx");
                }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtContraseñaNueva1.Text != txtContraseñaNueva2.Text)
            {
                mensajeAviso("warning", "La nueva contraseña no coincide");
            } else
            {
                BLCuenta miBLCuenta = new BLCuenta();
                miBLCuenta.correo = Session["Cuenta"].ToString();
                miBLCuenta.contrasena = txtContraseñaActual.Text;
                if (miBLCuenta.revisarContrasena())
                {
                    miBLCuenta.correo = Session["Cuenta"].ToString();
                    miBLCuenta.contrasena = txtContraseñaNueva1.Text;
                    miBLCuenta.editarContrasena();
                    mensajeAviso("success", "Contraseña editada correctamente");
                } else
                {
                    mensajeAviso("danger", "La contraseña actual no coincide");
                }
            }
        }

        public void mensajeAviso(String color, String texto)
        {
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + color + " alert-dismissible fade show\" " +
      "role=\"alert\"> <strong></strong>" + texto + "<button" +
     " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
       " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }
    }
}