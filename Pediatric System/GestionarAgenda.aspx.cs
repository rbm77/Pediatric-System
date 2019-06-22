using System;
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
        // El dia seleccionado corresponde a la fecha que se selecciona en el calendario

        private static DateTime diaSeleccionado = DateTime.Now; 

        protected void Page_Load(object sender, EventArgs e)
        {
            // La primera vez que se carga la pagina se debe mostrar la agenda del dia actual

            if (!IsPostBack)
            {
                MostrarAgenda(diaSeleccionado, "");
            }
            
        }

        /// <summary>
        /// Obtiene el horario del medico y las citas que estan agendadas para una fecha en particular
        /// </summary>
        /// <param name="fecha">Fecha</param>
        /// <param name="presionoBoton">Presiono boton</param>
        private void MostrarAgenda(DateTime fecha, string presionoBoton)
        {
            diaSeleccionado = fecha;

            string codigoMedico = "777";

            List<BLCita> listaCitas = new List<BLCita>();

            string fechaSeleccionada = diaSeleccionado.ToShortDateString();

            ManejadorCita manejadorCita = new ManejadorCita();

            string confirmacion = manejadorCita.CargarCitas(listaCitas, codigoMedico, fechaSeleccionada);


            // Si no hubo problema al cargar las citas se procede a cargar la disponibilidad

            if (!confirmacion.Contains("error"))
            {

                // Se obtiene la agenda de disponibilidad del medico para el dia seleccionado

                ManejadorAgenda manejadorAgenda = new ManejadorAgenda();

                string nombreDia = diaSeleccionado.ToString("dddd", new CultureInfo("es-ES")).ToUpperInvariant();
                string nombreMes = diaSeleccionado.ToString("MMMM", new CultureInfo("es-ES")).ToUpperInvariant();
                int numeroDia = diaSeleccionado.Day;

                nombreDia = nombreDia.Substring(0, 1).ToUpper() + nombreDia.Substring(1).ToLower();
                nombreMes = nombreMes.Substring(0, 1).ToUpper() + nombreMes.Substring(1).ToLower();


                BLAgendaEstandar blDia = new BLAgendaEstandar();

                blDia.CodigoMedico = codigoMedico;
                blDia.Dia = nombreDia;

                confirmacion = manejadorAgenda.CargarDisponibilidad(blDia);

                if (!confirmacion.Contains("error"))
                {

                    // Se crea una lista de items a mostrar en el grid

                    List<ListaItem> agenda = new List<ListaItem>();

                    //  Si la lista de citas y de disponibilidad esta vacia

                    if ((listaCitas.Count == 0) && (blDia.HoraInicio == null))
                    {

                        confirmacion = "El día " + nombreDia + " " + numeroDia + " de " + nombreMes + " no hay eventos";

                    }
                    else
                    {


                        DateTime horaInicio = DateTime.Now;
                        DateTime horaFin = DateTime.Now;
                        DateTime temporal = DateTime.Now;

                        if (blDia.HoraInicio != null)
                        {
                            horaInicio = DateTime.Parse(blDia.HoraInicio);
                            horaFin = DateTime.Parse(blDia.HoraFin);
                            temporal = horaInicio;
                        }

                        string t = "";
                        string estado = "";



                        // Si la lista de citas esta vacia pero hay disponibilidad

                        if ((listaCitas.Count == 0) && (blDia.HoraInicio != null))
                        {

                            confirmacion = "El día " + nombreDia + " " + numeroDia + " de " + nombreMes + " no tiene citas pendientes";


                            while (temporal < horaFin)
                            {
                                t = temporal.ToString("h:mm tt").Replace("p. m.", "PM").Replace("a. m.", "AM");

                                temporal = temporal.AddMinutes(30);

                                agenda.Add(new ListaItem(t, "Disponible"));
                            }


                        }

                        // Si no hay disponibilidad pero si hay citas pedientes

                        if ((listaCitas.Count > 0) && (blDia.HoraInicio == null))
                        {

                            confirmacion = "El día " + nombreDia + " " + numeroDia + " de " + nombreMes + " tiene citas pendientes";

                            foreach (BLCita cita in listaCitas)
                            {
                                agenda.Add(new ListaItem(cita.Hora, "Ocupado"));
                            }

                        }

                        // Si hay disponibilidad y citas

                        if ((listaCitas.Count > 0) && (blDia.HoraInicio != null))
                        {

                            confirmacion = "El día " + nombreDia + " " + numeroDia + " de " + nombreMes + " tiene citas pendientes";


                            // Primero se incluye la disponibilidad

                            while (temporal < horaFin)
                            {
                                t = temporal.ToString("h:mm tt").Replace("p. m.", "PM").Replace("a. m.", "AM");

                                temporal = temporal.AddMinutes(30);

                                agenda.Add(new ListaItem(t, "Disponible"));
                            }


                            // Luego se incluyen las citas 

                            bool existe = false;

                            foreach (BLCita cita in listaCitas)
                            {

                                foreach (ListaItem elemento in agenda)
                                {
                                    if (elemento.Hora.Equals(cita.Hora))
                                    {
                                        elemento.Estado = "Ocupado";
                                        existe = true;
                                        break;
                                    }
                                    else
                                    {
                                        existe = false;
                                    }
                                }
                                if (existe == false)
                                {
                                    agenda.Add(new ListaItem(cita.Hora, "Ocupado"));
                                }
                            }

                            // Se ordena la lista

                            agenda.Sort((x, y) => string.Compare(x.Hora, y.Hora));
                        }

                    }

                    vistaAgenda.DataSource = agenda;
                    vistaAgenda.DataBind();
                    //  vistaAgenda.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }

            if(!presionoBoton.Equals(""))
            {
                confirmacion = presionoBoton;
            }

            MostrarMensaje(confirmacion);
        }

        /// <summary>
        /// Actualiza el grid que muestra la agenda del medico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ActualizarAgenda(Object sender, EventArgs e)
        {
            MostrarAgenda(calendario.SelectedDate, "");
        }

        /// <summary>
        /// Muestra un alert con el mensaje de confirmacion de la transaccion recien ejecutada
        /// </summary>
        /// <param name="confirmacion">Mensaje de Confirmacion</param>
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

        /// <summary>
        /// Muestra el componente de calendario segun las especificaciones de requerimientos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Esta clase corresponde a los objetos que seran listados en el grid de la agenda
        /// </summary>
        private class ListaItem
        {
            public string Hora { get; set; }
            public string Estado { get; set; }

            public ListaItem()
            {

            }
            public ListaItem(string hora, string estado)
            {
                this.Hora = hora;
                this.Estado = estado;
            }

        }


        /// <summary>
        /// Muestra el grid segun las especificaciones de los parametros que recibe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void vistaAgenda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();

                if (estado.Equals("Ocupado"))
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#fbf4f4");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#e8f9e8");
                }


                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(vistaAgenda, "Select$" + e.Row.RowIndex, true);

            }


        }


        /// <summary>
        /// Envia los datos del formulario a base de datos para almacenar una nueva cita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click(object sender, EventArgs e)
        {

            // Recuperación de los campos de texto

            string nombreTxt = nombre.Text.Trim();
            string edadTxt = edad.Text.Trim();
            string correoTxt = correo.Text.Trim();
            int telefonoTxt = int.Parse(telefono.Text.Trim());
            string fechaTxt = fecha.Text.Trim();
            string horaT = horaTxt.Text.Trim();

            // Enviar datos para guardar en la base de datos

            ManejadorCita manejador = new ManejadorCita();

            string confirmacion = manejador.CrearCita("777", nombreTxt, edadTxt, correoTxt, telefonoTxt, fechaTxt, horaT);

            LimpiarCampos();

            MostrarAgenda(diaSeleccionado, confirmacion);

        }

        /// <summary>
        /// Vacia los campos de texto
        /// </summary>
        private void LimpiarCampos()
        {
            nombre.Text = "";
            edad.Text = "";
            correo.Text = "";
            telefono.Text = "";
            fecha.Text = "";
            horaTxt.Text = "";
        }


        /// <summary>
        /// Muestra el modal para crear o cancelar una cita, al seleccionar un elemento de la agenda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void vistaAgenda_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Seleccionar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow filaSeleccionada = vistaAgenda.Rows[indice];
                TableCell estado = filaSeleccionada.Cells[1];
                TableCell hora = filaSeleccionada.Cells[0];
                string estadoSeleccionado = estado.Text;
                string horaSeleccionada = hora.Text;

                mensajeConfirmacion.Visible = false;


                if (estadoSeleccionado.Equals("Ocupado"))
                {
                    btnCrear.Visible = false;
                    btnCancelar.Visible = true;

                }
                else
                {
                    btnCancelar.Visible = false;
                    btnCrear.Visible = true;
                }

                fecha.Text = diaSeleccionado.ToShortDateString();
                horaTxt.Text = horaSeleccionada;
                horaTxt.Enabled = false;
                fecha.Enabled = false;
                modalEdicion.Show();

            }

        }
    }
}