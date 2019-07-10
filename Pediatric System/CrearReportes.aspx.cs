using System;
using System.Collections.Generic;
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

                string disponible = "Seleccionar";

                if (fuente.Count == 0)
                {
                    disponible = "No disponible";
                }

                ddCodigoMedico.Items.Insert(0, new ListItem(disponible));
                ddCodigoMedico.SelectedIndex = 0;
                ddCodigoMedico.Items[0].Attributes.Add("disabled", "disabled");
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

    
    }
}