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

        protected void gridCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void grdAccidentMaster_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
     
            if (e.CommandName == "enviarCorreo")
            {
                String correo = Convert.ToString(e.CommandArgument);

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
            } else
            {
                ModalPopupEstado.Show();
            }
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
            mensajeConfirmacion.Text = "<div class=\"alert alert-success alert-dismissible fade show\" " +
          "role=\"alert\"> <strong></strong>" + "Cuenta Editada Correctamente" + "<button" +
          " type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
          " <span aria-hidden=\"true\">&times;</span> </button> </div>";
            mensajeConfirmacion.Visible = true;
            listaPersonal = miBLPersonal.buscarListaPersonal();
            gridCuentas.DataSource = listaPersonal;
            gridCuentas.DataBind();
        }




        public string GetLabelText(object dataItem)
        {
            string text = "";
            text = dataItem.ToString();
            return text;
        }

        protected void mostratPersonal(String id)
        {

        }

        protected void Tipo_TextChanged(object sender, EventArgs e)
        {

        }

    }
}