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
        private static List<BLCita> listaCitas = new List<BLCita>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // La primera vez que se carga la pagina se debe mostrar la agenda del dia actual

            if((String)Session["codigoMedico"] == "")
            {
                Response.Redirect("dashboard.aspx");
            }

            if (!IsPostBack)
            {
                MostrarAgenda(DateTime.Now, "");
            }

            calendario.DayStyle.Height = new Unit(40);
            //calendario.DayStyle.Width = new Unit(100);
            //calendario.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            //calendario.DayStyle.VerticalAlign = VerticalAlign.Middle;
        }


        /// <summary>
        /// Obtiene el horario del medico y las citas que estan agendadas para una fecha en particular
        /// </summary>
        /// <param name="fecha">Fecha</param>
        /// <param name="presionoBoton">Presiono boton</param>
        private void MostrarAgenda(DateTime fecha, string presionoBoton)
        {
            diaSeleccionado = fecha;

            string codigoMedico = Session["codigoMedico"].ToString();

            listaCitas.Clear();

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
                        // Si no hay disponibilidad pero si hay citas pedientes

                        if ((listaCitas.Count > 0) && (blDia.HoraInicio == null))
                        {

                            confirmacion = "El día " + nombreDia + " " + numeroDia + " de " + nombreMes + " tiene citas pendientes";

                            foreach (BLCita cita in listaCitas)
                            {
                                agenda.Add(new ListaItem(cita.Hora, "Ocupado"));
                            }

                        }

                        string segundaConfirmacion = manejadorAgenda.ObtenerDuracionCita(codigoMedico);

                        bool duracionCapturada = true;

                        int duracionCita = 0;

                        try
                        {
                            duracionCita = int.Parse(segundaConfirmacion);
                        }
                        catch (Exception)
                        {
                            duracionCapturada = false;
                        }

                        if ((!segundaConfirmacion.Contains("error")) && (duracionCapturada))
                        {

                       

                        //////////////////////////////////////////////////

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
                                t = ConvertirFormato(temporal);

                                temporal = temporal.AddMinutes(duracionCita);

                                agenda.Add(new ListaItem(t, "Disponible"));
                            }


                        }


                        // Si hay disponibilidad y citas

                        if ((listaCitas.Count > 0) && (blDia.HoraInicio != null))
                        {

                            confirmacion = "El día " + nombreDia + " " + numeroDia + " de " + nombreMes + " tiene citas pendientes";


                            // Primero se incluye la disponibilidad

                            while (temporal < horaFin)
                            {
                                t = ConvertirFormato(temporal);

                                temporal = temporal.AddMinutes(duracionCita);

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
                        else
                        {
                            confirmacion = "Ocurrió un error al cargar la duración de las citas o esta no se ha establecido";
                        }
                        /////////////////////////////////////////////

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

            if (confirmacion.Contains("error") || confirmacion.Contains("Debe"))
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

            if ((e.Day.Date < hoy) || (e.Day.Date > limite))
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
            if (ValidarDatos())
            {
            // Recuperación de los campos de texto

            string nombreTxt = nombre.Text.Trim();
            string edadTxt = edad.Text.Trim();
            string correoTxt = correo.Value.Trim();
            string telefonoTxt = telefono.Value.Trim();
            string fechaTxt = fecha.Text.Trim();
            string horaT = horaTxt.Text.Trim();

                int numTel = 0;

                if (!telefonoTxt.Equals(""))
                {
                    numTel = int.Parse(telefonoTxt);
                }



            // Enviar datos para guardar en la base de datos

            ManejadorCita manejador = new ManejadorCita();

            string codigoMedico = Session["codigoMedico"].ToString();

            string confirmacion = manejador.CrearCita(codigoMedico, nombreTxt, edadTxt, correoTxt, numTel, fechaTxt, horaT);

                if (!confirmacion.Contains("error"))
                {
                    if (!correoTxt.Equals(""))
                    {
                        BLEnviarCorreo correo = new BLEnviarCorreo(correoTxt, "Cita Médica", 
                            "Estimado usuario:\n\n" +
                            "La Clínica Pediátrica Divino Niño le informa que se ha programado una " +
                            "cita de atención médica. Los detalles de la misma se describen a continuación:\n" +
                            "Paciente: " + nombreTxt + "\n" + 
                            "Médico: " + Session["nombreMedico"].ToString() + "\n" +
                            "Fecha: " + (DateTime.Parse(fechaTxt)).ToLongDateString() + "\n" +
                            "Hora: " + horaT);
                    }
                    
                }


            LimpiarCampos();

            MostrarAgenda(diaSeleccionado, confirmacion);
        }
        }

        /// <summary>
        /// Vacia los campos de texto
        /// </summary>
        private void LimpiarCampos()
        {
            nombre.Text = "";
            edad.Text = "";
            correo.Value = "";
            telefono.Value = "";
            fecha.Text = "";
            horaTxt.Text = "";

            nombre.Enabled = true;
            edad.Enabled = true;
            correo.Disabled = false;
            telefono.Disabled = false;

        }


        /// <summary>
        /// Muestra el modal para crear o cancelar una cita, al seleccionar un elemento de la agenda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void vistaAgenda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LimpiarCampos();

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

                    // Se cargan los datos de la cita seleccionada

                    BLCita cita = CargarCita(horaSeleccionada);

                    if(cita != null)
                    {
                        nombre.Text = cita.Nombre;
                        edad.Text = cita.Edad;
                        correo.Value = cita.Correo;
                        telefono.Value = cita.Telefono + "";
                    } else
                    {
                        MostrarMensaje("Ocurrió un error y no se pudo cargar los datos de la cita");
                    }

                    nombre.Enabled = false;
                    edad.Enabled = false;
                    correo.Disabled = true;
                    telefono.Disabled = true;
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

        /// <summary>
        /// Recupera la cita seleccionada de la lista de citas
        /// </summary>
        /// <param name="hora"></param>
        /// <returns>Retorna la cita seleccionada</returns>
        private BLCita CargarCita(string hora)
        {
            foreach (BLCita cita in listaCitas)
            {
                if (cita.Hora.Equals(hora))
                {
                    return cita;
                }
            }
            return null;
        }
        /// <summary>
        /// Redirecciona a la pagina de inicio del rol medico o asistente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        /// <summary>
        /// Convierte el formato de la hora
        /// </summary>
        /// <param name="temporal"></param>
        /// <returns>Retorna el nuevo formato de la hora</returns>
        private string ConvertirFormato(DateTime temporal)
        {
            string nuevo = "";

            nuevo = temporal.TimeOfDay.ToString();

            string[] lista = nuevo.Split(':');

            int hora = int.Parse(lista[0]);

            if(hora > 12)
            {
                return (hora-12) + ":" +  lista[1] + " PM";
            }
            else
            {

                if (hora == 12)
                {
                    return "12" + ":" + lista[1] + " PM";
                }
                if (hora == 0)
                {
                    return "12" + ":" + lista[1] + " AM";
                }
                return hora + ":" + lista[1] + " AM";
            }

            return nuevo;
        }

        /// <summary>
        /// Elimina una cita de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string nombreTxt = nombre.Text.Trim();
            string correoTxt = correo.Value.Trim();
            string fechaTxt = fecha.Text.Trim();
            string horaT = horaTxt.Text.Trim();

            ManejadorCita manejador = new ManejadorCita();

            string codigoMedico = Session["codigoMedico"].ToString();


            string confirmacion = manejador.CancelarCita(codigoMedico, fechaTxt, horaT);


            if (!confirmacion.Contains("error"))
            {
                if (!correoTxt.Equals(""))
                {
                    BLEnviarCorreo correo = new BLEnviarCorreo(correoTxt, "Cancelación de cita",
                        "Estimado usuario:\n\n" +
                        "La Clínica Pediátrica Divino Niño le informa que se ha cancelado la " +
                        "cita de atención médica con la siguiente descripción:\n" +
                        "Paciente: " + nombreTxt + "\n" +
                        "Médico: " + Session["nombreMedico"].ToString() + "\n" +
                        "Fecha: " + (DateTime.Parse(fechaTxt)).ToLongDateString() + "\n" +
                        "Hora: " + horaT);
                }

            }


            LimpiarCampos();

            MostrarAgenda(diaSeleccionado, confirmacion);
        }

        /// <summary>
        /// Valida los datos de entrada para crear una nueva cita
        /// </summary>
        private bool ValidarDatos()
        {
            string nom = nombre.Text.Trim();
            string eda = edad.Text.Trim();
            string cor = correo.Value.Trim();
            string tel = telefono.Value.Trim();

            string mensaje = "";

            if (nom.Equals("") || eda.Equals(""))
            {
                mensaje = "Debe completar los campos requeridos";
            }
            if (cor.Equals("") && tel.Equals(""))
            {
                mensaje = "Debe registrar al menos un medio de contacto";
            }

            if (!tel.Equals(""))
            {
                try
                {
                    int temp = int.Parse(tel);
                }
                catch (Exception)
                {
                    mensaje = "Debe ingresar el formato correcto";
                }
            }

            MostrarMensaje(mensaje);

            if (!mensaje.Equals(""))
            {
                return false;
            }
            return true;
        }
    }
}