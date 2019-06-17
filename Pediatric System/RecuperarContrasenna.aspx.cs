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
            
        }

        protected void BotonEnviar_Click(object sender, EventArgs e)
        {
            String nuevaContrasena = CrearPassword(8);
            String mensaje = "Su nueva contraseña es : " + nuevaContrasena;     
            BLEnviarCorreo miCorreo = new BLEnviarCorreo(txtCorreo.Text, "Recuperacion de Contraseña", mensaje);

            BLCuenta miBLCuenta = new BLCuenta();
            miBLCuenta.correo = txtCorreo.Text;
            miBLCuenta.contrasena = nuevaContrasena;
            miBLCuenta.actualizarContraseña();

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

        protected void BotonRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IniciarSesion.aspx");
        }
    }
}