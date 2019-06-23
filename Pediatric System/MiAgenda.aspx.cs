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
            if (!IsPostBack)
            {
                MostrarAgenda(new List<BLAgendaEstandar>(), "777", true);
            }
        }

        /// <summary>
        /// Actualiza el grid cada vez que se presiona sobre el boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Actualizar_Click(object sender, EventArgs e)
        {

            // Obtener datos de entrada

            string codigoMedico = "777";

            string inicio = clockpicker.Text.Trim();
            string fin = clockpicker2.Text.Trim();

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

            MostrarAgenda(agenda, codigoMedico, false);

            ScriptManager.RegisterStartupScript(this, GetType(), "Limpiar campos de texto", "limpiar();", true);

        }

        /// <summary>
        /// Muestra el los dias laborales en el grid
        /// </summary>
        /// <param name="agenda"></param>
        /// <param name="codigo"></param>
        /// <param name="primeraVez"></param>
        private void MostrarAgenda(List<BLAgendaEstandar> agenda, string codigo, bool primeraVez)
        {

            ManejadorAgenda manejador = new ManejadorAgenda();

            string confirmacion = manejador.ActualizarAgenda(agenda, codigo);

            string colorMensaje = "success";

            if (confirmacion.Contains("error"))
            {
                colorMensaje = "danger";
            }
            else
            {
                // Si la agenda esta vacia no muestra el grid

                if (agenda.Count == 0)
                {
                    confirmacion = "En este momento no cuenta un horario laboral";
                    vistaAgenda.DataSource = agenda;
                    vistaAgenda.DataBind();
                } else
                {
                    // Se muestra la agenda

                    vistaAgenda.DataSource = agenda;
                    vistaAgenda.DataBind();
                    vistaAgenda.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Limpiar();
                    UpdatePanel2.Update();

                    if (primeraVez)
                    {
                        confirmacion = "La agenda se cargó exitosamente";
                    }

                }

            }

            mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
                "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
                " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;


        }


        /// <summary>
        /// Reinicia los valores de los campos de entrada
        /// </summary>
        private void Limpiar()
        {
            lunes.Checked = false;
            martes.Checked = false;
            miercoles.Checked = false;
            jueves.Checked = false;
            viernes.Checked = false;

        }

        /// <summary>
        /// Elimina el dia seleccionado en el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void vistaAgenda_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                string codigoMedico = "777";
                ManejadorAgenda manejador = new ManejadorAgenda();

                int indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow filaSeleccionada = vistaAgenda.Rows[indice];
                TableCell nombreDia = filaSeleccionada.Cells[0];
                string dia = nombreDia.Text.Replace("&#233;", "é");

                
                string confirmacion = manejador.EliminarHorario(codigoMedico, dia);
                string colorMensaje = "";

                if (confirmacion.Contains("error"))
                {
                    colorMensaje = "danger";
                    mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
                    "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
                    " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                    " <span aria-hidden=\"true\">&times;</span> </button> </div>";
                    mensajeConfirmacion.Visible = true;

                }
                else
                {
                    MostrarAgenda(new List<BLAgendaEstandar>(), codigoMedico, false);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Limpiar campos de texto", "limpiar();", true);
                }

            }



        }
    }
}