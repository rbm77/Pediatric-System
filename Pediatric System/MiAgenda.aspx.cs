using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class MiAgenda : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {

            // Obtener datos de entrada

            string codigoMedico = "777";

            string inicio = horaInicio.Value.Trim();
            string fin = horaFin.Value.Trim();

            List<BLAgendaEstandar> agenda = new List<BLAgendaEstandar>();

            if (lunes.Checked)
            {
                agenda.Add(new BLAgendaEstandar(codigoMedico, lunes.Value, inicio , fin));
            }
            if (martes.Checked)
            {
                agenda.Add(new BLAgendaEstandar(codigoMedico, martes.Value, inicio, fin));
            }
            if (miercoles.Checked)
            {
                agenda.Add(new BLAgendaEstandar(codigoMedico, miercoles.Value, inicio, fin));
            }
            if (jueves.Checked)
            {
                agenda.Add(new BLAgendaEstandar(codigoMedico, jueves.Value, inicio, fin));
            }
            if (viernes.Checked)
            {
                agenda.Add(new BLAgendaEstandar(codigoMedico, viernes.Value, inicio, fin));
            }

            // Se envian los datos para almacenar en base de datos

            ManejadorAgenda manejador = new ManejadorAgenda();

            string confirmacion = manejador.ActualizarAgenda(agenda);

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



            // Se muestra la agenda

            vistaAgenda.DataSource = agenda;
            vistaAgenda.DataBind();
            vistaAgenda.HeaderRow.TableSection = TableRowSection.TableHeader;

            Limpiar();
        }

        private void Limpiar()
        {
            horaInicio.Value = "";
            horaFin.Value = "";
            lunes.Checked = false;
            martes.Checked = false;
            miercoles.Checked = false;
            jueves.Checked = false;
            viernes.Checked = false;

        }

        protected void vistaAgenda_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {

                //// Convert the row index stored in the CommandArgument
                //// property to an Integer.
                //int indice = Convert.ToInt32(e.CommandArgument);

                //// Get the last name of the selected author from the appropriate
                //// cell in the GridView control.
                //GridViewRow filaSeleccionada = vistaAgenda.Rows[indice];
                //TableCell contacto = filaSeleccionada.Cells[0];
                //string contact = contacto.Text;

                //// Display the selected author.
                //Label1.Text = contact;

            }



        }
    }
}