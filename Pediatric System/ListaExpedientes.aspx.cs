using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class InicioPrincipal : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["Cuenta"] == null) { Response.Redirect("IniciarSesion.aspx"); }

            ManejadorExpediente manejador = new ManejadorExpediente();
            List<BLExpediente> expedientes = new List<BLExpediente>();
            manejador.cargarListaExpedientes(expedientes);

            if (!Page.IsPostBack)
            {
                gridExpedientes.DataSource = expedientes;
                gridExpedientes.DataBind();
            }
            regresar.Attributes.Add("onclick", "history.back(); return false;");
        }

        protected void nuevoExpediente_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "listaExpedientes-Nuevo";
            Response.Redirect("FichaBaseExpediente.aspx");
        }

       

        protected void gridExpedientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "seleccionar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccionada = gridExpedientes.Rows[indice];
                TableCell cedula = filaSeleccionada.Cells[1];
                Session["expedienteSeleccionado"] = cedula.Text;
                Session["pagina"] = "listaExpedientes-seleccionado";
                Response.Redirect("FichaBaseExpediente.aspx");

            }
        }
    }
}