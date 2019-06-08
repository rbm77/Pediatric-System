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

        private List<BLAgendaEstandar> estatica = new List<BLAgendaEstandar>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void MostrarAgenda()
        {
            vistaAgenda.DataSource = estatica;
            vistaAgenda.DataBind();
            vistaAgenda.HeaderRow.TableSection = TableRowSection.TableHeader;

            //repetidor.DataSource = estatica;
            //repetidor.DataBind();


        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {

            estatica.Clear();
            string inicio = horaInicio.Value;
            string fin = horaFin.Value;

            if (lunes.Checked)
            {
                estatica.Add(new BLAgendaEstandar("777", lunes.Value, inicio, fin));
            }
            if (martes.Checked)
            {
                estatica.Add(new BLAgendaEstandar("777", martes.Value, inicio, fin));
            }
            if (miercoles.Checked)
            {
                estatica.Add(new BLAgendaEstandar("777", miercoles.Value, inicio, fin));
            }
            if (jueves.Checked)
            {
                estatica.Add(new BLAgendaEstandar("777", jueves.Value, inicio, fin));
            }
            if (viernes.Checked)
            {
                estatica.Add(new BLAgendaEstandar("777", viernes.Value, inicio, fin));
            }
            MostrarAgenda();
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

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int indice = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow filaSeleccionada = vistaAgenda.Rows[indice];
                TableCell contacto = filaSeleccionada.Cells[0];
                string contact = contacto.Text;

                // Display the selected author.
                Label1.Text = contact;

            }



        }
    }
}