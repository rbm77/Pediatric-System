using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class AsociarPaciente : System.Web.UI.Page
    {
        public List<BL_Manejador_Cuentas> listaPersonal = new List<BL_Manejador_Cuentas>();
        BLCuenta miBLCuenta = new BLCuenta();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listaPersonal = miBLCuenta.buscarListaCuentas();
                gridCuentas.DataSource = listaPersonal;
                gridCuentas.DataBind();
            }
        }



        protected void grdCuentas(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AsociarExpediente")
            {
                ManejadorExpediente manejador = new ManejadorExpediente();
                List<BLExpediente> expedientes = new List<BLExpediente>();
                manejador.cargarListaExpedientes(expedientes);
                gridExpedientes.DataSource = expedientes;
                gridExpedientes.DataBind();
                modalExpedientes.Show();
            }
        }


        protected void grdExpedientes(object sender, GridViewCommandEventArgs e)
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
            String mensaje = miBLCuenta.insertarCuenta();
           if (mensaje == "Correcto")
            {
                mensajeAviso("success", "La cuenta se creo correctamente");
                listaPersonal = miBLCuenta.buscarListaCuentas();
                gridCuentas.DataSource = listaPersonal;
                gridCuentas.DataBind();
                BLEnviarCorreo miEnviar = new BLEnviarCorreo(correo, "Creación de cuenta", "Se ha creado una cuenta asociada a este correo que le permite utilizar el sistema de la Clinica Pediatrica Divino Niño");
            } else
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


        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}