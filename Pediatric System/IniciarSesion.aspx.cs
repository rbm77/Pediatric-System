using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;


namespace Pediatric_System
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        private Button miBoton = new Button();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Cuenta"] = null;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BLCuenta miBLCuenta = new BLCuenta();
                miBLCuenta.correo = txtCorreo.Text;
                miBLCuenta.contrasena = txtContra.Text;
                miBLCuenta.buscar();

                //metodo de verificacion, si es positivo entra y cambia vista, si es negativo borra campos y muestra label 
                if (miBLCuenta.estado == "Habilitada")
                {
                    Session["Cuenta"] = miBLCuenta.correo;
                    Session["Rol"] = miBLCuenta.tipo;
                    switch (miBLCuenta.tipo)
                    {
                        case "Medico":
                            Response.Redirect("Dashboard.aspx");
                            break;
                        case "Administrador":
                            Response.Redirect("InicioAdministrador.aspx");
                            break;
                        case "Paciente":
                            Response.Redirect("InicioUsuarioExterno.aspx");
                            break;
                        case "Asistente":
                            Response.Redirect("Dashboard.aspx");
                            break;
                    }
                }
                else {
                    txtContra.Text = "";
                    txtCorreo.Text = "";
                    mensajeConfirmacion.Text = "<div class=\"alert alert-danger alert-dismissible fade show\" " +
                           "role=\"alert\"> <strong></strong>" + "Contraseña o correo incorrecto" + "<button" +
                           " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                           " <span aria-hidden=\"true\">&times;</span> </button> </div>";
                    mensajeConfirmacion.Visible = true;
                }
            }
            catch (Exception)
            {
                txtContra.Text = "";
                txtCorreo.Text = "";
                throw;
            }
        }


        private void MostrarMensaje(string confirmacion)
        {
            string colorMensaje = "success";
            if (confirmacion.Contains("error"))
            {
                colorMensaje = "danger";
            }
            if (confirmacion.Contains(""))
            {
                colorMensaje = "danger";
            }

            mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
                "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
                " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }



    }
}