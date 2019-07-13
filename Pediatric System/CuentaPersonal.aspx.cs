using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class CuentaPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mensajeConfirmacion.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            string tipo = Rol.SelectedValue;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cedula = Int32.Parse(txtCedula.Text);
            int telefono = Int32.Parse(txtTelefono.Text);
            string codigo = txtCodigo.Text;
            string cedulaString = cedula + "";
            string contrasena = nombre.Substring(0, 3).ToLower() + apellido.Substring(0, 3).ToLower() + cedulaString.Substring(0, 3);

            BLCuenta miBLCuenta = new BLCuenta();
            miBLCuenta.correo = correo;
            miBLCuenta.contrasena = contrasena;
            miBLCuenta.tipo = tipo;

            String mensaje = miBLCuenta.insertarCuenta();

            if (mensaje == "Correcto")
            {
                BLPersonal miBLPersonal = new BLPersonal();
                miBLPersonal.correo = correo;
                miBLPersonal.nombre = nombre;
                miBLPersonal.apellido = apellido;
                miBLPersonal.cedula = cedula;
                miBLPersonal.telefono = telefono;
                miBLPersonal.insertarPersonal();

                BLMedico miBLMedico = new BLMedico();
                miBLMedico.codigo = codigo;
                miBLMedico.correo = correo;
                miBLMedico.nombre = nombre;
                miBLMedico.apellido = apellido;
                miBLMedico.cedula = cedula;
                miBLMedico.telefono = telefono;

                BLAdministrativo miBLAdministrativo = new BLAdministrativo();
                miBLAdministrativo.correo = correo;
                miBLAdministrativo.nombre = nombre;
                miBLAdministrativo.apellido = apellido;
                miBLAdministrativo.cedula = cedula;
                miBLAdministrativo.telefono = telefono;

                switch (tipo)
                {
                    case "Medico":
                        BLEnviarCorreo miEnviar = new BLEnviarCorreo(correo, "Bienvenido a PediatricSystem", "Bienvenido a Pediatric System \nLa aplicación para utilizar el sistema de la Clínica Pediátrica Divino Niño, su cuenta posee el rol de Medico y su contraseña es: " + contrasena + "\nLe recomendamos cambiar su contraseña al iniciar sesión para mas seguridad");
                        miBLMedico.insertarMedico();
                        mensajeAviso("success", "La cuenta de Medico se creó correctamente");
                        break;
                    case "Asistente":
                        BLEnviarCorreo miEnviar1 = new BLEnviarCorreo(correo, "Bienvenido a PediatricSystem", "Bienvenido a Pediatric System \nLa aplicación para utilizar el sistema de la Clínica Pediátrica Divino Niño, su cuenta posee el rol de Asistente y su contraseña es: " + contrasena + "\nLe recomendamos cambiar su contraseña al iniciar sesión para mas seguridad");
                        miBLAdministrativo.insertarAdministrativo();
                        mensajeAviso("success", "La cuenta de Asistente se creó correctamente");
                        break;
                    case "Administrador":
                        BLEnviarCorreo miEnviar2 = new BLEnviarCorreo(correo, "Bienvenido a PediatricSystem", "Bienvenido a Pediatric System \nLa aplicación para utilizar el sistema de la Clínica Pediátrica Divino Niño, su cuenta posee el rol de Administrador y su contraseña es: " + contrasena + "\nLe recomendamos cambiar su contraseña al iniciar sesión para mas seguridad");
                        miBLAdministrativo.insertarAdministrativo();
                        mensajeAviso("success", "La cuenta de Administrador se creó correctamente");
                        break;
                }
                txtCorreo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCedula.Text = "";
                txtTelefono.Text = "";
                txtCodigo.Text = "";
            }
            else
            {
                mensajeAviso("danger", "La cuenta no se pudo crear debido a que el correo ingresado ya esta en uso");

            }
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

        protected void Rol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Rol.SelectedValue == "Medico")
            {
                txtCodigo.Enabled = true;
            }
            else
            {
                txtCodigo.Enabled = false;
            }
        }

    }
}