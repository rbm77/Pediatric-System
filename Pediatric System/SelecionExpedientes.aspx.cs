using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class SelecionExpedientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CuentaParaAsociar"] == null) { Response.Redirect("AsociarPaciente.aspx"); }
            String cuentaParaAsociar = Session["CuentaParaAsociar"].ToString();       
            ManejadorExpediente manejador = new ManejadorExpediente();
            List<BLExpediente> expedientes = new List<BLExpediente>();
            manejador.cargarListaExpedientes(expedientes, true);
            gridConExpedientes.DataSource = expedientes;
            gridConExpedientes.DataBind();
            lblCuentaSel.Text = " Seleccione los expedientes que desea asociar a la cuenta de " + cuentaParaAsociar + " ";
            if (!Page.IsPostBack)
            {
                gridConExpedientes.DataSource = expedientes;
                gridConExpedientes.DataBind();
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsociarPaciente.aspx");
        }

        protected void gridExpedientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AsociarExpedienteEspecifico")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccionada = gridConExpedientes.Rows[indice];
                TableCell cedula = filaSeleccionada.Cells[1];
                string cedulaSel = cedula.Text;

                ManejadorExpediente manejador = new ManejadorExpediente();
                String mensaje = manejador.asociarCuenta(Session["CuentaParaAsociar"].ToString(), cedulaSel);
                if (mensaje == "Correcto")
                {
                    List<BLExpediente> expedientes = new List<BLExpediente>();
                    manejador.cargarListaExpedientes(expedientes, true);
                    gridConExpedientes.DataSource = expedientes;
                    gridConExpedientes.DataBind();
                    mensajeAviso("success", "Cuenta Asociada correctamente");
                }
                else
                {
                    mensajeAviso("danger", "Ha ocurrido un error al asociar la Cuenta");
                }

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
    }
}