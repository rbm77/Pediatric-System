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
            StringBuilder creador = new StringBuilder();

            foreach (BLAgendaEstandar elemento in estatica)
            {
                creador.Append("<tr>");

                creador.Append("<td>");
                creador.Append(elemento.Dia.ToString());
                creador.Append("</td>");

                creador.Append("<td>");
                creador.Append(elemento.HoraInicio);
                creador.Append("</td>");

                creador.Append("<td>");
                creador.Append(elemento.HoraFin);
                creador.Append("</td>");

                creador.Append("</tr>");
            }

            contenedor.Controls.Add(new Literal { Text = creador.ToString()});
            
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {

            estatica.Clear();
            string inicio = horaInicio.Value;
            string fin = horaFin.Value;

            if (lunes.Checked)
            {
                estatica.Add(new BLAgendaEstandar(lunes.Value, inicio, fin));
            }
            if (martes.Checked)
            {
                estatica.Add(new BLAgendaEstandar(martes.Value, inicio, fin));
            }
            if (miercoles.Checked)
            {
                estatica.Add(new BLAgendaEstandar(miercoles.Value, inicio, fin));
            }
            if (jueves.Checked)
            {
                estatica.Add(new BLAgendaEstandar(jueves.Value, inicio, fin));
            }
            if (viernes.Checked)
            {
                estatica.Add(new BLAgendaEstandar(viernes.Value, inicio, fin));
            }
            if (sabado.Checked)
            {
                estatica.Add(new BLAgendaEstandar(sabado.Value, inicio, fin));
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
            sabado.Checked = false;
        }

    }
}