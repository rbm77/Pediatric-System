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
    public partial class ListaConsultas : System.Web.UI.Page
    {
        BLExpediente expediente = new BLExpediente();
        protected void Page_Load(object sender, EventArgs e)
        {
            expediente = (BLExpediente)Session["expediente"];
            ManejadorConsulta manejador = new ManejadorConsulta();
            List<BLConsulta> consultas = new List<BLConsulta>();

            //Mostrar los datos generales 
            if (expediente.Codigo == expediente.Cedula)
            {
                cedGeneral.InnerText = " " + expediente.Cedula;
            }
            else
            {
                cedGeneral.InnerText = "No tiene aún";
            }

            paciGeneral.InnerText = " " + expediente.Nombre + " " + expediente.PrimerApellido + " " + expediente.SegundoApellido;
            TimeSpan dt = DateTime.Now - expediente.FechaNacimiento;
            edaGeneral.InnerText = " " + Convert.ToString(dt.Days) + " días";
            string imagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(expediente.Foto);
            imgPreview.ImageUrl = imagenDataURL64;

            if (!Page.IsPostBack)
            {
                manejador.cargarListaConsultas(consultas, expediente.Codigo);
                gridConsultas.DataSource = consultas;
                gridConsultas.DataBind();
            }
        }

        private void crear_guardarConsulta()
        {

        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Session["pagina"] = "regresar-listaconsultas";
            Response.Redirect("FichaBaseExpediente.aspx");
        }

        protected void nuevoConsulta_Click(object sender, EventArgs e)
        {

            Session["pagina"] = "consultas-nueva";
            Response.Redirect("FichaConsultaPaciente.aspx");

        }

        protected void gridConsultas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "seleccionar")
            {
                int indiceCod = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccionadaCod = gridConsultas.Rows[indiceCod];
                TableCell fecha = filaSeleccionadaCod.Cells[0];

                int indiceEst = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccionadaEst = gridConsultas.Rows[indiceEst];
                TableCell estado = filaSeleccionadaEst.Cells[2];

                //const string FMT = "o";
                //DateTime now1 = DateTime.Now;
                //string strDate = now1.ToString(FMT);
                //DateTime now2 = DateTime.ParseExact(strDate, FMT, CultureInfo.InvariantCulture);

                //string valorFecha = fecha.Text;
                const string FMT = "o";
                DateTime fff = Convert.ToDateTime(fecha.Text);
                string news = fff.ToString(FMT);
                DateTime ggg = DateTime.ParseExact(news, FMT, CultureInfo.InvariantCulture);

                BLConsulta consulta = new BLConsulta();
                consulta.CodigoExpediente = expediente.Codigo;
                consulta.Fecha_Hora = Convert.ToDateTime(fecha.Text);
                consulta.Estado = Boolean.Parse(estado.Text);
                Session["pagina"] = "consultas_guardada";
                Session["consulta"] = consulta;
                Response.Redirect("FichaConsultaPaciente.aspx");
            }
        }
    }
}