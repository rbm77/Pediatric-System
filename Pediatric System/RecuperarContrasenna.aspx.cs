using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text;

namespace Pediatric_System
{
    public partial class RecuperarContrasenna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mensajeConfirmacion.Visible = false;
        }

        protected void BotonEnviar_Click(object sender, EventArgs e)
        {
            String nuevaContrasena = CrearPassword(8);  
            BLCuenta miBLCuenta = new BLCuenta();
            miBLCuenta.correo = txtCorreo.Text;

            miBLCuenta.buscarCuentaPorCorreo();
            if (miBLCuenta.estado == "Habilitada")
            {
                miBLCuenta.contrasena = nuevaContrasena;
                miBLCuenta.actualizarContraseña();
                BLEnviarCorreo miCorreo = new BLEnviarCorreo(txtCorreo.Text, "Recuperacion de Contraseña", "Peditric System\nSe ha realizado la recuperación de su contraseña\nSu nueva contraseña es: " + nuevaContrasena + "\nLe recomendamos cambiar la contraseña al iniciar sesión");
                mensajeAviso("success", "Correo de recuperación enviado");
                txtCorreo.Text = "";
            } else
            {
                mensajeAviso("danger", "El correo ingresado no se encuentra registrado");
            }

        }

        public string CrearPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

        public void mensajeAviso(String color, String texto)
        {
            //Colores:  primary = Azul
            //          secondary = Gris
            //          success = Verde
            //          danger = Rojo
            //          warning = Amarillo
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + color + " alert-dismissible fade show\" " +
           "role=\"alert\"> <strong></strong>" + texto + "<button" +
         " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
         " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }
    }
}