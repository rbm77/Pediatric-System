using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace Pediatric_System
{
    public partial class ExamenesLaboratorio : System.Web.UI.Page
    {
        private static List<BLExpediente> listaPacientes = new List<BLExpediente>();
        private static List<BLExamenLaboratorio> listaExamenes = new List<BLExamenLaboratorio>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"].ToString().Equals("Paciente"))
            {
                if (!IsPostBack)
                {
                    CargarPacientes();
                }
                if (nombrePaciente.Items.Count > 0)
                {
                    nombrePaciente.Items[0].Attributes.Add("disabled", "disabled");
                }
                
            }
            else
            {
                if (!IsPostBack)
                {
                    Session["pacienteSeleccionado"] = ((BLExpediente)Session["expediente"]).Codigo;
                    mostrarDatosGenerales();
                }
            }
            mensajeConfirmacion.Visible = false;

        }

        private void mostrarDatosGenerales()
        {
            BLExpediente expediente = new BLExpediente();

            if (expediente.Codigo == expediente.Cedula)
            {
                cedGeneral.InnerText = " " + expediente.Cedula;
            }
            else
            {
                cedGeneral.InnerText = "No tiene aún";
            }
            paciGeneral.InnerText = " " + expediente.Nombre + " " + expediente.PrimerApellido + " " + expediente.SegundoApellido;
            TimeSpan dt = DateTime.Now - expediente.FechaNacimiento;
            edaGeneral.InnerText = " " + Convert.ToString(dt.Days) + " días";
            string imagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(expediente.Foto);
            imgPreview.ImageUrl = imagenDataURL64;
        }

        private void CargarExamenes()
        {
            listaExamenes.Clear();

            string idExpediente = nombrePaciente.SelectedValue;

            ManejadorExamenesLaboratorio manejador = new ManejadorExamenesLaboratorio();

            string confirmacion = manejador.CargarExamenesLaboratorio(listaExamenes, idExpediente);

            gridExamenes.DataSource = listaExamenes;
            gridExamenes.DataBind();

            if (confirmacion.Contains("error"))
            {
                MostrarMensaje(confirmacion);
            }
            else
            {
                if (listaExamenes.Count == 0)
                {
                    MostrarMensaje("El paciente no tiene exámenes de laboratotio");
                }
            }
        }

        private void CargarPacientes()
        {
            listaPacientes.Clear();
            nombrePaciente.Items.Clear();
            Session["pacienteSeleccionado"] = null;

            ManejadorExpediente manejador = new ManejadorExpediente();

            string cuenta = Session["Cuenta"].ToString();

            string confirmacion = manejador.CargarExpedientes(listaPacientes, cuenta);

            if (confirmacion.Contains("error"))
            {
                MostrarMensaje(confirmacion);
            }
            else
            {


                List<ListaPacientes> fuente = new List<ListaPacientes>();

                foreach (BLExpediente elemento in listaPacientes)
                {
                    fuente.Add(new ListaPacientes(elemento.Codigo, elemento.Nombre + " " + elemento.PrimerApellido + " " + elemento.SegundoApellido));
                }

                nombrePaciente.DataSource = fuente;
                nombrePaciente.DataTextField = "NombreCompleto";
                nombrePaciente.DataValueField = "IDExpediente";
                nombrePaciente.DataBind();

                string disponible = "Seleccionar";

                if (fuente.Count == 0)
                {
                    disponible = "No disponible";
                }

                nombrePaciente.Items.Insert(0, new ListItem(disponible));
                nombrePaciente.SelectedIndex = 0;
                nombrePaciente.Items[0].Attributes.Add("disabled", "disabled");
            }

        }

        private class ListaPacientes
        {
            public string IDExpediente { get; set; }
            public string NombreCompleto { get; set; }

            public ListaPacientes()
            {

            }

            public ListaPacientes(string id, string nombreCompleto)
            {
                this.IDExpediente = id;
                this.NombreCompleto = nombreCompleto;
            }
        }

        /// <summary>
        /// Muestra un alert con el mensaje de confirmacion de la transaccion recien ejecutada
        /// </summary>
        /// <param name="confirmacion">Mensaje de Confirmacion</param>
        private void MostrarMensaje(string confirmacion)
        {
            string colorMensaje = "success";

            if (confirmacion.Contains("error") || confirmacion.Contains("Error."))
            {
                colorMensaje = "danger";
            }
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + colorMensaje + " alert-dismissible fade show\" " +
                "role=\"alert\"> <strong></strong>" + confirmacion + "<button" +
                " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }

        protected void nombrePaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["pacienteSeleccionado"] = nombrePaciente.SelectedValue;
            CargarExamenes();
        }

        /// <summary>
        /// Agrega un nuevo examen de laboratorio a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnadir_Click(object sender, EventArgs e)
        {

            string confirmacion = "";

            string paciente = "";

            if (Session["pacienteSeleccionado"] == null)
            {
                MostrarMensaje("Error. Debe seleccionar un paciente");
            }
            else
            {


            paciente = Session["pacienteSeleccionado"].ToString();

            if ((descripcion.Value.Equals("")) || (paciente.Equals("Seleccionar")) || (nombrePaciente.Items.Count == 0))
            {
                if ((descripcion.Value.Equals("")))
                {
                    MostrarMensaje("Error. Se requiere una descripción para el examen");
                }
                if ((paciente.Equals("Seleccionar")) || (nombrePaciente.Items.Count == 0))
                {
                    MostrarMensaje("Error. Debe seleccionar un paciente");
                }
            }
            else
            {

                try
                {
                    string[] validFileTypes = { ".png", ".jpg", ".jpeg" };

                    // Validar que exista un archivo cargado
                    if (archivoSeleccionado.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(archivoSeleccionado.PostedFile.FileName).ToLower();
                        bool isValidFile = false;

                        // Validar extension de archivo cargado sea tipo imagen  
                        for (int i = 0; i < validFileTypes.Length; i++)
                        {
                            if (ext == validFileTypes[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }

                        // En caso no tener una extension permitida 
                        if (!isValidFile)
                        {
                            confirmacion = "Error. El archivo debe tener una de las siguientes extensiones: .png, .jpg, .jpeg";
                        }
                        else
                        {
                            // metodo que guarda la imagen en una carpeta

                            confirmacion = GuardarArchivo(archivoSeleccionado.PostedFile);
                        }
                    }
                    else
                    {
                        confirmacion = "Error. No se ha cargado ningún archivo";
                    }
                }
                catch (Exception)
                {
                    confirmacion = "Ocurrió un error y no se pudo almacenar el archivo";
                }

                if (!confirmacion.Equals(""))
                {
                    MostrarMensaje(confirmacion);
                }
                else
                {
                    // Se guarda en base datos

                    ManejadorExamenesLaboratorio manejador = new ManejadorExamenesLaboratorio();

                    confirmacion = manejador.IngresarExamenLaboratorio(Session["pacienteSeleccionado"].ToString(), DateTime.Now.ToString(),
                        archivoSeleccionado.PostedFile.FileName, descripcion.Value);

                    if (confirmacion.Contains("error"))
                    {
                        MostrarMensaje(confirmacion);
                    }
                    else
                    {
                        CargarExamenes();
                    }

                }

            }
                descripcion.Value = "";
            }
        }

        private string GuardarArchivo(HttpPostedFile file)
        {
            string confirmacion = "";

            try
            {
            // Se carga la ruta física de la carpeta temp del sitio
                string ruta = Server.MapPath("~/examenes");

                // Si el directorio no existe, crearlo
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);

                //string archivo = String.Format("{0}\\{1}", ruta, file.FileName);
                string fullPath = Path.Combine(Server.MapPath("~/examenes"), file.FileName);

                // Verificar que el archivo no exista
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                file.SaveAs(fullPath);

            }
            catch (Exception)
            {
                confirmacion = "Ocurrió un error y no se pudo almacenar el archivo";
            }
            return confirmacion;
        }

        protected void gridExamenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ver")
            {

                int indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow filaSeleccionada = gridExamenes.Rows[indice];

                string fecha = filaSeleccionada.Cells[0].Text.Trim();

                foreach (BLExamenLaboratorio exa in listaExamenes)
                {
                    if (exa.Fecha.Equals(fecha))
                    {
                        Session["examenSeleccionado"] = exa.UbicacionArchivo;
                        break;
                    }
                }
                modalEdicion.Show();

            }
        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioUsuarioExterno.aspx");
        }
    }
}