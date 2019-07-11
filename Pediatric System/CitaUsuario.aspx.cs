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
    public partial class CitaUsuario : System.Web.UI.Page
    {

        private static List<BLAgendaEstandar> agendaMedico = new List<BLAgendaEstandar>();
        private static List<BLPacienteCita> listaPacientes = new List<BLPacienteCita>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
                CargarMedicos();
            }
            mensajeConfirmacion.Visible = false;
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaCitas.aspx");
        }

        /// <summary>
        /// Agenda una nueva cita para el paciente seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agendarCita_Click(object sender, EventArgs e)
        {
            if (ValidarEntradas())
            {
                string nombreTxt = nombrePaciente.SelectedValue;
                string edadTxt = edad.Text.Trim();
                string correoTxt = correo.Text.Trim();
                string telefonoTxt = telefono.Text.Trim();
                string fechaTxt = fecha.SelectedValue;
                string horaT = hora.SelectedValue;

                int numTel = 0;

                if (!telefonoTxt.Equals(""))
                {
                    numTel = int.Parse(telefonoTxt);
                }

                // Enviar datos para guardar en la base de datos

                ManejadorCita manejador = new ManejadorCita();

                string codigoMedico = medico.SelectedValue;

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
                            "Médico: " + medico.SelectedItem.ToString() + "\n" +
                            "Fecha: " + (DateTime.Parse(fechaTxt)).ToLongDateString() + "\n" +
                            "Hora: " + horaT);
                    }

                }

                Session["confirmacionCreacion"] = confirmacion;

                Response.Redirect("ListaCitas.aspx");
            } else
            {
                MostrarMensaje("Favor completar los datos que se le solicitan");
            }
        }

        /// <summary>
        /// Carga la lista de medicos disponibles en un dropdownlist
        /// </summary>
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

                medico.DataSource = fuente;
                medico.DataTextField = "NombreCompleto";
                medico.DataValueField = "CodigoMedico";
                medico.DataBind();

                string disponible = "Seleccionar";

                if (fuente.Count == 0)
                {
                    disponible = "No disponible";
                }

                medico.Items.Insert(0, new ListItem(disponible));
                medico.SelectedIndex = 0;
                medico.Items[0].Attributes.Add("disabled", "disabled");
            }

        }

        /// <summary>
        /// Carga la lista de pacientes vinculados a la cuenta en un dropdownlist
        /// </summary>
        private void CargarPacientes()
        {
            listaPacientes.Clear();
            
            ManejadorCita manejador = new ManejadorCita();

            string cuenta = Session["Cuenta"].ToString();

            string confirmacion = manejador.CargarPacientes(listaPacientes, cuenta);

            if (confirmacion.Contains("error"))
            {
                MostrarMensaje(confirmacion);
            }
            else
            {


                foreach (BLPacienteCita p in listaPacientes)
                {
                    nombrePaciente.Items.Add(new ListItem(p.NombrePaciente));
                }

                nombrePaciente.Items.Insert(0, new ListItem("Seleccionar"));
                nombrePaciente.SelectedIndex = 0;
                nombrePaciente.Items[0].Attributes.Add("disabled", "disabled");
            }

        }

        /// <summary>
        /// Carga los datos del paciente en los campos de texto
        /// </summary>
        /// <param name="nombrePaciente"></param>
        private void CargarDatosPaciente(string nombrePaciente)
        {
            string edadPaciente = "";
            string correoEncargado = "";
            string telefonoEncargado = "";

            ManejadorEdad manejador = new ManejadorEdad();

            foreach (BLPacienteCita p in listaPacientes)
            {
                if (p.NombrePaciente.Equals(nombrePaciente))
                {
                    edadPaciente = manejador.ExtraerEdad(DateTime.Parse(p.EdadPaciente));
                    correoEncargado = p.CorreoEncargado;
                    telefonoEncargado = p.TelefonoEncargado;
                    break;
                }
            }

            edad.Text = edadPaciente;
            correo.Text = correoEncargado;
            telefono.Text = telefonoEncargado;
        }

        /// <summary>
        /// Carga la lista fechas disponibles para el medico
        /// </summary>
        /// <param name="codigoMedico"></param>
        private void CargarFechas(string codigoMedico)
        {
            fecha.Items.Clear();

            hora.Items.Clear();

            agendaMedico.Clear();

            ManejadorAgenda manejadorAgenda = new ManejadorAgenda();


            string confirmacion = "";


            confirmacion = manejadorAgenda.CargaHorasDisponibilidad(agendaMedico, codigoMedico);

            if (!confirmacion.Contains("error"))
            {

                for (int i = 0; i < 7; i++)
                {
                    DateTime temporal = DateTime.Now.AddDays(i);

                    string nombreDia = temporal.ToString("dddd", new CultureInfo("es-ES")).ToUpperInvariant();

                    nombreDia = nombreDia.Substring(0, 1).ToUpper() + nombreDia.Substring(1).ToLower();

                    foreach (BLAgendaEstandar dia in agendaMedico)
                    {
                        if (dia.Dia.Equals(nombreDia))
                        {
                            fecha.Items.Add(new ListItem(temporal.ToString("dd/MM/yyy")));
                        }
                    }
                }

                string disponible = "Seleccionar";

                if (agendaMedico.Count == 0)
                {
                    disponible = "No disponible";
                }

                fecha.Items.Insert(0, new ListItem(disponible));
                fecha.SelectedIndex = 0;
                fecha.Items[0].Attributes.Add("disabled", "disabled");

            }
            else
            {
                MostrarMensaje(confirmacion);
            }

        }



        /// <summary>
        /// Muestra un alert con el mensaje de confirmacion de la transaccion recien ejecutada
        /// </summary>
        /// <param name="confirmacion">Mensaje de Confirmacion</param>
        private void MostrarMensaje(string confirmacion)
        {
            string colorMensaje = "success";

            if (confirmacion.Contains("error") || confirmacion.Contains("completar"))
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

        protected void medico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFechas(medico.SelectedValue);
            medico.Items[0].Attributes.Add("disabled", "disabled");
            if (nombrePaciente.Items.Count > 0)
            {
                nombrePaciente.Items[0].Attributes.Add("disabled", "disabled");
            }
        }

        protected void fecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHoras(medico.SelectedValue);
            fecha.Items[0].Attributes.Add("disabled", "disabled");
            medico.Items[0].Attributes.Add("disabled", "disabled");
            if (nombrePaciente.Items.Count > 0)
            {
                nombrePaciente.Items[0].Attributes.Add("disabled", "disabled");
            }
        }

        /// <summary>
        /// Cargar la lista de horas disponibles para el medico
        /// </summary>
        private void CargarHoras(string codigoMedico)
        {
            hora.Items.Clear();

            string fechaSeleccionada = fecha.SelectedValue;

            DateTime temporal = DateTime.Parse(fechaSeleccionada);

            string nombreDia = temporal.ToString("dddd", new CultureInfo("es-ES")).ToUpperInvariant();

            nombreDia = nombreDia.Substring(0, 1).ToUpper() + nombreDia.Substring(1).ToLower();

            BLAgendaEstandar dia = ObtenerDia(nombreDia);

            if (dia != null)
            {

                DateTime horaInicio = DateTime.Parse(dia.HoraInicio);
                DateTime horaFin = DateTime.Parse(dia.HoraFin);
                DateTime i = horaInicio;
                ManejadorAgenda manejadorAgenda = new ManejadorAgenda();

                string confirmacion = manejadorAgenda.ObtenerDuracionCita(codigoMedico);

                bool duracionCapturada = true;

                int duracionCita = 0;

                try
                {
                    duracionCita = int.Parse(confirmacion);
                }
                catch (Exception)
                {
                    duracionCapturada = false;
                }

                if ((!confirmacion.Contains("error")) && (duracionCapturada))
                {
                    string t = "";
                    List<ListaHoras> listaHoras = new List<ListaHoras>();

                    while (i < horaFin)
                    {
                        t = ConvertirFormato(i);

                        i = i.AddMinutes(duracionCita);

                        listaHoras.Add(new ListaHoras(t));
                    }

                    ManejadorCita manejadorCita = new ManejadorCita();

                    List<BLCita> horasCitas = new List<BLCita>();

                    confirmacion =  manejadorCita.CargarHorasCita(horasCitas, codigoMedico, fechaSeleccionada);

                    if (!confirmacion.Contains("error"))
                    {

                        foreach (BLCita h in horasCitas)
                        {

                            for (int j= 0; j < listaHoras.Count; j++)
                            {
                                if (listaHoras[j].Hora.Equals(h.Hora))
                                {
                                    listaHoras.RemoveAt(j);
                                }
                            }
                        }
                        foreach (ListaHoras elemento in listaHoras)
                        {
                            hora.Items.Add(new ListItem(elemento.Hora));
                        }
                        string disponible = "Seleccionar";

                        if (listaHoras.Count == 0)
                        {
                            disponible = "No disponible";
                        }

                        hora.Items.Insert(0, new ListItem(disponible));
                        hora.SelectedIndex = 0;
                        hora.Items[0].Attributes.Add("disabled", "disabled");

                    }
                    else
                    {
                        MostrarMensaje(confirmacion);
                    }
                }
                else
                {
                    MostrarMensaje(confirmacion);
                }
            }
            
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

            if (hora >= 12)
            {
                return (hora - 12) + ":" + lista[1] + " PM";
            }
            else
            {
                if (hora == 0)
                {
                    return "12" + ":" + lista[1] + " AM";
                }
                return hora + ":" + lista[1] + " AM";
            }

            return nuevo;
        }

        /// <summary>
        /// Obtiene el dia seleccionado de la agenda
        /// </summary>
        /// <param name="nombreDia"></param>
        /// <returns></returns>
        private BLAgendaEstandar ObtenerDia(string nombreDia)
        {
            foreach (BLAgendaEstandar dia in agendaMedico)
            {
                if (nombreDia.Equals(dia.Dia))
                {
                    return dia;
                }
            }
            return null;
        }

        /// <summary>
        /// Esta clase corresponde a los objetos que seran listados en el dropdown de horas
        /// </summary>
        private class ListaHoras
        {
            public string Hora { get; set; }
            public ListaHoras()
            {

            }
            public ListaHoras(string hora)
            {
                this.Hora = hora;
            }

        }

        /// <summary>
        /// Valida los datos de entrada para crear una cita
        /// </summary>
        /// <returns></returns>
        private bool ValidarEntradas()
        {
            if ((nombrePaciente.Items.Count > 0) && (medico.Items.Count > 0) && (fecha.Items.Count > 0) && (hora.Items.Count > 0))
            {
                string pac = nombrePaciente.SelectedValue;
                string med = medico.SelectedValue;
                string fec = fecha.SelectedValue;
                string hor = hora.SelectedValue;

                if (pac.Equals("Seleccionar") || med.Equals("Seleccionar") || fec.Equals("Seleccionar") || hor.Equals("Seleccionar")
                    || med.Equals("No disponible") || fec.Equals("No disponible") || hor.Equals("No disponible"))
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

            return true;
        }
        protected void nombrePaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosPaciente(nombrePaciente.SelectedValue);
            nombrePaciente.Items[0].Attributes.Add("disabled", "disabled");

            if (medico.Items.Count > 0)
            {
                medico.Items[0].Attributes.Add("disabled", "disabled");
            }

            if (fecha.Items.Count > 0)
            {
                fecha.Items[0].Attributes.Add("disabled", "disabled");
            }
            if (hora.Items.Count > 0)
            {
                hora.Items[0].Attributes.Add("disabled", "disabled");
            }
        }
    }
}