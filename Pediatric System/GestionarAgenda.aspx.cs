using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class GestionarAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ActualizarAgenda(Object sender, EventArgs e)
        {
            DateTime fechaSeleccionada =  calendario.SelectedDate;

            int diaSemana = (int) fechaSeleccionada.DayOfWeek;

            List<DateTime> semana = ObtenerSemana(fechaSeleccionada, diaSemana);

            List<BLCita> citas = new List<BLCita>();
            citas.Add(new BLCita("777", "richardbomo26@gmail.com1", "207850434", "Varicela1", new DateTime(2019, 6, 6), "19:00"));
            citas.Add(new BLCita("777", "richardbomo26@gmail.com2", "207850434", "Varicela2", new DateTime(2019, 6, 7), "18:30"));
            citas.Add(new BLCita("777", "richardbomo26@gmail.com3", "207850434", "Varicela3", new DateTime(2019, 6, 10), "16:00"));

            repetidor.DataSource = citas;
            repetidor.DataBind();
        }

        private List<DateTime> ObtenerSemana(DateTime fechaSeleccionada, int diaSemana)
        {
            if (diaSemana == 0)
            {
                diaSemana = 7;
            }
            List<DateTime> semana = new List<DateTime>();

            semana.Add(fechaSeleccionada);

            for (int j = diaSemana - 1; j >= 1; j--)
            {
                semana.Add(fechaSeleccionada.AddDays(j - diaSemana));
            }

            for (int i = diaSemana + 1; i <= 7; i++)
            {
                semana.Add(fechaSeleccionada.AddDays(i - diaSemana));
            }

            semana.Sort();

            return semana;
        } 

        private void MostrarAgenda()
        {
            //List<BLAgendaEstandar> disponibilidad = new List<BLAgendaEstandar>();
            //disponibilidad.Add(new BLAgendaEstandar("777", "Lunes", "16:00", "18:30"));
            //disponibilidad.Add(new BLAgendaEstandar("777", "Martes", "17:30", "19:30"));
            //disponibilidad.Add(new BLAgendaEstandar("777", "Jueves", "16:30", "20:00"));
            //disponibilidad.Add(new BLAgendaEstandar("777", "Viernes", "18:00", "19:30"));

            List<BLCita> citas = new List<BLCita>();
            citas.Add(new BLCita("777", "richardbomo26@gmail.com1", "207850434", "Varicela1", new DateTime(2019, 6, 6), "19:00"));
            citas.Add(new BLCita("777", "richardbomo26@gmail.com2", "207850434", "Varicela2", new DateTime(2019, 6, 7), "18:30"));
            citas.Add(new BLCita("777", "richardbomo26@gmail.com3", "207850434", "Varicela3", new DateTime(2019, 6, 10), "16:00"));




        }





    }
}