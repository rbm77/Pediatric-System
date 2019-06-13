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
                if (miBLCuenta.estado == "Activo" && miBLCuenta.tipo == "Doctor")
                {
                    Session["Cuenta"] = miBLCuenta.correo;
                    Response.Redirect("InicioPrincipal.aspx");
                } else
                {
                    txtContra.Text = "";
                    txtCorreo.Text = "";
                    lblFallo.Visible = true;
                    lblFallo.Text = "La cuenta no esta prro";
                }

            }
            catch (Exception)
            {
                txtContra.Text = "";
                txtCorreo.Text = "";
                throw;
            }
            

           
        }
    }
}