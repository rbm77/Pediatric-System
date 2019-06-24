﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class EditarCuentaPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (!Page.IsPostBack) {
            if (Session["Cuenta"] == null) {
            
             Response.Redirect("IniciarSesion.aspx");
            } else {
            BLAdministrativo miBLAdministrativo = new BLAdministrativo();
            string correo = Session["Cuenta"].ToString();
            txtCorreo.Enabled = false;
            txtCorreo.Text = correo;
            Tipo.Text = Session["Rol"].ToString();
            Tipo.Enabled = false;
            switch (Session["Rol"].ToString())
            {
                case "Medico":                    
                        txtCodigo.Visible = true;
                        lblCodigo.Visible = true;
                        BLMedico miBLMedico = new BLMedico();
                        miBLMedico.correo = correo;
                        miBLMedico.buscarMedico();
                        txtNombre.Text = miBLMedico.nombre;
                        txtApellido.Text = miBLMedico.apellido;
                        txtCedula.Text = miBLMedico.cedula.ToString();
                        txtTelefono.Text = miBLMedico.telefono.ToString();
                        txtCodigo.Text = miBLMedico.codigo;
                        break;
                    case "Asistente":

                        miBLAdministrativo.correo = correo;
                        miBLAdministrativo.buscarAdministrativo();
                        txtNombre.Text = miBLAdministrativo.nombre;
                        txtApellido.Text = miBLAdministrativo.apellido;
                        txtCedula.Text = miBLAdministrativo.cedula.ToString();
                        txtTelefono.Text = miBLAdministrativo.telefono.ToString();
                        break;
                    case "Administrador":
                        
                        miBLAdministrativo.correo = Session["Cuenta"].ToString();
                        miBLAdministrativo.buscarAdministrativo();
                        txtNombre.Text = miBLAdministrativo.nombre;
                        txtApellido.Text = miBLAdministrativo.apellido;
                        txtCedula.Text = miBLAdministrativo.cedula.ToString();
                        txtTelefono.Text = miBLAdministrativo.telefono.ToString();
                        break;
                }
                    }
                }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string tipo = Tipo.Text ;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cedula = Int32.Parse(txtCedula.Text);
            int telefono = Int32.Parse(txtTelefono.Text);
            string codigo = txtCodigo.Text;

            BLAdministrativo miBLAdministrativo = new BLAdministrativo();

            BLPersonal miBLPersonal = new BLPersonal();
            miBLPersonal.correo = correo;
            miBLPersonal.nombre = nombre;
            miBLPersonal.apellido = apellido;
            miBLPersonal.cedula = cedula;
            miBLPersonal.telefono = telefono;
            miBLPersonal.editarPersonal();

            switch (Session["Rol"].ToString())
            {
                case "Medico":
                    BLMedico miBLMedico = new BLMedico();
                    miBLMedico.codigo = codigo;
                    miBLMedico.correo = correo;
                    miBLMedico.nombre = nombre;
                    miBLMedico.apellido = apellido;
                    miBLMedico.cedula = cedula;
                    miBLMedico.telefono = telefono;
                    miBLMedico.editarMedico();
                    break;
                case "Asistente":

                    miBLAdministrativo.correo = correo;
                    miBLAdministrativo.nombre = nombre;
                    miBLAdministrativo.apellido = apellido;
                    miBLAdministrativo.cedula = cedula;
                    miBLAdministrativo.telefono = telefono;
                    miBLAdministrativo.editarAdministrativo();
                    break;
                case "Administrador":

                    miBLAdministrativo.correo = correo;
                    miBLAdministrativo.nombre = nombre;
                    miBLAdministrativo.apellido = apellido;
                    miBLAdministrativo.cedula = cedula;
                    miBLAdministrativo.telefono = telefono;
                    miBLAdministrativo.editarAdministrativo();
                    break;
            }




            mensajeConfirmacion.Text = "<div class=\"alert alert-success alert-dismissible fade show\" " +
          "role=\"alert\"> <strong></strong>" + "Cuenta Editada Correctamente" + "<button" +
          " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
          " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }
    }
}