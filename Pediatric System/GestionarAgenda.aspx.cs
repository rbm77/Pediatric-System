﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class GestionarAgenda : System.Web.UI.Page
    {
        private static DateTime diaSeleccionado = DateTime.Now; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ActualizarAgenda(Object sender, EventArgs e)
        {

            diaSeleccionado = calendario.SelectedDate;

            List<BLCita> blLista = new List<BLCita>();

            string fechaSeleccionada = diaSeleccionado.ToShortDateString();

            ManejadorCita manejador = new ManejadorCita();

            string confirmacion = manejador.CargarCitas(blLista, "777", fechaSeleccionada);

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

            //DateTime fechaSeleccionada = calendario.SelectedDate;

            ////string diaSeleccionado = fechaSeleccionada.ToString("dddd", new CultureInfo("es-ES"));

            List<Elemento> agenda = new List<Elemento>();
            

            //citasDia.Add(new BLCita("fa", "dsa", "sad", "das", DateTime.Now, "5:00 PM"));
            //citasDia.Add(new BLCita("fa", "dsa", "sad", "das", DateTime.Now, "6:00 PM"));
            //citasDia.Add(new BLCita("fa", "dsa", "sad", "das", DateTime.Now, "6:30 PM"));
            //citasDia.Add(new BLCita("fa", "dsa", "sad", "das", DateTime.Now, "7:30 PM"));

            //BLAgendaEstandar disponibilidad = ObtenerHorario(diaSeleccionado);
            
            BLAgendaEstandar disponibilidad = new BLAgendaEstandar("777", "Lunes", "4:30 PM", "8:00 PM");
            DateTime horaInicio = DateTime.Parse(disponibilidad.HoraInicio);
            DateTime horaFin = DateTime.Parse(disponibilidad.HoraFin);
            DateTime temporal = horaInicio;
            string t = "";
            string estado = "";
            while (temporal < horaFin)
            {
                t = temporal.ToString("h:mm tt").Replace("p. m.", "PM").Replace("a. m.", "AM");
                estado = "Disponible";

                temporal = temporal.AddMinutes(30);

                foreach (BLCita cita in blLista)
                {
                    if ((cita.Hora).Equals(t))
                    {
                        estado = "Ocupado";

                    }
                }

                agenda.Add(new Elemento(t, estado));
            }


            vistaAgenda.DataSource = agenda;
            vistaAgenda.DataBind();






            //int diaSemana = (int)fechaSeleccionada.DayOfWeek;

            //List<DateTime> semana = ObtenerSemana(fechaSeleccionada, diaSemana);

            //List<BLCita> citas = new List<BLCita>();
            //citas.Add(new BLCita("777", "richardbomo26@gmail.com1", "207850434", "Varicela1", new DateTime(2019, 6, 6), "19:00"));
            //citas.Add(new BLCita("777", "richardbomo26@gmail.com2", "207850434", "Varicela2", new DateTime(2019, 6, 7), "18:30"));
            //citas.Add(new BLCita("777", "richardbomo26@gmail.com3", "207850434", "Varicela3", new DateTime(2019, 6, 10), "16:00"));

            //vistaAgenda.DataSource = citas;
            //vistaAgenda.DataBind();
        }


        //private List<DateTime> ObtenerSemana(DateTime fechaSeleccionada, int diaSemana)
        //{
        //    if (diaSemana == 0)
        //    {
        //        diaSemana = 7;
        //    }
        //    List<DateTime> semana = new List<DateTime>();

        //    semana.Add(fechaSeleccionada);

        //    for (int j = diaSemana - 1; j >= 1; j--)
        //    {
        //        semana.Add(fechaSeleccionada.AddDays(j - diaSemana));
        //    }

        //    for (int i = diaSemana + 1; i <= 6; i++)
        //    {
        //        semana.Add(fechaSeleccionada.AddDays(i - diaSemana));
        //    }

        //    semana.Sort();

        //    return semana;
        //} 

        private void MostrarAgenda()
        {
            //List<BLAgendaEstandar> disponibilidad = new List<BLAgendaEstandar>();
            //disponibilidad.Add(new BLAgendaEstandar("777", "Lunes", "16:00", "18:30"));
            //disponibilidad.Add(new BLAgendaEstandar("777", "Martes", "17:30", "19:30"));
            //disponibilidad.Add(new BLAgendaEstandar("777", "Jueves", "16:30", "20:00"));
            //disponibilidad.Add(new BLAgendaEstandar("777", "Viernes", "18:00", "19:30"));

            List<BLCita> citas = new List<BLCita>();
            //citas.Add(new BLCita("777", "richardbomo26@gmail.com1", "207850434", "Varicela1", new DateTime(2019, 6, 6), "19:00"));
            //citas.Add(new BLCita("777", "richardbomo26@gmail.com2", "207850434", "Varicela2", new DateTime(2019, 6, 7), "18:30"));
            //citas.Add(new BLCita("777", "richardbomo26@gmail.com3", "207850434", "Varicela3", new DateTime(2019, 6, 10), "16:00"));




        }

        protected void calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime hoy = DateTime.Now.Date;

            DateTime limite = hoy.AddDays(6);

            if ((e.Day.Date < hoy) || (e.Day.Date > limite) || (e.Day.IsWeekend))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.LightGray;
            }
        }
        private class Elemento
        {
            public string Hora { get; set; }
            public string Estado { get; set; }

            public Elemento()
            {

            }
            public Elemento(string hora, string estado)
            {
                this.Hora = hora;
                this.Estado = estado;
            }

        }



        protected void vistaAgenda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();

                if (estado.Equals("Ocupado"))
                {
                    e.Row.BackColor = System.Drawing.Color.LightCoral;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }



                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(vistaAgenda, "Select$" + e.Row.RowIndex, true);
                //e.Row.Attributes.Add("data-toggle", "modal");
                //e.Row.Attributes.Add("data-target", "#exampleModal");

            }


        }

        protected void vistaAgenda_SelectedIndexChanged(object sender, EventArgs e)
        {

            mensajeConfirmacion.Visible = false;

            GridViewRow row = vistaAgenda.SelectedRow;
            string estadoSeleccionado = row.Cells[1].Text;

            if (estadoSeleccionado.Equals("Ocupado"))
            {
                btnCrear.Visible = false;
                btnCancelar.Visible = true;
            } else
            {
                btnCancelar.Visible = false;
                btnCrear.Visible = true;
            }

            fecha.Text = diaSeleccionado.ToShortDateString();
            hora.Text = row.Cells[0].Text;
            hora.Enabled = false;
            fecha.Enabled = false;
            modalEdicion.Show();

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {


            // Recuperación de los campos de texto

            string nombreTxt = nombre.Text.Trim();
            string edadTxt = edad.Text.Trim();
            string correoTxt = correo.Text.Trim();
            int telefonoTxt = int.Parse(telefono.Text.Trim());
            string fechaTxt = fecha.Text.Trim();
            string horaTxt = hora.Text.Trim();

            // Enviar datos para guardar en la base de datos

            ManejadorCita manejador = new ManejadorCita();

            string confirmacion = manejador.CrearCita("777", nombreTxt, edadTxt, correoTxt, telefonoTxt, fechaTxt, horaTxt);

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

            LimpiarCampos();

        }

        private void LimpiarCampos()
        {
            nombre.Text = "";
            edad.Text = "";
            correo.Text = "";
            telefono.Text = "";
            fecha.Text = "";
            hora.Text = "";
        }

    }
}