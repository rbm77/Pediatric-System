using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class ListaConsultasActivas : System.Web.UI.Page
    {
        List<BLConsulta> consultas = new List<BLConsulta>();
        List<ListaItem> lista = new List<ListaItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            obtenerConsultas();

            if (!Page.IsPostBack)
            {
                gridConsultasActivas.DataSource = lista;
                gridConsultasActivas.DataBind();
            }
        }

        protected void gridConsultasActivas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "seleccionar")
            {
                int indiceCod = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccionadaCod = gridConsultasActivas.Rows[indiceCod];
                TableCell fecha = filaSeleccionadaCod.Cells[1];
                                
                //const string FMT = "o";
                //DateTime fff = Convert.ToDateTime(fecha.Text);
                //string news = fff.ToString(FMT);
                //DateTime ggg = DateTime.ParseExact(news, FMT, CultureInfo.InvariantCulture);

                BLConsulta consulta = new BLConsulta();
                consulta.Estado = true;
                consulta.Fecha_Hora = Convert.ToDateTime(fecha.Text);

                
                Session["pagina"] = "consultas_activas_seleccionada";
                Session["consulta"] = consulta;
                Response.Redirect("FichaConsultaPaciente.aspx");
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {

        }

        private void obtenerConsultas()
        {
            string codigoMedico = (string)Session["codigoMedico"];

            ManejadorConsulta manejador = new ManejadorConsulta();
            manejador.obtnerConsultasActivas(codigoMedico, consultas);

            ManejadorExpediente manejadorExpediente = new ManejadorExpediente();

            foreach (BLConsulta cons in consultas)
            {
                DateTime fecha = cons.Fecha_Hora;
                string doctor = cons.CodigoMedico;
                string paciente = "";

                manejadorExpediente.obtenerNombrePaciente(cons.CodigoMedico, paciente);

                lista.Add(new ListaItem(fecha, paciente));
            }


        }

        private class ListaItem
        {
            public DateTime Fecha { get; set; }
            public string Paciente { get; set; }

            public ListaItem()
            {

            }
            public ListaItem(DateTime fecha, string paciente)
            {
                this.Fecha = fecha;
                this.Paciente = paciente;
            }
        }
    }
}