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



        protected void grdAccidentMaster_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "enviarCorreo")
            {
                ManejadorExpediente manejador = new ManejadorExpediente();
                List<BLExpediente> expedientes = new List<BLExpediente>();
                manejador.cargarListaExpedientes(expedientes);
                gridExpedientes.DataSource = expedientes;
                gridExpedientes.DataBind();
                modalExpedientes.Show();
            }
        }

        protected void gridCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}