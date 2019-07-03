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
            miBLCuenta.insertarCuenta();

            mensajeConfirmacion.Text = "<div class=\"alert alert-success alert-dismissible fade show\" " +
            "role=\"alert\"> <strong></strong>" + "Cuenta Creada Correctamente" + "<button" +
            " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
            " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;

            txtCorreo.Text = "";
        }

        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}