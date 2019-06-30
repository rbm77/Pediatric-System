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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMedicos();
            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {

        }

        protected void agendarCita_Click(object sender, EventArgs e)
        {

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

        protected void medico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFechas(medico.SelectedValue);
        }

        protected void fecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHoras(medico.SelectedValue);
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

    }
}