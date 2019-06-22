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

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrasena = "123";
            string tipo = Rol.SelectedValue;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cedula = Int32.Parse(txtCedula.Text);
            int telefono = Int32.Parse(txtTelefono.Text);
            string codigo = txtCodigo.Text;

            BLCuenta miBLCuenta = new BLCuenta();
            miBLCuenta.correo = correo;
            miBLCuenta.contrasena = contrasena;
            miBLCuenta.tipo = tipo;
            miBLCuenta.insertarCuenta();

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
                   miBLMedico.insertarMedico();
             break;
                case "Asistente":
                    miBLAdministrativo.insertarAdministrativo();
                    break;
                case "Administrador":
                    miBLAdministrativo.insertarAdministrativo();
                    break;
            }

            txtCorreo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtCodigo.Text = "";
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