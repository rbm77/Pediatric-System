using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class ListaCitas : System.Web.UI.Page
    {
        private static List<BLCita> listaCitas = new List<BLCita>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["confirmacionCreacion"] != null)
                {
                    string confirmacion = Session["confirmacionCreacion"].ToString();
                    MostrarMensaje(confirmacion);
                    Session["confirmacionCreacion"] = null;
                }
                CargarCitas();
            }
        }

        private void CargarCitas()
        {
            string cuenta = Session["Cuenta"].ToString();

            ManejadorCita manejador = new ManejadorCita();

            listaCitas.Clear();

            string confirmacion = manejador.CargarCitasUsuario(listaCitas, cuenta);

            gridCitas.DataSource = listaCitas;
            gridCitas.DataBind();

            if (confirmacion.Contains("error"))
            {
                MostrarMensaje(confirmacion);
            }
            else
            {
                if (listaCitas.Count == 0)
                {
                    MostrarMensaje("No tiene citas pendientes");
                }
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

        private string Formato(string cambiar)
        {
            return cambiar.Replace("&#233;", "é").Replace("&#225;", "á").Replace("&#237;", "í").Replace("&#250;", "ú").Replace("&#241;", "ñ");
        }

        protected void gridCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cancelar")
            {

                ManejadorCita manejador = new ManejadorCita();

                int indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow filaSeleccionada = gridCitas.Rows[indice];
                string nombrePaciente = Formato(filaSeleccionada.Cells[0].Text.Trim());
                string nombreMedico = Formato(filaSeleccionada.Cells[1].Text.Trim());
                string fecha = Formato(filaSeleccionada.Cells[2].Text.Trim());
                string hora = Formato(filaSeleccionada.Cells[3].Text.Trim());
                string correoTxt = Session["Cuenta"].ToString();

                string confirmacion = "";


                foreach (BLCita cita in listaCitas)
                {
                    if (cita.Nombre.Equals(nombrePaciente) && cita.Fecha.Equals(fecha) && cita.Hora.Equals(hora))
                    {
                        confirmacion = manejador.CancelarCita(cita.CodigoMedico, fecha, hora);

                        if (!confirmacion.Contains("error"))
                        {
                            if (!correoTxt.Equals(""))
                            {
                                BLEnviarCorreo correo = new BLEnviarCorreo(correoTxt, "Cancelación de cita",
                                    "Estimado usuario:\n\n" +
                                    "La Clínica Pediátrica Divino Niño le informa que se ha cancelado la " +
                                    "cita de atención médica con la siguiente descripción:\n" +
                                    "Paciente: " + nombrePaciente + "\n" +
                                    "Médico: " + nombreMedico + "\n" +
                                    "Fecha: " + (DateTime.Parse(fecha)).ToLongDateString() + "\n" +
                                    "Hora: " + hora);
                            }

                        }


                        break;
                    }

                }

                MostrarMensaje(confirmacion);
                CargarCitas();

            }


        }

        protected void nuevaCita_Click(object sender, EventArgs e)
        {
            Response.Redirect("CitaUsuario.aspx");
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioUsuarioExterno.aspx");
        }
    }
}