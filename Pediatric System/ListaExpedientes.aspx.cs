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
        List<ListaItem> lista = new List<ListaItem>();
        List<BLExpediente> expedientes = new List<BLExpediente>();

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["Cuenta"] == null) { Response.Redirect("IniciarSesion.aspx"); }

            cargarListaGrid();

            if (!Page.IsPostBack)
            {
                gridExpedientes.DataSource = lista;
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
                TableCell nombre = filaSeleccionada.Cells[0];
                string cdg = obtenerCodigo(nombre.Text);
                Session["expedienteSeleccionado"] = cdg;
                Session["pagina"] = "listaExpedientes-seleccionado";
                Response.Redirect("FichaBaseExpediente.aspx");

            }
        }

        private void cargarListaGrid()
        {
            ManejadorExpediente manejador = new ManejadorExpediente();
            manejador.cargarListaExpedientes(expedientes);

            foreach(BLExpediente exp in expedientes)
            {
                string nombre = exp.Nombre + " " + exp.PrimerApellido + " " + exp.SegundoApellido;
                string cedula;
                if (exp.Cedula == "")
                {
                    cedula = "Recien Nacido";
                }
                else
                {
                    cedula = exp.Cedula;
                }
                string sx = exp.Sexo;
                string sexo = sx.Substring(0, 1).ToUpper() + sx.Substring(1);
                lista.Add(new ListaItem(nombre, cedula, sexo));
            }
        }

        private string obtenerCodigo(string nombre)
        {
            string[] nombreCompleto = nombre.Split();

            foreach(BLExpediente expB in expedientes)
            {
                if((expB.Nombre == nombreCompleto[0]) && (expB.PrimerApellido == nombreCompleto[1]) && (expB.SegundoApellido == nombreCompleto[2]))
                {
                    return expB.Codigo;
                }
            }
            return "No se encontró";
        }

        private class ListaItem
        {
            public string Nombre { get; set; }
            public string Cedula { get; set; }
            public string Sexo { get; set; }

            public ListaItem()
            {

            }
            public ListaItem(string nombre, string cedula, string sexo)
            {
                this.Nombre = nombre;
                this.Cedula = cedula;
                this.Sexo = sexo;
            }

        }

        protected void regresarMed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}