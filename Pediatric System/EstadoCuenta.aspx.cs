using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL;

namespace Pediatric_System
{
    public partial class EstadoCuenta : System.Web.UI.Page
    {
        protected global::System.Web.UI.WebControls.Button btnPrueba;
        public List<BL_ManejadorPersonal> listaPersonal = new List<BL_ManejadorPersonal>();
        BLPersonal miBLPersonal = new BLPersonal();
        BLCuenta miBLCuenta = new BLCuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {             
                listaPersonal = miBLPersonal.buscarListaPersonal();
                gridCuentas.DataSource = listaPersonal;
                gridCuentas.DataBind();
            }

        }


        protected void grdAccidentMaster_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

           
            switch (e.CommandName)
            {
                case "enviarCorreo":
                    int indice = Convert.ToInt32(e.CommandArgument);
                    GridViewRow filaSeleccionada = gridCuentas.Rows[indice];
                    TableCell estado = filaSeleccionada.Cells[1];
                    string correo = estado.Text;
                    BLAdministrativo miBLAdministrativo = new BLAdministrativo();
                    miBLCuenta.correo = correo;
                    miBLCuenta.buscarCuentaPorCorreo();
                    String rol = miBLCuenta.tipo;
                    switch (rol)
                    {
                        case "Medico":
                            txtCodigo.Visible = true;
                            lblCodigo.Visible = true;
                            BLMedico miBLMedico = new BLMedico();
                            miBLMedico.correo = correo;
                            miBLMedico.buscarMedico();
                            txtRol.Text = rol;
                            txtNombre.Text = miBLMedico.nombre;
                            txtApellido.Text = miBLMedico.apellido;
                            txtCedula.Text = miBLMedico.cedula.ToString();
                            txtTelefono.Text = miBLMedico.telefono.ToString();
                            txtCodigo.Text = miBLMedico.codigo;
                            txtCorreo.Text = miBLMedico.correo;
                            txtCodigo.Enabled = false;
                            txtCorreo.Enabled = false;
                            txtRol.Enabled = false;
                            modalEdicion.Show();
                            break;

                        default:
                            txtCodigo.Visible = false;
                            lblCodigo.Visible = false;
                            miBLAdministrativo.correo = correo;
                            miBLAdministrativo.buscarAdministrativo();
                            txtNombre.Text = miBLAdministrativo.nombre;
                            txtApellido.Text = miBLAdministrativo.apellido;
                            txtCedula.Text = miBLAdministrativo.cedula.ToString();
                            txtTelefono.Text = miBLAdministrativo.telefono.ToString();
                            txtRol.Text = rol;
                            txtCorreo.Text = miBLAdministrativo.correo;
                            txtCorreo.Enabled = false;
                            txtRol.Enabled = false;
                            modalEdicion.Show();
                            break;
                    }
                    break;

                case "habilitarCuenta":
                    Button btn = e.CommandSource as Button;
                    string correo1 = btn.ToolTip;
                    miBLCuenta.correo = correo1;
                    miBLCuenta.editarEstado("HABILITAR");
                    listaPersonal = miBLPersonal.buscarListaPersonal();
                    gridCuentas.DataSource = listaPersonal;
                    gridCuentas.DataBind();
                    mensajeAviso("success", "La cuenta de " + correo1 + " ha sido habilitada correctamente");
                    break;
                case "deshabilitarCuenta":
                    Button btn2 = e.CommandSource as Button;
                    string correo2 = btn2.ToolTip;
                    miBLCuenta.correo = correo2;
                    miBLCuenta.editarEstado("DESHABILITAR");
                    listaPersonal = miBLPersonal.buscarListaPersonal();
                    gridCuentas.DataSource = listaPersonal;
                    gridCuentas.DataBind();
                    mensajeAviso("success", "La cuenta de " + correo2 + " ha sido deshabilitada correctamente");
                    break;
            }
        }

        protected void vistaCuentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        }




        protected void btnEditarSeleccion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string tipo = txtRol.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int cedula = Int32.Parse(txtCedula.Text);
            int telefono = Int32.Parse(txtTelefono.Text);
            string codigo = txtCodigo.Text;

            BLAdministrativo miBLAdministrativo = new BLAdministrativo();

            BLPersonal miBLPersonal = new BLPersonal();
            miBLPersonal.correo = correo;
            miBLPersonal.nombre = nombre;
            miBLPersonal.apellido = apellido;
            miBLPersonal.cedula = cedula;
            miBLPersonal.telefono = telefono;
            miBLPersonal.editarPersonal();

            switch (tipo)
            {
                case "Medico":
                    BLMedico miBLMedico = new BLMedico();
                    miBLMedico.codigo = codigo;
                    miBLMedico.correo = correo;
                    miBLMedico.nombre = nombre;
                    miBLMedico.apellido = apellido;
                    miBLMedico.cedula = cedula;
                    miBLMedico.telefono = telefono;
                    miBLMedico.editarMedico();
                    break;
                default:

                    miBLAdministrativo.correo = correo;
                    miBLAdministrativo.nombre = nombre;
                    miBLAdministrativo.apellido = apellido;
                    miBLAdministrativo.cedula = cedula;
                    miBLAdministrativo.telefono = telefono;
                    miBLAdministrativo.editarAdministrativo();
                    break;
            }


            listaPersonal = miBLPersonal.buscarListaPersonal();
            gridCuentas.DataSource = listaPersonal;
            gridCuentas.DataBind();
            mensajeAviso("success", "Cuenta Editada Correctamente");
        }




        public string GetLabelText(object dataItem)
        {
            string text = "";
            text = dataItem.ToString();
            return text;
        }


        protected void btnSwitch_Click(object sender, EventArgs e)
        {           
            CheckBox box = (CheckBox)sender;
            String correo = box.ToolTip;
            miBLCuenta.correo = correo;
            if (!box.Checked)
            {             
                miBLCuenta.editarEstado("DESHABILITAR");
                mensajeAviso("success", "La cuenta de " + correo + " ha sido deshabilitada correctamente");
            } else
            {
                miBLCuenta.editarEstado("HABILITAR");
                mensajeAviso("success", "La cuenta de " + correo + " ha sido habilitada correctamente");
            }
        }



        protected static void cambiarEstado(object sender, EventArgs e)
        {
            String nombre = "Hola";

        }


        public void mensajeAviso(String color, String texto)
        {
          //Colores:  primary = Azul
          //          secondary = Gris
          //          success = Verde
          //          danger = Rojo
          //          warning = Amarillo
            mensajeConfirmacion.Text = "<div class=\"alert alert-" + color + " alert-dismissible fade show\" " +
           "role=\"alert\"> <strong></strong>" + texto + "<button" +
         " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
         " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
        }



    }
}