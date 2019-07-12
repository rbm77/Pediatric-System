using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Pediatric_System
{
    public partial class CrearReportes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarMedicos();

            }
            regresar.Attributes.Add("onclick", "history.back(); return false;");
        }
        private void CargarMedicos()
        {
            List<BLMedico> listaMedicos = new List<BLMedico>();

            BLMedico manejador = new BLMedico();
            string confirmacion = manejador.CargarMedicos(listaMedicos);

            if (confirmacion.Contains("error"))
            {
                MostrarMensaje(confirmacion);
            }
            else
            {
                List<ListaMedicos> fuente = new List<ListaMedicos>();
                foreach (BLMedico elemento in listaMedicos)
                {
                    fuente.Add(new ListaMedicos(elemento.codigo, elemento.nombre + " " + elemento.apellido));
                }

                ddCodigoMedico.DataSource = fuente;
                ddCodigoMedico.DataTextField = "NombreCompleto";
                ddCodigoMedico.DataValueField = "CodigoMedico";
                ddCodigoMedico.DataBind();

                string disponible = "Todos";

                if (fuente.Count == 0)
                {
                    disponible = "No disponible";
                }

                ddCodigoMedico.Items.Insert(0, new ListItem(disponible));
                ddCodigoMedico.SelectedIndex = 0;

            }

        }
        private void MostrarMensaje(string confirmacion)
        {
            string colorMensaje = "success";

            if (confirmacion.Contains("error"))
            {
                colorMensaje = "danger";
            }
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
                "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
                " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }

        private class ListaMedicos
        {
            public string CodigoMedico { get; set; }
            public string NombreCompleto { get; set; }

            public ListaMedicos()
            {

            }

            public ListaMedicos(string codigoMedico, string nombreCompleto)
            {
                this.CodigoMedico = codigoMedico;
                this.NombreCompleto = nombreCompleto;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {


            DateTime fini = DateTime.ParseExact(dateIni.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            DateTime ffin = DateTime.ParseExact(dateFin.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            string trep = tipoReporte.Value;
            string codeMed = ddCodigoMedico.SelectedValue;
            
            ManejadorConsulta cons = new ManejadorConsulta();
            List<BLConsulta> consultas = new List<BLConsulta>();
            cons.cargarListaConsultasFiltrada(consultas, codeMed, trep, fini.ToString("yyyy-MM-dd"), ffin.ToString("yyyy-MM-dd"));
            gridConsultas.DataSource = consultas;
            gridConsultas.DataBind();
            Session["consultasRe"] = consultas;

            btnGenerar.Enabled = true;
            mensajeConfirmacion.Visible = false;
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (Session["consultasRe"] != null)
            {
                try
                {

               
            //DateTime fini = DateTime.ParseExact(dateIni.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            //DateTime ffin = DateTime.ParseExact(dateFin.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            //string trep = tipoReporte.Value;
            //string codeMed = ddCodigoMedico.SelectedValue;


            //fini.ToString("yyyy-MM-dd"); // variable donde se  guarda el numero de factura
            //ffin.ToString("yyyy-MM-dd");

            ManejadorConsulta cons = new ManejadorConsulta();

            //DataTable da = cons.generarMedMixta(fini.ToString("yyyy-MM-dd"), ffin.ToString("yyyy-MM-dd"), codeMed);

            List<BLConsulta> das = Session["consultasRe"] as List<BLConsulta>;
            DataTable dat = ConvertToDataTable(das);
            ReportDocument crystalReport = new ReportDocument(); // creating object of crystal report

            crystalReport.Load(Server.MapPath("~/Reportes/MedMixta.rpt")); // path of report 
            crystalReport.SetDataSource(dat); // binding datatable
            crystalReport.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Medicina_mixta_" + DateTime.Today.ToString("dd-MM-yy"));
                MostrarMensaje("Se generó exitosamente");

                }
                catch (Exception ex)
                {
                    Elog.save(this, ex);
                    MostrarMensaje("Ocurrió un error inesperado, si persiste comuniquese con el equipo de TI");
                }
            }    else    {
                MostrarMensaje("Ocurrió un error al generar, proceda a realizar la búsqueda filtrada primero.");
            }

        }


        private DataTable ConvertToDataTable<T>(IList<T> list)
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable();
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}