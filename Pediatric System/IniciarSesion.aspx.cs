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
            mensajeConfirmacion.Visible = false;
            Session["Cuenta"] = null;
            Session.Clear();
            Session["codigoMedico"] = null;
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

                switch (miBLCuenta.estado)
                {
                    case "Habilitada":
                        Session["Cuenta"] = miBLCuenta.correo;
                        Session["Rol"] = miBLCuenta.tipo;
                        string cor;
                        switch (miBLCuenta.tipo)
                        {
                            case "Medico":
                                 cor = Session["Cuenta"].ToString();
                                BLMedico miBLMedico = new BLMedico();
                                miBLMedico.correo = cor;
                                miBLMedico.buscarMedico();
                                Session["codigoMedico"] = miBLMedico.codigo;
                                Session["nombre"] = miBLMedico.nombre + " " + miBLMedico.apellido;
                                Response.Redirect("Dashboard.aspx", false);
                                break;
                            case "Administrador":
                                Session["nombre"] = "Administrador";
                                Response.Redirect("EstadoCuenta.aspx");
                                break;
                            case "Paciente":
                                Response.Redirect("InicioUsuarioExterno.aspx");
                                break;
                            case "Asistente":
                                 cor = Session["Cuenta"].ToString();
                                BLAdministrativo miBLAsist = new BLAdministrativo();
                                miBLAsist.correo = cor;
                                miBLAsist.buscarAdministrativo();
                                Session["codigoMedico"] = miBLAsist.cod_Asist;
                                Session["nombre"] = miBLAsist.nombre + " " + miBLAsist.apellido;
                                Response.Redirect("Dashboard.aspx");
                                break;
                        }
                        break;

                    case "Deshabilitada":
                        txtContra.Text = "";
                        txtCorreo.Text = "";
                        mensajeAviso("danger", "La cuenta que desea ingresar se encuentra deshabilitada");
                        break;
                    default:
                        txtContra.Text = "";
                        txtCorreo.Text = "";
                        mensajeAviso("danger", "Correo o Contraseña Incorrectos");
                        break;
                }

            }
            catch (Exception ex)
            {
                txtContra.Text = "";
                txtCorreo.Text = "";
                Elog.save(this, ex);
                throw;
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