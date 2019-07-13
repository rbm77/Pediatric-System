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
        List<BLConsulta> consultas = new List<BLConsulta>();
        List<ListaItem> lista = new List<ListaItem>();
        BLExpediente expediente = new BLExpediente();


        protected void Page_Load(object sender, EventArgs e)
        {
            expediente = (BLExpediente)Session["expediente"];

            ManejadorEdad mane = new ManejadorEdad();

            

            //Mostrar los datos generales 
            if (expediente.Codigo == expediente.Cedula)
            {
                cedGeneral.InnerText = " " + expediente.Cedula;
            }
            else
            {
                cedGeneral.InnerText = "No tiene aún";
            }
            cargarListaGrid();

            paciGeneral.Text = "    " + expediente.Nombre + " " + expediente.PrimerApellido + " " + expediente.SegundoApellido;
            edaGeneral.InnerText = mane.ExtraerEdad(expediente.FechaNacimiento);
            string imagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(expediente.Foto);
            imgPreview.ImageUrl = imagenDataURL64;

            if (!Page.IsPostBack)
            {
                gridConsultas.DataSource = lista;
                gridConsultas.DataBind();
            }
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

        private void cargarListaGrid()
        {
            ManejadorConsulta manejador = new ManejadorConsulta();
            manejador.cargarListaConsultas(consultas, expediente.Codigo);
            BLMedico manejadorMed = new BLMedico();

            String nombreCom = "";

            foreach (BLConsulta cons in consultas)
            {
                DateTime fecha = cons.Fecha_Hora;
                
                BLMedico medico = new BLMedico();
                manejadorMed.buscarNombreMedico(cons.CodigoMedico, medico);
                nombreCom = medico.nombre + " ";
                nombreCom += medico.apellido;

                string estado;
                if (cons.Estado == false)
                {
                    estado = "Finalizada";
                }
                else
                {
                    estado = "Activa";
                }

                lista.Add(new ListaItem(fecha, nombreCom, estado));
            }
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

                const string FMT = "o";
                DateTime fff = Convert.ToDateTime(fecha.Text);
                string news = fff.ToString(FMT);
                DateTime ggg = DateTime.ParseExact(news, FMT, CultureInfo.InvariantCulture);

                BLConsulta consulta = new BLConsulta();
                consulta.CodigoExpediente = expediente.Codigo;
                consulta.Fecha_Hora = Convert.ToDateTime(fecha.Text);

                Boolean est;

                if (estado.Text == "Activa")
                {
                    est = true;
                }
                else
                {
                    est = false;
                }

                consulta.Estado = est;
                Session["pagina"] = "consultas_guardada";
                Session["consulta"] = consulta;
                Response.Redirect("FichaConsultaPaciente.aspx");
            }
        }

        private class ListaItem
        {
            public DateTime Fecha { get; set; }
            public string Doctor { get; set; }
            public string Estado { get; set; }

            public ListaItem()
            {

            }
            public ListaItem(DateTime fecha, string Doctor, string estado)
            {
                this.Fecha = fecha;
                this.Doctor = Doctor;
                this.Estado = estado;
            }

        }
    }
}